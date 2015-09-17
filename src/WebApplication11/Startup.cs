using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using System.Diagnostics;

namespace WebApplication11
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.Use(async (HttpContext httpContext, Func<Task> next) =>
            //{
            //    var sw = Stopwatch.StartNew();

            //    httpContext.Response.OnSendingHeaders((state) =>
            //    {
            //        sw.Stop();
            //        httpContext.Response.Headers.Add("X-Response-Time", new string[] { sw.ElapsedMilliseconds.ToString() + "ms" });
            //    }, null);

            //    await next.Invoke();
            //});

            //app.Use(async (HttpContext httpContext, Func<Task> next) =>
            //{
            //    Debug.WriteLine("Begin Request");
            //    await next.Invoke();
            //    Debug.WriteLine("End Request");
            //});

            //app.Use(async (HttpContext httpContext, Func<Task> next) =>
            //{
            //    httpContext.Response.OnSendingHeaders((state) =>
            //    {
            //        httpContext.Response.Headers.Add("Content-Security-Policy", new string[] { "script-src 'self' https://apis.google.com" });
            //    }, null);

            //    await next.Invoke();
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
