using NollyTickets.Ng.Data.Base;
using NollyTickets.Ng.Data.Enums;
using NollyTickets.Ng.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NollyTickets.Ng.Models
{
    public class Movie:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double  Price { get; set; }

        public string ImageURL{ get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        //Defining relationships
        //Actor MANY -> MANY Relationship
        public ICollection<Actor_Movie> Actor_Movies { get; set; }

        //Cinema One -> Many Relationship
        //The cinema foreign key
        //Cinema
        //The one to many relationship between the cinema and the movie
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        // //The one to many relationship between the producer and the movie
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

       

    }
}
//Entity relationship
//Cinema has ONE -> MANY relationship with the movie because. a Movie can be purchased from a single cinema, but a cinema can have multiple movies
//Producer has ONE -> MANY relationship with the movie because. a Movie has one producer, but a producer can produce multiple movies
//Actors has MANY -> MANY relationship with the movie because. an actor can act many movies, and a movie can have multiple actors
//Note  MANY -> MANY Relationship introduces join model or tables into our database





