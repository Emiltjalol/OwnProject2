using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OwnProject2.DataMananger
{
    class DogApiDataManager
    {
        public static async Task <List<Models.Dog>> GetDogsInformation(string uri)
        {            

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "TTO105TEjJcfI7KNkR2LEg==clDxbbw6VRcUP8y3");

            List<Models.Dog> dogs = null;

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                dogs = JsonSerializer.Deserialize<List<Models.Dog>>(responseString);               
            }
            return dogs;
        }
    }
}
