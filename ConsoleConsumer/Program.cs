using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert Length here ");
            int length = int.Parse(Console.ReadLine());

            Console.WriteLine("Insert width here ");
            int width = int.Parse(Console.ReadLine());

            // 2,3
            AreaRec rect = new AreaRec(length, width);
            var result = AreaRecAsync(rect).Result;

            Console.WriteLine("Final result is: " + result);

            Console.ReadKey();
        }

        public static async Task<string> AreaRecAsync(AreaRec rec)
        {
            string result = null;
            using (HttpClient client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(rec);

                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://localhost:44378/Rectangle/AreaRectangle", content);

                if(response.StatusCode != HttpStatusCode.Conflict)
                {
                    response.EnsureSuccessStatusCode();

                    result = await response.Content.ReadAsStringAsync();

                }
                else
                {
                    throw new Exception("service is not running");
                }
            }

            return result;
        }
    }
}
