using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Queste.Models
{
    public class UserContext:DbContext
    {
        public DbSet<Quest> Quests { get; set; }
        public DbSet<TypeOfQuest> TypeOfQuest { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}