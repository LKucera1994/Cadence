using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        [ValidateNever]
        public int ProductTypeId { get; set; }
        [ForeignKey(nameof(ProductTypeId))]
        public ProductType ProductType { get; set; }
        [ValidateNever]
        public int ProductBrandId { get; set; }
        [ForeignKey(nameof(ProductBrandId))]
        public ProductBrand ProductBrand { get; set; }
    }
}
