using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pegler.Players.BusinessLogic.Contracts;
using Pegler.Players.BusinessLogic.Managers;
using Pegler.Players.DataAccess;
using Pegler.Players.DataAccess.Contracts;
using Pegler.Players.DataAccess.Providers;
using System;
using System.Text.Json.Serialization;

namespace Pegler.Players
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
            services.AddControllers()
                .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Tournament Earnings Challenge API",
                        Description = "A set of APIs to interact with with the Challenge",
                        Contact = new OpenApiContact
                        {
                            Name = "Nicholas Pegler",
                            Email = string.Empty,
                            Url = new Uri("https://github.com/nicholaspegler/Leaderboard")
                        }
                    });
                });

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<PlayersContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PlayersConnection")));

            services.AddTransient<IPlayerManager, PlayerManager>();
            services.AddTransient<IPlayerProvider, PlayerProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(
                options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tournament Earnings Challenge");
                    options.RoutePrefix = string.Empty;
                });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
