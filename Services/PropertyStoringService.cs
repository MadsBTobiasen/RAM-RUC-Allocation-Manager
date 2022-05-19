using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class PropertyStoringService
    {
        private Employee employee;
        private List<Redemption> redemptions;
        private List<Course> courses;
        private List<EmployeeCourse> employeeCourses;

        public void StoreProperty(Employee employee)
        {
            this.employee = employee;
        }
        public void StoreProperty(List<Redemption> redemptions)
        {
            this.redemptions = redemptions;
        }
        public void StoreProperty(List<Course> courses)
        {
            this.courses = courses;
        }
        public void StoreProperty(List<EmployeeCourse> employeeCourses)
        {
            this.employeeCourses = employeeCourses;
        }
        public Employee GetEmployee()
        {
            return employee;
        }
        public List<Redemption> GetRedemptions()
        {
            return redemptions;
        }

        public List<Course> GetCourses()
        {
            return courses;
        }

        public List<EmployeeCourse> GetEmployeeCourses()
        {
            return employeeCourses;
        }
    }
}
