using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatanProject.Services
{
    public class MicroservocesManager
    {
        private readonly string _downloadUrl = "http://localhost:{0}/{1}?numberone={2}&numbertwo={3}";

        private readonly Dictionary<string ,List<string>> _availblePorts = new Dictionary<string, List<string>> 
        { 
            { "Addition" ,new List<string>{"3000", "3001" }},
            { "Division" ,new List<string>{"3010", "3011" }},
            { "Multiplication" ,new List<string>{"3020", "3021" }},
            { "Power" ,new List<string>{"3030", "3031" }},
            { "Substraction" ,new List<string>{"3040", "3041" }},
            { "Sqrt" ,new List<string>{"3050", "3051" }},
            { "Modulo" ,new List<string>{"3060", "3061" }},
            { "Abs" ,new List<string>{"3070", "3071" }}
        };

        private readonly DownloadManager _downloadManager = new DownloadManager();
        private List<string> portList;
        public async Task<string> CalculateAsync(string operation, string number1, string number2 = null)
        {
            _availblePorts.TryGetValue(operation, out portList);

            foreach (var port in portList)
            {
                try
                {
                    var requestUrl = String.Format(_downloadUrl, port, operation, number1, number2);

                    var response = await _downloadManager.SendCalculation(requestUrl);

                    if (response != null )
                    {
                        return response;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine($"Will check for another service");
                }
            }

            return "no services are up - contact IT";
        }

    }
}
