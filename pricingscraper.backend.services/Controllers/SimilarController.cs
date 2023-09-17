using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pricingscraper.backend.businesslogic.Interfaces;
using pricingscraper.backend.domain;

namespace pricingscraper.backend.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimilarController : ControllerBase
    {
        public readonly ISimilarBL service;

        public SimilarController(ISimilarBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SimilarDTO>>>> getListSimilarByProducto(int nIdProducto)
        {

            ApiResponse<List<SimilarDTO>> response = new ApiResponse<List<SimilarDTO>>();

            try
            {
                var result = await service.getListSimilarByProducto(nIdProducto);

                response.success = true;
                response.data = (List<SimilarDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SimilarDTO>>> getSimilarByID(int nIdSimilar)
        {

            ApiResponse<SimilarDTO> response = new ApiResponse<SimilarDTO>();

            try
            {
                var result = await service.getSimilarByID(nIdSimilar);

                response.success = true;
                response.data = (SimilarDTO)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectComercio()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectComercio();

                response.success = true;
                response.data = (List<SelectDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsSimilar([FromBody] SimilarDTO similar)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsSimilar(similar);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdSimilar([FromBody] SimilarDTO similar)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdSimilar(similar);

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
