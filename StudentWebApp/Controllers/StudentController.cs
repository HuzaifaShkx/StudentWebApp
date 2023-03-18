using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentWebApp.Models;
using System.Data.SqlClient;

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
            int rollno = s.rollno;
            string prog = s.program;
            bool job = s.isjob;
            char gender = s.gender;
            string q = "insert into Student(Rollno,Name,Program,Gender,isJob) values('" + s.rollno + "','" + s.name + "','" + s.program + "','" + s.gender + "','" + s.isjob + "')";
            DBAccess obj = new DBAccess();
            obj.openConnection();
            obj.InsertUpdateDelete(q);
            obj.closeConnection();
            return View();
        }
        DBAccess obj = new DBAccess();

        public ActionResult AllStudents() {
            List<Student> slist = new List<Student>();
            try
            {
                obj.openConnection();
                string q = "select Rollno,Name,Program from student";
                obj.cmd=new SqlCommand(q,obj.con);
                //using SQL DATA Reader
                SqlDataReader sdr = obj.cmd.ExecuteReader();
                while(sdr.Read())
                {
                    Student s = new Student();
                    s.rollno = int.Parse(sdr["Rollno"].ToString());
                    s.name = sdr["Name"].ToString();
                    s.program = sdr["Program"].ToString();

                    slist.Add(s);
                }
                sdr.Close();
                obj.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }
            return View(slist);
        }

        private Student SingleStudent(int rn)
        {
            Student s = new Student();
            obj.openConnection();
            string q = "Select * from Student where Rollno='" + rn + "'";
            obj.cmd = new SqlCommand(q, obj.con);
            //using SQL DATA Reader
            SqlDataReader sdr = obj.cmd.ExecuteReader();
            sdr.Read();
            s.rollno = rn;
            s.name = sdr["Name"].ToString();
            s.program = sdr["Program"].ToString();
            s.gender = char.Parse(sdr["Gender"].ToString());
            s.isjob = bool.Parse(sdr["isJob"].ToString());

            sdr.Close();
            obj.closeConnection();
            
            return s;
        }
        public ActionResult DeleteStudent(int rn) {
            
            string q="Delete from Student where Rollno='"+rn+"'";
            obj.openConnection();
            obj.InsertUpdateDelete(q);
            obj.closeConnection();
            return RedirectToAction("AllStudents");
        }

        public ActionResult StudentDetail(int id) {

            return View(SingleStudent(id));
            
        }

        public ActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Course c)
        {
            string coursetitle = c.courseTitle;
            string coursecode = c.courseCode;
            int crreditHour = c.creditHour;
  
            string qc = "insert into Courses values('" + c.courseCode + "','" + c.courseTitle + "','" + c.creditHour + "')";
            DBAccess obj = new DBAccess();
            obj.openConnectionc();
            obj.InsertUpdateDeletec(qc);
            obj.closeConnectionc();
            return View();
        }
        [HttpGet]
        public ActionResult AllCourses() {

            List<Course> clist = new List<Course>();
            try
            {
                obj.openConnectionc();
                string qs = "select * from Courses";
                obj.cmdcourse = new SqlCommand(qs, obj.concourse);
                //using SQL DATA Reader
                SqlDataReader sdrc = obj.cmdcourse.ExecuteReader();
                while (sdrc.Read())
                {
                    Course c = new Course();
                    c.courseCode = sdrc["coursecode"].ToString();
                    c.courseTitle = sdrc["coursetitle"].ToString();
                    c.creditHour = int.Parse(sdrc["credithours"].ToString());

                    clist.Add(c);
                }
                sdrc.Close();
                obj.closeConnectionc();
            }
            catch (Exception)
            {

                throw;
            }
            return View(clist);
        }




} 
}