using MediatR;
using Microsoft.Extensions.Logging;
using Xplora.Services.Interfaces;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.Product.Command.Update
{
    public class ProductUpdateHanlder : IRequestHandler<ProductUpdateCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductUpdateCommandValidator _validations;
        private readonly ILogger<ProductUpdateHanlder> _logger;
        public ProductUpdateHanlder(IUnitOfWork unitOfWork, ProductUpdateCommandValidator validations, ILogger<ProductUpdateHanlder> logger)
        {
            _unitOfWork = unitOfWork;
            _validations = validations;
            _logger = logger;
        }

        public async Task<BaseResponse<bool>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();
            try
            {
                response.Data = await _unitOfWork.ProductRepository.ExecAsync("USP_PRODUCT_UPDATE", request);
                if (response.Data)
                {
                    response.Message = "Producto actualizado correctamente";
                }
                else
                {
                    response.Message = "Error al actualizar el producto";
                    response.IsSucces = false;
                }
            }
            catch (Exception ex)
            {
                response.IsSucces = false;
                response.Message = ex.Message;
                _logger.LogError($"Error al actualizar producto con el id {request.ProductId}");
            }
            return response;
        }
    }
}

