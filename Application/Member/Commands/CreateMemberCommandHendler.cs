
using AutoMapper;
using DataAccess.Interfaces;
using Email.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Interfaces;

namespace UseCases.Member.Commands
{
    public class CreateMemberCommandHendler : IRequestHandler<CreateMemberCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;
        private readonly IBackgroundJobService _backgroundJobService;
        private readonly ICurrentUserService _currentUserService;
        public CreateMemberCommandHendler(IMapper mapper, IDbContext dbContext, IBackgroundJobService backgroundJobService, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _backgroundJobService = backgroundJobService;
            _currentUserService = currentUserService;
        }
        public async Task<int> Handle(CreateMemberCommand command, CancellationToken cancellationToken) 
        {
            var member = _mapper.Map<Domain.Entities.Member>(command.Dto);
            _dbContext.Members.Add(member);
            await _dbContext.SaveChangesAsync();

            _backgroundJobService.Schedule<IEmailService>(e => e.SendAsync(_currentUserService.Email, "Any", $"{member.Id}"));

            return member.Id;
        }
    }
}
