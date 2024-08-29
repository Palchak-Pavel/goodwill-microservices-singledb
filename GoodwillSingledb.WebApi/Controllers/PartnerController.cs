using AutoMapper;
using GoodwillSingledb.Application.Goodwills.Commands.Partners.Queries.GetPartnerDetails;
using Microsoft.AspNetCore.Mvc;

namespace GoodwillSingledb.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PartnerController : BaseController
    {
        private readonly IMapper _mapper;

        //public NoteController(IMapper mapper) => _mapper = mapper;

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
    }
}
