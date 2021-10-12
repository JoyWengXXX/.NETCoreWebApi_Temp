using Microsoft.EntityFrameworkCore;
using ProjectModels.Entities;

namespace DataAccessLayer_Entity_Framwork
{
    public class Proj_DBContext : DbContext
    {
        public Proj_DBContext(DbContextOptions<Proj_DBContext> options) : base(options)
        {
        }

        public DbSet<Test> Test { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
