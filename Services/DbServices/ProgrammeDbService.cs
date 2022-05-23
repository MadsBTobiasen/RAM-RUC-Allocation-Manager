using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RAM___RUC_Allocation_Manager.Models;

namespace RAM___RUC_Allocation_Manager.Services.DbServices
{
    public class ProgrammeDbService : DbService<Programme>
    {
        public async Task<IEnumerable<Programme>> GetProgrammesWithNavProps()
        {
            IEnumerable<Programme> programmes;
            using (var context = new RamDbContext())
            {
                programmes = context.Programmes
                    .Include(p => p.LeaderProgrammes)
                    .Include(p => p.EmployeeProgrammes)
                    .AsNoTracking();
            }

            return programmes;
        }

        public async Task<Programme> GetProgrammeWithNavPropsById(int id)
        {
            Programme programme;
            using (var context = new RamDbContext())
            {
                programme = context.Programmes
                    .Include(p => p.LeaderProgrammes)
                    .Include(p => p.EmployeeProgrammes)
                    .FirstOrDefault(p => p.Id == id);
            }

            return programme;
        }
    }
}
