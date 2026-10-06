using Microsoft.AspNetCore.Http;

namespace BookManagement.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Lấy thông tin request
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var method = context.Request.Method;
            var path = context.Request.Path.ToString();

            // Log trước khi vào Controller
            Console.WriteLine(
                $"[{time}] Method: {method} - Path: {path}");

            // Chặn Book Id không hợp lệ
            if (path.Equals("/Books/Details/0",
                    StringComparison.OrdinalIgnoreCase) ||
                path.Equals("/Books/Details/-1",
                    StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(
                    "Book id khong hop le");

                Console.WriteLine(
                    $"Status Code: {context.Response.StatusCode}");

                return;
            }

            // Cho request đi tiếp
            await _next(context);

            // Log sau khi request đã được xử lý
            Console.WriteLine(
                $"Status Code: {context.Response.StatusCode}");
        }
    }
}