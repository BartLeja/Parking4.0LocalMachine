using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parking4._0LocalMachine.Clients;
using Parking4._0LocalMachine.Services;

namespace Parking4._0LocalMachine
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
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAny",
            //        policy =>
            //            policy.AllowCredentials()
            //                .AllowAnyHeader()
            //                .SetIsOriginAllowedToAllowWildcardSubdomains()
            //                .AllowAnyMethod()
            //                .WithOrigins("http://192.168.1.108:5000", "https://localhost:44390", "https://localhost:44395",
            //                    "https://localhost:44318", "https://sogoodhomeautomation.firebaseapp.com"
            //                    )
            //                );
            //});
            services.AddControllers();
            services.AddHttpClient();
            services.AddSingleton<IParkingService, ParkingService>();
            services.AddSingleton<ISignalRClient, SignalRClient>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseCors("AllowAny");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parking 4.0 local machine API");
                c.RoutePrefix = string.Empty;
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
