using Microsoft.EntityFrameworkCore;

namespace Vestora.DAL.Data;

public class VestoraDbContext : DbContext
{
    public VestoraDbContext(
        DbContextOptions<VestoraDbContext> options)
        : base(options)
    {
    }
}
