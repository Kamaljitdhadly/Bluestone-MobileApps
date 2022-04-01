using System;
using System.Collections.Generic;
using System.Text;

namespace Bluestone.Presentation.Services.ApplicationStateService
{
    public interface IApplicationStateService
    {
        bool IsApplicationActive { get; }
    }
}
