using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using MicroServiceLREC.GraphQL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MicroServiceLREC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static readonly string appName = "MicroServiceLREC".ToUpper();

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroServiceLREC", Version = "v1" });
            });
            */

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = appName,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appName.PadLeft(16, '*').Substring(0, 16)))
                };
                options.Events = new JwtBearerEvents();

            });

            services.AddGraphQL(provider => SchemaBuilder
               .New()
               .AddServices(provider)
               .AddQueryType<QuerysAPI>()
               .AddMutationType<MutationsAPI>()
               .AddAuthorizeDirectiveType()
               .Create()
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroServiceLREC v1"));
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api/LargeRealEstateCompany",
                    Path = "/playground"
                });
            }

            app.UseAuthentication();

            app.UseGraphQL("/api/LargeRealEstateCompany");

            /*
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            */
        }
    }
}
