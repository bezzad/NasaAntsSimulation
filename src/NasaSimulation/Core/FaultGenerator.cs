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


        public void RulerFailure()
        {
            Time.StartSimulationTime = Time.GlobalSimulationTime;
            Config.StartMessageCount = Container.ContainerMedia.MessageCount;
            var iRemoveIndex = Config.Rnd.Next(0, Container.RulerList.Count - 1);
            var lostRuler = Container.RulerList[iRemoveIndex];

            while (lostRuler.LeaderList.Count == 0)
            {
                iRemoveIndex = Config.Rnd.Next(0, Container.RulerList.Count - 1);
                lostRuler = Container.RulerList[iRemoveIndex];
            }

            lostRuler.Status = State.Failed;
        }

        public void LeaderFailure()
        {

        }

        public void MessengerFailure()
        {

        }

        public void WorkerFailure()
        {

        }

    }
}
