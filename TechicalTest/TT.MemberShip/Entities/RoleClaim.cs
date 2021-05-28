using System;

using Microsoft.AspNetCore.Identity;

namespace TT.MemberShip.Entities
{
    public class RoleClaim
        : IdentityRoleClaim<Guid>
    {
        public RoleClaim()
            : base()
        {

        }
    }
}
