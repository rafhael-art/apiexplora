using MediatR;
using Xplora.Model.Entities;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.Product.Queries.FindByName
{
  public class ProductFindByNameQuery : IRequest<BaseResponse<IEnumerable<Products>>>
  {
    public string Name { get; set; } = string.Empty;
  }
}

