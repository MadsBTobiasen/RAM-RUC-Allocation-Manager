using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class CourseDbService : DbService<Course>
    {
        /// <summary>
        /// Returns all Courses with navigation properties
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetCoursesWithNavProps()
        {
            IEnumerable<Course> courses;
            using (var context = new RamDbContext())
            {
                courses = context.Courses
                    .Include(c => c.ResponsibleEmployee).AsNoTracking();
            }

            return courses;
        }

        public async Task<Course> GetCourseWithNavProps(int id)
        {
            Course course;
            using (var context = new RamDbContext())
            {
                course = context.Courses
                    .Include(c => c.ResponsibleEmployee)
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == id);
            }

            return course;
        }
    }
}
