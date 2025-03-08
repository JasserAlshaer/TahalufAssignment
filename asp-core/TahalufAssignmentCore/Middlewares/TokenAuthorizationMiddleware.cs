using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using TahalufAssignmentCore.Attributes;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.Middlewares
{
    public class TokenAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();

            // Ignore the middleware if the endpoint allows anonymous access
            if (endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>() != null)
            {
                await _next(context);
                return;
            }

            // Retrieve required role for the endpoint
            var requiredRole = endpoint?.Metadata.GetMetadata<RoleRequirementAttribute>()?.Role;

            // Ignore the middleware if no role is required
            if (string.IsNullOrEmpty(requiredRole))
            {
                await _next(context);
                return;
            }

            // Ensure the user is authenticated
            var user = context.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: No valid authentication.");
                return;
            }

            // Extract roles from user claims
            var roles = user.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            // Check if the required role exists in the token
            if (!roles.Contains(requiredRole))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: Insufficient permissions.");
                return;
            }

            // Call the next middleware
            await _next(context);
        }
    }
}
