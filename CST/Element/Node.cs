using CST.Loads;

namespace CST.Element
{
    public class Node
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Label { get; set; }
        public NodalSupport NodalSupport { get; set; }
        public NodalLoad NodalLoad { get; set; }
        public Node()
        {
        }
        public Node(double x, double y, string label)
        {
            X = x;
            Y = y;
            Label = label;
        }
    }
}
