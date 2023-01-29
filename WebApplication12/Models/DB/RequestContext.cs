using Microsoft.EntityFrameworkCore;

namespace WebApplication12.Models.DB {
    public class RequestContext : DbContext {

        public DbSet<Request> Requests { get; set; }


        // Логика взаимодействия с таблицами в БД
        public RequestContext (DbContextOptions<RequestContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
