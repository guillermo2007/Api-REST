using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserModule.Aggregates
{
    public class User : EntityBase
    {
        public User() : base()
        {

        }

        public User(string name, DateTime birthdate) : base()
        {
            Name = name;
            Birthdate = birthdate;
        }

        public User(Guid id, string name, DateTime birthdate) : base (id)
        {
            Name = name;
            Birthdate = birthdate;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthdate {get;set;}
    }
}
