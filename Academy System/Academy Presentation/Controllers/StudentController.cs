using Academy_Presentation.Helpers;
using Domain.Entities;
using Service.Services.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Presentation.Controllers
{
    public class StudentController
    {
        StudentService _studentService = new();

        public void Create()
        {
        GroupId:
            Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");

            string groupId = Console.ReadLine();
            int selectedGroupId;

            bool isSelectedId = int.TryParse(groupId, out selectedGroupId);

            if (isSelectedId)
            {
                Helper.PrintConsole(ConsoleColor.Blue, "Add Student Name");
                string studentName = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Blue, "Add Student Surname");
                string studentSurname = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Blue, "Add Student Age");
                string ageInput = Console.ReadLine();

                if (!int.TryParse(ageInput, out int age))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Please enter a valid age!");
                    goto GroupId;
                }

                Student student = new Student
                {
                    Name = studentName,
                    Surname = studentSurname,
                    Age = age
                };

                var result = _studentService.Create(selectedGroupId, student);

                if (result != null)
                {
                    Helper.PrintConsole(ConsoleColor.Green,
                        $"Student Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {student.Group.Name}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found, please add correct group id!");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct group id type!");
                goto GroupId;
            }
        }
        //public void UpdateStudent();{}
          public void Delete() 
        {
            {
            StudentId: Helper.PrintConsole(ConsoleColor.Green, "Add Group Id:");
                string studentId = Console.ReadLine();

                int id;

                bool isStudentId = int.TryParse(studentId, out id);

                if (isStudentId)
                {
                    _studentService.Delete(id);
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type");
                    goto StudentId;
                }
            }
        }
        public void GetById()
        {
        StudentId: Helper.PrintConsole(ConsoleColor.Green, "Add Group Id:");
            string studentId = Console.ReadLine();
            int id;
            bool isStudentId = int.TryParse(studentId, out id);
            if (isStudentId)
            {
                Student student = _studentService.GetById(id);
                if (student != null)
                {
                    Helper.PrintConsole(ConsoleColor.Cyan, $"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age},Group: {student.Group}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: Group not found!");
                    goto StudentId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type!");
                goto StudentId;
            }
        }
        public void GetByAge() { }
        public void GetByGroupId() { }
        public void Search() 
        {
            {
            SearchText: Helper.PrintConsole(ConsoleColor.Blue, "Add Group search text");

                string searchName = Console.ReadLine();
                List<Student> students = _studentService.Search(searchName);
                if (students.Count != 0)
                {
                    foreach (var student in students)
                    {
                        Helper.PrintConsole(ConsoleColor.Cyan, $"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age},Group: {student.Group}");
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Groups not found for search text!");
                    goto SearchText;
                }
            }
        }
}
}

