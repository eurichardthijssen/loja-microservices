using AutoMapper;
using LojaVirtual.CouponAPI.Data.ValueObjects;
using LojaVirtual.CouponAPI.Model;

namespace LojaVirtual.CouponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponVO,Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
