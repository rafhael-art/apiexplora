using MediatR;
using Microsoft.Extensions.Logging;
using Xplora.Model.Entities;
using Xplora.Services.Interfaces;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.Product.Queries.GetAll
{
  public class ProductGellAllHandler : IRequestHandler<ProductGellAllQuery, BaseResponse<IEnumerable<Products>>>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductGellAllHandler> _logger;
    public ProductGellAllHandler(IUnitOfWork unitOfWork, ILogger<ProductGellAllHandler> logger)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
    }

    public async Task<BaseResponse<IEnumerable<Products>>> Handle(ProductGellAllQuery request, CancellationToken cancellationToken)
    {
      BaseResponse<IEnumerable<Products>> response = new BaseResponse<IEnumerable<Products>>();
      try
      {
        response.Data = await _unitOfWork.ProductRepository.GetAllAsync("USP_PRODUCT_GET_ALL");
      }
      catch (Exception ex)
      {
        response.IsSucces = false;
        response.Message = ex.Message;
        _logger.LogError("Error al obtener productos");
      }
      return response;
    }
  }
}

