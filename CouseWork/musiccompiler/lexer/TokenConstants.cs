using System.Collections.Generic;

namespace CouseWork.musiccompiler.lexer
{
	public static class TokenConstants
	{
		public static Dictionary<char, Symbol> Symbols { get; } = new Dictionary<char, Symbol>()
		{
			{'=', Symbol.Equals},
			{'+', Symbol.Plus},
			{'-', Symbol.Plus},
			{'\n', Symbol.Line},
			{'\t', Symbol.Tab}
		};

		public static Dictionary<string, Identificator> Identificators { get; } = new Dictionary<string, Identificator>()
		{
			{"if", Identificator.If},
			{"else", Identificator.Else},
			{"while", Identificator.While}
		};

		public enum Type
		{
			Nullable,
			Empty,
			Number,
			Symbol,
			Identificator
		}

		public enum Symbol
		{
			Equals,
			Plus,
			Minus,
			Line,
			Tab
		}

		public enum Identificator
		{
			If,
			While,
			Else,
			Repeat,
			Thread
		}
	}
}