using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pricingscraper.backend.businesslogic.Interfaces;
using pricingscraper.backend.domain;

namespace pricingscraper.backend.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotExecutionController : ControllerBase
    {
        public readonly IBotExecutionBL service;

        public BotExecutionController(IBotExecutionBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<BotExecutionDTO>>>> getListBotExecution()
        {

            ApiResponse<List<BotExecutionDTO>> response = new ApiResponse<List<BotExecutionDTO>>();

            try
            {
                var result = await service.getListBotExecution();

                response.success = true;
                response.data = (List<BotExecutionDTO>)result;
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
