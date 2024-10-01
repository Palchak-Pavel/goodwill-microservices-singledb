using AutoMapper;
using GoodwillSingledb.Application.Goodwills.Commands.Partners;
using GoodwillSingledb.Application.Goodwills.Commands.Partners.Queries.GetPartnerDetails;
using GoodwillSingledb.Domain;
using GoodwillSingledb.Persistence.Models;
using GoodwillSingledb.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GoodwillSingledb.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnerController : BaseController
    {
        private readonly IMapper _mapper;

        public PartnerController(IMapper mapper) => _mapper = mapper;
     

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Partner>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Partner>>> GetPartners()
        {
            var partners = await _mapper.Partners.Find(x => true).ToListAsync();
            var vm = await Mediator.Send(partners);

            return Ok(vm);
        }

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
