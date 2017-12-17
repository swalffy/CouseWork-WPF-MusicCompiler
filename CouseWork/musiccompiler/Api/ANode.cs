using System.Collections.Generic;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model
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