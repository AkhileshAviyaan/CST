using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllEnums;
namespace CST.Element
{
    public class NodalSupport
    {
        public double Ux { get; set; }
        public double Uy { get; set; }

        public bool UxRestrain { get; set; }
        public bool UyRestrain { get; set; }

        public ENodalSupport ENodalSupport { get; set; }
        public NodalSupport() { }
        public NodalSupport(ENodalSupport restrainCondition)
        {
            if (restrainCondition == ENodalSupport.Hinge || restrainCondition == ENodalSupport.Fixed)
            {
                UxRestrain = true;
                UyRestrain = false;
            }
            else if (restrainCondition == ENodalSupport.RollarX)
            {
                UxRestrain = true;
            }
            else if (restrainCondition == ENodalSupport.RollarY)
            {
                UyRestrain = true;
            }
        }
    }
}

