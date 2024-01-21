using Backend_Project.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Backend_Project.ViewModels
{
    public class ProductUpdateVM
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        [Range(0, 3000)]
        public decimal NewPrice { get; set; }
        [Required]
        [Range(0, 3000)]
        public decimal OldPrice { get; set; }
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        [Required]
        public string Offer { get; set; } = null!;
        [Required]
        public string SKU { get; set; } = null!;
        [Required]
        public ICollection<IFormFile> Photo { get; set; } = null!;
        [ValidateNever]
        public ICollection<Category> Categories { get; set; } = null!;
        [ValidateNever]
        public ICollection<Information> Informations { get; set; } = null!;
        [Required]
        [Display(Name = "Informations")]
        public ICollection<int> InformationIds { get; set; } = null!;
        [Required]
        [Display(Name = "Categories")]
        public ICollection<int> CategoryIds { get; set; } = null!;
        [Required]
        public List<int> ImagesIds { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
    }
}
