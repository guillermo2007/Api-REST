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
            Id = default(Guid);
        }

        public EntityBase(Guid id)
        {
            Id = id;
        }        

        [Key]
        public Guid Id { get; set; }

        public void GenerateNewId() => Id = Guid.NewGuid();
    }
}
