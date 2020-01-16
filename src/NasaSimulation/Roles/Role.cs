namespace Nasa.ANTS.Simulation.Roles
{
   public class Role
    {
        public string RoleName { set; get; }
        private string RoleId{set; get;}
        private string RoleModel{set;get;}
        public double RadioRange { set; get; }

       public  enum RolesName{Worker, Ruler, Leader, Messenger};
            
        


        public Role()
        {

        }

        public int AssignRole()
        {

            return 0;

        }

        public int ResignRole()
        {

            return 0;

        }
    }
}
