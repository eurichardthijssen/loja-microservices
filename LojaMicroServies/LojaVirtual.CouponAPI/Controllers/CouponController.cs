using LojaVirtual.CouponAPI.Data.ValueObjects;
using LojaVirtual.CouponAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.CouponAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CouponController : Controller
    {
        
        private ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{couponCode}")]
        public async Task<ActionResult<CouponVO>> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _repository.GetCouponByCouponCode(couponCode);
            if (coupon == null) return NotFound();
            return Ok(coupon);
        }

    }
}
