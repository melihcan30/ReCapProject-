using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(x => x.CarId).NotNull().WithMessage("Id boş olamaz.");
            //RuleFor(p => p.ImagePath).NotEmpty();
            //RuleFor(p => p.ImagePath).NotNull();   
        }
    }
}
