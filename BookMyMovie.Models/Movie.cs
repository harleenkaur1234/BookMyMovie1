using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookMyMovie.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string MovieName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Director { get; set; }

        [Required]
        public string Actor { get; set; }

        [Required]
        [MaxLength(20)]
        public string Genre { get; set; }

        [DataType(DataType.Date)]

        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        [MaxLength(20)]
        public string Language { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime Duration { get; set; }
        public List<ShowTime> ShowTimes { get; set; }
    }
}
