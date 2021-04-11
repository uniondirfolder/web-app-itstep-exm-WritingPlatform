
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public interface IMemberService
    {
        Task<MemberDto> GetByIdAsync(int id);

        Task<int> CreateMemberAsync(CreateMemberDto dto);
    }

   
}
