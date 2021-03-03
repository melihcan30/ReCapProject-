using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Marka adı en fazla 3 karakterden oluşabilir!");
        }
    }
}
