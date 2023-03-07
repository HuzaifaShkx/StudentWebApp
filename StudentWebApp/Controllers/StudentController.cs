using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentWebApp.Models;

namespace StudentWebApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult StudentEntry()
        {

            return View();
        }

        [HttpPost]
        public ActionResult StudentEntry(Student s)
        {
            
            string name = s.name;
            int rollno=s.rollno;
            string prog = s.program;
            bool job = s.isjob;
            char gender = s.gender;
            string q = "insert into Student(Rollno,Name,Program,Gender,isJob) values('"+s.rollno+"','"+s.name+"','"+s.program+"','"+s.gender+"','"+s.isjob+"')";
            DBAccess obj=new DBAccess();
            obj.openConnection();
            obj.InsertUpdateDelete(q);
            obj.closeConnection();
            return View();
        }
    }
}