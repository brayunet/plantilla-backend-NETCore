using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.IO;
using System.Linq;

using plantilla.Core.Models;

namespace plantilla.Persistence
{
    public static class DbContextExtension
    {
        

        public static void EnsureSeeded(this plantillaContext context)
        {

            context.Database.OpenConnection();
            try
            {
                /*
                if (!context.Permiso.Any())
                {
                    var datos = JsonConvert.DeserializeObject<List<Permiso>>(File.ReadAllText(@".." + Path.DirectorySeparatorChar + "plantilla.Persistence" + Path.DirectorySeparatorChar + "Seed" + Path.DirectorySeparatorChar + "permisos.json"));

                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.PERMISO ON");
                    context.AddRange(datos);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.PERMISO OFF");
                }
                */
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

    }
}
