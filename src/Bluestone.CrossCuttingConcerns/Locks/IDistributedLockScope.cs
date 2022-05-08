using System;

namespace Bluestone.CrossCuttingConcerns.Locks
{
    public interface IDistributedLockScope : IDisposable
    {
        bool StillHoldingLock();
    }
}
