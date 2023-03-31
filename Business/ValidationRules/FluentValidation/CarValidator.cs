using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.Name).NotEmpty().WithMessage("Ad alanı boş bırakılamaz");
            RuleFor(c=>c.Name).Must(StartWithA).WithMessage("Araba ismi A ile başlamalı");
            RuleFor(c=>c.ModelYear).NotEmpty();
            RuleFor(c=>c.ModelYear).GreaterThanOrEqualTo("2000").When(p=>p.BrandId==1);
            RuleFor(c => c.DailyPrice).NotEmpty();
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
