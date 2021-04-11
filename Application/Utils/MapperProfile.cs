
using AutoMapper;
using Domain.Entities;

namespace Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Member, MemberDto>();
            CreateMap<CreateMemberDto, Member>();
            CreateMap<MemberStoryDto, MemberStory>();
        }
    }
}
