using OrderService.Models;

namespace OrderService.Helpers
{
    public static class ResponseHelper
    {
        public static BaseResponse<T> Ok<T>(T data, string message = "OK") =>
            new() { Success = true, Message = message, Data = data };

        public static BaseResponse<T> Fail<T>(string message, List<string>? errors) =>
            new()
            {
                Success = false,
                Message = message,
                Errors = errors
            };
    }
}
