using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz.");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz.");
            RuleFor(x=>x.CategoryName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakterlik Kategori Girişi Adı Yapınız.");
            RuleFor(x=>x.CategoryName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakterlik Kategori Girişi Adı Yapınız.");


        }
    }
}
