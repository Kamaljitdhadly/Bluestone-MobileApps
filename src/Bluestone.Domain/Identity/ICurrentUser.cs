using System;

namespace Bluestone.Domain.Identity
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }

        Guid UserId { get; }
    }
}
