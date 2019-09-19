using DeratControl.API.Middlewares;
using DeratControl.Security.Infrastracture;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DeratControl.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using DeratControl.Security;
using DeratControl.Domain.Security;
using System.Reflection;
using DeratControl.Domain.Root;
using DeratControl.API.Dispatchers;
using DeratControl.Application.Interfaces;
using DeratControl.Application.Organizations;
using DeratControl.Infrastructure.Repositories;
using DeratControl.Domain.Root.Repositories;
using DeratControl.Application.Points.Commands.AddPoint;
using DeratControl.Application.Points.Queries.GetPointsByPerimeter;
using DeratControl.Application.Perimeters.Queries.GetPerimetersList;
using DeratControl.Application.Perimeters.Commands;
using DeratControl.Application.Facilities.Commands;
using DeratControl.Application.Facilities.Queries.GetFacilitiesList;
using DeratControl.Application.Traps.Commands.SetTrap;
using DeratControl.Application.Traps.Queries.ViewTrapByPoint;

namespace DeratControl.API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            this._config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DeratContext>(options => {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"), 
                    builder => builder.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name));
            });



            services.AddMvcCore().AddApiExplorer();
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"), 
                builder => builder.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name)));

            services.AddIdentity<SecurityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = AuthOptions.ISSUER,
                            ValidateAudience = true,
                            ValidAudience = AuthOptions.AUDIENCE,
                            ValidateLifetime = true,
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<DbContext, DeratContext>();
            
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(CommandDispatcher));
            services.AddScoped(typeof(QueryDispatcher));
               
            services.AddScoped(typeof(ICommandHandler<AddPointsCommand>), typeof(AddPointCommandHandler));
            services.AddScoped(typeof(IQueryHandler<GetPointsQuery,PointsViewModelResult>), typeof(GetPointsQueryHandler));
            services.AddScoped(typeof(ICommandHandler<AddPerimeterCommand>), typeof(AddPerimeterCommandHandler));
            services.AddScoped(typeof(IQueryHandler<GetPerimetersQuery, PerimetersViewModelResult>), typeof(GetPerimetersQueryHandler));
            services.AddScoped(typeof(ICommandHandler<AddFacilityCommand>), typeof(AddFacilityCommandHandler));
            services.AddScoped(typeof(IQueryHandler<GetFacilitiesListQuery, FacilitiesListViewModel>), typeof(GetFacilitiesListQueryHandler));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpStatusCodeExceptionMiddleware();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseHttpStatusCodeExceptionMiddleware();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}

