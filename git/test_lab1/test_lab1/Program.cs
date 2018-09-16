using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group = new Group();
            Student student1 = new Student("John", "Smith");
            Student student2 = new Student("Jack", "Daniel");

            student1.AddNote(new Note(9));
            student1.AddNote(new Note(5));
            student1.AddNote(new Note(6));

            student2.AddNote(new Note(8));
            student2.AddNote(new Note(9));
            student2.AddNote(new Note(7));

            group.AddStudent(student1);
            group.AddStudent(student2);
  
            while(true){
                Console.WriteLine("1 - Add Student");
                Console.WriteLine("2 - Average note of Student");
                Console.WriteLine("3 - Average note of group");
                Console.WriteLine("4 - Add Note to Student");
                int decision = 0;
                Int32.TryParse(Console.ReadLine(), out decision);
                switch (decision)
                {
                    case 1:
                        String n1 = "", n2 = "";
                        Console.WriteLine("Name:");
                        n1 = Console.ReadLine();
                        Console.WriteLine("Surname:");
                        n2 = Console.ReadLine();
                        group.AddStudent(new Student(n1, n2));
                        break;
                    case 2:
                        int ind = 0;
                        Console.WriteLine("Index of student:");
                        Int32.TryParse(Console.ReadLine(), out ind);
                        Student stud;
                        try {
                            stud = group.students.ToArray()[ind];
                        }
                        catch (Exception e)
                        {
                            break;
                        }
                        Console.WriteLine("Note:" + stud.AverageNote());
                        break;
                    case 3:
                        Console.WriteLine("Value: " + group.AverageNote());
                        break;
                    case 4:
                        int i = 0, val = 0;
                        Console.WriteLine("Index of student:");
                        Int32.TryParse(Console.ReadLine(), out i);
                        Console.WriteLine("Note:");
                        Int32.TryParse(Console.ReadLine(), out val);
                        Student stud1;
                        try
                        {
                            stud1 = group.students.ToArray()[i];
                        }
                        catch (Exception e){
                            break;
                        }
                        stud1.AddNote(new Note(val));
                        break;
                    default: break;
                }
            } 
        }
    }
}
