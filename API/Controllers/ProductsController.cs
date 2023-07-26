
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Entities.DTOs;
using Infrastructure.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public  async Task<ActionResult<Pagination<IEnumerable<ProductDTO>>>> GetAllProducts([FromQuery]ProductParams productParams)
        {
            var sortParam = String.IsNullOrEmpty(productParams.SortOrder) ? "" :
                            productParams.SortOrder == "priceAsc"? "priceAsc" :
                            productParams.SortOrder == "priceDesc" ? "priceDesc": 
                            "nameDesc";

            var products = await _unitOfWork.Product.GetAll(x=> 
                                                            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                                                            (!productParams.BrandId.HasValue ||x.ProductBrandId== productParams.BrandId) &&
                                                            (!productParams.TypeId.HasValue || x.ProductTypeId== productParams.TypeId), 
                                                            includeProperties: "ProductBrand,ProductType");

            //sorting
            switch (sortParam)
            {
                case "nameDesc":
                    products = products.OrderByDescending(x => x.Name);
                    break;
                case "priceAsc":
                    products = products.OrderBy(x => x.Price);
                    break;
                case "priceDesc":
                    products = products.OrderByDescending(x => x.Price);
                    break;
                default: 
                    products = products.OrderBy(x => x.Name);
                    break;
            }

            //Pagination
            int productCount = products.Count();
            products = products.Skip(productParams.PageSize*(productParams.PageIndex-1)).Take(productParams.PageSize);
            

            
            
            //Mapping to DTO
            var mappedProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(new Pagination<ProductDTO>(productParams.PageIndex, productParams.PageSize, productCount, mappedProducts));


                
                
            
            

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id, includeProperties: "ProductBrand,ProductType");

            if(product != null)
            {
                return _mapper.Map<Product,ProductDTO>(product);
            }

            return NotFound();
            
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var brands = await _unitOfWork.ProductBrand.GetAll();
            return Ok(brands) ;
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {
            var types = await _unitOfWork.ProductType.GetAll();
            return Ok(types);
        }




    }
}
