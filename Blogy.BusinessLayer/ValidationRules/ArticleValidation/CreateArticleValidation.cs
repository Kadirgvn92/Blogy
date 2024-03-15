using Blogy.EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.ArticleValidation;
public class CreateArticleValidation : AbstractValidator<Article>
{
    public CreateArticleValidation()
    {
        RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Lütfen makale için bir kategori seçin");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen makale için bir başlık girin")
            .MinimumLength(5).WithMessage("Lütfen başlık kısmına en az 5 karakter girin")
            .MaximumLength(100).WithMessage("Lütfen başlık kısmına en fazla 10 karaker girin");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen makale için bir açıklama girin");
    }
}
