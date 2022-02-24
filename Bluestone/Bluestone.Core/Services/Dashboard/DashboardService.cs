using Bluestone.Core.Services.RequestProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Core.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IRequestProvider _requestProvider;

        public DashboardService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }
    }
}
