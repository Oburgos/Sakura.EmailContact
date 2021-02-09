﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sakura.EmailContact.Features.Common
{
    public static class ModelValidator
    {
        public static EntityResponse Validate<T>(T model, string errorCode)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            if (isValid)
            {
                return EntityResponse.CreateOk();
            }
            return EntityResponse.CreateError(results.First().ErrorMessage, errorCode);
        }
    }
}
