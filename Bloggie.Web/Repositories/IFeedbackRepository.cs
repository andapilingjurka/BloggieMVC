using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllAsync();

        Task<Feedback> AddAsync(Feedback feedback);

        Task<Feedback?> DeleteAsync(int id);
    }
}
