using DrugApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugApp.Data
{
    public class DataContext : DbContext
    {
        public virtual DbSet<ItemData> Items { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }

    }

}