using LojaVirtual.CartAPI.Data.ValueObjects;

namespace LojaVirtual.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode, string token);
    }
}
