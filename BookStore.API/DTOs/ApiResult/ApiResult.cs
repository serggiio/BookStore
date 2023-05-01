using BookStore.API.Constants;

namespace BookStore.API.DTOs.ApiResult
{
    public class ApiResult<TResult> : ApiCommonResult
            where TResult : class
    {
        public ApiResult(TResult data)
    : base(true, ResponseMessages.OkMessage)
        {
            this.Data = data;
        }

        public ApiResult(TResult data, string message)
            : base(true, message)
        {
            this.Data = data;
        }

        public TResult? Data { get; init; }
    }
}
