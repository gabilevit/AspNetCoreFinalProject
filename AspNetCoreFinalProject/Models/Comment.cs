using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFinalProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Info  { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
