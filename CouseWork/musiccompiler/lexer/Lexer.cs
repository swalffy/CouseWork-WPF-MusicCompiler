using System;
using System.IO;
using System.Text;
using CouseWork.musiccompiler.utils;

namespace CouseWork.musiccompiler.lexer
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
					token.Type = TokenConstants.Type.Empty;
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
					else if (true)
					{
						// TODO variable implimentation
					}
				}
				else
				{
					return token;
				}
			}
			return token;
		}
	}
}