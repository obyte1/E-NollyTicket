using NollyTickets.Ng.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace NollyTickets.Ng.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Cinema logo is required")]
        [Display(Name = "Cinema Logo")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Cinema Name is required")]
        [Display(Name = "Cinema Name")]
        public string Name{ get; set; }

        [Required(ErrorMessage = "Cinema Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }


        /// <summary>
        /// Defining the entity relationship one -> many
        //  Cinema has ONE -> MANY relationship with the movie because,
        /// a Movie can be purchased from a single cinema, but a cinema can have multiple movies
        /// </summary>
        public ICollection<Movie> Movies { get; set; }
      
    }
}

