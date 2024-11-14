using CarPark.Models;
using CarPark.Repos.Interfaces;
using MongoDB.Driver;

namespace CarPark.Repos
{
    public class DriverRepo : MongoRepo<Driver>, IDriverRepo
    {
        public DriverRepo(IMongoDatabase db) : base(db)
        {
        }
    }
}
