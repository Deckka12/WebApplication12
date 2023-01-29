using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication12.Models.DB;
using WebApplication12.Models.Repositories;

namespace WebApplication12.Controllers {
    public class UsersController : Controller {
        private readonly IBlogRepository _repo;
      
       public UsersController(IBlogRepository repo)
       {
           _repo = repo;
       }
      
       public async Task <IActionResult> Index()
       {
           var authors = await _repo.GetUsers();
           return View(authors);
       }
        public async Task<IActionResult> Authors () {
            var authors = await _repo.GetUsers();
            return View(authors);
        }
        [HttpPost]
        public async Task<IActionResult> Register (User newUser) {
            await _repo.AddUser(newUser);
            return View(newUser);
        }
        [HttpGet]
        public IActionResult Register () {
            return View();
        }
    }
}
