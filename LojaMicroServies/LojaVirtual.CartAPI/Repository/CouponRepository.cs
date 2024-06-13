using LojaVirtual.CartAPI.Data.ValueObjects;
using System.Net.Http.Headers;
using System.Net;
using System.Text.Json;

namespace LojaVirtual.CartAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {

        private readonly HttpClient _context;


        public CouponRepository(HttpClient context)
        {
            _context = context;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode, string token)
        {

            //Coupon
            _context.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _context.GetAsync($"/Coupon/{couponCode}");
            var content = await response.Content.ReadAsStringAsync();
            
            if (response.StatusCode != HttpStatusCode.OK) return new CouponVO();

            return JsonSerializer.Deserialize<CouponVO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
