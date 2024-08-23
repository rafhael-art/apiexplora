using MediatR;
using System.ComponentModel.DataAnnotations;
using Xplora.UseCases.Bases;
using Xplora.UseCases.Validators;

namespace Xplora.UseCases.UseCases.Product.Command.Insert
{
    public class ProductInsertCommand : IRequest<BaseResponse<int>>
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Sku { get; set; } = string.Empty;

        [Required]
        [MinLength(10)]
        public string Descripcion { get; set; } = string.Empty;

        [NonZero]
        [NonNegative]
        public decimal Precio { get; set; }
    }
}



