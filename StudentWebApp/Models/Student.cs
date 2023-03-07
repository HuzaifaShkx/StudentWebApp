using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Mvc;

namespace StudentWebApp.Models
{
    public class Student
    {
        public int rollno { get; set; }
        public string name { get; set; }
        public string program { get; set; }
        public char gender { get; set; }
        public bool isjob { get; set; }
    }
}