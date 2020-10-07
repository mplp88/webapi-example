using Microsoft.EntityFrameworkCore;
using webapi_test.Models;

namespace webapi_test.DAL
{
  public class DatabaseContext : DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
      : base(options)
    {

    }

    public DbSet<Usuario> Usuarios { get; set; }
  }
}