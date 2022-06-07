using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookMyMovie.Models
{
    public class ShowTime
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }
        
        [Required]
        [MaxLength(50)]
        public double TicketPrice { get; set; }

        public long MovieId { get; set; }
    }
}
