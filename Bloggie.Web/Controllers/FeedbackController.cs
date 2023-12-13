using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository feedbackRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        //  [Authorize(Roles = "User")]

        public FeedbackController(IFeedbackRepository feedbackRepository,
            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.feedbackRepository = feedbackRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "User")]

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddFeedbackRequest addKontaktRequest)
        {

            if (signInManager.IsSignedIn(User))
            {
                var userId = (userManager.GetUserName(User));
                var domainModel = new Feedback
                {
                    Mesazhi = addKontaktRequest.Mesazhi,
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    Username = userId,
                    DateAdded = DateTime.Now
                };

                await feedbackRepository.AddAsync(domainModel);
                return RedirectToAction("List");

            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            //use db context to read the tags

            var tags = await feedbackRepository.GetAllAsync();

            return View(tags);
        }


        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(Feedback feedback)
        {
            var deletedTag = await feedbackRepository.DeleteAsync(feedback.Id);

            if (deletedTag != null)
            {
                //show success notification
                return RedirectToAction("List");
            }
            //Show error notification
            return RedirectToAction("Add");

        }
    }
}
