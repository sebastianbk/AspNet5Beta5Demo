using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using WebApplication11.Repositories;
using System.Diagnostics;

namespace WebApplication11
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IBlogRepo, BlogRepo>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            }).Use(async (HttpContext httpcontext, Func<Task> next) =>
            {
                var sw = Stopwatch.StartNew();

                httpcontext.Response.OnSendingHeaders((state) =>
                {
                    sw.Stop();
                    httpcontext.Response.Headers.Add("X-Response-Time", new string[] { sw.ElapsedMilliseconds.ToString() + "ms" });
                }, null);
                await next.Invoke();
            }); ;
        }
    }
}
