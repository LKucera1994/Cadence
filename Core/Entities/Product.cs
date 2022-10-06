using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product
    {
       [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public string PhotoUrl { get; set; }

        public ProductType ProductType { get; set; }
        [ForeignKey(nameof(ProductTypeId))]
        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }
        [ForeignKey(nameof(ProductBrandId))]
        public int ProductBrandId { get; set; }


    }
}
