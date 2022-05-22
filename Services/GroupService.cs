using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using RAM___RUC_Allocation_Manager.Services.DbServices;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class GroupService
    {
        #region Fields

        private GroupDbService groupDbService;
        #endregion

        #region Properties

        public List<Group> Groups { get; set; }
        #endregion

        #region Constructor
        public GroupService(GroupDbService groupDbService)
        {

            this.groupDbService = groupDbService;
            Groups = groupDbService.GetObjectsAsync().Result.ToList();
        }
        #endregion

        #region Methods
        public List<Group> GetGroups()
        {
            return Groups;
        }


      
        public Group GetCourseById(int id)
        {
            return Groups.FirstOrDefault(x => x.Id == id);
        }

       
        public async Task<Group> GetGroupWithNavPropById(int id)
        {
            return groupDbService.GetGroupWithNavPropsById(id).Result;
        }


        public async Task<Group> CreateGroup(Group group)
        {
            Groups.Add(group);
            await groupDbService.AddObjectAsync(group);
            return group;
        }



        
        public async Task<Group> DeleteGroup(Group groupToDelete)
        {
            Group deletedGroup = null;

            foreach (Group x in Groups)
            {
                if (x.Id == groupToDelete.Id)
                {
                    Groups.Remove(x);
                    deletedGroup = x;
                    break;

                }
            }

            await groupDbService.DeleteObjectAsync(groupToDelete);
            return deletedGroup;
        }

        #endregion
    }
}
