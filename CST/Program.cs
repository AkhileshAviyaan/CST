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
			TestCollections test = new();
			test.Test1();
			var disp=test.cst.U;
			var stress=test.cst.Stress;
		}
	}
}
