using LojaVirtual.Web.Models;
using LojaVirtual.Web.Services.IServices;
using LojaVirtual.Web.Utils;
using System.Net.Http.Headers;

namespace LojaVirtual.Web.Services
{
    public class ProductService : IProductService
    {
        
        private readonly HttpClient _httpClient;
        public const string BasePath = "/Product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProductViewModel>> FindAllProducts(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();  
        }

        public async Task<ProductViewModel> FindProductById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
                throw new Exception("Erro ao chamar a API");
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
                throw new Exception("Erro ao chamar a API");
        }

        public async Task<bool> DeleteProductById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Erro ao chamar a API");
        }

    }
}
