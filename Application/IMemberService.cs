
using System.Threading.Tasks;

namespace Application
{
    public interface IMemberService
    {
        Task<MemberDto> GetByIdAsync(int id);
    }
}
