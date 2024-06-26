﻿using AutoMapper;
using LojaVirtual.ProductAPI.Data.ValueObjects;
using LojaVirtual.ProductAPI.Model;

namespace LojaVirtual.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });

            return mappingConfig;
        }
    }
}
