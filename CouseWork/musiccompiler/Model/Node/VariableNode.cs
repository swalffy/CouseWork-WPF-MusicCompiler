using System.Collections.Generic;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model.Node
{
	public class VariableNode : Node
	{
		public string Name { get; }

		public VariableNode(string name)
		{
			Name = name;
		}

		public override List<Note> Execute()
		{
			List<Note> melody = new List<Note>();
//			TODO var impl

			return melody;
		}
	}
}