using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LittlePacktBookstore.Models;
using LittlePacktBookstore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace LittlePacktBookstore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc();
			services.AddSingleton<IRepository<Book>, MockBooksRepository>();
			services.AddTransient<IRepository<Carousel>, MockCarouselRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			app.UseMvc(ConfigureRoutes);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

		private static void ConfigureRoutes(IRouteBuilder routes)
		{
			routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
		}

	}
}
