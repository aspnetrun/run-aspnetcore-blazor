using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Policy
{
    // TODO : check tennbookings - this will be loaded from aspnet core DI - from appsettings.json
    public interface IIssueAssignmentConfiguration
    {
        int MaxConcurrentOpenIssueCountForAUser { get; set; }
    }
}
