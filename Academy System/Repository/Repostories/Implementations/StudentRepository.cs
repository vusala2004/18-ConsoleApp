using Domain.Entities;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repostories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {

            try
            {
                if (data is null) throw new NotFoundException("data not found");

                AppDpContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Delete(Student data)
        {
            AppDpContext<Student>.datas.Remove(data);
        }

        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDpContext<Student>.datas.Find(predicate) : null;
        }

        public List<Student> GetAll(Predicate<Student> predicate)
        {
            return predicate != null ? AppDpContext<Student>.datas.FindAll(predicate) : AppDpContext<Student>.datas;

        }

        public void Update(Student data)
        {
            Student dpStudent = Get(s => s.Id == data.Id);

            if (dpStudent == null) return;

            if (!string.IsNullOrEmpty(data.Name))
            {
                dpStudent.Name = data.Name;
            }

            if (data.Id > 0)
            {
                dpStudent.Id = data.Id;
            }
        }
    }
}
