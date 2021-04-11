

using Application;
using MediatR;

namespace UseCases.Member.Commands
{
    public class CreateMemberCommand : IRequest<int>
    {
        public CreateMemberDto Dto { get; set; }
    }
}
