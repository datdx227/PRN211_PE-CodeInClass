using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Course 
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        

        private Dictionary<Student, double> Dict = new Dictionary<Student, double>();
        public delegate void handle();
        public event handle OnNumberOfStudentChange;
        public void NumberOfStudentChange(int a, int b)
        {
            a = 2;
            b = 3;
        }
        public int oldnumber(int a)
        {
            return a = Convert.ToInt32(Dict.Count);
        }
        //public int newnumber(int a)
        //{
        //    return a = Convert.ToInt32(Dict.Count);
        //}
        
        public Course(int courseID, string courseTitle)
        {
            CourseID = courseID;
            CourseTitle = courseTitle;
        }

        public Course(int courseID, string courseTitle, Dictionary<Student, double> dict)
        {
            CourseID = courseID;
            CourseTitle = courseTitle;
            Dict = dict;
        }

        public override string ToString()
        {
            var a = "";
            foreach (var dict in Dict)
            {
                a += "Student: " +dict.Key.ToString() + " " + dict.Value.ToString() + "\n";  
            }
            //StringBuilder sb = new StringBuilder();
            //sb.Append(CourseID + " - ");
            //sb.Append(CourseTitle + "\n");
            //sb
            return "Course: " + CourseID + " - " + CourseTitle + "\n" + a;
            
        }



        public void AddStudent(Student p, double g)
        {
            Dict.Add(p, g);
        }

        public void RemoveStudent(int StudentId)
        {
            Student S = null;
            foreach (var student in Dict)
            {
                if (student.Key.StudentID == StudentId)
                {
                    S = student.Key;
                }
            }
            Dict.Remove(S);
        }

    }
}
