using FluentValidation;

namespace Xplora.UseCases.UseCases.Product.Command.Insert
{
  public class ProductInsertCommandValidator : AbstractValidator<ProductInsertCommand>
  {
    public ProductInsertCommandValidator()
    {
      RuleFor(x => x.Name)
         .NotNull().WithMessage("El campo descripción no puede ser nulo")
        .NotEmpty().WithMessage("El campo descripción no puede ser vacío");

      RuleFor(x => x.Sku)
         .NotNull().WithMessage("El campo Sku no puede ser nulo")
         .NotEmpty().WithMessage("El campo Sku no puede ser vacío");

      RuleFor(x => x.Descripcion)
          .NotNull().WithMessage("El campo descripción no puede ser nulo")
         .NotEmpty().WithMessage("El campo descripción no puede ser vacío");
      RuleFor(x => x.Precio)
          .NotNull().WithMessage("El campo descripción no puede ser nulo")
          .GreaterThan(0).WithMessage("El precio debe ser mayor a 0");
    }
  }
}

