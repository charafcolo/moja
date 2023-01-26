using Azure.Core;
using Azure;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.Formatting;

namespace MVC.ApiRequest
{
    public static class RequestPoleEmploi
    {

        public static List<Offre> RetourResult()
        {
            (RestClient, RestResponse, RestRequest) TokenResult = GetToken();
            return SearchJob(TokenResult.Item1, TokenResult.Item2, TokenResult.Item3);
        }

        private static (RestClient, RestResponse, RestRequest) GetToken()
        {
            var Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string client_id = Config.GetValue<string>("SecretIds:ClientId");
            string client_secret = Config.GetValue<string>("SecretIds:ClientSecret");
            string scope = Config.GetValue<string>("SecretIds:Scope");

            var client = new RestClient("https://entreprise.pole-emploi.fr/");
            var request = new RestRequest("connexion/oauth2/access_token?realm=%2Fpartenaire", Method.Post);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&scope=" + scope + "&client_id=" + client_id + "&client_secret=" + client_secret, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Debug.WriteLine("Je suis appelez une fois");
            return (client, response, request);
            
        }

        private static List<Offre> SearchJob(RestClient client, RestResponse response, RestRequest request)
        {
            string motsCles = "Developpeur";
            dynamic resp = JObject.Parse(response.Content);
            string token = resp.access_token;
            client = new RestClient($"https://api.pole-emploi.io/partenaire/offresdemploi/v2/offres/search?range=1-3&motsCles={motsCles}");
            request = new RestRequest("", Method.Get);
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            response = client.Execute(request);
            resp = JObject.Parse(response.Content)["resultats"];
            List<Offre> offres = new();
            foreach (var item in resp)
            {
                offres.Add(new(item["intitule"].ToString(), item["description"].ToString(), item["lieuTravail"]["libelle"].ToString(), item["origineOffre"]["urlOrigine"].ToString()));
            }

            return offres;
        }





    }
}
