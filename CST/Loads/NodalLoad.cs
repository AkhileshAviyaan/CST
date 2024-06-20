using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CST.Utility.MathHelp;
using static CST.Utility.MathHelp;
namespace CST.Loads
{
	public class NodalLoad
	{
		public double Fx
		{
			get
			{
				return this.F * Cos(this.AngleFromHorizontal);
			}
			set { Fx = value; }
		}
		public double Fy
		{
			get
			{
				return this.F * Sin(this.AngleFromHorizontal);
			}
			set { Fy = value; }
		}
		public double F { get; set; }
		public double AngleFromHorizontal { get; set; }

		public NodalLoad() { }
		public NodalLoad(double fx, double fy)
		{
			Fx = fx;
			Fy = fy;
			F = Sqrt(Pow(fx, 2) + Pow(fy, 2));
			AngleFromHorizontal = Atan2(fx, fy);
		}
	}

}
