using BookStore.API.DTOs.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Text;
using BookStore.API.DTOs.ApiResult;

namespace BookStore.API.Extensions
{
    public static class AplicationExtendedMethods
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    ApiCommonResult apiResult = new ApiCommonResult(exceptionHandlerPathFeature?.Error);
                    await context.Response.WriteAsJsonAsync(apiResult);
                });
            });
        }

        public static void UseCustomBadExceptionHandler(this IServiceCollection service)
        {
            service.AddMvc()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = (context) =>
                    {
                        var bodyStr = string.Empty;
                        var req = context.HttpContext.Request;
                        req.Body.Position = 0;
                        using (StreamReader reader = new(req.Body, Encoding.UTF8, true, 1024, true))
                        {
                            Task<string> body = reader.ReadToEndAsync();
                            body.Wait();
                            bodyStr = Regex.Replace(body.Result, @"\t|\n|\r", string.Empty);
                        }

                        var apiErrorResult = new ApiErrorResult(context.ModelState, bodyStr);
                        return new BadRequestObjectResult(apiErrorResult);
                    };
                });
        }
    }
}
