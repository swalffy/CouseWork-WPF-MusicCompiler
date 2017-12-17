using System.Collections.Generic;

namespace CouseWork.musiccompiler.Api
{
	public abstract class ANode
	{
		public List<ANode> Children { get; }

		protected ANode()
		{
			Children = new List<ANode>();
		}

		public void AddChild(ANode node)
		{
			Children.Add(node);
		}

	}
}