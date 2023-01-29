using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using WebApplication12.Models.DB;
using WebApplication12.Models.Repositories;

namespace WebApplication12.Middlewares {
    public class LoggingMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogsRepositories _logsRepository;
        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware (RequestDelegate next) {
            _next = next;


            
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync (HttpContext context, ILogsRepositories logsRepositories) {
            var newRequest = new Request() {
                Date = DateTime.Now,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };
            logsRepositories.AddLogs(newRequest);
            await _next.Invoke(context);
        }

    }
}
