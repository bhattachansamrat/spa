using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Spa.Web.Infrastructure.Validators;

namespace Spa.Web.Models
{
    public class LoginViewModel : IValidatableObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new LoginViewModelValidators();
            var result = validator.Validate(this);
            return result.Errors.Select(s => new ValidationResult(s.ErrorMessage, new[] { s.PropertyName }));
        }
    }
}