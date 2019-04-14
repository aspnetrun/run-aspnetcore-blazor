using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Authorization
{
    public interface IAuthorizationService
    {
        void CheckPermission(string permissionName);
        void CheckPermission(string permissionName, int entityId);
        void CheckLogin();
    }
}
