using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyMovie.ViewModels
{
    public class MovieNameView
    {
        
        [Required]
        [MaxLength(70)]

        public string MovieName { get; set; }
    }
}
