using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaServiceController : ControllerBase
    {
        // GET: api/<ContaServiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }        
    }
}
