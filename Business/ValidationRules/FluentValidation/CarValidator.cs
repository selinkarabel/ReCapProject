using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(2).WithMessage(Messages.CarNameInvalid);
            RuleFor(p => p.DailyPrice).NotEmpty().WithMessage("Pls enter daily price for car!");
            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage(Messages.CarDailyPriceInvalid);
        }
    }
}
