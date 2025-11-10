using Domain.Entities;
using Repository.Repostories.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private GroupRepository groupRepository;
        private int _count=1;
        public GroupService()
        {
            groupRepository = new GroupRepository();
        }

        public Group Create(Group group)
        {
           group.Id = _count;

           groupRepository.Create(group);

            _count++;
            return group;

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Group GeyById(int id)
        {
            throw new NotImplementedException();
        }

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
