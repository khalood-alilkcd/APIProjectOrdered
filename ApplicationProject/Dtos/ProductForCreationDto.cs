
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationProject.Dtos
{
    public class ProductForCreationDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product picture URL is required")]
        public string PictureUrl { get; set; }

        [Required(ErrorMessage = "Product brand is required")]
        public string ProductBrand { get; set; }

        [Required(ErrorMessage = "Product type is required")]
        public string ProductType { get; set; }

        [Required(ErrorMessage = "Product availability status is required")]
        public bool Avaraible { get; set; }
    }
}
