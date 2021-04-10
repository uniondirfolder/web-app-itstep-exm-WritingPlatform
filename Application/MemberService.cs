using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application
{
    public class MemberService : IMemberService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public MemberService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<MemberDto> GetByIdAsync(int id)
        {
            var member = await _dbContext.Members
                .AsNoTracking()
                .Include(q => q.SystemStatus == Domain.Enums.SystemStatus.On)
                .Include(q => q.Stories).ThenInclude(q => q.Rating)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (null == member) throw new EntityNotFoundException();
            
            var dto = _mapper.Map<MemberDto>(member);
            foreach (var item in member.Stories)
            {
                dto.Rating += item.Rating.CurrentValue;
            }
            dto.Rating /= member.Stories.Count;

            return dto;
        }
    }
}
