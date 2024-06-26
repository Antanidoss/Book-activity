﻿namespace BookActivity.Api.Common.Models
{
    public class ApiResult<T>
    {
        public T Result { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public ApiResult(T result, bool success)
        {
            Result = result;
            Success = success;
        }

        public ApiResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Success = false;
        }
    }
}
