

using AutoMapper;
using DataAccess.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace UseCases.Member.Commands
{
    public class CreateMemberCommandHendler : IRequestHandler<CreateMemberCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;
        public CreateMemberCommandHendler(IMapper mapper, IDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateMemberCommand command, CancellationToken cancellationToken) 
        {
            var member = _mapper.Map<Domain.Entities.Member>(command.Dto);
            _dbContext.Members.Add(member);
            await _dbContext.SaveChangesAsync();
            return member.Id;
        }
    }
}
