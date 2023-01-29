using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication12.Models;
using WebApplication12.Models.DB;
using WebApplication12.Models.Repositories;

namespace WebApplication12.Controllers {
    public class RequestController :Controller{
        private readonly ILogsRepositories _repo;
        private readonly ILogger<RequestController> _logger;

        // Также добавим инициализацию в конструктор
        public RequestController (ILogger<RequestController> logger, ILogsRepositories repo) {
            _logger = logger;
            _repo = repo;
        }
        public async Task<IActionResult> Index () {
            var authors = await _repo.GetLogs();
            return View(authors);
        }
        [HttpPost]
        public async Task<IActionResult> Log (Request request) {
            request.Date = DateTime.Now;
            request.Url = " ";
            await _repo.AddLogs(request);
            return View(request);
        }
        [HttpGet]
        public IActionResult Log () {
            return View();
        }
    }
}
