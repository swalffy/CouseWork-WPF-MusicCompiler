using System.Collections.Generic;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model.Node
{
	public class Node : ICompiler
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

		public virtual List<INote> Compile()
		{
			List<INote> melody = new List<INote>();
			foreach (var child in Children)
			{
				melody.AddRange(child.Compile());
			}
			return melody;
		}
	}
}