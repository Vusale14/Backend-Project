using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Backend_Project.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Offer { get; set; } = null!;
        public string URL { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string BgImage { get; set; } = null!;
    }
}
