using Microsoft.AspNetCore.Mvc;
using MInitweetApi.Models;

namespace MinitweetApi.Controllers
{


    [Route("")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IUtilityRepository _repository;

        public UtilityController(DatabaseContext context, IUtilityRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        [Route("latest")]
        public async Task<ActionResult> Latest()
        {
            try
            {
                var res = _repository.Latest();
                var obj = new
                {
                    latest = res
                };
                return new OkObjectResult(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(404);
            }
        }
    }
}