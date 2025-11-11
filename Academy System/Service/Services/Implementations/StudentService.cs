using Domain.Entities;
using Repository.Repostories.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private StudentRepository studentRepository;
        private GroupRepository groupRepository;
        private int _count = 1;
        
        public StudentService()
        {
            studentRepository = new StudentRepository();
            groupRepository = new GroupRepository();
        }
        public Student Create(int groupId, Student  student)
        {
            var group = groupRepository.Get(g=> g.Id == groupId);

            if (group is null) return null;

            student.Id = _count;

            student.Group = group;

            studentRepository.Create(student);

            _count++;

            return student;
        }

        

        public void Delete(int id)
        {
            Student student= GetById(id);

            studentRepository.Delete(student);
        }

       
        public List<Student> GetByAge(int age)
        {
            var students = studentRepository.GetAll(s => s.Age == age);

            if (students is null || students.Count == 0)
                return new List<Student>(); // boş siyahı qaytarırıq, null yox

            return students;
        }

        public Student GetById(int id)
        {
            Student student =studentRepository.Get(s => s.Id == id);
            if (student is null) return null;
            return student;
        }

        public List<Student> Search(string name)
        {
            return studentRepository.GetAll(s => s.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
        }

       

        public Student Update(int studentid, Student student)
        {
            Student dbStudent = GetById(studentid);

            if (dbStudent is null) return null;

            student.Id = studentid;

            studentRepository.Update(student);

            return GetById(studentid);
        }

       public List<Student> GetAllByGroupId(int groupId)
       {


            var filtered = studentRepository.datas.Where(s => s.GroupId == groupId).ToList();

            return filtered; // filterlənmiş siyahını qaytar
        }

    }
}
    

