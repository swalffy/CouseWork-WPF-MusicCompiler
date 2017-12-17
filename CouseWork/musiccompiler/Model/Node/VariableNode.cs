using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model.Node
{
	public class VariableNode : Api.Node
	{
		public string Name { get; }

		public VariableNode(string name)
		{
			Name = name;
		}
	}
}