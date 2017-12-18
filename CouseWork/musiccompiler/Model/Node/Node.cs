using System.Collections.Generic;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model.Node
{
	public class Node : IExecutor
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


		public virtual List<Note> Execute()
		{
			List<Note> melody = new List<Note>();
			foreach (var child in Children)
			{
				melody.AddRange(child.Execute());
			}
			return melody;
		}
	}
}