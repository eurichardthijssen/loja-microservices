using LojaVirtual.Web.Models;
using LojaVirtual.Web.Services.IServices;
using LojaVirtual.Web.Utils;
using System.Net.Http.Headers;

namespace LojaVirtual.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "Cart";

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(_httpClient));
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/find-cart/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel model, string token)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //var response = await _httpClient.PostAsJson($"{BasePath}/add-cart", model);
            var response = await _httpClient.PostAsJson("Cart/add-cart", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Erro ao chamar a API");
        }

        public async Task<CartViewModel> UpdateToCart(CartViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJson($"{BasePath}/update-cart", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else
                throw new Exception("Erro ao chamar a API");
        }

        public async Task<bool> RemoveFromCart(long cartId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"{BasePath}/remove-cart/{cartId}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Erro ao chamar a API");
        }

        public async Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userId, string token)
        {
            throw new NotImplementedException();
        }

    }
}
