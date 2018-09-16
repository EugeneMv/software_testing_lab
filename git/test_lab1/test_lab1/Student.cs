using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_lab1
{
    class Student
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        private List<Note> notes = new List<Note>();

        public Student()
        {

        }

        public Student(String name, String surname)
        {
            Name = name;
            Surname = surname;
        }

        public void AddNote(Note note)
        {
            notes.Add(note);
        }

        public double AverageNote()
        {
            double val = 0;
            foreach (var note in notes)
            {
                val += note.Value;
            }

            if (notes.Count > 0)
                val /= notes.Count;

            return val;
        }
    }
}
