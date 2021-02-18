//using MailKit.Security;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyRS1.Services
{
    public class EmailSenderOptions
    {
        public string SenderEmail { get; set; }

        public string SendGridName { get; set; }
        public string SendGridKey { get; set; }
    }
}
