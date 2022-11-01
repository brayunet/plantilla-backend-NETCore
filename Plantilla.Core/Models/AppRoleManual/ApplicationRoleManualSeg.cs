using Common.Utils.ApplicationRoles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace plantilla.Core.Models.AppRoleManual
{
    public class ApplicationRoleManualSeg : ApplicationRoleParams
    {

        protected override string ConfigSector { get { return "ApplicationRoleSeguridad"; } }
        public ApplicationRoleManualSeg(IConfiguration configuration, ILogger<ApplicationRoleManualSeg> logger) : base(configuration, logger) { }

    }
}

