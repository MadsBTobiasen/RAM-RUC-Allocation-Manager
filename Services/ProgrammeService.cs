using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Services.DbServices;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class ProgrammeService
    {
        #region Fields

        private ProgrammeDbService programmeDbService;
        #endregion

        #region Properties

        public List<Programme> Programmes { get; set; }
        #endregion

        #region Constructor
        public ProgrammeService(ProgrammeDbService programmeDbService)
        {

            this.programmeDbService = programmeDbService;
            Programmes = programmeDbService.GetObjectsAsync().Result.ToList();
        }
        #endregion

        #region Methods
        public List<Programme> GetProgrammes()
        {
            return Programmes;
        }



        public Programme GetProgrammeById(int id)
        {
            return Programmes.FirstOrDefault(x => x.Id == id);
        }


        public async Task<Programme> GeProgrammeWithNavPropById(int id)
        {
            return programmeDbService.GetProgrammeWithNavPropsById(id).Result;
        }


        public async Task<Programme> CreateProgramme(Programme programme)
        {
            Programmes.Add(programme);
            await programmeDbService.AddObjectAsync(programme);
            return programme;
        }

        public async Task<Programme> EditProgramme(Programme editedProgramme)
        {

            Programme programmeToEdit = null;

            foreach (Programme p in Programmes)
            {
                if (p.Id == editedProgramme.Id)
                {

                    programmeToEdit = p;
                    break;

                }
            }

            if (programmeToEdit != null)
            {
                programmeToEdit.Name = editedProgramme.Name;
            }


            await programmeDbService.UpdateObjectAsync(editedProgramme);

            return programmeToEdit;

        }


        public async Task<Programme> DeleteProgramme(Programme programmeToDelete)
        {
            Programme deletedProgramme = null;

            foreach (Programme x in Programmes)
            {
                if (x.Id == programmeToDelete.Id)
                {
                    Programmes.Remove(x);
                    deletedProgramme = x;
                    break;

                }
            }

            await programmeDbService.DeleteObjectAsync(programmeToDelete);
            return deletedProgramme;
        }

        #endregion
    }
}
