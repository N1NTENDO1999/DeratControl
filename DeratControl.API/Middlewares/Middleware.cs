using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DeratControl.Domain.Root.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace DeratControl.API.Middlewares
{
    public class HttpStatusCodeExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public HttpStatusCodeExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                if (context.Response.HasStarted)
                {
                    throw;
                }
                context.Response.Clear();
                Log.Error($"Occured exception:  {ex.Message}");
                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = ex.ContentType;
                await context.Response.WriteAsync(ex.Message);
                return;
            }
        }
    }
    public static class HttpStatusCodeExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpStatusCodeExceptionMiddleware>();
        }
    }
}
