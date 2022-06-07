using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyMovie.Models
{
    public class Booking
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
    }
}
