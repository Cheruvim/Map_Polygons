using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace TestJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonSting = File.ReadAllText("C:/1/1.txt");
            var data = JsonSerializer.Deserialize<List<Data>>(jsonSting);
            Console.WriteLine(data[0].geojson.coordinates[0]);
        }
    }
}
