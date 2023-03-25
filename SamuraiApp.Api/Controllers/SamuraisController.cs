using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.Domain;
using SamuraiApp.Service.Interfaces;

namespace SamuraiApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamuraisService samuraisService;

        public SamuraisController(ISamuraisService samuraisService)
        {
            this.samuraisService = samuraisService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await samuraisService.GetSamurais());
        }

        [HttpGet]
        [Route("{samuraiId:int}")]
        public async Task<IActionResult> GetById(int samuraiId)
        {
            return Ok(await samuraisService.GetSamuraiById(samuraiId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Samurai samurai)
        {
            return Ok(await samuraisService.CreateSamurai(samurai));
        }

        [HttpDelete]
        [Route("{samuraiId:int}")]
        public async Task<IActionResult> Delete(int samuraiId)
        {
            if (await samuraisService.DeleteSamurai(samuraiId))
                return Ok();
            else
                return NotFound();
        }

        [HttpPut]
        [Route("{samuraiId:int}")]
        public async Task<IActionResult> Update(int samuraiId, Samurai samurai)
        {
            if (!samuraiId.Equals(samurai.Id))
                return BadRequest();

            await samuraisService.UpdateSamurai(samuraiId, samurai);
            return Ok();
        }
    }
}