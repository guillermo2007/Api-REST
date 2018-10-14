using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserModule
{
    public class UserProfile : Profile
    {
        public void Configure()
        {
            CreateMap<UserDto, UserDto>();
        }
    }
}
