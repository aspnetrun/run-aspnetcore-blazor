using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Session
{
    public class NullSessionService : ISessionService
    {
        public static NullSessionService Instance { get; } = new NullSessionService();
        public int UserId { get; set; }

        private NullSessionService()
        {
        }
    }
}
