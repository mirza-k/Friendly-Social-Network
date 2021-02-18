using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.EntityModels;
using FriendlyRS1.Repository;
using FriendlyRS1.Repository.RepostorySetup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendlyRS1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ApplicationDbContext context;

        public IActionResult Index()
        {
            return View();
        }

        public AdminController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            this.unitOfWork = unitOfWork;
            this.context = context;
        }

        public IActionResult DisplayFeedback()
        {
            List<Feedback> feedbacks = unitOfWork.Feedback.GetSelect(X => X.AdminRead == false, new string[] { "AreaTag", "User" }).ToList();
            ViewData["Feedbacks"] = feedbacks;

            return View();
        }

        public IActionResult AdminRead(int id)
        {
            if (id != -1)
            {
                Feedback f = unitOfWork.Feedback.Get(x => x.Id == id);
                f.AdminRead = true;
                unitOfWork.Complete();
            }

            List<Feedback> feedbacks = unitOfWork.Feedback.GetSelect(x => x.AdminRead == false, new string[] { "AreaTag", "User" }).ToList();
            ViewData["Feedbacks"] = feedbacks;

            return PartialView();
        }

        public IActionResult ReadFeedbacks()
        {
            List<Feedback> feedbacks = unitOfWork.Feedback.GetSelect(x => x.AdminRead == true, new string[] { "AreaTag", "User" }).ToList();
            ViewData["ReadFeedbacks"] = feedbacks;

            return PartialView();
        }

        public IActionResult DeleteFeedback(int id)
        {
            Feedback f = unitOfWork.Feedback.Get(x => x.Id == id);
            context.Feedbacks.Remove(f);
            context.SaveChanges();

            return RedirectToAction("ReadFeedbacks");
        }
    }
}
