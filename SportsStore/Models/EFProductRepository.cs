namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private SportsStoreContext context;

        public EFProductRepository(SportsStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> Products => context.Products;
    }
}
