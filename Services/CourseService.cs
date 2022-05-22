using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class CourseService
    {
        #region Fields

        private CourseDbService courseDbService;
        #endregion

        #region Properties

        public List<Course> Courses { get; set; }
        #endregion

        #region Constructor
        public CourseService(CourseDbService courseDbService)
        {

            this.courseDbService = courseDbService;
            //TODO: Retrieve Users from DB-Service.
            Courses = courseDbService.GetObjectsAsync().Result.ToList();
            Courses = Courses.OrderBy(c => c.Name).ToList();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that returns a List of all Courses
        /// </summary>
        /// <returns>List of User(s)</returns>
        public List<Course> GetCourses()
        {
            return Courses;
        }


        /// <summary>
        /// Method that returns a Course with the given ID.
        /// </summary>
        /// <param name="id">ID to search for.</param>
        /// <returns>Matched User.</returns>
        public Course GetCourseById(int id)
        {
            return Courses.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Returns a course with navigation property
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Course> GetCourseWithNavPropById(int id)
        {
            return courseDbService.GetCourseWithNavProps(id).Result;
        }


        /// <summary>
        /// Method that adds a given course to the List.
        /// </summary>
        /// <param name="userToAdd">User object to add.</param>
        /// <returns>The added user object.</returns>
        public async Task<Course> CreateCourse(Course course)
        {
            Courses.Add(course);
            await courseDbService.AddObjectAsync(course);
            return course;
        }


        /// <summary>
        /// Method that edits a course object, by trying to match an incoming course-id with one in the list of Courses,
        /// if theres a match, that courses in the list, gets updated with the properties of the courseToEdit object.
        /// </summary>
        /// <param name="courseToEdit">course object to update with.</param>
        /// <returns>Returns a ocurse-object, the object is null if the edit failed, and the updated course if the update was succesfull.</returns>
        public async Task<Course> EditCourse(Course editedCourse)
        {

            Course courseToEdit = null;

            foreach (Course c in Courses)
            {
                if (c.Id == editedCourse.Id)
                {

                    courseToEdit = c;
                    break;

                }
            }

            if (courseToEdit != null)
            {
                courseToEdit.Name = editedCourse.Name;
                courseToEdit.Type = editedCourse.Type;
                courseToEdit.LectureAmount = editedCourse.LectureAmount;
                courseToEdit.EmployeeId = editedCourse.EmployeeId;
            }

            await courseDbService.UpdateObjectAsync(editedCourse);

            return courseToEdit;

        }


        /// <summary>
        /// Method that "deletes" a course object, by replacing it with the given argument, if the two objects have a matching id.
        /// </summary>
        /// <param name="courseToEdit">Course object to delete with.</param>
        /// <returns>Returns a course-object, the object is null if the delete failed, and the deletedCourse if the update was succesfull.</returns>
        public async Task<Course> DeleteCourse(Course courseToDelete)
        {
            Course deletedCourse = null;

            foreach (Course c in Courses)
            {
                if (c.Id == courseToDelete.Id)
                {
                    Courses.Remove(c);
                    deletedCourse = c;
                    break;

                }
            }

            await courseDbService.DeleteObjectAsync(courseToDelete);
            return deletedCourse;
        }

        #endregion
    }
}
