using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebApplication12.Models.DB;

namespace WebApplication12.Models.Repositories {
    public class BlogRepository : IBlogRepository {
        private readonly BlogContext _context;

        
        public BlogRepository (BlogContext context) {
            _context = context;
        }
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddUser (User user) {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(user);
            if(entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Вывод всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<User[]> GetUsers () {
            return await _context.Users.ToArrayAsync();
        }
    }
}
