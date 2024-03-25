using deadly.viper.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace deadly.viper.Data
{
	public class StoreContext : DbContext
	{
		public StoreContext(DbContextOptions<StoreContext> options)
			: base(options)
		{ }
		public DbSet<Item> Items { get; set;}
	}
}

