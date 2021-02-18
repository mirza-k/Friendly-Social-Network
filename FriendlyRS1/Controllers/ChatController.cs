using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataLayer.EntityModels;
using FriendlyRS1.Repository.RepostorySetup;
using FriendlyRS1.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FriendlyRS1.Controllers
{
    public class ChatController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public ChatController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            List<GroupChat> groupChats = unitOfWork.GroupChat.GetAll().ToList();

            return View(groupChats);
        }
        public async Task<IActionResult> Get(int id)
        {
            GroupChat groupChat = unitOfWork.GroupChat.Get(x => x.Id == id, new string[] { "Creator" });
            List<ApplicationUserGroupChat> participants = unitOfWork.UserGroupChat.GetSelect(x => x.GroupId == id, new string[] { "User", "Group" }).ToList();
            ApplicationUser user = await userManager.GetUserAsync(User);
            List<Message> messages = unitOfWork.Messages.GetSelect(x => x.GroupChatId == groupChat.Id, new string[] { "GroupChat", "Sender" }).ToList();

            GroupChatVM groupChatVM = new GroupChatVM
            {
                groupChat = groupChat,
                User = user,
                Participants = participants,
                Messages = messages
            };

            return View(groupChatVM);
        }
    }
}
