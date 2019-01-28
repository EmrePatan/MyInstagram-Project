using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataAccessLayer.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Story> Story { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Followers> Followers { get; set; }
        public DbSet<Following> Following { get; set; }
        public DbSet<Likes> Likes { get; set; }
    }
}