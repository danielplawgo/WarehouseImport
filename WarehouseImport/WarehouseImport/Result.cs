using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseImport
{
    public class Result
    {
        public bool Success { get; set; }

        public IEnumerable<ErrorMessage> Errors { get; set; }

        public static Result Ok()
        {
            return new Result()
            {
                Success = true
            };
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>()
            {
                Success = true,
                Value = value
            };
        }

        public static Result<T> Failure<T>(string message)
        {
            var result = new Result<T>();

            result.Success = false;
            result.Errors = new List<ErrorMessage>()
            {
                new ErrorMessage()
                {
                    Message = message
                }
            };

            return result;
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; set; }
    }

    public class ErrorMessage
    {
        public string PropertyName { get; set; }

        public string Message { get; set; }
    }
}
