using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Model;
using CouseWork.musiccompiler.Model.Node;

namespace CouseWork.musiccompiler.Controller
{
	public static class Parser
	{
		private static Lexer _lexer;

		public static ANode Parse(string input)
		{
			_lexer = new Lexer(input);
			ANode node = Statement();

			return node;
		}

		private static ANode Statement()
		{
			Token token = _lexer.GetNextToken();
			ANode node = null;
			switch (token.Type)
			{
				case TokenConstants.Type.Identificator:
					switch (token.Value)
					{
						case "repeat":
							node = new IdentificatorNode(ParserConstants.Identificator.Repeat);
//							TODO end repeat statement
							node.AddChild(Statement());
							node.AddChild(Statement());
							break;
						case "sleep":
							break;
						case "thread":
							break;
					}
					break;
				case TokenConstants.Type.Note:
					node = GetSequenceOfNotes(token);
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

		private static MelodyNode GetSequenceOfNotes(Token token)
		{
			MelodyNode melody = new MelodyNode();
			do
			{
				melody.AddNote(token);
				token = _lexer.GetNextToken();
			} while (token.Type == TokenConstants.Type.Note);
			return melody;
		}
	}
}