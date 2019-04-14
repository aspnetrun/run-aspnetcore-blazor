using AspnetRun.Application.Authorization;
using AspnetRun.Application.Dtos;
using AspnetRun.Application.Dtos.Issue;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Notification;
using AspnetRun.Application.Session;
using AspnetRun.Application.Validation;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Policy;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class IssueAppService : IIssueAppService
    {        
        private readonly IIssueRepository _issueRepository;
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IIssueAssignmentPolicy _issueAssignmentPolicy;

        private readonly IValidationService _validationService;
        private readonly IAppLogger<IssueAppService> _logger;
        private readonly IUserEmailer _userEmailer;

        public IAuthorizationService AuthorizationService { get; set; }
        public ISessionService SessionService { get; set; }

        public IssueAppService(IIssueRepository issueRepository, IAsyncRepository<User> userRepository, IIssueAssignmentPolicy issueAssignmentPolicy, IValidationService validationService, IAppLogger<IssueAppService> logger, IUserEmailer userEmailer)
        {
            _issueRepository = issueRepository ?? throw new ArgumentNullException(nameof(issueRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _issueAssignmentPolicy = issueAssignmentPolicy ?? throw new ArgumentNullException(nameof(issueAssignmentPolicy));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userEmailer = userEmailer ?? throw new ArgumentNullException(nameof(userEmailer));

            AuthorizationService = NullAuthorizationService.Instance;
            SessionService = NullSessionService.Instance;
        }

        public async Task AssignIssueToUser(AssignIssueToUserInput input)
        {
            // authorization
            AuthorizationService.CheckPermission("TaskAssignmentPermission");

            // validation
            _validationService.Validate(input);

            // domain
            var user = await _userRepository.GetByIdAsync(input.UserId);
            var issue = await _issueRepository.GetByIdAsync(input.IssueId);

            issue.AssignTo(user, _issueAssignmentPolicy);
            await _issueRepository.UpdateAsync(issue);


            // notification
            if (SessionService.UserId != user.Id)
            {
                _userEmailer.IssueAssigned(user, issue);
            }
            
            // logging
            _logger.LogInformation($"Assigned issue {issue} to user {user}");            
        }

        public async Task AddComment(AddCommentInput input)
        {
            AuthorizationService.CheckPermission("AddComment", input.IssueId);
            _validationService.Validate(input);

            var currentUser = await _userRepository.GetByIdAsync(SessionService.UserId);
            var issue = await _issueRepository.GetByIdAsync(input.IssueId);

            var comment = issue.AddComment(currentUser, input.Message);
            await _issueRepository.UpdateAsync(issue);

            _userEmailer.AddedIssueComment(currentUser, issue, comment);
        }

        public async Task<GetIssueOutput> GetIssue(GetIssueInput input)
        {
            AuthorizationService.CheckLogin();
            _validationService.Validate(input);

            var issue = await _issueRepository.GetByIdAsync(input.Id);

            return new GetIssueOutput
            {
                Issue = ObjectMapper.Mapper.Map<IssueDto>(issue),
                //Comments = GetIssueCommentDtos(issue.Id)
            };
        }       

        //private List<IssueCommentDto> GetIssueCommentDtos(string issueId)
        //{
        //    return _issueRepository
        //        .GetCommentsWithCreatorUsers(issueId)
        //        .Select(c =>
        //        {
        //            var commentDto = _objectMapper.Map<IssueCommentDto>(c.Comment);
        //            commentDto.CreatorUser = _objectMapper.Map<BasicUserDto>(c.CreatorUser);
        //            return commentDto;
        //        })
        //        .ToList();
        //}
    }
}
