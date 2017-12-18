using System.Collections.Generic;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Utils;

namespace CouseWork.musiccompiler.Model.Node
{
	public class VariableNode : Node
	{
		public string Name { get; }

		public VariableNode(string name)
		{
			Name = name;
		}

		public override List<INote> Compile()
		{
			return VariableMemory.GetRecord(Name).Compile();
		}
	}
}