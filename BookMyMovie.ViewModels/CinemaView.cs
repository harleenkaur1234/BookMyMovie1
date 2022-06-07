using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyMovie.ViewModels
{
    public class CinemaView
    {
        [Required]
        public string CinemaName { get; set; }

        [Required]
        public string Location { get; set; }
        public List<TheaterView> Theaters { get; set; } = new List<TheaterView>();
    }
}
