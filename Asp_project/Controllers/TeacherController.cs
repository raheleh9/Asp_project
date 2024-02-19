using Asp_project.Models;
using Asp_project.Repository.Implement;
using Asp_project.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Asp_project.Controllers
{
    //test
    public class TeacherController : Controller
    {
        #region constructor and fields
        private ITeacherRepository _teacherRepository;
        public TeacherController()
        {
            _teacherRepository = new TeacherRepository();
        }
        #endregion
        #region Actions 

        #region List
        public IActionResult List()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeacherInf();
            return View(teachers);
        }


        #endregion
        #endregion

        #region creat
        public IActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Creat(string firstname, string lastname, int nationalcode, int phonenumber, string teachingarea)
        {
            bool result = _teacherRepository.Creatinfo(firstname, lastname, nationalcode, phonenumber, teachingarea);
            {
                if (result)
                {
                    return RedirectToAction("list");
                }
                else
                {
                    return View();
                }
            }

        }
        #endregion

        #region Edit

        public IActionResult Edit(int id)
        {
            Teacher teacher = _teacherRepository.GetTeacherbyid(id);
            return View(teacher);
        }
        [HttpPost]
        public IActionResult Edit(int id, string firstname, string lastname, int nationalcode, int phonenumber, string teachingarea)
        {
            var result = _teacherRepository.Editinfo(id, firstname, lastname, nationalcode, phonenumber, teachingarea);

            if (result)
            {
                return RedirectToAction("list");
            }
            else
            {
                Teacher teacher = new Teacher()
                {
                    Id = id,
                    FirstName = firstname,
                    LastName = lastname,
                    NationalCode = nationalcode,
                    PhoneNumber = phonenumber,
                    TeachingArea = teachingarea,
                };
                return View(teacher);
            }
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            _teacherRepository.Deleteinfo(id);

            return RedirectToAction("list");
        }


        #endregion
    }
}

