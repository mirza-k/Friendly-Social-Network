using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FriendlyRS1.Repository;
using DataLayer.EntityModels;

namespace FriendlyRS1.Hubs
{
    public class ChatHub : Hub
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public ChatHub(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task SendMessage(string username, string message, int chatId, int userId)
        {
            var user = context.Users.Find(userId);
            var userImg = Convert.ToBase64String(user.ProfileImage);
            //save message to db
            Message msg = new Message()
            {
                Created = DateTime.Now,
                Text = message,
                GroupChatId = chatId,
                SenderId = userId
            };
            context.Messages.Add(msg);
            context.SaveChanges();


            await Clients.All.SendAsync("RecieveMessage", username, message, userId, userImg);
        }
    }
}
