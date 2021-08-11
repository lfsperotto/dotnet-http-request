using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace dotnet_http_request
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting application!");

            string url = Environment.GetEnvironmentVariable("URL");
            
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("URL: " + url);

                try
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    Console.WriteLine("Starting API request test!");
                    HttpResponseMessage response = await client.GetAsync(url);
                    Console.WriteLine("API request test status code: " + response.StatusCode);
                    //response.EnsureSuccessStatusCode();
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API request test success result: " + result);

                }catch(Exception ex){
                    Console.WriteLine("API request test failed result: " + ex.Message);
                    throw ex;
                }
            }

            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("URL: " + url + "/test-get");

                try
                {
                    client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                    client.DefaultRequestHeaders.Add("Keep-Alive", "360000");
                    client.Timeout = TimeSpan.FromMinutes(30);
                    Console.WriteLine("Starting API timeout GET request test!");
                    HttpResponseMessage response = await client.GetAsync(url + "/test-get");
                    Console.WriteLine("API timeout GET request test status code: " + response.StatusCode);
                    //response.EnsureSuccessStatusCode();
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API timeout GET request test success result: " + result);

                }catch(Exception ex){
                    Console.WriteLine("API timeout GET request test failed result: " + ex.Message);
                    throw ex;
                }
            }

            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("URL: " + url + "/test-post");

                try
                {
                    client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                    client.DefaultRequestHeaders.Add("Keep-Alive", "360000");
                    client.Timeout = TimeSpan.FromMinutes(30);
                    Console.WriteLine("Starting API timeout POST request test!");
                    var values = new Dictionary<string, string>
                    {
                        { "user", "user" },
                        { "pass", "pass" }
                    };
                    var content = new FormUrlEncodedContent(values);
                    HttpResponseMessage response = await client.PostAsync(url + "/test-post", content);
                    Console.WriteLine("API timeout POST request test status code: " + response.StatusCode);
                    //response.EnsureSuccessStatusCode();
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API timeout POST request test success result: " + result);

                }catch(Exception ex){
                    Console.WriteLine("API timeout POST request test failed result: " + ex.Message);
                    throw ex;
                }
            }
        }
    }
}
