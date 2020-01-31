using System.Collections.Generic;
using Simulation.Core;

namespace Simulation.Scenario
{
    public class SelfHealingScenario1 : IScenario
    {
        protected Configuration Config { get; }
        public List<Team> TeamList;

        public SelfHealingScenario1(Configuration config)
        {
            Config = config;
            //for (int iOrgCount = 0; iOrgCount < initNumOfTeams; iOrgCount++)
            //{
            //    TeamList.Add(new Team(TeamList.Count,"org"+TeamList.Count,initNumOfWorkersInOrganization));
            //}
        }

        public void Run()
        {
        }
    }
}
