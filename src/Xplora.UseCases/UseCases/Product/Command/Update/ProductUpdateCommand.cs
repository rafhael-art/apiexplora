using System.ComponentModel.DataAnnotations;
using MediatR;
using Xplora.UseCases.Bases;
using Xplora.UseCases.Validators;

namespace Xplora.UseCases.UseCases.Product.Command.Update
{
    public class ProductUpdateCommand : IRequest<BaseResponse<bool>>
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Sku { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [NonNegative]
        public decimal Precio { get; set; }
    }
}

