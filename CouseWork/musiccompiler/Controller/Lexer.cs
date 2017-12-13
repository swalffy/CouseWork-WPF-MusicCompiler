using System.IO;
using System.Text;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Model;
using CouseWork.musiccompiler.utils;

namespace CouseWork.musiccompiler.Controller
{
	public static class Lexer
	{
		private static char GetNextChar(StreamReader reader)
		{

			return (char) reader.Read();
		}

		public static TokenModel GetToken(string line)
		{
			var reader = Utils.GetStreamFromString(line);
			var token = new TokenModel();
			var currentSymbol = GetNextChar(reader);

			while (token.Type.Equals(TokenConstants.Type.Nullable))
			{
				if (string.IsNullOrEmpty(line))
				{
					token.Type = TokenConstants.Type.Error;
				}
				else if (currentSymbol == ' ')
				{
					currentSymbol = GetNextChar(reader);
				}
				else if (TokenConstants.Symbols.ContainsKey(currentSymbol))
				{
					
					token.Type = TokenConstants.Type.Symbol;
					token.Value = currentSymbol.ToString();
					currentSymbol = GetNextChar(reader);
				}
				else if (char.IsDigit(currentSymbol))
				{
					int value = 0;

					do
					{
						value = value * 10 + int.Parse(currentSymbol.ToString());
						currentSymbol = GetNextChar(reader);
					} while (char.IsDigit(currentSymbol));
					token.Type = TokenConstants.Type.Number;
					token.Value = value.ToString();
				}
				else if (char.IsLetter(currentSymbol))
				{
					var sb = new StringBuilder();
					do
					{
						sb.Append(currentSymbol);
					} while (char.IsLetter(currentSymbol = GetNextChar(reader)));

					if (TokenConstants.Identificators.ContainsKey(sb.ToString()))
					{
						token.Type = TokenConstants.Type.Identificator;
						token.Value = sb.ToString();
					}
					else
					{
						token.Type = TokenConstants.Type.Error;
						token.Value = "Unexpected token";
//						TODO lexer error		
					}
				}
				else if (currentSymbol.Equals(TokenConstants.VariableStarter))
				{
					var sb = new StringBuilder();
					currentSymbol = GetNextChar(reader);
					if (char.IsLetter(currentSymbol))
					{
						do
						{
							sb.Append(currentSymbol);
						} while (char.IsLetterOrDigit(currentSymbol = GetNextChar(reader)));
						if (sb.Length < 24)
						{
							token.Type = TokenConstants.Type.Variable;
							token.Value = sb.ToString();
						}
						else
						{
							token.Type = TokenConstants.Type.Error;
							token.Value = "Too long variable name";
						}
					}
					else
					{
						token.Type = TokenConstants.Type.Error;
						token.Value = "Wrong variable name";
//						TODO lexer error
					}
				}
				else
				{
					token.Type = TokenConstants.Type.Error;
					token.Value = "Wrong Token";
//					TODO lexer error
				}
			}
			reader.Close();
			return token;
		}
	}
}