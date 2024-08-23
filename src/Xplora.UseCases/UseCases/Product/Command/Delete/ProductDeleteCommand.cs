using System.ComponentModel.DataAnnotations;
using MediatR;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.Product.Command.Delete
{
    public class ProductDeleteCommand : IRequest<BaseResponse<bool>>
    {
        [Required]
        public int ProductId { get; set; }
    }
}

