using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPoints.DataAccess
{
    public class RepositoryBase<T>
    {
        public IConfiguration _configuration;
        public readonly MongoClient _client;
        public readonly IMongoDatabase _db;
        public IMongoCollection<T> _collection;

        public RepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MongoClient(_configuration["DATABASE_CONN"]);
            _db = _client.GetDatabase("indiecampersdb");
        }
    }
}
