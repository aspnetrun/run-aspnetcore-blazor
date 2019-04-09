namespace AspnetRun.Application.Interfaces
{
    public interface IIssueAppService
    {
        void AssignIssueToUser(AssignIssueToUserInput input);
        void AddComment(AddCommentInput input);
        GetIssueOutput GetIssue(GetIssueInput input);
    }
}
