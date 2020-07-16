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
        private readonly Guid _userId;
        public StudentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStudent(StudentCreate model)
        {
            var entity =
                new Student()
                {
                    OwnerId = _userId,
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
        public IEnumerable<StudentListItem> GetStudent()
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
                                    StudentId = e.StudentId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Active = e.Active,
                                    Age = e.Age,
                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateStudent(StudentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Students
                        .Single(e => e.StudentId == model.StudentId && e.OwnerId == _userId);

                entity.LastName = model.LastName;
                entity.Active = model.Active;
                entity.Age = model.Age;
                entity.Weight = model.Weight;

                return ctx.SaveChanges() == 1;
            }

        }
        public StudentDetail GetStudentById(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Students
                        .Single(e => e.StudentId == id && e.OwnerId == _userId);
                return
                    new StudentDetail
                    {
                        StudentId = entity.StudentId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Active = entity.Active,
                    };
            }
        }
        public StudentDetail GetStudentByFirstName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Students
                        .Single(e => e.FirstName == name );
                return
                    new StudentDetail
                    {
                        StudentId = entity.StudentId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Active = entity.Active,
                    };
            }
        }
    }
}





