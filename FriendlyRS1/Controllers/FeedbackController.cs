using DataLayer.EntityModels;
using FriendlyRS1.Repository.RepostorySetup;
using FriendlyRS1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyRS1.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IUnitOfWork unitOfWOrk;
        private readonly UserManager<ApplicationUser> userManager;

        public FeedbackController(IUnitOfWork unitOfWOrk, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWOrk = unitOfWOrk;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeedbackVM input)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.GetUserAsync(User);

                Feedback obj = new Feedback()
                {
                    Details = input.Details,
                    AreaTagId = input.areaTagId,
                    CreatedDate = DateTime.Now,
                    UserId = user.Id,
                    AdminRead = false
                };

                unitOfWOrk.Feedback.Add(obj);
                unitOfWOrk.Complete();

                TempData["feedbackError"] = "success";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["feedbackError"] = "Area tags and details are required.";
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
