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
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public List<ShowTimeView> ShowTimes { get; set; }
    }
}
