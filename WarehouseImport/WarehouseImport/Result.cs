using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public static Task<Result> OkAsync()
        {
            return Task.FromResult(Ok());
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>()
            {
                Success = true,
                Value = value
            };
        }

        public static Task<Result<T>> OkAsync<T>(T value)
        {
            return Task.FromResult(Ok<T>(value));
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

        public static Result Failure(string message)
        {
            var result = new Result();

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

        public static Task<Result> FailureAsync(string message)
        {
            return Task.FromResult(Failure(message));
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
