using Backend_Project.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Project.ViewModels
{
    public class ProductCreateVM
    {
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public IFormFile Image { get; set; } = null!;
        [Required]
        [Range(0, 3000)]
        public decimal OldPrice { get; set; }
        [Required]
        [Range(0, 3000)]
        public decimal NewPrice { get; set; }
        [Required]
        public string Offer { get; set; } = null!;
        [Required]
        public string SKU { get; set; } = null!;
        [Required]
        [ValidateNever]
        public ICollection<Category> Categories { get; set; }
        [Required]
        [ValidateNever]
        public ICollection<Information> Informations { get; set; }
        [Required]
        public ICollection<int> InformationIds { get; set; } = null!;
        [NotMapped]
        public ICollection<IFormFile> Photo { get; set; } = null!;
        [Required]
        public ICollection<int> CategoryIds { get; set; } = null!;
    }
}
