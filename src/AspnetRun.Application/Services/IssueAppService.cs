using AspnetRun.Application.Authorization;
using AspnetRun.Application.Dtos.Issue;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Notification;
using AspnetRun.Application.Session;
using AspnetRun.Application.Validation;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Policy;
using System;

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

        public async void AssignIssueToUser(AssignIssueToUserInput input)
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

        public void AddComment(AddCommentInput input)
        {
            throw new NotImplementedException();
        }
        
        public GetIssueOutput GetIssue(GetIssueInput input)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<CategoryDto>> GetCategoryList()
        //{
        //    var category = await _categoryRepository.GetAllAsync();
        //    var mapped = ObjectMapper.Mapper.Map<IEnumerable<CategoryDto>>(category);
        //    return mapped;
        //}
    }
}
