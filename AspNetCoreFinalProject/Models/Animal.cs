using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFinalProject.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot have more then 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers are valid")]
        public int Age { get; set; }
        public string Picturename { get; set; }
        [Required]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
