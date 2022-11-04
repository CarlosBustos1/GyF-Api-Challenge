using GyF_Api_Challenge.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GyF_Api_Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        public static List<KeyValueDto<int>> generos = new List<KeyValueDto<int>>()
        {
            new KeyValueDto<int>(1,"Masculino"),
            new KeyValueDto<int>(2,"Femenino"),
            new KeyValueDto<int>(3,"No binario"),
        };

        [HttpGet]
        public async Task<IActionResult> Generos()
        {
            try
            {
                return Ok(generos);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
