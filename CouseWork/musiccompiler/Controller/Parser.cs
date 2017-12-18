using System.Collections.Generic;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Model;
using CouseWork.musiccompiler.Model.Node;
using CouseWork.musiccompiler.Utils;

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
				case Constants.TokenType.Identificator:
					if (token.Value.Equals(Constants.Identificators[EIdentificator.Repeat]))
					{
						node = new IdentificatorNode(EIdentificator.Repeat);
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
					else if (token.Value.Equals(Constants.Identificators[EIdentificator.Sleep]))
					{
						node = new IdentificatorNode(EIdentificator.Sleep);
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
					else if (token.Value.Equals(Constants.Identificators[EIdentificator.Thread]))
					{
						node = new IdentificatorNode(EIdentificator.Thread);
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
						} while (ListOfTokens[Index].Type != Constants.TokenType.Line);
					}
					break;
				case Constants.TokenType.Note:
					node = ParseNotes();
					break;
				case Constants.TokenType.Variable:
					if (!VariableMemory.Contains(token.Value))
					{
						if (ListOfTokens[Index].Type == Constants.TokenType.Note)
						{
							MelodyNode melody = ((MelodyNode) Statement());
							VariableMemory.Add(token.Value, melody);
							break;
						}
						else
						{
							node = new ErrorNode("No such variable");
						}
					}
					node = new VariableNode(token.Value);
					break;
				case Constants.TokenType.Number:
					node = new NumberNode(int.Parse(token.Value));
					break;
			}

			return node;
		}

		private static MelodyNode ParseNotes()
		{
			MelodyNode melody = new MelodyNode();
			Token token = ListOfTokens[Index++ - 1];

			while (token.Type == Constants.TokenType.Note)
			{
				melody.AddNote(token);
				token = ListOfTokens[Index++ - 1];
			}
			Index -= 2;
			return melody;
		}
	}
}