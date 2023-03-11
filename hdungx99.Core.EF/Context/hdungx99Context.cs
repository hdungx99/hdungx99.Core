using Microsoft.EntityFrameworkCore;

namespace hdungx99.Core.EF.Context
{
    public class hdungx99Context : DbContext
    {
        public hdungx99Context(DbContextOptions<hdungx99Context> options) : base(options)
        {
        }
    }
}
