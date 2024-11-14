namespace CarPark.Models
{
    class SelectViewModel<T>
    {
        public required string Id { get; set; }
        public required string FieldName { get; set; }
        public T? Item { get; set; }
        
    }
}
