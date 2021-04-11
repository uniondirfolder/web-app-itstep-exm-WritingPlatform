﻿using AutoMapper;
using DataAccess;
using DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application
{
    public class MemberService : IMemberService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMemberAnemicService _memberRichService;
        public MemberService(AppDbContext dbContext, IMapper mapper, IMemberAnemicService memberRichService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _memberRichService = memberRichService;
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

            //dto.Rating = member.GetRating();
            dto.Rating = _memberRichService.GetRating(member);

            return dto;
        }
    }
}
