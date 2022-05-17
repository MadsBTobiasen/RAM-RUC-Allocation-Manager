using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.DbConnections;

namespace RAM___RUC_Allocation_Manager.MockData
{
    public class MockLeaderProgrammes
    {
        private static List<LeaderProgramme> LeaderProgrammes = new List<LeaderProgramme>();

        public MockLeaderProgrammes()
        {
            
        }
        public static void CreateMockData()
        {
            LeaderProgramme leaderProgramme1 = new LeaderProgramme();
            Leader Simon = new Leader();
            Programme Matematik = new Programme();
            Matematik.Name = "Matematik";
            Simon.Name = "Simon";
            //leaderProgramme1.Id = 1;
            leaderProgramme1.Programme = Matematik;
            leaderProgramme1.Leader = Simon;
            LeaderProgrammes.Add(leaderProgramme1);
        }

        public static List<LeaderProgramme> GetMockLeaderProgramme()
        {
            return LeaderProgrammes;
        }
    }
}


