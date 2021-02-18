using DataLayer.EntityModels;
using DataLayer.Repositories;
using FriendlyRS1.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendlyRS1.Repository.RepostorySetup
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public HobbyRepository hobby { get; set; }
        public HobbyCategoryRepository hobbyCategory { get; set; }
        public ApplicationUserHobbyRepository UserHobby { get; set; }
        public GroupChatRepository GroupChat { get; set; }
        public UserGroupChatRepository UserGroupChat { get; set; }
        public MessagesRepository Messages { get; set; }
        public AreaTagRepository AreaTags { get; set; }
        public UserRepository User { get; set; }
        public FeedbackRepository Feedback { get; set; }
        private GenderRepository GenderRepository;
        public GenderRepository Gender
        {
            get
            {
                if (this.GenderRepository == null)
                {
                    GenderRepository = new GenderRepository(context);
                }
                return GenderRepository;
            }
        }
        private CountryRepository CountryRepository;
        public CountryRepository Country
        {
            get
            {
                if (CountryRepository == null)
                {
                    CountryRepository = new CountryRepository(context);
                }
                return CountryRepository;
            }
        }
        private FriendshipStatusRepository FriendshipStatusRepository;
        public FriendshipStatusRepository FriendshipStatus
        {
            get
            {
                if(FriendshipStatusRepository == null)
                {
                    FriendshipStatusRepository = new FriendshipStatusRepository(context);
                }
                return FriendshipStatusRepository;
            }
        }

        // friendship
        private FriendshipRepository FriendshipRepository;
        public FriendshipRepository Friendship
        {
            get
            {
                if (this.FriendshipRepository == null)
                {
                    this.FriendshipRepository = new FriendshipRepository(context);
                }
                return FriendshipRepository;
            }
        }
        // city
        private CityRepository CityRepository;

        public CityRepository City
        {
            get
            {
                if (this.CityRepository == null)
                {
                    this.CityRepository = new CityRepository(context);
                }
                return CityRepository;
            }
        }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            hobby = new HobbyRepository(context);
            hobbyCategory = new HobbyCategoryRepository(context);
            User = new UserRepository(context);
            UserHobby = new ApplicationUserHobbyRepository(context);
            GroupChat = new GroupChatRepository(context);
            UserGroupChat = new UserGroupChatRepository(context);
            Messages = new MessagesRepository(context);
            AreaTags = new AreaTagRepository(context);
            Feedback = new FeedbackRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}
