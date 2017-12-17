using System.IO;
using System.Text;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Model;
using CouseWork.musiccompiler.utils;

namespace CouseWork.musiccompiler.Controller
{
	public class Lexer
	{
		private readonly StreamReader _reader;

		public Lexer(string line)
		{
			if (string.IsNullOrEmpty(line))
			{
				_reader = StreamReader.Null;
			}
			else
			{
				_reader = Utils.GetStreamFromString(line);
			}
		}

		~Lexer()
		{
			_reader.Close();
		}

		private char GetNextChar()
		{
			return (char) _reader.Read();
		}

		public Token GetNextToken()
		{
			var currentSymbol = GetNextChar();

			while (true)
			{
				if (_reader == null)
				{
					return new Token("EmptyLine", TokenConstants.Type.Error);
				}
				else if (currentSymbol == ' ')
				{
					currentSymbol = GetNextChar();
				}
				else if (currentSymbol == TokenConstants.Line)
				{
					return new Token(TokenConstants.Line.ToString(), TokenConstants.Type.Line);
				}
				else if (char.IsDigit(currentSymbol))
				{
					int value = 0;

					do
					{
						value = value * 10 + int.Parse(currentSymbol.ToString());
						currentSymbol = GetNextChar();
					} while (char.IsDigit(currentSymbol));
					return new Token(value.ToString(), TokenConstants.Type.Number);
				}
				else if (char.IsLetter(currentSymbol))
				{
					var sb = new StringBuilder();
					do
					{
						sb.Append(currentSymbol);
						if (TokenConstants.Notes.ContainsValue(sb.ToString()))
						{
							return new Token(sb.ToString(), TokenConstants.Type.Note);
						}
					} while (char.IsLetterOrDigit(currentSymbol = GetNextChar()));

					if (TokenConstants.Identificators.ContainsValue(sb.ToString()))
					{
						return new Token(sb.ToString(), TokenConstants.Type.Identificator);
					}
					else
					{
						return new Token("Unexpected token", TokenConstants.Type.Error);
//						TODO lexer error		
					}
				}
				else if (currentSymbol.Equals(TokenConstants.VariableStarter))
				{
					var sb = new StringBuilder();
					currentSymbol = GetNextChar();
					if (char.IsLetter(currentSymbol))
					{
						do
						{
							sb.Append(currentSymbol);
						} while (char.IsLetterOrDigit(currentSymbol = GetNextChar()));
						if (sb.Length < TokenConstants.VariableMaxLenght)
						{
							return new Token(sb.ToString(), TokenConstants.Type.Variable);
						}
						else
						{
							return new Token("Too long variable name", TokenConstants.Type.Error);
						}
					}
					else
					{
						return new Token("Wrong variable name", TokenConstants.Type.Error);
//						TODO lexer error
					}
				}
				else
				{
					return new Token("Wrong token", TokenConstants.Type.Error);
//					TODO lexer error
				}
			}
		}
	}
}