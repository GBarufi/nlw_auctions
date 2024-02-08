using Auctions.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auctions.API.Repositories
{
    public class AuctionsDbContext : DbContext
    {
        public AuctionsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
