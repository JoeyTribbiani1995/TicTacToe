using TicTacToe.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace TicTacToe.Extensions
{
    public static class CommunicationMiddlewareExtension
    {
        public static IApplicationBuilder UseCommunicationMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CommunicationMiddleware>();
        }
    }
}
