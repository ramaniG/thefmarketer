using System;
using System.ComponentModel.DataAnnotations;

namespace thefmarketer.Models
{
    public class BaseModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime Modified { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
