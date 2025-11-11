using Academy_Presentation.Helpers;
using Domain.Entities;
using Service.Services.Implementations;
using System;

using Domain.Entities;
namespace Academy_Presentation.Controllers
{
    public class GroupController
    {
        GroupService _groupService = new();

        public void Create()
        {
            Helper.PrintConsole(ConsoleColor.Green, "Add Group Name:");
            string groupName = Console.ReadLine().Trim().ToUpper();

            Helper.PrintConsole(ConsoleColor.Green, "Add Group Teacher:");
            string groupTeacher = Console.ReadLine().Trim().ToUpper();


            Helper.PrintConsole(ConsoleColor.Green, "Add Group Room:");
            string groupRoom = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(groupName) || string.IsNullOrWhiteSpace(groupTeacher) || string.IsNullOrWhiteSpace(groupRoom))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Error: All fields must be filled!");
                return;
            }

            Group group = new Group { Name = groupName, Teacher = groupTeacher, Room = groupRoom };

            var groupResult = _groupService.Create(group);

            if (groupResult != null)
            {
                Helper.PrintConsole(ConsoleColor.Yellow, $" Group added successfully! \nId: {groupResult.Id}, \nGroupName: {groupResult.Name},\nGroupTeacher: {group.Teacher},\nGroupRoom: {group.Room}");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Error: Could not add group");
            }
        }
 
        public void UpdateGroup()
        {
        GroupId:
            Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id (or press Enter to cancel):");

            string groupId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupId))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Update operation cancelled.");
                return;
            }

            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                var findGroup = _groupService.GetById(id);

                if (findGroup != null)
                {
                    // Name
                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Name: {findGroup.Name}. Add new name (or press Enter to keep current):");
                    string newName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newName))
                    {
                        newName = findGroup.Name;
                    }

                    // Teacher
                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Teacher: {findGroup.Teacher}. Add new Teacher (or press Enter to keep current):");
                    string newTeacher = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newTeacher))
                    {
                        newTeacher = findGroup.Teacher;
                    }

                    // Room
                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Room: {findGroup.Room}. Add new Room (or press Enter to keep current):");
                    string newRoom = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newRoom))
                    {
                        newRoom = findGroup.Room;
                    }

                    // Yarat və update et
                    Group updatedGroup = new Group
                    {
                        Name = newName,
                        Teacher = newTeacher,
                        Room = newRoom
                    };

                    var result = _groupService.Update(id, updatedGroup);

                    if (result != null)
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Group updated successfully! \nId: {result.Id}, Name: {result.Name}, Teacher: {result.Teacher}, Room: {result.Room}");
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Group not updated, please try again.");
                        goto GroupId;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found.");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct Group Id type.");
                goto GroupId;
            }
        } 
        public void Delete()
        {
            {
            GroupId: Helper.PrintConsole(ConsoleColor.Green, "Add Group Id:");
                string groupId = Console.ReadLine();

                int id;

                bool isGroupId = int.TryParse(groupId, out id);

                if (isGroupId)
                {
                    _groupService.Delete(id);
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type");
                    goto GroupId;
                }
            }
        }
        public void GetById()

        {
        GroupId: Helper.PrintConsole(ConsoleColor.Green, "Add Group Id:");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                Group group = _groupService.GetById(id);
                if (group != null)
                {
                    Helper.PrintConsole(ConsoleColor.Yellow, $" Group added successfully! \nId: {group.Id}, \nGroupName: {group.Name},\nGroupTeacher: {group.Teacher},\nGroupRoom: {group.Room}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: Group not found!");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type!");
                goto GroupId;
            }
        }
        public void GetAll()
        {
            List<Group> groups = _groupService.GetAll();
            if (groups.Count != 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Yellow, $"  \nId: {group.Id}, \nGroupName: {group.Name},\nGroupTeacher: {group.Teacher},\nGroupRoom: {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Error: Please Create Group");
            }

        }
        public void GetByTeacher()

        {
        TeacherName:
            Helper.PrintConsole(ConsoleColor.Green, "Add Group Teacher:");
            string groupTeacher = Console.ReadLine().Trim().ToUpper();

            bool isGroupTeacher = !string.IsNullOrWhiteSpace(groupTeacher);

            if (isGroupTeacher)
            {
                List<Group> groups = (List<Group>)_groupService.GetAllByTeacher(groupTeacher);

                if (groupTeacher != null)
                {
                    Helper.PrintConsole(ConsoleColor.Yellow, $"Groups found for teacher: {groupTeacher}\n");


                    {
                        foreach (var group in groups)
                            Helper.PrintConsole(ConsoleColor.Cyan, $"Id: {group.Id},GroupName:{group.Name},GroupTeacher:{group.Teacher},GroupRoom{group.Room}");

                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: Teacher not found or has no groups!");
                    goto TeacherName;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct teacher name!");
                goto TeacherName;
            }
        }

       public void GetByRoom()
        {
        RoomName:
            Helper.PrintConsole(ConsoleColor.Green, "Add Group Room:");
            string groupRoom = Console.ReadLine().Trim().ToUpper();

            bool isGroupRoom = !string.IsNullOrWhiteSpace(groupRoom);

            if (isGroupRoom)
            {
                List<Group> groups = (List<Group>)_groupService.GetAllByRoom(groupRoom);

                if (groups != null && groups.Count > 0)
                {
                    Helper.PrintConsole(ConsoleColor.Yellow, $"Groups found in room: {groupRoom}\n");

                    foreach (var group in groups)
                    {
                        Helper.PrintConsole(ConsoleColor.Cyan,
                            $"Id: {group.Id}, GroupName: {group.Name}, GroupTeacher: {group.Teacher}, GroupRoom: {group.Room}");
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: No groups found in this room!");
                    goto RoomName;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct room name!");
                goto RoomName;
            }
        }
        public void Search()
        {
        SearchText: Helper.PrintConsole(ConsoleColor.Blue, "Add Group search text");

            string searchName = Console.ReadLine();
            List<Group>groups=_groupService.Search(searchName);
            if (groups.Count != 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Cyan,$"Id: {group.Id}, GroupName: {group.Name}, GroupTeacher: {group.Teacher}, GroupRoom: {group.Room}");
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


