using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace TestApi
{
    internal class Program
    {
        private const string GLOBAL_DATA_URL = "https://api.pole-emploi.io/partenaire/offresdemploi/v2/offres/1";
        //private const string GLOBAL_DATA_URL = "https://api.pole-emploi.io/partenaire/offresdemploi/v2/offres/10";
        //private const string DETAIL_OFFRE_URL = "https://api.pole-emploi.io/partenaire/offresdemploi/v2/offres/{offerId}";

        private static HttpClient client;
        static void Main(string[] args)
        {
            client = new HttpClient();  

            async Task<string> GetGlobalDatatAsync()
            {
                // Add the API token to the request headers
                string token = "04f96776c711aef4611b17975a22f6234b86928d2f0573a8e0c9745d8abdede9";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var data = string.Empty;

                var response =  await client.GetAsync(GLOBAL_DATA_URL);

                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync ();
                }
                return data;
            }

            Console.WriteLine("Api Offres d'emplois");

            while (true)
            {
                args = Console.ReadLine().Split(' ');
                var command = args[0];

                switch (command)
                {
                    case "offre":
                        var result = GetGlobalDatatAsync().GetAwaiter ().GetResult(); 
                        Console.WriteLine(result);
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

