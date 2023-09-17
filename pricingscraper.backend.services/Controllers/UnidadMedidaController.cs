using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pricingscraper.backend.businesslogic.Interfaces;
using pricingscraper.backend.domain;

namespace pricingscraper.backend.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadMedidaController : ControllerBase
    {
        public readonly IUnidadMedidaBL service;

        public UnidadMedidaController(IUnidadMedidaBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<UnidadMedidaDTO>>>> getListUnidadMedida()
        {

            ApiResponse<List<UnidadMedidaDTO>> response = new ApiResponse<List<UnidadMedidaDTO>>();

            try
            {
                var result = await service.getListUnidadMedida();

                response.success = true;
                response.data = (List<UnidadMedidaDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<UnidadMedidaDTO>>> getUnidadMedidaByID(int nIdUnidadMedida)
        {

            ApiResponse<UnidadMedidaDTO> response = new ApiResponse<UnidadMedidaDTO>();

            try
            {
                var result = await service.getUnidadMedidaByID(nIdUnidadMedida);

                response.success = true;
                response.data = (UnidadMedidaDTO)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsUnidadMedida([FromBody] UnidadMedidaDTO unidadMedida)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsUnidadMedida(unidadMedida);

                response.success = result.nCod == 0 ? false : true;
                response.data = result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdUnidadMedida([FromBody] UnidadMedidaDTO unidadMedida)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdUnidadMedida(unidadMedida);

                response.success = result.nCod == 0 ? false : true;
                response.data = result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }
    }
}
