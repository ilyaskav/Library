using System;
using System.ComponentModel.DataAnnotations;

namespace Business.ViewModels
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
