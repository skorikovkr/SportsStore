namespace SportsStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = null!;
        public PagingInfo PagingInfo { get; set; } = null!;

    }
}
