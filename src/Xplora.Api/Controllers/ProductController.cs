using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Xplora.Model.Entities;
using Xplora.UseCases.Bases;
using Xplora.UseCases.UseCases.Product.Command.Delete;
using Xplora.UseCases.UseCases.Product.Command.Insert;
using Xplora.UseCases.UseCases.Product.Command.Update;
using Xplora.UseCases.UseCases.Product.Queries.FindByName;
using Xplora.UseCases.UseCases.Product.Queries.GetAll;

namespace Xplora.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await _mediator.Send(new ProductGellAllQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener productos");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductInsertCommand command)
        {
            try
            {
                var data = await _mediator.Send(command);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear producto");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut]
        public async Task<ActionResult> Update(ProductUpdateCommand command)
        {
            try
            {
                var data = await _mediator.Send(command);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar producto con el id {command.ProductId}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(ProductDeleteCommand command)
        {

            try
            {
                var data = await _mediator.Send(command);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar producto con el id {command.ProductId}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Buscar productos por nombre
        /// </summary>
        /// <param name="query">El query param que contiene el nombre del producto a buscar</param>
        /// <returns>Devuelve un objeto con el estado de la operación, datos de productos, y posibles errores</returns>
        /// <remarks>
        /// **Ejemplo de solicitud:**
        ///
        ///     GET /api/products/SearchByName?Name=example
        ///
        /// **Ejemplo de respuesta:**
        ///
        ///     HTTP/1.1 200 OK
        ///     Content-Type: application/json
        ///     {
        ///       "isSucces": true,
        ///       "data": [
        ///         {
        ///           "productId": 1,
        ///           "name": "Celular",
        ///           "sku": "C0001",
        ///           "descripcion": "Smartphone",
        ///           "precio": 5000.0
        ///         },
        ///         {
        ///           "productId": 2,
        ///           "name": "Televisor",
        ///           "sku": "T0001",
        ///           "descripcion": "Smart TV",
        ///           "precio": 1500.0
        ///         }
        ///       ],
        ///       "message": "string"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Operación exitosa con datos del producto</response>
        /// <response code="400">Solicitud incorrecta si los parámetros de consulta no son válidos</response>
        /// <response code="401">No autorizado si el usuario no tiene permisos para realizar esta acción</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("SearchByName")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<Products>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> SearchByName([FromQuery] ProductFindByNameQuery query)
        {
            try
            {
                var data = await _mediator.Send(query);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al buscar producto con el nombre {query.Name}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}

