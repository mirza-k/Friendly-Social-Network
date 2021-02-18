using DataLayer.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendlyRS1.Repository
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserHobby>().HasKey(x => new {x.HobbyId,x.ApplicationUserId});
            modelBuilder.Entity<ApplicationUserGroupChat>().HasKey(x => new { x.GroupId, x.UserId });
        }

        public DbSet<Hobby> Hobby { get; set; }
        public DbSet<HobbyCategory> HobbyCategory { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<FriendshipStatus> FriendshipStatus { get; set; }
        public DbSet<Friendship> Friendship { get; set; }
        public DbSet<ApplicationUserHobby> ApplicationUserHobbies { get; set; }
        public DbSet<GroupChat> GroupChat { get; set; }
        public DbSet<ApplicationUserGroupChat> ApplicationUserGroupChat { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AreaTag> AreaTags { get; set; }
        public DbSet<Feedback> Feedbacks{ get; set; }
    }
}
