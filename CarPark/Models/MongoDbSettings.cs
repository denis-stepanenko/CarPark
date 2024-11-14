namespace CarPark.Models
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
        public string User { get; set; } = "";
        public string Password { get; set; } = ""; 
    }
}
