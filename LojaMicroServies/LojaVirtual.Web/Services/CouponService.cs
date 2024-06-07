using LojaVirtual.Web.Models;
using LojaVirtual.Web.Services.IServices;
using LojaVirtual.Web.Utils;
using System.Net;
using System.Net.Http.Headers;

namespace LojaVirtual.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "Coupon";

        public CouponService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(_httpClient));
        }

        public async Task<CouponViewModel> GetCoupon(string code, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{code}");
            if (response.StatusCode != HttpStatusCode.OK) return new CouponViewModel();

            return await response.ReadContentAs<CouponViewModel>();
        }



    }
}
