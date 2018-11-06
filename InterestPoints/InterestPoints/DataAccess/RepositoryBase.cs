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
        private IConfiguration _configuration;
        private readonly MongoClient _client;
        protected readonly IMongoDatabase _db;
        protected IMongoCollection<T> _collection;

        public RepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MongoClient(_configuration["DATABASE_CONN"]);
            _db = _client.GetDatabase(_configuration["DATABASE_NAME"]);
        }
    }
}
