using MediatR;
using Xplora.Model.Entities;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.Product.Queries.GetAll
{
  public class ProductGellAllQuery : IRequest<BaseResponse<IEnumerable<Products>>>
  {
  }
}

