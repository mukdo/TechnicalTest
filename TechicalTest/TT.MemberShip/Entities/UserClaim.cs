using System;

using Microsoft.AspNetCore.Identity;

namespace TT.MemberShip.Entities
{
    public class UserClaim
        : IdentityUserClaim<Guid>
    {
        public UserClaim()
            : base()
        {

        }
    }
}
