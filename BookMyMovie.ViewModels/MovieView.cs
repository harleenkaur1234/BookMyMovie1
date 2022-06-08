using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookMyMovie.ViewModels
{
    public class MovieView
    {
        [Required]
        public string MovieName { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Actor { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Duration { get; set; }
        public List<ShowTimeView> ShowTimes { get; set; }
    }
}
