using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = default(int);
        }

        public EntityBase(int id)
        {
            Id = id;
        }

        [Key]
        public int Id { get; set; }
    }
}
