using CarPark.Models;
using CarPark.Repos.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarPark.Repos
{
    public class CarRepo : MongoRepo<Car>, ICarRepo
    {
        public CarRepo(IMongoDatabase db) : base(db)
        {
        }
    }
}
