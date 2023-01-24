using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace consoleapp
{
    class test
    {
        class program
        {
            public static void Main()
            {
                using (var client = new HttpClient())
                {
                    var ApiUrl = new Uri("http://httpbin.org/post");
                    var newModel = new dummy()
                    {
                        name = "nikhil",
                        salary = "20000",
                        age = "21"
                    };
                    var newModelJson = JsonConvert.SerializeObject(newModel);
                    var payload = new StringContent(newModelJson, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(ApiUrl, payload).Result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(result);
                }
            }

        }

    }
    internal class dummy
    {
        public string name { get; set; }
        public string salary { get; set; }
        public string age { get; set; }
    }

}