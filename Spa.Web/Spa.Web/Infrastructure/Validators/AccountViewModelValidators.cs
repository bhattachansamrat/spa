using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Spa.Web.Models;

namespace Spa.Web.Infrastructure.Validators
{
    public class LoginViewModelValidators:AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidators()
        {
            RuleFor(s => s.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(s => s.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}