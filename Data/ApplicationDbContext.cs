using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ST10134934_CLDV6211_Part_Two.Models;

namespace ST10134934_CLDV6211_Part_Two.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ST10134934_CLDV6211_Part_Two.Models.Product> Product { get; set; } = default!;

        public DbSet<ST10134934_CLDV6211_Part_Two.Models.Transaction> Transaction { get; set; } = default!;

        public DbSet<ST10134934_CLDV6211_Part_Two.Models.Kuser> Kuser { get; set; } = default!;

        public DbSet<ST10134934_CLDV6211_Part_Two.Models.TransactionHistory> TransactionHistory { get; set; } = default!;




    }
}
