using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TT.MemberShip.Services
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        bool IsAuthenticated { get; }
    }
}
