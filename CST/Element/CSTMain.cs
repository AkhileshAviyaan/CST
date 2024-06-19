using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST.Loads;

namespace CST.Element
{
    public class CSTMain
    {
        public List<Node> Nodes { get; set; }
        public List<TractionForce> TractioForce { get; set; }
        public MaterialProperties MaterialProp { get; set; }
        public CSTMain()
        {
            Nodes = new List<Node>();
            TractioForce = new List<TractionForce>();
            MaterialProp = new MaterialProperties();
        }
    }
}
