using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hdungx99.Core.EF.Context
{
    public class hdungx99Context : DbContext
    {
        public hdungx99Context(DbContextOptions<hdungx99Context> options) : base(options)
        {

        }
    }
}
