using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST
{
	public class NodalLoad
	{
		public double Fx { get; set; }
		public double Fy { get; set; }
		public double F { get; set; }
		public double AngleFromHorizontal { get; set; }

		public NodalLoad() { }
		public NodalLoad(double fx,double fy)
		{
			Fx = fx;
			Fy = fy;
		}
		public NodalLoad(double f,double angleFormHorizontal)
		{
			F = f;
			Fx = f * cos;
			Fy = fy;
		}
	}

}
