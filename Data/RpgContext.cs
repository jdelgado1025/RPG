using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RPG.Data
{
    public class RpgContext : DbContext
    {
        public RpgContext(DbContextOptions<RpgContext> options): base(options)
        {
            
        }
        //Table in SQL
        DbSet<Character> Characters {get; set;}
    }
}