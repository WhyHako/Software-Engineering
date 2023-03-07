using Newtonsoft.Json;
using RestSharp;

namespace SoftwareEngineeringNumber1
{
    public class Rootobject
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public Datum[] data { get; set; }
        public Support support { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
            {
                var client = new RestClient("https://reqres.in");
                var request = new RestRequest("api/users?page=2");
                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string rawResponse = response.Content;
                    Rootobject result = JsonConvert.DeserializeObject<Rootobject>(rawResponse);

                    for (int j = 0; j < result.data.Length; j++)
                    {
                        if (result.data[j].id == 10) Console.Write("id " + result.data[j].id + ": " + result.data[j].first_name + " " + result.data[j].last_name + " (" + result.data[j].email + ")");
                    }
                }
            }
        }
    }