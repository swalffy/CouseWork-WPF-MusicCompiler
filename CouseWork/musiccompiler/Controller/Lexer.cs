using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Model;

namespace CouseWork.musiccompiler.Controller
{
	public class Lexer
	{
		private const char FinalCodeChar = '>';

		private readonly string _code;

		private int _index;

		private char _currentCharacter;

		public Lexer(string code)
		{
			_index = 0;
			_code = code + '\n';
			_currentCharacter = GetNextChar();
		}

		public char GetNextChar()
		{
			try
			{
				return _code[_index++];
			}
			catch (IndexOutOfRangeException)
			{
				return FinalCodeChar;
			}
		}

		public List<Token> GetTokens()
		{
			List<Token> response = new List<Token>();
			Token token;
			while ((token = GetNextToken()).Type != TokenConstants.Type.Final )
			{
				response.Add(token);
			}
			return response;
		}

		public Token GetNextToken()
		{
			while (true)
			{
				if (string.IsNullOrEmpty(_code))
				{
					return new Token("EmptyLine", TokenConstants.Type.Error);
				}
				else if (_currentCharacter == ' ')
				{
					_currentCharacter = GetNextChar();
				}
				else if (_currentCharacter == FinalCodeChar)
				{
					return new Token(null, TokenConstants.Type.Final);
				}
				else if (_currentCharacter == TokenConstants.Line)
				{
					_currentCharacter = GetNextChar();
					return new Token(TokenConstants.Line.ToString(), TokenConstants.Type.Line);
				}
				else if (char.IsDigit(_currentCharacter))
				{
					return ParseNumberToken();
				}
				else if (char.IsLetter(_currentCharacter))
				{
					return NoteAndIdentifireParse();
				}
				else if (_currentCharacter.Equals(TokenConstants.VariableStarter))
				{
					return VariableParse();
				}
				else
				{
					return new Token("Wrong token", TokenConstants.Type.Error);
//					TODO lexer error
				}
			}
		}

		private Token VariableParse()
		{
			var sb = new StringBuilder();
			_currentCharacter = GetNextChar();
			if (char.IsLetter(_currentCharacter))
			{
				do
				{
					sb.Append(_currentCharacter);
				} while (char.IsLetterOrDigit(_currentCharacter = GetNextChar()));
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

		private Token NoteAndIdentifireParse()
		{
			var sb = new StringBuilder();
			do
			{
				sb.Append(_currentCharacter);
				if (TokenConstants.Notes.ContainsKey(sb.ToString()))
				{
					_currentCharacter = GetNextChar();
					return new Token(sb.ToString(), TokenConstants.Type.Note);
				}
			} while (char.IsLetterOrDigit(_currentCharacter = GetNextChar()));

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

		private Token ParseNumberToken()
		{
			int value = 0;

			do
			{
				value = value * 10 + int.Parse(_currentCharacter.ToString());
				_currentCharacter = GetNextChar();
			} while (char.IsDigit(_currentCharacter));
			return new Token(value.ToString(), TokenConstants.Type.Number);
		}
	}
}