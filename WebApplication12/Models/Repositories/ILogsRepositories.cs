using System.Threading.Tasks;
using System;
using WebApplication12.Models.DB;

namespace WebApplication12.Models.Repositories {
    public interface ILogsRepositories {
        Task AddLogs (Request request);
        Task<Request[]> GetLogs ();
    }
}
