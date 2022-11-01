using Common.Utils.ApplicationRoles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace plantilla.Core.Models.AppRoleManual
{
    public class ApplicationRoleManualWF : ApplicationRoleParams
    {

        protected override string ConfigSector { get { return "ApplicationRoleManualWF"; } }
        public ApplicationRoleManualWF(IConfiguration configuration, ILogger<ApplicationRoleManualWF> logger) : base(configuration, logger) { }

    }
}