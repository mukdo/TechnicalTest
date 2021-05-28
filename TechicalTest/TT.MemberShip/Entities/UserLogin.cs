using System;

using Microsoft.AspNetCore.Identity;

namespace TT.MemberShip.Entities
{
    public class UserLogin
        : IdentityUserLogin<Guid>
    {
        public UserLogin()
            : base()
        {

        }
    }
}
