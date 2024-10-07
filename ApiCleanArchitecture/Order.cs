namespace ApiCleanArchitecture
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Product { get; set; }

        public int Total { get; set; }

        public int Quantity { get; set; }
    }
}
