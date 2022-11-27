using NollyTickets.Ng.Data.Base;
using NollyTickets.Ng.Data.Enums;
using NollyTickets.Ng.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NollyTickets.Ng.Models
{
    public class NewMovieVM 
    {
        public int Id { get; set; }

        [Display(Name = "Movie name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster URL is required")]

        public string ImageURL { get; set; }


        [Display(Name = " Movie Start date")]
        [Required(ErrorMessage = "Start date required")]
        public DateTime StartDate { get; set; }

        [Display(Name =  "Movie End date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }


        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Move category is required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Select Actor(s)")]
        [Required(ErrorMessage = "Actor(s) is required")]
        public ICollection<int> ActorsIds { get; set; }
        [Display(Name = "Select Cinema")]
        [Required(ErrorMessage = "Movie cinema is required")]
        public int CinemaId { get; set; }
        [Display(Name = "Select Producer")]
        [Required(ErrorMessage = "Movie Producer is Required")]
        public int ProducerId { get; set; }
     



    }
}
//Entity relationship
//Cinema has ONE -> MANY relationship with the movie because. a Movie can be purchased from a single cinema, but a cinema can have multiple movies
//Producer has ONE -> MANY relationship with the movie because. a Movie has one producer, but a producer can produce multiple movies
//Actors has MANY -> MANY relationship with the movie because. an actor can act many movies, and a movie can have multiple actors
//Note  MANY -> MANY Relationship introduces join model or tables into our database





