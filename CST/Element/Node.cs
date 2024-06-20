using CST.Loads;
using System.Runtime.InteropServices;

namespace CST.Element
{
	public class Node
	{
		public double X { get; set; }
		public double Y { get; set; }
		public int Id {  get; set; }	
		public string Label { get; set; }
		public NodalSupport NodalSupport { get; set; }
		public NodalLoad NodalLoad { get; set; }
		public ReactionForce reactionForce { get; set; }
		public bool ReactionUnkonwn { get; set; }
		public NodalTractionForce nodalTractionForce { get; set; }
		public double BodyForceX { get; set; }
		public double BodyForceY { get; set; }

		public bool IsFree
		{
			get
			{
				if (NodalSupport == null)
				{
					return true;
				}
				else
				{
					if (NodalSupport.UxRestrain is true || NodalSupport.UyRestrain is true)
					{
						return false;
					}
				}
				return false;
			}
		}
		public Node()
		{
			nodalTractionForce=new NodalTractionForce();
			reactionForce=new ReactionForce();

		}
		public Node(double x, double y, string label):this()
		{
			X = x;
			Y = y;
			Label = label;
		}
	}

}
public class ReactionForce()
{
	public double Fx { get; set; }
	public double Fy { get; set; }
}
public class NodalTractionForce()
{
	public double Fx { get; set; }
	public double Fy { get; set; }
}