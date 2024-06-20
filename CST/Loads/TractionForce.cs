using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllEnums;
using static CST.Utility.MathHelp;
using CST.Element;
namespace CST.Loads
{
	public class TractionForce
	{
		public Node StartNode { get; set; }
		public Node EndNode { get; set; }
		public double Length => Sqrt(Pow(StartNode.X - EndNode.X, 2) + Pow(StartNode.Y - EndNode.Y, 2));
		public double F1 { get; set; }
		public double F2 { get; set; }
		public double Angle { get; set; }
		private double slope => Atan((EndNode.Y - StartNode.Y) / (EndNode.X - StartNode.X));
		public LoadDirection loadDirection { get; set; }

		/// <summary>
		/// Intialize TractionForce Parameter. For no angle input, angle is zero that represent aligned horizontally
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <param name="f1"></param>
		/// <param name="f2"></param>
		public TractionForce(Node n1, Node n2, double f1, double f2)
		{
			StartNode = n1;
			EndNode = n2;
			F1 = f1;
			F2 = f2;
			Angle = 0;
			loadDirection = LoadDirection.GlobalDirection;

		}

		/// <summary>
		/// Constructor which takes additional parameter like LoadDirection and Angle 
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <param name="f1"></param>
		/// <param name="f2"></param>
		/// <param name="ld"></param>
		/// <param name="angle"></param>
		public TractionForce(Node n1, Node n2, double f1, double f2, LoadDirection ld, double angle) : this(n1, n2, f1, f2)
		{
			Angle = angle*PI/180;
			loadDirection = ld;
		}

		/// <summary>
		/// Initialize with default LoadDirection
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <param name="f1"></param>
		/// <param name="f2"></param>
		/// <param name="angle"></param>
		public TractionForce(Node n1, Node n2, double f1, double f2, double angle) : this(n1, n2, f1, f2)
		{
			Angle = angle * PI / 180;
			loadDirection = LoadDirection.GlobalDirection;
		}


	}
}
