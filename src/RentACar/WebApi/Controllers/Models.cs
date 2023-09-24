using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Models : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetListModelQuery() { PageRequest = pageRequest };
            var response = await Mediator!.Send(query);

            return Ok(response);
        }
    }
}
