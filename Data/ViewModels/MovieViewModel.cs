using eTicket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTicket.Models
{
    public class MovieViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public MovieCategory MovieCategory { get; set; }
        [Required]
        public List<int> ActorIds { get; set; }
        [Required]
        public int CinemaId { get; set; }
        [Required]
        public int ProducerId { get; set; }
        
    }
}
