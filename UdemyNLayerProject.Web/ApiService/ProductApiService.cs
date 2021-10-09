using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Web.DTOs;

namespace UdemyNLayerProject.Web.ApiService
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<ProductDto> productDtos;
            var response = await _httpClient.GetAsync("products");

            if (response.IsSuccessStatusCode)
            {
                productDtos = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(await response.Content.ReadAsStringAsync());
               // categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync());

            }
            else
            {
                productDtos = null;
            }
            return productDtos;

        }

        public async Task<ProductDto> AddAsync(ProductDto productDtos)
        {
            var stringcontent = new StringContent(JsonConvert.SerializeObject(productDtos), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("products", stringcontent);

            if (response.IsSuccessStatusCode)
            {
                productDtos = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
                return productDtos;
            }
            else
            {
                return null;
            }


        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Update(ProductDto productDtos)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productDtos), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("products", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
