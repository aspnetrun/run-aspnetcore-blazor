using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Session
{
    public class NullSessionService : ISessionService
    {
        public static NullSessionService Instance { get; } = new NullSessionService();
        public string UserId { get; set; }

        private NullSessionService()
        {
        }
    }
}
