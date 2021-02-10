using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sakura.EmailContact.Features.Contacts;
using Sakura.EmailContact.Infrastructure;
using Sakura.EmailContact.Infrastructure.Core;

namespace Sakura.EmailContact
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<EmailContactDbContext>(options => {
                options.UseNpgsql(Configuration.GetConnectionString("EmailContactDbPostgres"));
            });

            services.AddScoped<IUnitOfWork>(r => {
                var dbContext = r.GetService<EmailContactDbContext>();
                return new EntityUnitOfWork<EmailContactDbContext>(dbContext);
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sakura.EmailContact", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                 {
                     Description = "JWT Authorization header",
                     Name = "Authorization",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.ApiKey,
                     Scheme = "Bearer"
                 });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                                          {
                                            {
                                              new OpenApiSecurityScheme
                                              {
                                                Reference = new OpenApiReference
                                                  {
                                                    Type = ReferenceType.SecurityScheme,
                                                    Id = "Bearer"
                                                  },
                                                  Scheme = "oauth2",
                                                  Name = "Bearer",
                                                  In = ParameterLocation.Header,
                                                },
                                                new List<string>()
                                              }
                                            });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<ContactsAppService>();

            ConfigureSecurity(services);
        }

        private void ConfigureSecurity(IServiceCollection services)
        {
            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = domain;
                    options.Audience = Configuration["Auth0:Audience"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sakura.EmailContact v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
