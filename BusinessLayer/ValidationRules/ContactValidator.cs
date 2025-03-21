using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        { 
            RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad Kısmı Boş Geçilemez");
            RuleFor(x=>x.SurName).NotEmpty().WithMessage("Soyad Kısmı Boş Geçilemez");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez");
            RuleFor(x=>x.Message).NotEmpty().WithMessage("Mesaj Boş Geçilemez");

        }
    }
}
