using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Xplora.Model.Entities;
using Xplora.Services.Interfaces;
using Xplora.UseCases.Bases;

namespace Xplora.UseCases.UseCases.Product.Command.Insert
{
    public class ProductInsertHandler : IRequestHandler<ProductInsertCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ProductInsertCommandValidator _validations;
        private readonly ILogger<ProductInsertHandler> _logger;
        public ProductInsertHandler(IUnitOfWork unitOfWork, IMapper mapper, ProductInsertCommandValidator validations, ILogger<ProductInsertHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validations = validations;
            _logger = logger;
        }

        public async Task<BaseResponse<int>> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<int> response = new BaseResponse<int>();
            try
            {
                var model = _mapper.Map<Products>(request);
                response.Data = await _unitOfWork.ProductRepository.InsertAsync("USP_PRODUCT_INSERT", model);

            }
            catch (Exception ex)
            {
                response.IsSucces = false;
                response.Message = ex.Message;
                _logger.LogError("Error al insertar un producto");
            }
            return response;
        }
    }
}

