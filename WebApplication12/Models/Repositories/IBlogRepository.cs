using System;
using System.Threading.Tasks;
using WebApplication12.Models.DB;

namespace WebApplication12.Models.Repositories {
    public interface IBlogRepository {
        Task AddUser (User user);
        Task<User[]> GetUsers ();

    }
}
