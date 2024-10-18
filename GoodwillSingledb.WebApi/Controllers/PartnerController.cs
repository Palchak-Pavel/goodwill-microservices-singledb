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


        [HttpGet]
        // Необходимо создать дополнительный класс как GetPartnerListQuery для ролей?
        // Прописать в Program
        public async Task<ActionResult<PartnerListVm>> GetAll([FromQuery] GetPartnerListQuery query)
        {
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            if (identity.IsInRole(UserRoles.Manager))
                query.CuratorID = identity.GetUserID();
            if (identity.IsInRole(UserRoles.User))
                query.ContactID = identity.GetUserID();

            //var userid = User.Identity;
            //var query = new GetPartnerListQuery();
            var vm = await _mediator.Send(GetPartnerListQuery, PartnerListVm(query));
            //return Ok(vm);
            return Ok(vm);
        }

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
