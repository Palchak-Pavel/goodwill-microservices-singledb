using AutoMapper;
using GoodwillSingledb.Application.Goodwills.Commands.Partners;
using GoodwillSingledb.Application.Goodwills.Commands.Partners.Queries.GetPartnerDetails;
using GoodwillSingledb.Persistence.Models;
using GoodwillSingledb.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoodwillSingledb.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PartnerController : BaseController
    {
        private readonly IMapper _mapper;

        public PartnerController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PartnerDetailsVm>> Get(int id)
        {
            var query = new GetPartnerDetailsQuery
            {
                PartenrID = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
      
        public async Task<ActionResult> CreatePartnerCommand([FromBody]CreatePartnerDto createPartnerDto, int id)
        {
            var command =_mapper.Map<CreatePartnerCommand>(createPartnerDto);
            command.PartenrID = id;
            var partnerId = await Mediator.Send(command);
            return Ok(partnerId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePartnerCommand([FromBody]UpdatePartnerDto updatePartnerDto, int id)
        {
            var command = _mapper.Map<UpdatePartnerCommand>(updatePartnerDto);
            command.PartenrID = id;
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
