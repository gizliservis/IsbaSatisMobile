﻿using IsbaSatisMobile.Models;
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
        string url = "http://192.168.1.242/isbasatis.WebApi/api/Data/";
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
    }
}
