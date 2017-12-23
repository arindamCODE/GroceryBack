using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Services;

namespace GroceryBack
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
            try
            {
                services.AddDbContext<ProductContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));
                services.AddTransient<IGroupService, GroupService>();
                services.AddTransient<IInfoService, InfoService>();
                services.AddCors();
                services.AddMvc();
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            try
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());


                app.UseMvc();
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
}
