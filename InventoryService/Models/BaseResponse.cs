using InventoryService.Interfaces;

namespace InventoryService.Models
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public bool Success { get; set; }

        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public static BaseResponse<T> SuccesResult(T? data) {
            return new BaseResponse<T>
            {
                Success = true,
                Data = data,
                Errors = null
            };
        }

        public static BaseResponse<T> FailResult(string? msg, List<string>? errors)
        {
            return new BaseResponse<T>
            {
                Success = false,
                Message = msg,                
                Errors = errors
            };
        }

    }
}
