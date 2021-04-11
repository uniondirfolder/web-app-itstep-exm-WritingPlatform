
using Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UseCases.Member.Commands;
using UseCases.Member.Queries.GetById;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : Controller
    {
        //private readonly IMemberService _memberService;

        //public MemberController(IMemberService memberService)
        //{
        //    _memberService = memberService;
        //}

        private readonly ISender _sender;

        public MemberController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<MemberDto> Get(int id) 
        {
            //var result = await _memberService.GetByIdAsync(id);
            var result = await _sender.Send(new GetMemberByIdQuery { Id = id });
            return result;
        }

        [HttpPost]
        public async Task<int>Create([FromBody] CreateMemberDto dto) 
        {
            //var id = await _memberService.CreateMemberAsync(dto);
            var id = await _sender.Send(new CreateMemberCommand { Dto = dto });
            return id;
        }
    }
}
