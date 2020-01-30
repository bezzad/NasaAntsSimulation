using Simulation.Core;

namespace Simulation.Roles
{
    public class Role
    {
        public Role(Configuration config)
        {
            Config = config;
        }


        protected Configuration Config { get; }
        public string RoleName { set; get; }
        public double RadioRange { set; get; }

        public enum RolesName { Worker, Ruler, Leader, Messenger }
    }
}
