namespace Simulation.Roles
{
    public class Role
    {
        public string RoleName { set; get; }
        public string RoleId { set; get; }
        public string RoleModel { set; get; }
        public double RadioRange { set; get; }

        public enum RolesName { Worker, Ruler, Leader, Messenger }
    }
}
