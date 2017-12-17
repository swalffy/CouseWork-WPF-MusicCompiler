using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model.Node
{
	public class VariableNode : ANode
	{
		public string Name { get; }

		public VariableNode(string name)
		{
			Name = name;
		}
	}
}