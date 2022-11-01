using Common.Utils.ApplicationRoles;
using Common.Utils.CustomTypes;
using Common.Utils.Error;
using Common.Utils.Logging;
using Common.Utils.Media;
using Common.Utils.Middelware;
using Common.Utils.Middleware;
using Common.Utils.Redirecccionamiento;

using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using plantilla.Api.Graphql;
//using plantilla.Api.Graphql.Mutations;
using plantilla.Api.Graphql.Queries;
using plantilla.Core;
using plantilla.Core.Models.AppRoleManual;
using plantilla.Persistence;

namespace plantilla.Api
{
    /// <summary>
    /// Configura los servicios y la canalización de solicitudes de la aplicación
    /// </summary>
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private const int CONEXIONES_POOL_DEFAULT = 128;
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Representa un conjunto de propiedades de configuración de la aplicación de clave y valor.
        /// </summary>
        /// <param name="configuration">Configuraciones</param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Configuraciones del servicio
        /// </summary>
        /// <param name="services">Coleccion de Servicios</param>
        public void ConfigureServices(IServiceCollection services)
        {

           //services.AddTransient<ApplicationRoleParams>();
             //services.AddScoped<ApplicationRoleParams>();

            //OJO PARA ROLES MANUALES
          //  services.AddScoped<ApplicationRoleManualWF>();
          //  services.AddScoped<ApplicationRoleManualSeg>();



            // Configurar base de datos            
            //services.AddDbContext<plantillaContext>(options =>
            //    options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")),
            //    ServiceLifetime.Transient
            //);

            //fragmento para hacer parametrizable la cantidad de conexiones en el Pool mediante appsettings
            var existeCantidadConexionesBD = _configuration.GetSection("CantidadConexionesBD").Exists();
            var cantidadConexiones = existeCantidadConexionesBD ? System.Int32.Parse(_configuration["CantidadConexionesBD"]) : CONEXIONES_POOL_DEFAULT;

            //fragmento para implementar el pool de conexiones con DbContext
            services.AddDbContextPool<plantillaContext>(options => {
                    options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
                    options.UseLazyLoadingProxies();
                }, cantidadConexiones
            );
            

            // Caracteristicas de Graphql
            //services.AddTransient<Query>();
            //services.AddTransient<Mutation>();
            //services.AddTransient<Subscription>();
            //services.AddTransient<Calls>();
            services.AddScoped<Query>();
            //services.AddScoped<Mutation>();
            services.AddScoped<Calls>();


            // enable InMemory messaging services for subscription support.
            services.AddInMemorySubscriptionProvider();


            // Políticas de autorización
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("HasRole", policy =>
                    policy.RequireAssertion(context =>
                        context.User.HasClaim(c =>
                            (c.Type == ClaimsIdentity.DefaultRoleClaimType))));
            });


            // JWT Políticas de autenticacion
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                    };
                });



            // Agregar acceso CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Token")
                    //.AllowCredentials()
                    .Build());
            });

            // this enables you to use DataLoader in your resolvers.
            // services.AddDataLoaderRegistry();


            // Caracteristicas de Graphql
            // Add GraphQL Services
            services.AddGraphQL(
                SchemaBuilder.New()
                .AddQueryType<QueryType>()
                //.AddMutationType<MutationType>()
                .AddAuthorizeDirectiveType()
                .AddType<FechaHoraType>()
               .Create(),
                builder => builder
                .UseExceptionHandling()
                //.Use<ImpersonatedMiddleware>()
                //.Use<AuthenticationMiddleware>()
                .UseDefaultPipeline()
               );

            AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);


            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IConfiguration>(_configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddErrorFilter<ErrorFilter>();
            //services.AddTransient<Calls>();
            services.AddScoped<Calls>();
          
            //AQUI SE AÑADE EL SIGNALR
            //services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            /*
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificacionHub>("/notificacionHub");
            });
            */

            app.UseCors("CorsPolicy");
            app.UseAuthentication();


            app.UseWebSockets();
            app.UseGraphQL();
            app.UsePlayground();


            //app.UseVoyager();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Service running");
            });
        }
    }
}
