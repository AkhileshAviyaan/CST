
namespace CST
{
	public class Node
	{
		public double X { get; set; }
		public double Y {  get; set; }
		public double Label {  get; set; }
		public NodalSupport NodalSupport { get; set; }
		public NodalLoad NodalLoad { get; set; }
		public Node() 
		{
		}
		public Node(double x, double y, double label)
		{
			X = x;
			Y = y;
			Label = label;
		}
	}
}
