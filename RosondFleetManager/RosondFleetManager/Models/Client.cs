using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosondFleetManager.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact Info is required")]
        public string ContactInfo { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
