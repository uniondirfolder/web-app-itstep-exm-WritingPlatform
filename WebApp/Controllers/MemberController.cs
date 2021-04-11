using Application;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("{id}")]
        public async Task<MemberDto> Get(int id) 
        {
            var result = await _memberService.GetByIdAsync(id);
            return result;
        }

        [HttpPost]
        public async Task<int>Create([FromBody] CreateMemberDto dto) 
        {
            var id = await _memberService.CreateMemberAsync(dto);
            return id;
        }
    }
}
