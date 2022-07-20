namespace SportsStore.Models
{
    public class FakeRepository : IProductRepository
    {
        public IEnumerable<Product> Products =>
            new List<Product> {
                new Product() { Name="Football", Price=25 },
                new Product() { Name="Surf board", Price=205 },
                new Product() { Name="Shoes", Price=40 }
            };
    }
}
