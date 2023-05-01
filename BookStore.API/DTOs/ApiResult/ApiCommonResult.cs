using BookStore.API.Constants;
using System.Diagnostics.CodeAnalysis;

namespace BookStore.API.DTOs.ApiResult
{
    public class ApiCommonResult
    {
        public ApiCommonResult(bool isSuccessful, string message)
        {
            this.IsSuccessful = isSuccessful;
            this.Message = message;
        }

        [ExcludeFromCodeCoverage]
        public ApiCommonResult(Exception? exception)
        {
            this.Message = exception is null ? ResponseMessages.NullExceptionMessage : $"{exception.Message}\n\n{exception.StackTrace}";
        }

        public bool IsSuccessful { get; init; }

        public string Message { get; init; } = string.Empty;
    }
}
