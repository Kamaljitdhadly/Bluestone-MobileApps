using System.Threading;
using System.Threading.Tasks;

namespace Bluestone.Domain.Events
{
    public interface IDomainEvents
    {
        Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
