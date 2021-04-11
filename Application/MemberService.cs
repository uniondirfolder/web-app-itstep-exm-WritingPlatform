using AutoMapper;
using DataAccess;
using DataAccess.Interfaces;
using Domain.Entities;
using DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application
{
    public class MemberService : IMemberService
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMemberAnemicService _memberAnemicService;
        public MemberService(IDbContext dbContext, IMapper mapper, IMemberAnemicService memberAnemicService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _memberAnemicService = memberAnemicService;
        }

        public async Task<int> CreateMemberAsync(CreateMemberDto dto)
        {
            var member = _mapper.Map<Member>(dto);
            _dbContext.Members.Add(member);
            await _dbContext.SaveChangesAsync();
            return member.Id;
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

            //dto.Rating = member.GetRating(); //Rich-model
            dto.Rating = _memberAnemicService.GetRating(member);//Anemic-model

            return dto;
        }
    }
}
