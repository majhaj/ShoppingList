using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(ListNotFoundException listException)
            {
                _logger.LogError(listException, listException.Message);
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(listException.Message);
            }
            catch(UserNotFoundException userException)
            {
                _logger.LogError(userException, userException.Message);
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(userException.Message);
            }
            catch(ItemNotFoundException itemException)
            {
                _logger.LogError(itemException, itemException.Message);
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(itemException.Message);
            }
            catch(ProductNotFoundException productException)
            {
                _logger.LogError(productException, productException.Message);
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(productException.Message);
            }
            catch(BadRequestException badRequestException)
            {
                _logger.LogError(badRequestException, badRequestException.Message);
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch(DuplicateObjectNameException duplicateNameException)
            {
                _logger.LogError(duplicateNameException, duplicateNameException.Message);
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(duplicateNameException.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
