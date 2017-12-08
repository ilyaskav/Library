using System;
using System.ComponentModel.DataAnnotations;

namespace Business.ViewModels
{
    public class AuthorModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
