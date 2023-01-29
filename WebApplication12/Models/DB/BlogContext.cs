using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApplication12.Models.DB {
    public class BlogContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        /// Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; }

        // Логика взаимодействия с таблицами в БД
        public BlogContext (DbContextOptions<BlogContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
