using CarPark.Models;

namespace CarPark.Repos.Interfaces
{
    public interface ITripTicketRepo : IMongoRepo<TripTicket>
    {
        public Task<List<Car>> GetTopMostUsedCarsAsync();
        public Task<List<Driver>> GetTopMostInDemandDriversAsync();
    }
}
