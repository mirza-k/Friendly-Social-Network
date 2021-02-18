using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.EntityModels;
using FriendlyRS1.Repository.RepostorySetup;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FriendlyRS1.Controllers
{
    public class FeedController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMemoryCache memoryCache;
        public FeedController(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _userManager = userManager;
            this.memoryCache = memoryCache;
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        // uzme sve usere iz baze i predlozi ih u feed
        // samo za test :)
        public async Task<IActionResult> FriendSuggestion()
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            var a = unitOfWork.User.GetAll();

            var users = _userManager.Users.Where(u => u.Id != applicationUser.Id).Select(x => new ApplicationUser {
                Id = x.Id,
                City = x.City,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ProfileImage = x.ProfileImage
            }).ToList();


            return View(users);
        }
    }
}
