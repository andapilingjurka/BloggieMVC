namespace Bloggie.Web.Models.ViewModels
{
    public class AddFeedbackRequest
    {
        public string Mesazhi { get; set; }
        public DateTime DateAdded { get; set; }

        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
}
