using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyMovie.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [MaxLength(30)]
        public string CinemaName { get; set; }

        [MaxLength(30)]
        public string Location { get; set; }
    }
}
