using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApplication12.Models.DB {
    public class Request {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
