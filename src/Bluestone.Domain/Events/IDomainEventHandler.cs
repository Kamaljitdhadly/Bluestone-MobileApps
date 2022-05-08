using System.Threading;
using System.Threading.Tasks;

namespace Bluestone.Domain.Events
{
    public interface IDomainEventHandler<T>
           where T : IDomainEvent
    {
        Task HandleAsync(T domainEvent, CancellationToken cancellationToken = default);
    }
}
