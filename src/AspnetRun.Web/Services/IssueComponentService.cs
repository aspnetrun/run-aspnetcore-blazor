using AspnetRun.Application.Dtos.Issue;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Session;
using AspnetRun.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class IssueComponentService
    {
        private readonly IIssueAppService _issueAppService;
        private readonly ISessionService _sessionService;

        public IssueComponentService(IIssueAppService issueAppService, ISessionService sessionService)
        {
            _issueAppService = issueAppService ?? throw new ArgumentNullException(nameof(issueAppService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
        }

        public void Detail(int id)
        {
            var output = _issueAppService.GetIssue(new GetIssueInput { Id = id });

            // TODO : this service will consume by razor components as below way 

            //var viewModel = _objectMapper.Map<IssueDetailViewModel>(output);
            //viewModel.CurrentUserId = _sessionService.UserId;

            //return View(viewModel);
        }
    }
}
