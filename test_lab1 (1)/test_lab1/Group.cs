using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_lab1
{
    class Group
    {
        public List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public double AverageNote()
        {
            double val = 0;

            foreach(var student in students)
            {
                val += student.AverageNote();
            }

            if (students.Count > 0)
                val /= students.Count;

            return val;
        }
    }
}
