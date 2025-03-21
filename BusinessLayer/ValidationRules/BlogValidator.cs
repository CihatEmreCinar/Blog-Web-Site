using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator() 
        {
            RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş Geçilemez");
            RuleFor(x=>x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş Geçilemez");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakterlik Blog Başlığı Girişi Yapınız.");
            RuleFor(x => x.BlogTitle).MaximumLength(50).WithMessage("Lütfen En Fazla 100 Karakterlik Başlığı Girişi Yapınız.");
        }
    }
}
