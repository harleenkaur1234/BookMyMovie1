using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyMovie.ViewModels
{
    public class MovieGenreViewModel
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Actor { get; set; }
    }
}
