using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
