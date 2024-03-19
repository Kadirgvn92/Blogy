using Blogy.EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.CategoryValidation;
public class UpdateCategoryValidator : AbstractValidator<Category>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz")
             .MinimumLength(3).WithMessage("Kategori adını en az 3 karakter girebilirsiniz")
            .MaximumLength(30).WithMessage("Kategori adını en fazla 30 karakter girebilirsiniz");
    }
}
