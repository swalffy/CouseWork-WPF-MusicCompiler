using System;
using System.Collections.Generic;
using CouseWork.musiccompiler.Api;
using static CouseWork.musiccompiler.Api.Identificator;

namespace CouseWork.musiccompiler.Model.Node
{
	public class IdentificatorNode : Node
	{
		public Identificator Identificator { get; }

		public IdentificatorNode(Identificator identificator)
		{
			Identificator = identificator;
		}

		public override List<Note> Execute()
		{
			List<Note> melody = new List<Note>();
			switch (Identificator)
			{
				case Repeat:
					for (int i = 0; i < ((NumberNode)Children[1]).Value; i++)
					{
						melody.AddRange(Children[0].Execute());
					}
					break;
				case Sleep:
					for (int i = 0; i < ((NumberNode) Children[0]).Value; i++)
					{
						melody.Add(Note.N0);
					}
					break;
				case Thread:
//					TODO thread impl
					break;
			}
			return melody;
		}
	}
}