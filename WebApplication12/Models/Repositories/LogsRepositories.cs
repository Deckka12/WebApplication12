using System.Threading.Tasks;
using System;
using WebApplication12.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication12.Models.Repositories {
    public class LogsRepositories : ILogsRepositories {
        private readonly RequestContext _context;

        public LogsRepositories (RequestContext context ) {
            _context = context;
        }
        public async Task AddLogs (Request request) {
            request.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(request);
            if(entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);
            // Сохранение изенений
            await _context.SaveChangesAsync();
        }
        public async Task<Request[]> GetLogs () {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
