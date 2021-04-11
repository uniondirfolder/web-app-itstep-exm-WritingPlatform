using Application;
using AutoMapper;
using DataAccess.Interfaces;
using Delivery.Interfaces;
using DomainServices.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Member.Queries.GetById
{
    public class GetMemberByIdQueryHendler : IRequestHandler<GetMemberByIdQuery, MemberDto>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;
        private readonly IMemberAnemicService _memberAnemicService;
        private readonly IDeliveryNService _deliveryNService;
        public GetMemberByIdQueryHendler(IMapper mapper, IDbContext dbContext, IMemberAnemicService memberAnemicService, IDeliveryNService deliveryNService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _memberAnemicService = memberAnemicService;
            _deliveryNService = deliveryNService;
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
            dto.Rating = _memberAnemicService.GetRating(member, _deliveryNService.SomethingGood);//Anemic-model

            return dto;
        }
    }
}
