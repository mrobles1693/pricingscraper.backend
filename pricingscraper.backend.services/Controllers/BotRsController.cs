using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pricingscraper.backend.businesslogic.Interfaces;
using pricingscraper.backend.domain;

namespace pricingscraper.backend.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotRsController : ControllerBase
    {

        private readonly IBotBL service;

        public BotRsController(IBotBL _service) 
        { 
            this.service = _service;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SimilarDTO>>>> getListSimilar()
        {

            ApiResponse<List<SimilarDTO>> response = new ApiResponse<List<SimilarDTO>>();

            try
            {
                var result = await service.getListSimilar();

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
    }
}
