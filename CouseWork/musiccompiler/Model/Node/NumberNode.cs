using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model.Node
{
	public class NumberNode : Api.Node
	{
		public int Value { get; }

		public NumberNode(int value)
		{
			Value = value;
		}
	}
}