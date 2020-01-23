using System.Collections.Generic;

namespace Simulation.Scenario
{
    class SelfHealingScenario1
    {
        public const int InitNumOfTeams = 10;
        public const int InitNumOfRulers = 2;
        public const int InitNumOfMessengers = 4;
        public const int InitNumOfWorkersInOrganization = 20;
        public int NumOfOrganizations { get; set; }
        public List<Team> TeamList;

        SelfHealingScenario1()
        {
            //for (int iOrgCount = 0; iOrgCount < initNumOfTeams; iOrgCount++)
            //{
            //    TeamList.Add(new Team(TeamList.Count,"org"+TeamList.Count,initNumOfWorkersInOrganization));
            //}
        }
    }
}
