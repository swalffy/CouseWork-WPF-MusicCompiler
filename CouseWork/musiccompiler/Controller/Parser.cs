using System.Collections.Generic;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Model;
using CouseWork.musiccompiler.Model.Node;

namespace CouseWork.musiccompiler.Controller
{
	public static class Parser
	{
		public static List<Token> ListOfTokens { get; private set; }

		public static int Index;

		public static Node Parse(string input)
		{
			Index = 0;
			ListOfTokens = new Lexer(input).GetTokens();

			Node node = new Node();
			while (Index < ListOfTokens.Count)
			{
				Node temp = Statement();
				if (temp != null)
				{
					node.AddChild(temp);
				}
			}
			return node;
		}

		private static Node Statement()
		{
			Token token = ListOfTokens[Index++];
			Node node = null;
			Node temp;
			switch (token.Type)
			{
				case TokenConstants.Type.Identificator:
					if (token.Value.Equals(TokenConstants.Identificators[Identificator.Repeat]))
					{
						node = new IdentificatorNode(Identificator.Repeat);
						temp = Statement();
						if (temp is VariableNode || temp is MelodyNode)
						{
							node.AddChild(temp);
						}
						else
						{
							node.AddChild(new ErrorNode("Variable or notes"));
						}
						temp = Statement();
						if (temp is NumberNode)
						{
							node.AddChild(temp);
						}
						else
						{
							node.AddChild(new ErrorNode("Number value requered"));
						}
					}
					else if (token.Value.Equals(TokenConstants.Identificators[Identificator.Sleep]))
					{
						node = new IdentificatorNode(Identificator.Sleep);
						temp = Statement();
						if (temp is NumberNode)
						{
							node.AddChild(temp);
						}
						else
						{
							node.AddChild(new ErrorNode("Number value requered"));
						}
					}
					else if (token.Value.Equals(TokenConstants.Identificators[Identificator.Thread]))
					{
						node = new IdentificatorNode(Identificator.Thread);
						do
						{
							temp = Statement();
							if (temp is VariableNode)
							{
								node.AddChild(temp);
							}
							else
							{
								node.AddChild(new ErrorNode("Variable requered"));
							}
						} while (ListOfTokens[Index].Type != TokenConstants.Type.Line);
					}
					break;
				case TokenConstants.Type.Note:
					node = ParseNotes();
					break;
				case TokenConstants.Type.Variable:
					node = new VariableNode(token.Value);

					break;
				case TokenConstants.Type.Number:
					node = new NumberNode(int.Parse(token.Value));
					break;
			}

			return node;
		}

		private static MelodyNode ParseNotes()
		{
			MelodyNode melody = new MelodyNode();
			Token token = ListOfTokens[Index++ - 1];
			while (token.Type == TokenConstants.Type.Note)
			{
				melody.AddNote(token);
				token = ListOfTokens[Index++ - 1];
			}
			Index -= 2;
			return melody;
		}
	}
}