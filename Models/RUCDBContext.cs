using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class RUCDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RUCDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }
    }
}
