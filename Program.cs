#:package Newtonsoft.Json@13.0.3
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Geolocate
{
    public class Data
    {
        public string? city { get; set; }
        public string? region { get; set; }
        public string? country { get; set; }
        public string? loc { get; set; }
        public string? postal { get; set; }
        public string? org { get; set; }
    }

    internal class Program
    {
        static void ShowBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("""
        ___ ____   ____            _                 _             
        |_ _|  _ \ / ___| ___  ___ | | ___   ___ __ _| |_ ___  _ __ 
        | || |_) | |  _ / _ \/ _ \| |/ _ \ / __/ _` | __/ _ \| '__|
        | ||  __/| |_| |  __/ (_) | | (_) | (_| (_| | || (_) | |   
        |___|_| (_)\____|\___|\___/|_|\___/ \___\__,_|\__\___/|_|   
        """);
            Console.ResetColor();
            Console.WriteLine();
        }
        static async Task Main(string[] args)
        {
            Console.Title = "Geolocator";
            ShowBanner();
            Console.Write("Enter IP Address: ");
            string? ip = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ip))
            {
                Console.WriteLine("Geen IP-adres ingevoerd.");
                return;
            }

            string url = $"https://ipinfo.io/{ip.Trim()}/json";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    Console.WriteLine("[+] Request successfully made!");

                    string responseData = await response.Content.ReadAsStringAsync();
                    Data? ipInfo = JsonConvert.DeserializeObject<Data>(responseData);

                    if (ipInfo == null)
                    {
                        Console.WriteLine("Geen data ontvangen.");
                        return;
                    }

                    Console.Clear();
                    Console.Write("\u001b\u005b3J");
                    Console.WriteLine($"Country: {ipInfo.country}");
                    Console.WriteLine($"City: {ipInfo.city}");
                    Console.WriteLine($"Coordinates: {ipInfo.loc}");
                    Console.WriteLine($"Postal code: {ipInfo.postal}");
                    Console.WriteLine($"Region: {ipInfo.region}");
                    Console.WriteLine($"ASN/Org: {ipInfo.org}");
                    if (!string.IsNullOrEmpty(ipInfo.loc))
                    {
                        string[] coords = ipInfo.loc.Split(',');
                        Console.WriteLine($"Google Maps: https://www.google.com/maps?q={coords[0]},{coords[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Geen coördinaten beschikbaar voor dit IP.");
                    }

                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}