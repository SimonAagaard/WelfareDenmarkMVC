using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WelfareDenmarkMVC.Models;
using WelfareDenmarkMVC.Models.AccountViewModels;

namespace WelfareDenmarkMVC.Services
{
    public class ProxyAPI
    {
        const string baseUrl = "http://localhost:50504/api";

        public async Task<List<ChecklistViewModel>> GetAllAsync()
        {
            List<ChecklistViewModel> checklists = new List<ChecklistViewModel>();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("http://localhost:50504/api/checklists");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var checklistResponse = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<ChecklistViewModel>>(checklistResponse);
        }

        public async Task<ChecklistViewModel> GetDetailsAsync(int id)
        {
            var url = $"{baseUrl}/Checklists/{id}";
            var client = new HttpClient();
            string json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<ChecklistViewModel>(json);
        }

    }
}
