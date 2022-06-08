using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookMyMovie.ViewModels
{
    public class ActorByMovieName
    {
        [Required]
        public string Actor { get; set; }
    }
}
