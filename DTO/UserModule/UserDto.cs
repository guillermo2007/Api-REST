using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserModule
{
    public class UserDto
    {
        public UserDto()
        {
            Id = default(Guid);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
