using IsbaSatisMobile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisMobile.Provider
{
    public class ServiceManager
    {
        string url = "http://192.168.3.42/isbasatis.WebApi/api/Data/";
        private async Task<HttpClient> GetClient()
        {
           HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "aplication/json");
            return client;
        }
        public async Task<IEnumerable<Stok>> StokListele()
        {
            HttpClient client=await GetClient();
            var result = await client.GetStringAsync(url + "StokListele");
            var resul2 = JsonConvert.DeserializeObject<IEnumerable<Stok>>(result);
            return resul2;
        }
        public async Task<IEnumerable<Stok>> StokListeleFilter()
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(url + "StokListeleFilter");
            var resul2 = JsonConvert.DeserializeObject<IEnumerable<Stok>>(result.ToString());
            return resul2;
        }

        public void ekle(Stok stok)
        {
           
            var httpClient = new HttpClient();
            var Json = JsonConvert.SerializeObject(stok);
            HttpContent httpContent = new StringContent(Json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
            httpClient.PostAsync(url + "StokEkle", httpContent);
        }
        public void Sil(Stok stok)
        {
            var httpClient = new HttpClient();
            var Json = JsonConvert.SerializeObject(stok);
            HttpContent httpContent = new StringContent(Json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
            httpClient.PostAsync(url + "StokSil", httpContent);

        }
        public async void Guncelle(Stok stok)
        {
            var httpClient = new HttpClient();
            var Json =  JsonConvert.SerializeObject(stok);
            HttpContent httpContent = new StringContent(Json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
           await httpClient.PostAsync(url + "StokUpdate", httpContent);

        }
        public async Task<IEnumerable<Cari>> CariListele()
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(url + "CariListele");
            var resul2 = JsonConvert.DeserializeObject<IEnumerable<Cari>>(result);
            return resul2;
        }
        public void CariSil(Cari cari)
        {
            var httpClient = new HttpClient();
            var Json = JsonConvert.SerializeObject(cari);
            HttpContent httpContent = new StringContent(Json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
            httpClient.PostAsync(url + "CariSil", httpContent);

        }
        public void Cariekle(Cari cari)
        {

            var httpClient = new HttpClient();
            var Json = JsonConvert.SerializeObject(cari);
            HttpContent httpContent = new StringContent(Json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
            httpClient.PostAsync(url + "CariEkle", httpContent);
        }
    }
}
