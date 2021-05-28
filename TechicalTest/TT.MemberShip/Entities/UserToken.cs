using System;

using Microsoft.AspNetCore.Identity;

namespace TT.MemberShip.Entities
{
    public class UserToken
        : IdentityUserToken<Guid>
    {
        public UserToken()
            : base()
        {

        }
    }
}
