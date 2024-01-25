using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService
	{
		TestDbContext _ctx;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

		public ProductList  ListProducts(int page)
		{
            if (page == 1)
            {
				return new ProductList() { HasNext = false, TotalCount = 10, Products = _ctx.Products.Take(10).ToList() };

			}
            else
            {
				return new ProductList() { HasNext = false, TotalCount = _ctx.Products.Count(), Products = _ctx.Products.Skip(10).Take(10).ToList() };
			}
			
		}

	}
}
