using System.Collections.Generic;
using System.Windows;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model.Node
{
	public class MelodyNode : Api.Node
	{
		public List<Token> Notes { get; }

		public MelodyNode (){
			Notes = new List<Token>();
		}

		public void AddNote(Token node){
			Notes.Add(node);
		}
	}
}