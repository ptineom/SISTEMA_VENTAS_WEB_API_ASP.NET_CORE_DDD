using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaVentas.Aplication.Services.Security.Contracts;
using SistemaVentas.Aplication.Services.Security.Implementations;
using SistemaVentas.Cross.Utils;
using SistemaVentas.Presentation.WebApi.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Presentation.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string _myCors { get; } = "myCors";

        public void ConfigureServices(IServiceCollection services)
        {
            //CORS
            services.AddCors((options) =>
            {
                options.AddPolicy(_myCors, (builder) =>
                {
                    builder.WithOrigins("http://localhost:8080");
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowCredentials();
                });
            });

            //Autorizacion global
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:IssuerToken"],
                    ValidAudience = Configuration["Jwt:AudienceToken"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Encode.GetHash256(Configuration["Jwt:SecretKey"])))
                };
                //options.Events = new JwtBearerEvents
                //{
                //    OnMessageReceived = (context) =>
                //    {
                //        var accessToken = context.Request.Query["access_token"];
                //        var path = context.HttpContext.Request.Path;
                //        if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/cambiarestadocajahub")))
                //        {
                //            context.Token = accessToken;
                //        }
                //        return Task.CompletedTask;
                //    }
                //};
            });

            services.AddControllers();

            //Agregando Ioc configurados.
            services.AddRegistration();

            services.AddHttpContextAccessor();

            services.AddScoped<ISessionIdentity, SessionIdentity>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaVentas.Presentation.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaVentas.Presentation.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            //Cors
            app.UseCors(_myCors);

            //Jwt
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
