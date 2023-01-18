using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace TestApi
{
    internal class Program
    {
        //private const string GLOBAL_DATA_URL = "https://api.pole-emploi.io/partenaire/offresdemploi/v2/offres/search";
        //private const string Auth = "https://entreprise.pole-emploi.fr/connexion/oauth2/access_token";
        //private const string DETAIL_OFFRE_URL = "https://api.pole-emploi.io/partenaire/offresdemploi/v2/offres/{offerId}";
        static void Main(string[] args)
        {
          

            var clientId = "PAR_moja_c8712da2a47803e757a10ed81a58e3e3938cf69232156e46c632429319c96358";
            var clientSecret = "04f96776c711aef4611b17975a22f6234b86928d2f0573a8e0c9745d8abdede9";

            var tokenEndpoint = "https://entreprise.pole-emploi.fr/connexion/oauth2/access_token";

            var protectedResource = "https://api.pole-emploi.io/partenaire/offresdemploi/v2/offres/search";

            // Create a new HttpClient
            var client = new HttpClient();

            // Add the client ID and client secret to the request's Authorization header
            var authValue = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}")));
            client.DefaultRequestHeaders.Authorization = authValue;

            // Create the request body
            var requestBody = new StringContent(JsonConvert.SerializeObject(new
            {
                    grant_type = "client_credentials",
                    client_id =clientId,
                    client_secret =clientSecret,
                    scope = "api_labonneboitev1"

            }), Encoding.UTF8, "application/x-www-form-urlencoded") ;

            // Send the request
            var response = client.PostAsync(tokenEndpoint, requestBody).Result;

            // Read the response
            var responseContent = response.Content.ReadAsStringAsync().Result;
            // Console.WriteLine(responseContent);

            var tokenResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
            var accessToken = tokenResponse.access_token;

            // Add the access token to the Authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Send a request to the protected resource
            var resourceResponse = client.GetAsync(protectedResource).Result;

            // Read the response
            var resourceResponseContent = resourceResponse.Content.ReadAsStringAsync().Result;
            Console.WriteLine(resourceResponseContent);

            Console.WriteLine("Ecrire le mot 'offre' pour lancer une recherche :");

            while (true)
            {
                args = Console.ReadLine().Split(' ');
                var command = args[0];

                switch (command)
                {
                    case "offre":
                        Console.WriteLine(responseContent);
                        Console.WriteLine(resourceResponseContent);
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


