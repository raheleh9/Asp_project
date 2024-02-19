using Asp_project.context;
using Asp_project.Models;
using Asp_project.Repository.Interface;

namespace Asp_project.Repository.Implement
{
    public class TeacherRepository:ITeacherRepository
    {

        private Teachercontext _context;

        public TeacherRepository()
        {
            _context = new Teachercontext();
        }

        public bool Creatinfo(string firstname, string lastname, int nationalcode, int phonenumber, string teachingarea)
        {
            Teacher teacher = new Teacher()
            {
                FirstName = firstname,
                LastName = lastname,
                NationalCode = nationalcode,
                PhoneNumber = phonenumber,
                TeachingArea = teachingarea,
            };
            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return true;
        }


        public List<Teacher> GetAllTeacherInf()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetTeacherbyid(int id)
        {
            return _context.Teachers.FirstOrDefault(Teachers => Teachers.Id == id);
        }

        public bool Editinfo(int id, string firstname, string lastname, int nationalcode, int phonenumber, string teachingarea)
        {

            Teacher teacher = GetTeacherbyid(id);
            teacher.FirstName = firstname;
            teacher.LastName = lastname;
            teacher.NationalCode = nationalcode;
            teacher.PhoneNumber = phonenumber;
            teacher.TeachingArea = teachingarea;
            _context.Teachers.Update(teacher);
            _context.SaveChanges();

            return true;

        }

        public bool Deleteinfo(int id)
        {
            Teacher teacher = GetTeacherbyid(id);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return true;
        }
    }
}

