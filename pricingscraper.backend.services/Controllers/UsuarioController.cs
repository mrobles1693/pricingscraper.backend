using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pricingscraper.backend.businesslogic.Interfaces;
using pricingscraper.backend.domain;

namespace pricingscraper.backend.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioBL service;

        public UsuarioController(IUsuarioBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<UsuarioDTO>>>> getListUsuario()
        {

            ApiResponse<List<UsuarioDTO>> response = new ApiResponse<List<UsuarioDTO>>();

            try
            {
                var result = await service.getListUsuario();

                response.success = true;
                response.data = (List<UsuarioDTO>)result;
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
        public async Task<ActionResult<ApiResponse<UsuarioDTO>>> getUsuarioByID(int nIdUsuario)
        {

            ApiResponse<UsuarioDTO> response = new ApiResponse<UsuarioDTO>();

            try
            {
                var result = await service.getUsuarioByID(nIdUsuario);

                response.success = true;
                response.data = (UsuarioDTO)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsUsuario([FromBody] UsuarioDTO usuario)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsUsuario(usuario);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdUsuario([FromBody] UsuarioDTO usuario)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdUsuario(usuario);

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
