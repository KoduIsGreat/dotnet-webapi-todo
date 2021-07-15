using System;
namespace EspAPI.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }

        DateTime ModifiedOn { get; set; }
    }
}