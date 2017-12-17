﻿using System.Collections.Generic;
using System.Windows;

namespace CouseWork.musiccompiler.Model.Node
{
	public class MelodyNode : ANode
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