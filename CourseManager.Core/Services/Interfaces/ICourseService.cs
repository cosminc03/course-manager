﻿using CourseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();

        IEnumerable<string> GetAllCourseNames();

        Course GetCourseById(Guid guid);

        Employee GetOwner(Guid guid);

        IEnumerable<Student> GetStudents(Guid guid);

        IEnumerable<Employee> GetAssociates(Course course);

        IEnumerable<Employee> GetPossibleAssociates(Course course);

        void CreateCourse(Course course);

        void UpdateCourse(Course course);

        void DeleteCourse(Course course);
    }
}
