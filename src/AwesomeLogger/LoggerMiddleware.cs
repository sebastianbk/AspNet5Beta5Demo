using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace AwesomeLogger
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class LoggerMiddleware
    {
        private readonly RequestDelegate next;

        public LoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpRequest context)
        {
            var sw = Stopwatch.StartNew();

            context.Response.OnSendingHeaders((state) =>
            {
                sw.Stop();
                context.Response.Headers.Add("X-Response-Time", new string[] { sw.ElapsedMilliseconds.ToString() + "ms" });
            }, null);

            return next(context);
        }
    }
}
