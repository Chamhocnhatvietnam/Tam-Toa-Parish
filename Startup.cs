using FinalHDT.Pages.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalHDT
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
        }
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseSession();
        }
    }
}
