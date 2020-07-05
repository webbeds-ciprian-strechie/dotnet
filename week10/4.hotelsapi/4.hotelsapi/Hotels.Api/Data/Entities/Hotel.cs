using System.Collections.Generic;

namespace Hotels.Api.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Hotel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }
    }
}
