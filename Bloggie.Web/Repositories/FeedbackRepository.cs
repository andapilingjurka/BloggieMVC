using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class FeedbackRepository:IFeedbackRepository

    {
        private readonly BloggieDbContext bloggieDbContext;

        public FeedbackRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<Feedback> AddAsync(Feedback feedback)
        {
            await bloggieDbContext.AddAsync(feedback);
            await bloggieDbContext.SaveChangesAsync();
            return feedback;

        }

        public async Task<Feedback?> DeleteAsync(int id)
        {
            var existingTag = await bloggieDbContext.Feedbacks.FindAsync(id);

            if (existingTag != null)
            {
                bloggieDbContext.Feedbacks.Remove(existingTag); //kjo ska version async
                await bloggieDbContext.SaveChangesAsync();

                //Show success notification

                return existingTag;

            }
            return null;
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await bloggieDbContext.Feedbacks.ToListAsync();
        }

    }
}
