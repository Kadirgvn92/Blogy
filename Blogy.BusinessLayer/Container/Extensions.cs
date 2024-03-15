using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.BusinessLayer.ValidationRules.ArticleValidation;
using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.EntityFramework;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Container;
public static class Extensions
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        services.AddScoped<IArticleDal, EfArticleDal>();
        services.AddScoped<IArticleService, ArticleManager>();

        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<ICategoryService, CategoryManager>();

        services.AddScoped<ICommentDal, EfCommentDal>();
        services.AddScoped<ICommentService, CommentManager>();

        services.AddScoped<ITagDal, EfTagDal>();
        services.AddScoped<ITagService, TagManager>();

        services.AddScoped<IWriterDal, EfWriterDal>();
        services.AddScoped<IWriterService, WriterManager>();
    }
    public static void RegisterValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateArticleValidation>();
    }
}
