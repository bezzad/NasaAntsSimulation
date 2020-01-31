using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simulation.Enums;
using Simulation.Tools;

namespace Simulation.Core
{
    public class FaultGenerator
    {
        public FaultGenerator(Configuration config, Container container)
        {
            Config = config;
            Container = container;
        }



        protected Configuration Config { get; }
        protected Container Container { get; }


        protected void PreFailureProcess()
        {
            Time.StartSimulationTime = Time.GlobalSimulationTime;
            Config.StartMessageCount = Container.ContainerMedia.MessageCount;
        }

        protected void SetLostAgent(Agent agent)
        {
            agent.Status = State.Failed;
        }

        public void RulerFailure()
        {
            PreFailureProcess();
            var iRemoveIndex = Config.Rnd.Next(0, Container.RulerList.Count - 1);
            var lostRuler = Container.RulerList[iRemoveIndex];

            while (lostRuler.LeaderList.Count == 0)
            {
                iRemoveIndex = Config.Rnd.Next(0, Container.RulerList.Count - 1);
                lostRuler = Container.RulerList[iRemoveIndex];
            }
            SetLostAgent(lostRuler);
        }

        public void LeaderFailure()
        {
            PreFailureProcess();
            var iRemoveIndex = Config.Rnd.Next(0, Container.TeamList.Count - 1);
            var lostLeader = Container.TeamList[iRemoveIndex].OrgLeader;
            SetLostAgent(lostLeader);
        }

        public void MessengerFailure()
        {
            PreFailureProcess();
            var iRemoveIndex = Config.Rnd.Next(0, Container.MessengerList.Count - 1);
            var lostMessenger = Container.MessengerList[iRemoveIndex];
            SetLostAgent(lostMessenger);
        }

        public void WorkerFailure()
        {
            PreFailureProcess();
            var randomTeamIndex = Config.Rnd.Next(0, Container.TeamList.Count - 1);
            var workers = Container.TeamList[randomTeamIndex].AgentsArray;
            var iRemoveIndex = Config.Rnd.Next(0, workers.Count - 1);
            var lostWorker = workers[iRemoveIndex];
            SetLostAgent(lostWorker);
        }

    }
}
