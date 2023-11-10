using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RestSharp;
using Skymey_stock_tinkoff_bondlist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymey_stock_tinkoff_bondlist.Actions.GetBonds
{
    public class GetBonds
    {
        private RestClient _client;
        private RestRequest _request;
        private MongoClient _mongoClient;
        private ApplicationContext _db;
        private string _apiKey;
        public GetBonds()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            _apiKey = config.GetSection("ApiKeys:Polygon").Value;
            _client = new RestClient("https://api.polygon.io/v3/reference/exchanges?asset_class=stocks&apiKey=" + _apiKey);
            _request = new RestRequest("https://api.polygon.io/v3/reference/exchanges?asset_class=stocks&apiKey=" + _apiKey, Method.Get);
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            _db = ApplicationContext.Create(_mongoClient.GetDatabase("skymey"));
        }
    }
}
