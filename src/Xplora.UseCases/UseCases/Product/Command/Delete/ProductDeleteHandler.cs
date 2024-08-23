using MediatR;
using Microsoft.Extensions.Logging;
using Xplora.Services.Interfaces;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.Product.Command.Delete
{
  public class ProductDeleteHandler : IRequestHandler<ProductDeleteCommand, BaseResponse<bool>>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductDeleteHandler> _logger;
    public ProductDeleteHandler(IUnitOfWork unitOfWork, ILogger<ProductDeleteHandler> logger)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
    }

    public async Task<BaseResponse<bool>> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
    {
      BaseResponse<bool> response = new BaseResponse<bool>();
      try
      {
        response.Data = await _unitOfWork.ProductRepository.ExecAsync("USP_PRODUCT_DELETE", request);
        if (response.Data)
        {
          response.Message = "Producto elimina correctamente";
        }
        else
        {
          response.IsSucces = false;
          response.Message = "Ocurrio un error al eliminar el producto";
        }
      }
      catch (Exception ex)
      {
        response.IsSucces = false;
        response.Message = ex.Message;
        _logger.LogError($"Error al eliminar producto con el id {request.ProductId}");
      }
      return response;
    }
  }
}

