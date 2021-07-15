using System;
using System.ComponentModel.DataAnnotations;

namespace EspAPI.Models
{
    public class Todo : IEntity
    {
        [Required]
        public string Name {get; set;}

        public bool Completed {get; set;}
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}