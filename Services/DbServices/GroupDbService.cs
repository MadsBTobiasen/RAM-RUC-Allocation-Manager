using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;

namespace RAM___RUC_Allocation_Manager.Services.DbServices
{
    public class GroupDbService : DbService<Group>
    {
        /// <summary>
        /// Returns all Groups with navigation properties
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Group>> GetGroupsWithNavProps()
        {
            IEnumerable<Group> groups;
            using (var context = new RamDbContext())
            {
                groups = context.Groups
                    .Include(g => g.EmployeeGroups).AsNoTracking();
            }

            return groups;
        }

        public async Task<Group> GetGroupWithNavPropsById(int id)
        {
            Group group;
            using (var context = new RamDbContext())
            {
                group = context.Groups
                    .Include(g => g.EmployeeGroups)
                    .AsNoTracking()
                    .FirstOrDefault(g => g.Id == id);
            }

            return group;
        }
    }
}
