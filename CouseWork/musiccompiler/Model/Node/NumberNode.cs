using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model.Node
{
	public class NumberNode : ANode
	{
		public int Value { get; }

		public NumberNode(int value)
		{
			Value = value;
		}
	}
}