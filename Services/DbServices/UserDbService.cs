using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RAM___RUC_Allocation_Manager.Models;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class UserDbService : DbService<User>
    {
        /// <summary>
        /// Returns all employees with navigation properties
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetEmployeesWithNavPropsAsync()
        {
            IEnumerable<User> employees;
            using (var context = new RamDbContext())
            {
                employees = context.Employees
                    .Include(e => e.EmployeeCourses)
                    .ThenInclude(ec => ec.Course)
                    .Include(e => e.CoordinatorOfCourses)
                    .Include(e => e.EmployeeHiringCommittees)
                    .ThenInclude(ehc => ehc.HiringCommittee)
                    .Include(e => e.EmployeeCustomCommittees)
                    .ThenInclude(cc => cc.CustomCommittee)
                    .Include(e => e.PromotionCommittees)
                    .Include(e => e.EmployeeGroups)
                    .ThenInclude(eg => eg.Group)
                    .Include(e => e.PhdsTasks)
                    .Include(e => e.GroupFacilitationTasks)
                    .Include(e => e.EmployeeProgrammes)
                    .ThenInclude(ep => ep.Programme)
                    .Include(e => e.Redemptions)
                    .AsNoTracking();
            }

            return employees;
        }
        
        /// <summary>
        /// Returns all Leaders with navigation properties
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Leader>> GetLeadersWithNavProps()
        {
            IEnumerable<Leader> leaders;
            using (var context = new RamDbContext())
            {
                leaders = context.Leaders
                    .Include(l => l.LeaderProgrammes)
                    .ThenInclude(lp => lp.Programme)
                    .AsNoTracking();
            }

            return leaders;
        }


        /// <summary>
        /// Returns a single employee by id with all nav props filled
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee</returns>
        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee;
            using (var context = new RamDbContext())
            {
                employee = context.Employees
                    .Include(e => e.EmployeeCourses)
                    .ThenInclude(ec => ec.Course)
                    .Include(e => e.CoordinatorOfCourses)
                    .Include(e => e.EmployeeHiringCommittees)
                    .ThenInclude(ehc => ehc.HiringCommittee)
                    .Include(e => e.EmployeeCustomCommittees)
                    .ThenInclude(cc => cc.CustomCommittee)
                    .Include(e => e.PromotionCommittees)
                    .Include(e => e.EmployeeGroups)
                    .ThenInclude(eg => eg.Group)
                    .Include(e => e.PhdsTasks)
                    .Include(e => e.GroupFacilitationTasks)
                    .Include(e => e.EmployeeProgrammes)
                    .ThenInclude(ep => ep.Programme)
                    .Include(e => e.Redemptions)
                    .AsNoTracking()
                    .FirstOrDefault(e => e.Id == id);
            }

            return employee;
        }


        /// <summary>
        /// Returns a single leader by id with all nav props filled
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Leader</returns>
        public async Task<Leader> GetLeaderById(int id)
        {
            Leader leader;
            using (var context = new RamDbContext())
            {
                leader = context.Leaders
                    .Include(l => l.LeaderProgrammes)
                        .ThenInclude(lp => lp.Programme)
                        .ThenInclude(p => p.EmployeeProgrammes)
                        .ThenInclude(ep => ep.Employee)
                    .AsNoTracking()
                    .FirstOrDefault(l => l.Id == id);
            }

            return leader;
        }
    }
}
