﻿using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.Data
{
    public class SchoolInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Check if any students already exist
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new List<Student>
            {
                new Student { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") },
                new Student { FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 },
                new Course { CourseID = 1045, Title = "Calculus", Credits = 4 },
                new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4 },
                new Course { CourseID = 2021, Title = "Composition", Credits = 3 },
                new Course { CourseID = 2042, Title = "Literature", Credits = 4 }
            };

            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment { StudentID = students[0].ID, CourseID = courses[0].CourseID, Grade = Grade.A },
                new Enrollment { StudentID = students[0].ID, CourseID = courses[1].CourseID, Grade = Grade.C },
                new Enrollment { StudentID = students[0].ID, CourseID = courses[2].CourseID, Grade = Grade.B },
                new Enrollment { StudentID = students[1].ID, CourseID = courses[3].CourseID, Grade = Grade.B },
                new Enrollment { StudentID = students[1].ID, CourseID = courses[4].CourseID, Grade = Grade.F },
                new Enrollment { StudentID = students[1].ID, CourseID = courses[5].CourseID, Grade = Grade.F },
                new Enrollment { StudentID = students[2].ID, CourseID = courses[0].CourseID },
                new Enrollment { StudentID = students[3].ID, CourseID = courses[0].CourseID },
                new Enrollment { StudentID = students[3].ID, CourseID = courses[1].CourseID, Grade=Grade.F},
                new Enrollment { StudentID=students[4].ID, CourseID=courses[2].CourseID, Grade=Grade.C},
                new Enrollment { StudentID=students[5].ID, CourseID=courses[3].CourseID},
                new Enrollment { StudentID=students[6].ID, CourseID=courses[4].CourseID, Grade=Grade.A}
            };

            enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();
        }
    }
}