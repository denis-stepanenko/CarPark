using CarPark.Models;
using CarPark.Repos.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CarPark.Repos
{
    public class TripTicketRepo : MongoRepo<TripTicket>, ITripTicketRepo
    {
        public TripTicketRepo(IMongoDatabase db) : base(db)
        {
        }

        public async Task<List<Car>> GetTopMostUsedCarsAsync()
        {
            var items = await _collection.AsQueryable()
                .GroupBy(x => x.Car)
                .Select(x => new { _id = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .Select(x => new Car { Id = x._id.Id, Make = x._id.Make, Name = x._id.Name })
                .ToListAsync();

            return items;
        }

        public async Task<List<Driver>> GetTopMostInDemandDriversAsync()
        {
            var items = await _collection.Aggregate()
                .Group(new BsonDocument
                {
                    { "_id", "$Driver" },
                    { "count", new BsonDocument("$sum", 1) }
                })
                .Sort(new BsonDocument("count", -1))
                .Limit(5)
                .Project<Driver>(new BsonDocument
                {
                    { "_id", "$_id._id" },
                    { "Name", "$_id.Name" }
                })
                .ToListAsync();

            return items;
        }
    }
}
