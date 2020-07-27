﻿using System.Net.Http;
using System.Threading.Tasks;

namespace Aax.Activation.ApiClient
{
    public class AaxActivationClient
    {
        private static AaxActivationClient _instance;

        private HttpClient httpClient;

        public static AaxActivationClient Instance => (_instance = new AaxActivationClient(new HttpClient()));

        public AaxActivationClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// a4cfea52649d6efc12c5174b6b51dd523f102fa1
        /// </summary>
        /// <param name="checksum"></param>
        /// <returns></returns>
        public async Task<string> ResolveActivationBytes(string checksum)
        {
            var httpResponse = await httpClient.GetAsync($"https://aaxactivationserviceapi.azurewebsites.net/api/v1/activation/{checksum}");
            httpResponse.EnsureSuccessStatusCode();
            return await httpResponse.Content.ReadAsStringAsync();
        }
    }
}