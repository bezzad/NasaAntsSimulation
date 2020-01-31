using Simulation.Enums;
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

            var rulersHasLeader = Container.RulerList.Where(r => r.LeaderList.Any() && r.Status == State.Stable).ToList();
            if (rulersHasLeader.Count == 0) return;
            var iRemoveIndex = Config.Rnd.Next(0, rulersHasLeader.Count - 1);
            var lostRuler = rulersHasLeader[iRemoveIndex];

            SetLostAgent(lostRuler);
        }

        public void LeaderFailure()
        {
            PreFailureProcess();
            var stableLeaders = Container.TeamList.Where(t => t.ActiveLeader.Status == State.Stable).ToList();
            if (stableLeaders.Count == 0) return;
            var iRemoveIndex = Config.Rnd.Next(0, stableLeaders.Count - 1);
            var lostLeader = stableLeaders[iRemoveIndex].ActiveLeader;
            SetLostAgent(lostLeader);
        }

        public void MessengerFailure()
        {
            PreFailureProcess();
            var stableMessengers = Container.MessengerList.Where(m => m.Status == State.Stable).ToList();
            if (stableMessengers.Count == 0) return;
            var iRemoveIndex = Config.Rnd.Next(0, stableMessengers.Count - 1);
            var lostMessenger = stableMessengers[iRemoveIndex];
            SetLostAgent(lostMessenger);
        }

        public void WorkerFailure()
        {
            PreFailureProcess();
            var stableWorkers = Container.TeamList.SelectMany(t => t.AgentsArray).Where(w => w.Status == State.Stable).ToList();
            if (stableWorkers.Count == 0) return;
            var iRemoveIndex = Config.Rnd.Next(0, stableWorkers.Count - 1);
            var lostWorker = stableWorkers[iRemoveIndex];
            SetLostAgent(lostWorker);
        }

    }
}
