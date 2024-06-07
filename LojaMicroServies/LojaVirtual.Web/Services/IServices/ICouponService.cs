using LojaVirtual.Web.Models;

namespace LojaVirtual.Web.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCoupon(string code, string token);
    
    }
}
