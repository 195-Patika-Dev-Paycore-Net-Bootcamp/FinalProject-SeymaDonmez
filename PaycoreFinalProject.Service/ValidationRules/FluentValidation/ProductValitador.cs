using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Service.Constants;

namespace PaycoreFinalProject.Service.ValidationRules.FluentValidation
{
    //Product nesnesinin doğrulama sınıfıdır.
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().NotNull().MaximumLength(100).WithMessage(Messages.ProductNameInvalid);
            RuleFor(p => p.CategoryId).NotEmpty().NotNull().WithMessage(Messages.ProductCategoryError);
            RuleFor(p => p.Description).NotEmpty().NotNull().MaximumLength(100).WithMessage(Messages.ProductDescriptionError);
            RuleFor(p => p.Color).NotEmpty().NotNull().WithMessage(Messages.ProductColorError);
            RuleFor(p => p.Brand).NotEmpty().NotNull().WithMessage(Messages.ProductBrandError);
            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage(Messages.ProductPriceError);

        }
    }
}
