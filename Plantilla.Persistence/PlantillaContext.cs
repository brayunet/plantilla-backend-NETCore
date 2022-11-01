using Common.Utils.ApplicationRoles;

using Microsoft.EntityFrameworkCore;

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

//using plantilla.Core.DbQueries;
using plantilla.Core.Models;
using plantilla.Core.ViewModels;
using plantilla.Core.DbQueries;

namespace plantilla.Persistence
{
    public partial class plantillaContext : DbContext
    {
        //...
        /// <summary>
        /// Alamcena el Token/cookie del rol de aplicacion ejecutado
        /// </summary>
        byte[] cookie;
        //private readonly ILogger _logger;

        //protected readonly string _connectionString;
        //public plantillaContext(string connection) : base()
        //{
        //    _connectionString = connection;
        //    // Database.OpenConnection();
        //    //_cookie = SetAppRole("NOMBRE_ROL", "CONTRASEÑA_ROL");
        //}

        //public plantillaContext(DbContextOptions<plantillaContext> options,
        //                        ApplicationRoleParams appRoleParams,
        //                        ILogger<plantillaContext> logger)
        //    : base(options)
        //{
        //    _logger = logger;
        //    cookie = (this as DbContext).SetAppRole(appRoleParams);
        //}


        public plantillaContext(DbContextOptions<plantillaContext> options)
        : base(options) { }


        // CUANDO SE LLAMA AL DISPOSE, SE RETIRA EL ROL DE APLICACION
        // DbContext hereda de IDisposable, por eso se asume el retiro completo del rol
        public override void Dispose()
        {
            if (cookie != null)
            {
                (this as DbContext).UnSetAppRole(cookie);
            }
            //base.Dispose();
        }


        public void setApplicationRoleParametro(ApplicationRoleParams appRoleParams)
        {
            cookie = (this as DbContext).SetAppRole(appRoleParams);
        }








        public virtual DbQuery<OpcionDeFinanciacion> OpcionDeFinanciacion { get; set; }
        public virtual DbQuery<ConsultarEstadoplantillainTarjeta> ConsultarEstadoplantillainTarjeta { get; set; }







    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //_logger.LogInformation("StringConexion a BD" + _connectionString);
                optionsBuilder.UseSqlServer("");
            }
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation(
                "ProductVersion", "2.2.6-servicing-10079");

            
            /*
            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("PERMISO");



                
            });
            */
            

        }


        // ENCAPSULAMIENTO DE LA LLAMADA AL PROCEDIMIENTO DE LA ASUNCION DEL ROL DE APLICACION
        public byte[] SetAppRole(string approle, string password)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "sp_setapprole";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@rolename", approle));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            cmd.Parameters.Add(new SqlParameter("@fCreateCookie", 1));
            var pCookieId = new SqlParameter("@cookie",
            System.Data.SqlDbType.VarBinary);
            pCookieId.Size = 8000;
            pCookieId.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(pCookieId);
            cmd.ExecuteNonQuery();
            return (byte[])pCookieId.Value;
        }

        // ENCAPSULAMIENTO DE LA LLAMADA AL PROCEDIMIENTO DEL RETIRO DE EL ROL DE APLICACION
        public void UnSetAppRole(byte[] cookie)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "sp_unsetapprole";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var pCookieId = new SqlParameter("@cookie",
            System.Data.SqlDbType.VarBinary);
            pCookieId.Size = 8000;
            pCookieId.Value = cookie;
            cmd.Parameters.Add(pCookieId);
            cmd.ExecuteNonQuery();
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity is EntidadBase && (
                            e.State == EntityState.Added
                            || e.State == EntityState.Modified));


            foreach (var entityEntry in entries)
            {

                if (entityEntry.State == EntityState.Modified)
                {
                    ((EntidadBase)entityEntry.Entity).FechaModificacion = DateTime.Now;
                    //Asignar al registro entrante la fecha de creación original
                    ((EntidadBase)entityEntry.Entity).FechaCreacion = ((EntidadBase)entityEntry.OriginalValues.Clone().ToObject()).FechaCreacion;
                }
                if (entityEntry.State == EntityState.Added)
                {
                    ((EntidadBase)entityEntry.Entity).FechaCreacion = DateTime.Now;
                }
            }

            return base.SaveChanges();

        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity is EntidadBase && (
                            e.State == EntityState.Added
                            || e.State == EntityState.Modified));


            foreach (var entityEntry in entries)
            {

                if (entityEntry.State == EntityState.Modified)
                {
                    ((EntidadBase)entityEntry.Entity).FechaModificacion = DateTime.Now;
                    //Asignar al registro entrante la fecha de creación original
                    ((EntidadBase)entityEntry.Entity).FechaCreacion = ((EntidadBase)entityEntry.OriginalValues.Clone().ToObject()).FechaCreacion;
                }
                if (entityEntry.State == EntityState.Added)
                {
                    ((EntidadBase)entityEntry.Entity).FechaCreacion = DateTime.Now;
                }
            }

            return base.SaveChangesAsync();


        }

    }

}
