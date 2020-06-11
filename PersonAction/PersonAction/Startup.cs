using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PersonAction.Business;
using PersonAction.Business.Implemetations;
using PersonAction.Model.Context;
using PersonAction.Repository;
using PersonAction.Repository.Implemetations;

namespace PersonAction
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;           
        }

        public IConfiguration _configuration { get; }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));
            services.AddMvc();
            services.AddApiVersioning();

            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();

            services.AddScoped<IBookBusiness, BookBusinessImpl>();
            services.AddScoped<IBookRepository, BookRepositoryImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Worker Process Name : "
                    + System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            });
        }
    }
}
