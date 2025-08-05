using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PorfolioValidator:AbstractValidator<Portfolio>
    {
        public PorfolioValidator()
        {
            RuleFor(x => x.ProjectName).NotEmpty().WithMessage("Proje Adı Boş geçilemez");
            RuleFor(x => x.ProjectName).MinimumLength(5).WithMessage("Proje Adı en az 5 karakter olmalı.");
            RuleFor(x => x.ProjectName).MaximumLength(55).WithMessage("Proje Adı en fazla 5 karakter olmalı.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Alanı Boş geçilemez");
        }
    }
}
