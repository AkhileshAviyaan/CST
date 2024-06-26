﻿using AllEnums;
using CST.Element;
using CST.Loads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CST.Utility.MathHelp;
namespace CST
{
	public class TestCollections
	{
		public CSTMain cst;
		public TestCollections()
		{
			cst = new CSTMain();
		}
		public void Test1()
		{
			Node n1 = new Node(0, 0, "n1");
			Node n2 = new Node(20, 0, "n2");
			Node n3 = new Node(10, 10 * Sqrt(3), "n3");
			List<Node> nodes = [n1, n2, n3];
			n1.NodalSupport = new NodalSupport(ENodalSupport.Hinge);
			n2.NodalSupport = new NodalSupport(ENodalSupport.Hinge);
			cst.Nodes.AddRange(nodes);

			cst.TractionForce.Add(new TractionForce(n2, n3, 0, 360, 30));
			cst.MaterialProp = new MaterialProperties(30e6, 0.3, 460, 0.3);

			cst.Solve();
			var disp = cst.U;
			var stress = cst.Stress;

		}
		public void Test2()
		{
			Node n1 = new Node(0, 0, "n1");
			Node n2 = new Node(0.4, 0, "n2");
			Node n3 = new Node(0.4, 0.4, "n3");
			List<Node> nodes = [n1, n2, n3];
			n1.NodalSupport = new NodalSupport(ENodalSupport.Fixed);
			n2.NodalSupport = new NodalSupport(ENodalSupport.Fixed);
			cst.Nodes.AddRange(nodes);

			cst.TractionForce.Add(new TractionForce(n2, n3, 25, 25, 0));
			cst.MaterialProp = new MaterialProperties(210e6, 0.008, 78.5, 0);

			cst.Solve();
			var disp = cst.U;
			var stress = cst.Stress;
		}
		public void Test3()
		{
			Node n1 = new Node(0, 0, "n1");
			Node n2 = new Node(0.1, 0, "n2");
			Node n3 = new Node(0.05, 0.05 * Sqrt(3), "n3");
			List<Node> nodes = [n1, n2, n3];
			n1.NodalSupport = new NodalSupport(ENodalSupport.Fixed);
			n2.NodalSupport = new NodalSupport(ENodalSupport.Fixed);
			cst.Nodes.AddRange(nodes);

			cst.TractionForce.Add(new TractionForce(n2, n3, 10, 10, 30));
			cst.MaterialProp = new MaterialProperties(210e6, 0.01, 78.5, 0.3);

			cst.Solve();
			var disp = cst.U;
			var stress = cst.Stress;
		}
		public void Test4()
		{
			Node n1 = new Node(0, 0.8, "n1");
			Node n2 = new Node(0, 0, "n2");
			Node n3 = new Node(0.6, 0.8, "n3");
			List<Node> nodes = [n1, n2, n3];
			n1.NodalSupport = new NodalSupport(ENodalSupport.Fixed);
			n3.NodalSupport = new NodalSupport(ENodalSupport.Fixed);
			cst.Nodes.AddRange(nodes);

			cst.TractionForce.Add(new TractionForce(n1, n2, 5, 5, 180));
			cst.MaterialProp = new MaterialProperties(200e6, 0.01, 0, 0.3);

			cst.Solve();
			var disp = cst.U;
			var stress = cst.Stress;
		}
	}
}
