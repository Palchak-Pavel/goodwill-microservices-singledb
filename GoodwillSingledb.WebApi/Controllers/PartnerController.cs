using AutoMapper;
using GoodwillSingledb.Application.Goodwills.Commands.Partners;
using GoodwillSingledb.Application.Goodwills.Commands.Partners.Queries.GetPartnerDetails;
using GoodwillSingledb.Persistence.Models;
using GoodwillSingledb.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodwillSingledb.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PartnerController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PartnerDetailsVm>> Get(int id)
        {
            var query = new GetPartnerDetailsQuery
            {
                PartenrID = id
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
      
        public async Task<ActionResult> CreatePartnerCommand([FromBody]CreatePartnerDto createPartnerDto, int id)
        {
            var command =_mapper.Map<CreatePartnerCommand>(createPartnerDto);
            command.PartenrID = id;
            var partnerId = await _mediator.Send(command);
            return Ok(partnerId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePartnerCommand([FromBody]UpdatePartnerDto updatePartnerDto, int id)
        {
            var command = _mapper.Map<UpdatePartnerCommand>(updatePartnerDto);
            command.PartenrID = id;
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
