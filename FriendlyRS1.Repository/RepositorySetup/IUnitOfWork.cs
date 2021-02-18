using DataLayer.Repositories;
using FriendlyRS1.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendlyRS1.Repository.RepostorySetup
{
    public interface IUnitOfWork
    {
        public HobbyRepository hobby { get; set; }
        public HobbyCategoryRepository hobbyCategory { get; set; }
        public UserRepository User { get; set; }
        public GenderRepository Gender { get; }
        public CountryRepository Country { get; }
        public FriendshipRepository Friendship { get; }
        public CityRepository City { get; }
        public FriendshipStatusRepository FriendshipStatus { get; }
        public ApplicationUserHobbyRepository UserHobby { get; set; }
        public GroupChatRepository GroupChat { get; set; }
        public UserGroupChatRepository UserGroupChat { get; set; }
        public MessagesRepository Messages { get; set; }
        public AreaTagRepository AreaTags { get; set; }
        public FeedbackRepository Feedback { get; set; }
        int Complete();
    }
}
