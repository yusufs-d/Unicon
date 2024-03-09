using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unicon.Data
{
    public class Entity
    {
        [Key]
        public int EntityId { get; set; }

        public string? EntityName {get; set; }
    }
}