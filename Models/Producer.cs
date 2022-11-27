using NollyTickets.Ng.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace NollyTickets.Ng.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile picture is required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]

        public string FullName { get; set; }
        [Required(ErrorMessage = "Biography is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FullNAme must be between 3 and 50 chars")]
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        //defining the entity relationship(one -> many)
        //Producer has ONE -> MANY relationship with the movie because. a Movie has one producer, but a producer can produce multiple movies
        public ICollection<Movie> Movies { get; set; }
        
    }
}

