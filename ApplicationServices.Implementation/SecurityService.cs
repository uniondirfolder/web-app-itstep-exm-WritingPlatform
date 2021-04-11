using ApplicationServices.Interfaces;
using System;

namespace ApplicationServices.Implementation
{
    public class SecurityService : ISecurityService
    {
        public bool IsCurrentUserAdmin => throw new NotImplementedException();

        public string[] CurrentUserPermissions => throw new NotImplementedException();
    }
}
