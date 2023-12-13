using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.Domain
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public string Mesazhi { get; set; }

        public Guid UserId { get; set; }

        public string Username { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
