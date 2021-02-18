using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EntityModels
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public int SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public int GroupChatId { get; set; }
        public GroupChat GroupChat { get; set; }
    }
}
