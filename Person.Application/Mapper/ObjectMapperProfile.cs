using AutoMapper;
using Person.Application.Base;
using Person.Application.Commands.User.Create;
using Person.Application.Commands.User.Update;
using Person.Application.Responses;
using Person.Core.Entities;
using Person.Core.Entities.Base;

namespace Person.Application.Mapper
{
    internal class ObjectMapperProfile : Profile
    {
        public ObjectMapperProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<Entity<int>, EntityDto<int>>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<UserResponse, UpdateUserCommand>().ReverseMap();
        }
    }
}