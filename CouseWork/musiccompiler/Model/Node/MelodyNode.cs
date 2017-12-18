using System.Collections.Generic;
using System.Windows;
using CouseWork.musiccompiler.Api;

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

		public override List<Note> Execute()
		{
			List<Note> melody = new List<Note>();
			foreach (var token in Notes)
			{
				melody.Add(TokenConstants.Notes[token.Value]);
			}
			return melody;
		}
	}

}