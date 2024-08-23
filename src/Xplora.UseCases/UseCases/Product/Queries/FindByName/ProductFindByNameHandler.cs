using MediatR;
using Microsoft.Extensions.Logging;
using Xplora.Model.Entities;
using Xplora.Services.Interfaces;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.Product.Queries.FindByName
{
  public class ProductFindByNameHandler : IRequestHandler<ProductFindByNameQuery, BaseResponse<IEnumerable<Products>>>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductFindByNameHandler> _logger;
    public ProductFindByNameHandler(IUnitOfWork unitOfWork, ILogger<ProductFindByNameHandler> logger)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
    }

    public async Task<BaseResponse<IEnumerable<Products>>> Handle(ProductFindByNameQuery request, CancellationToken cancellationToken)
    {
      BaseResponse<IEnumerable<Products>> response = new BaseResponse<IEnumerable<Products>>();
      try
      {
        response.Data = await _unitOfWork.ProductRepository.FindByName(request);
      }
      catch (Exception ex)
      {
        response.IsSucces = false;
        response.Message = ex.Message;
        _logger.LogError($"Error al obtener productos con el nombre {request.Name}");
      }
      return response;
    }
  }
}

