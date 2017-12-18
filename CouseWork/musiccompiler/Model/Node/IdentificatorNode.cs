using System;
using System.Collections.Generic;
using System.Windows.Documents;
using CouseWork.musiccompiler.Api;
using static CouseWork.musiccompiler.Api.EIdentificator;

namespace CouseWork.musiccompiler.Model.Node
{
	public class IdentificatorNode : Node
	{
		public EIdentificator Identificator { get; }

		public IdentificatorNode(EIdentificator identificator)
		{
			Identificator = identificator;
		}

		public override List<INote> Compile()
		{
			List<INote> melody = new List<INote>();
			switch (Identificator)
			{
				case Repeat:
					Node notes = Children[0];
					int repetions = ((NumberNode) Children[1]).Value;

					for (int i = 0; i < repetions; i++)
					{
						melody.AddRange(notes.Compile());
					}
					break;
				case Sleep:
					for (int i = 0; i < ((NumberNode) Children[0]).Value; i++)
					{
						melody.Add(new Note(ENote.N0));
					}
					break;
				case Thread:
					List<List<INote>> compile = new List<List<INote>>();
					foreach (var child in Children)
					{
						compile.Add(child.Compile());
					}
					int maxLenght = GetMaxLenght(compile);
					for (int i = 0; i < maxLenght; i++)
					{
						NoteComposite composite = new NoteComposite();
						foreach (List<INote> list in compile)
						{
							ENote note;
							try
							{
								note = ((Note) list[i]).Value;
							}
							catch (Exception)
							{
								note = ENote.N0;
							}
							composite.Add(note);
						}
						melody.Add(composite);
					}
					break;
			}
			return melody;
		}

		private int GetMaxLenght(List<List<INote>> lists)
		{
			int value = 0;
			foreach (var list in lists)
			{
				var lenght = list.Count;
				if (lenght > value)
				{
					value = lenght;
				}
			}
			return value;
		}
	}
}