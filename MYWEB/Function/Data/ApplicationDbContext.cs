using Microsoft.EntityFrameworkCore;
using MYWEB.Models;

namespace MYWEB.Function.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
