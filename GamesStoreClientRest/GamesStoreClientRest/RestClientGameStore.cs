using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GameStorelibrary;
using Newtonsoft.Json;

namespace GamesStoreClientRest
{
    class RestClientGameStore
    {
        private const string uri = "http://localhost:58448/Service1.svc";

        public RestClientGameStore()
        {
            
        }

        public void Start()
        {
            var GamesList = GetGamesAsync().Result;
            Console.WriteLine("All games\n" + string.Join("\n", GamesList));

            var oneGame = GetOneGameAsync(1).Result;
            Console.WriteLine("Game with id = " + 1 + "\n" + oneGame);

            var deleteGame = DeleteGameAsync(2).Result;
            Console.WriteLine("Game with id = " + 2 + " is removed" + "\n" + deleteGame);

            UpdateGameAsync(new Games(1, "Donkey Kong", 4.95, 2));
            Console.ReadKey();
            var GamesList2 = GetGamesAsync().Result;
            Console.WriteLine("Game with id = " + 1 + " was updated \n" + string.Join("\n", GamesList2));

            AddGameAsync(new Games(5, "HarvestMoon", 9.95,19));
            Console.ReadKey();
            var GamesList3 = GetGamesAsync().Result;
            Console.WriteLine("All Games \n" + string.Join("\n", GamesList3));
        }




        private async Task<IList<Games>> GetGamesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri + "/games");
                IList<Games> cList = JsonConvert.DeserializeObject<IList<Games>>(content);
                return cList;
            }
        }
        private async Task<Games> GetOneGameAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri + "/game/" + id);
                Games c = JsonConvert.DeserializeObject<Games>(content);
                return c;
            }
        }
        private async Task<Games> DeleteGameAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = await client.DeleteAsync(uri + "/game?id=" + id);
                Games c = JsonConvert.DeserializeObject<Games>(content.Content.ReadAsStringAsync().Result);
                return c;
            }
        }
        private async void UpdateGameAsync(Games newGame)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(newGame));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PutAsync(uri + "/game", content);

            }
        }
        private async void AddGameAsync(Games newGame)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(newGame));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync(uri + "/addgame", content);

            }
        }
    }
}
