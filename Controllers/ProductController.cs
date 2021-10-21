using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Data;
using Products.Dto;
using Products.Models;
using Products.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApiRepo _productApiRepo;
        private readonly IMapper _mapper;
        public ProductController(IProductApiRepo productApiRepo,IMapper mapper)
        {
            _productApiRepo = productApiRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreatedDto productCreatedDto)
        {
            var productModel = _mapper.Map<Product>(productCreatedDto);
            await _productApiRepo.CreateProduct(productModel);
            await _productApiRepo.SaveChangesAsync();
            var productReadDto = _mapper.Map<ProductReadDto>(productModel);
            return Created("",productReadDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var products = await _productApiRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _productApiRepo.GetById(id);
            return Ok(_mapper.Map<ProductReadDto>(products));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,ProductUpdateDto product)
        {
            /* _productApiRepo.UpdateProduct(id, product);
             await  _productApiRepo.SaveChangesAsync();
             return NoContent();*/
            Product demomodel = await _productApiRepo.GetById(id);
            if (demomodel == null)
            {
                return NotFound();
            }
            _mapper.Map(product, demomodel);
            await _productApiRepo.UpdateProduct(demomodel);
            await _productApiRepo.SaveChangesAsync();

            return NoContent();
        }
    }
}
