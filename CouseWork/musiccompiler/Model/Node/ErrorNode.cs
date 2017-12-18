using System.Collections.Generic;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model.Node
{
	public class ErrorNode : Node
	{

		public string Error { get; }

		public ErrorNode(string error)
		{
			Error = error;
		}

		public override List<INote> Compile()
		{
//			TODO errors
			return base.Compile();
		}
	}
}