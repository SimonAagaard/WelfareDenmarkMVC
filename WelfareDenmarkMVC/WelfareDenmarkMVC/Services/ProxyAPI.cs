using Microsoft.AspNetCore.Mvc;
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
        //For GetDetailsAsync
        const string baseUrl = "https://welfaredenmarkapi.azurewebsites.net/api";

        [HttpGet]
        public async Task<List<ChecklistViewModel>> GetAllAsync()
        {
            //List<ChecklistViewModel> checklists = new List<ChecklistViewModel>();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("https://welfaredenmarkapi.azurewebsites.net/api/checklists");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var checklistResponse = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<ChecklistViewModel>>(checklistResponse);
        }

        [HttpGet]
        public async Task<ChecklistViewModel> GetDetailsAsync(int id)
        {
            var url = $"{baseUrl}/Checklists/{id}";
            var client = new HttpClient();
            string json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<ChecklistViewModel>(json);
        }

        [HttpPut]
        public async Task<ChecklistViewModel> EditChecklistAsync(ChecklistViewModel checklistViewModel)
        {
            var url = $"{baseUrl}/Checklists/{checklistViewModel.Id}";
            var client = new HttpClient();
            var json = new StringContent(JsonConvert.SerializeObject(checklistViewModel), Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, json);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var checklistResponse = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ChecklistViewModel>(checklistResponse);

        }

    }
}
