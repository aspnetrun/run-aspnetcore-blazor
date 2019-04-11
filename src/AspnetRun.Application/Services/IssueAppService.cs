using AspnetRun.Application.Dtos.Issue;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Services
{
    public class IssueAppService : IIssueAppService
    {        
        private readonly IIssueRepository _issueRepository;
        private readonly IAppLogger<IssueAppService> _logger;

        public IssueAppService(IIssueRepository issueRepository, IAppLogger<IssueAppService> logger)
        {
            _issueRepository = issueRepository ?? throw new ArgumentNullException(nameof(issueRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddComment(AddCommentInput input)
        {
            throw new NotImplementedException();
        }

        public void AssignIssueToUser(AssignIssueToUserInput input)
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
