using DTO.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserModule.Interfaces
{
    public interface IUserAppService
    {
        UserDto Get(Guid id);
        IEnumerable<UserDto> GetAll();
        UserDto Add(UserDto value);
        UserDto Update(UserDto value);
        void Delete(Guid id);
    }
}
