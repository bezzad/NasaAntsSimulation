﻿using Simulation.Enums;
using Simulation.Tools;
using System.Linq;

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

            var rulersHasLeader = Container.RulerList.Where(r => r.LeaderList.Any()).ToList();
            var iRemoveIndex = Config.Rnd.Next(0, rulersHasLeader.Count - 1);
            var lostRuler = rulersHasLeader[iRemoveIndex];

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
