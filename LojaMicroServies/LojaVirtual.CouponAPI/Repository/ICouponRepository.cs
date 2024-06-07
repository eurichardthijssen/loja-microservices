using LojaVirtual.CouponAPI.Data.ValueObjects;

namespace LojaVirtual.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode);
    }
}
