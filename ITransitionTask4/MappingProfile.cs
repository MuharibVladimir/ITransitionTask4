using AutoMapper;
using ITransitionTask4.DataTransferObjects;
using ITransitionTask4.Entities.Models;
using System;

namespace ITransitionTask4
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(dest =>
                    dest.UserName,
                    opt => opt.MapFrom(src => src.Email));

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<UserForAuthenticationDto, User>();
        }
    }
}
