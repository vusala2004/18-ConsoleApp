using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(int groupId, Student student);
     
        Student Update(int  groupid,Student student);
        void Delete(int id);
        Student GetById(int id);
        List<Student> GetByAge(int age);
        List<Student> GetAllByGroupId(int groupId);
      
        List<Student> Search(string name);
    }
}
