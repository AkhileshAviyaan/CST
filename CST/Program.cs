using CST.Element;
using CST.Loads;
using static CST.Utility.MathHelp;
using AllEnums;
namespace CST.Progarm
{

	public class Program
	{
		public static void Main(string[] args)
		{
			CSTMain cst = new CSTMain();
			Node n1 = new Node(0, 0, "n1");
			Node n2 = new Node(20, 0, "n2");
			Node n3 = new Node(10, 10 * Sqrt(2), "n3");
			List<Node> nodes = [n1,n2,n3];
			n1.NodalSupport = new NodalSupport(ENodalSupport.Hinge); 
			n2.NodalSupport = new NodalSupport(ENodalSupport.Hinge);
			cst.Nodes.AddRange(nodes);

			TractionForce tractionForce=new TractionForce(n2,n3,0,360,30);


			

		}
	}
}
