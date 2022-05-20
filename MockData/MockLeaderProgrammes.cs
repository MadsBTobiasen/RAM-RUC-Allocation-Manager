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
        private static List<Leader> Leaders = new List<Leader>();

        public MockLeaderProgrammes()
        {
            LeaderProgramme leaderProgramme1 = new LeaderProgramme();
            Leader Simon = new Leader();
            Programme Matematik = new Programme();
            Matematik.Name = "Matematik";
            Simon.Name = "Simon";
            leaderProgramme1.LeaderId = 1;
            leaderProgramme1.Programme = Matematik;
            leaderProgramme1.Leader = Simon;
            LeaderProgrammes.Add(leaderProgramme1);
            Leaders.Add(Simon);

        }
        public static void CreateMockData()
        {
            LeaderProgramme leaderProgramme1 = new LeaderProgramme();
            Leader Simon = new Leader();
            Programme Matematik = new Programme();
            Matematik.Name = "Matematik";
            Simon.Name = "Simon";
            leaderProgramme1.LeaderId = 1;
            leaderProgramme1.Programme = Matematik;
            leaderProgramme1.Leader = Simon;
            LeaderProgrammes.Add(leaderProgramme1);
        }
        public static LeaderProgramme CreateMockDataOneObj()
        {
            LeaderProgramme leaderProgramme1 = new LeaderProgramme();
            Leader Simon = new Leader();
            Employee Frank = new Employee();
            Programme Matematik = new Programme();
            Matematik.Name = "Matematik";
            Simon.Name = "Simon";
            Simon.Programmes.Add(Matematik);
            
            Simon.ProgrammeUsers.Add(Frank);
            leaderProgramme1.LeaderId = 1;
            leaderProgramme1.Programme = Matematik;
            leaderProgramme1.Leader = Simon;
            return leaderProgramme1;
        }

        public static List<LeaderProgramme> GetMockLeaderProgrammes()
        {
            return LeaderProgrammes;
        }

        public static List<Leader> GetMockLeaders()
        {
            return Leaders;
        }
    }
}


