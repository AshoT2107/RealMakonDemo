using AutoMapper;
using Products.Dto;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreatedDto,Product>();

            CreateMap<Product, ProductReadDto>();

            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
