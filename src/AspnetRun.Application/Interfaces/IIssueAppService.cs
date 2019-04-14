using AspnetRun.Application.Dtos.Issue;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IIssueAppService
    {
        Task AssignIssueToUser(AssignIssueToUserInput input);
        Task AddComment(AddCommentInput input);
        Task<GetIssueOutput> GetIssue(GetIssueInput input);
    }
}
