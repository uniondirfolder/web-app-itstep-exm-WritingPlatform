using Application;
using AutoMapper;
using DataAccess.Interfaces;
using DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Member.Queries.GetById
{
    public class GetMemberByIdQueryHendler : IRequestHandler<GetMemberByIdQuery, MemberDto>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;
        private readonly IMemberAnemicService _memberAnemicService;
        public GetMemberByIdQueryHendler(IMapper mapper, IDbContext dbContext, IMemberAnemicService memberAnemicService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _memberAnemicService = memberAnemicService;
        }
        public async Task<MemberDto> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {

            var member = await _dbContext.Members
                .AsNoTracking()
                .Include(q => q.SystemStatus == Domain.Enums.SystemStatus.On)
                .Include(q => q.Stories).ThenInclude(q => q.Rating)
                .FirstOrDefaultAsync(q => q.Id == request.Id);

            if (null == member) throw new EntityNotFoundException();

            var dto = _mapper.Map<MemberDto>(member);

            //dto.Rating = member.GetRating(); //Rich-model
            dto.Rating = _memberAnemicService.GetRating(member);//Anemic-model

            return dto;
        }
    }
}
