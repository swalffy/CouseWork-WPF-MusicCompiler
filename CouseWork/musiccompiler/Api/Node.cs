using System.Collections.Generic;

namespace CouseWork.musiccompiler.Api
{
	public class Node
	{
		public List<Node> Children { get; }

		public Node()
		{
			Children = new List<Node>();
		}

		public void AddChild(Node node)
		{
			Children.Add(node);
		}

	}
}