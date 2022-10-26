using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public static class ShiftService
    {
        public static async Task<bool> Add(Shift shift)
        {
            var client = new RestClient("https://localhost:7071/api/");
            var request = new RestRequest("Shifts/post", Method.Post);
            var json = JsonConvert.SerializeObject(shift);
            
            request.AddJsonBody(json);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public static async Task<List<Shift>> Get()
        {
            var client = new RestClient("https://localhost:7071/api/");
            var request = new RestRequest($"Shifts/getall", Method.Get);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var seralize = response.Content;
                return JsonConvert.DeserializeObject<List<Shift>>(seralize);
            }

            return default;
        }

        public static async Task<bool> Update(Shift shift)
        {
            var client = new RestClient("https://localhost:7071/api/");
            var request = new RestRequest($"Shifts/update/{shift.ShiftId}", Method.Put);
            var json = JsonConvert.SerializeObject(shift);

            request.AddJsonBody(json);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public static async Task<bool> Delete(int shiftId)
        {
            var client = new RestClient("https://localhost:7071/api/");
            var request = new RestRequest($"Shifts/delete/{shiftId}", Method.Delete);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }
    }
}
