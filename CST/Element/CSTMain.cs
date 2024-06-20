﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using CST.Loads;
using CST.Utility;
using static CST.Utility.MathHelp;

namespace CST.Element
{
	public class CSTMain
	{
		public List<Node> Nodes { get; set; }
		public List<TractionForce> TractionForce { get; set; }
		public MaterialProperties MaterialProp { get; set; }
		public Matrix K { get; set; }
		public Matrix F { get; set; }
		public Matrix D { get; set; }
		public CSTMain()
		{
			Nodes = new List<Node>();
			TractionForce = new List<TractionForce>();
			MaterialProp = new MaterialProperties();
			K = new Matrix(6, 6);
			F = new Matrix(6, 1);
			D = new Matrix(6, 1);
		}
		void ComputeForce()
		{
			ComputeTractionForce();
			ComputeBodyForce();
		}
		void ComputeTractionForce()
		{
			foreach (var tf in TractionForce)
			{
				double firstExpression = MaterialProp.t * tf.Length / 6;
				double cos0 = Cos(tf.Angle);
				double sin0 = Sin(tf.Angle);
				tf.StartNode.nodalTractionForce.Fx = 2 * tf.F1 * cos0 + tf.F2 * cos0;
				tf.StartNode.nodalTractionForce.Fy = 2 * tf.F1 * sin0 + tf.F2 * sin0;
				tf.EndNode.nodalTractionForce.Fx = tf.F1 * cos0 + 2 * tf.F2 * cos0;
				tf.EndNode.nodalTractionForce.Fy = tf.F1 * sin0 + 2 * tf.F2 * sin0;
			}
		}
		void ComputeBodyForce()
		{
			double Area = 1 / 2 * Abs(Nodes[0].X * (Nodes[1].Y - Nodes[2].Y) + Nodes[1].X * (Nodes[2].Y - Nodes[0].Y) + Nodes[2].X * (Nodes[0].Y - Nodes[1].Y));
			MaterialProp.Area = Area;
			foreach (var node in Nodes)
			{
				node.BodyForceX = 0;
				node.BodyForceY = -MaterialProp.Gamma * Area * MaterialProp.t / 3;
			}
		}
		void ComputeStiffnessMatrix()
		{

			//Calculate D Matrix
			var mP = this.MaterialProp;
			Matrix D = new Matrix(3, 3);
			double firstExpD = mP.E / (1 - Pow(mP.Rho, 2));
			D.Data[0, 0] = D.Data[1, 1] = 1;
			D.Data[0, 1] = D.Data[1, 0] = mP.Rho;
			D.Data[0, 2] = D.Data[1, 2] = D.Data[2, 0] = D.Data[2, 1] = 0;
			D = firstExpD * D;


			//Calculate B Matrix
			var n = Nodes;
			double firstExpB = 1 / 2 * mP.Area;
			Matrix B = new Matrix(3, 6);
			double y23 = diff(n[1].Y, n[2].Y);
			double y31 = diff(n[2].Y, n[0].Y);
			double y12 = diff(n[0].Y, n[1].Y);
			double x32 = diff(n[2].X, n[1].X);
			double x13 = diff(n[0].X, n[2].X);
			double x21 = diff(n[1].X, n[0].X);

			B.Data = new double[,] { { y23, 0, y31, 0, y12, 0 }, { 0, x32, 0, x13, 0, x21 }, { x32, y23, x13, y31, x21, y12 } };
			B = firstExpB * B;


			this.K = mP.t * mP.Area * B.Transpose * D * B;
		}
		double diff(double a, double b) => a - b;
		void CalculateDisplacement()
		{

			//Initilize node number and compute displacement matrix
			int count = 0;
			foreach (var node in Nodes)
			{
				node.Id = count;
				this.F.Data[node.Id * 2 - 1, 1] = node.NodalLoad.Fx + node.BodyForceX + node.nodalTractionForce.Fx;
				this.F.Data[node.Id * 2, 1] = node.NodalLoad.Fy + node.BodyForceY + node.nodalTractionForce.Fx;
				this.
					D.Data[node.Id * 2 - 1, 1] = 0;
				this.
					D.Data[node.Id * 2, 1] = 0;
				count++;
			}

			List<int> usefulRC = [];
			//Calculate Reduced Force
			foreach (var node in Nodes)
			{
				if (node.NodalSupport is null)
				{
					usefulRC.Add(node.Id * 2 - 1);
					usefulRC.Add(node.Id * 2);
				}
				else
				{
					if (node.NodalSupport.UxRestrain == false)
					{
						usefulRC.Add(node.Id * 2 - 1);

					}
					if (node.NodalSupport.UyRestrain == false)
					{
						usefulRC.Add(node.Id * 2);
					}
				}
			}

			Matrix rF = new Matrix(usefulRC.Count, 1);
			Matrix rK = new Matrix(usefulRC.Count, usefulRC.Count);
			for (int i = 0; i < usefulRC.Count; i++)
			{
				for (int j = 0; j < usefulRC.Count; j++)
				{
					rK.Data[i, j] = this.K.Data[usefulRC[i], usefulRC[j]];
					rF.Data[i, j] = this.F.Data[usefulRC[i], usefulRC[j]];
				}
			}
		}
	}


}
