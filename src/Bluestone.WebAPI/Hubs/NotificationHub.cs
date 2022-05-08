using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Bluestone.WebAPI.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
    }
}
