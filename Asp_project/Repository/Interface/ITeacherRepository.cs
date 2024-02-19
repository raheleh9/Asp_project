using Asp_project.Models;

namespace Asp_project.Repository.Interface
{
    public interface ITeacherRepository
    {
        List<Teacher> GetAllTeacherInf();

        bool Creatinfo(string firstname, string lastname, int nationalcode, int phonenumber, string teachingarea);

        public Teacher GetTeacherbyid(int id);
        bool Editinfo(int id, string firstname, string lastname, int nationalcode, int phonenumber, string teachingarea);
        bool Deleteinfo(int id);
    }
}
