using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVentas.Aplication.Services.Contracts;
using SistemaVentas.Aplication.Services.Implementations;
using SistemaVentas.Aplication.Services.Security.Contracts;
using SistemaVentas.Aplication.Services.Security.Implementations;
using SistemaVentas.Domain.RepositoriesContracts;
using SistemaVentas.Domain.RepositoriesContracts.Contracts;
using SistemaVentas.Domain.Services.Contracts;
using SistemaVentas.Domain.Services.Implementations;

using SistemaVentas.Infrastructure.Repositories;
using SistemaVentas.Infrastructure.Repositories.Implementations;
using SistemaVentas.Presentation.WebApi.Mappings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentas.Presentation.WebApi.Register
{
    public static class IocRegister
    {
        public static void AddRegistration(this IServiceCollection services)
        {
            AddRegisterAplicationServices(services);
            AddRegisterConnection(services);
            AddRegisterOthers(services);
            AddRegisterDomainServices(services);
            AddRegisterRepositories(services);
            AddRegisterComponents(services);
        }
        public static void AddRegisterAplicationServices(IServiceCollection services)
        {
            services.AddTransient<IProveedorService, ProveedorService>();
            services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<ITokenProcess, TokenProcess>();
        }
        public static void AddRegisterDomainServices(IServiceCollection services)
        {
            services.AddTransient<IProveedorDomainService, ProveedorDomainService>();
            services.AddTransient<IRefreshTokenDomainService, RefreshTokenDomainService>();
            services.AddTransient<ISecurityDomainService, SecurityDomainService>();
        }
        public static void AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IProveedorRepository, ProveedorRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<ISecurityRepository, SecurityRepository>();
        }
        public static void AddRegisterConnection(IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var sqlConnectionSb = new SqlConnectionStringBuilder()
            {
                UserID = configuration.GetSection("ConnectionStrings:UserId").Value,
                Password = configuration.GetSection("ConnectionStrings:Password").Value,
                DataSource = configuration.GetSection("ConnectionStrings:DataSource").Value,
                InitialCatalog = configuration.GetSection("ConnectionStrings:InitialCatalog").Value,
                PersistSecurityInfo = true
            };

            //Configurar el proveedor, en este caso SQL Server.
            services.AddScoped<IDbConnection>(db => new SqlConnection(sqlConnectionSb.ConnectionString));
            //La conección será según el proveedor configurado.
            services.AddTransient<IConnection, Connection>();
        }

        public static void AddRegisterOthers(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddRegisterComponents(IServiceCollection services)
        {
            //Mapper
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();
        }
    }
}
