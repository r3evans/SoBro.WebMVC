using SoBro.Data;
using SoBro.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Services.Services
{
    public class StudentService
    {
        private readonly Guid _userID;
        public StudentService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateStudent(StudentCreate model)
        {
            var entity =
                new Student()
                {
                    OwnerID = _userID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Height = model.Height,
                    Weight = model.Weight,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<StudentListItem> GetStudents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Students
                        .Select(
                            e =>
                                new StudentListItem
                                {
                                    StudentID = e.StudentId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Active = e.Active,
                                    Age = e.Age
                                }
                        );

                return query.ToArray();
            }
        }
    }
}



