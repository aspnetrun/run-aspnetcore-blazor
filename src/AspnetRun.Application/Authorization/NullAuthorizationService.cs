using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Authorization
{
    public class NullAuthorizationService : IAuthorizationService
    {
        public static NullAuthorizationService Instance { get; } = new NullAuthorizationService();

        private NullAuthorizationService()
        {
        }

        public void CheckPermission(string permissionName)
        {

        }

        public void CheckPermission(string permissionName, string entityId)
        {

        }

        public void CheckLogin()
        {

        }
    }
}
