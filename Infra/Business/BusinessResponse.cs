using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Business
{
    public class BusinessResponse<T>
    {
        public bool IsValid { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public T Result { get; set; }

        public static BusinessResponse<T> GenerateOk(T result) => new BusinessResponse<T>() { IsValid = true, Errors = new List<string>(), Result = result };

        public static BusinessResponse<T> GenerateError(ValidationResult validationResult) => new BusinessResponse<T>() { IsValid = validationResult.IsValid, Errors = validationResult.Errors.Select(er => er.ErrorMessage), Result = default(T)};
    }
}
