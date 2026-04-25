using LanceCoffeeSystem.API.Controllers;
using LanceCoffeeSystem.Application.Features.CoffeeSystem.Queries.BrewCoffee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LanceCoffeeSystem.Api.Controllers.v1
{
    public class BrewCoffeeController : BaseApiController<BrewCoffeeController>
    {
        [HttpGet("brew-coffee")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBrewCoffee()
        {
            var brew_coffee = await _mediator.Send(new GetBrewCoffeeQuery());
            return Ok(brew_coffee);
        }
    }
}