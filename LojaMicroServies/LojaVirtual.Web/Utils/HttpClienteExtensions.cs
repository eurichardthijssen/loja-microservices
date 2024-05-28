﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace LojaVirtual.Web.Utils
{
    public static class HttpClienteExtensions
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) throw new ApplicationException($"Algo errado ao chamar a API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions{PropertyNameCaseInsensitive = true });
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpCliente, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);

            content.Headers.ContentType = contentType;

            return httpCliente.PostAsync(url,content);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpCliente, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);

            content.Headers.ContentType = contentType;

            return httpCliente.PutAsync(url, content);
        }
    }
}
