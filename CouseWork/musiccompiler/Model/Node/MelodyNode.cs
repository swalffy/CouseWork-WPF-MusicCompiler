using System.Collections.Generic;
using System.Windows;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Utils;

namespace CouseWork.musiccompiler.Model.Node
{
	public class MelodyNode : Node
	{
		public List<Token> Notes { get; }

		public MelodyNode (){
			Notes = new List<Token>();
		}

		public void AddNote(Token node){
			Notes.Add(node);
		}

		public override List<INote> Compile()
		{
			List<INote> melody = new List<INote>();
			foreach (var token in Notes)
			{
				melody.Add(new NoteClass(Constants.Notes[token.Value]));
			}
			return melody;
		}
	}

}