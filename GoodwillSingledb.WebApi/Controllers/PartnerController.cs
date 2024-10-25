using AutoMapper;
using GoodwillSingledb.Application.Goodwills.Commands.Partners;
using GoodwillSingledb.Application.Goodwills.Queries.GetPartnerDetails;
using GoodwillSingledb.Application.Goodwills.Queries.GetPartnerList;
using GoodwillSingledb.Domain;
using GoodwillSingledb.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections;

namespace GoodwillSingledb.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin, director, moderator, manager, user")]
    public class PartnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PartnerController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        
        //[HttpGet]

        //public async Task<PartnerDto[]> GetAll([FromBody] GetPartnerListQuery query)
        //{
        //    //var query = new GetPartnerListQuery();
        //    //  var vm = await _mediator.Send(GetPartnerListQuery, PartnerListVm(query));
        //    var identity = User.Identity as ClaimsIdentity;
        //    int? userId;
        //    if (identity.RoleClaimType.Equals("manager"))
        //    {
        //        var nameidentifier = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //        int userid = 0;
        //        if (int.TryParse(nameidentifier, out userid))
        //            userId = userid;
        //    }
        //    //var command = _mapper.Map<Partner>(partnerDto);
        //    //var query = await _mediator.Send(command)
        //    return await _mediator.Send<GetPartnerListQuery, PartnerDto[]>(query);
        //}

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "admin, director, moderator, manager")]
        public async Task<ActionResult<PartnerDetailsVm>> Get(int id)
        {

            var query = new GetPartnerDetailsQuery
            {
                PartnerID = id
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]     
        public async Task<ActionResult> CreatePartnerCommand([FromBody]CreatePartnerDto createPartnerDto, int id)
        {
            var command =_mapper.Map<CreatePartnerCommand>(createPartnerDto);
            command.PartnerID = id;
            var partnerId = await _mediator.Send(command);
            return Ok(partnerId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePartnerCommand([FromBody]UpdatePartnerDto updatePartnerDto, int id)
        {
            var command = _mapper.Map<UpdatePartnerCommand>(updatePartnerDto);
            command.PartnerID = id;
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
