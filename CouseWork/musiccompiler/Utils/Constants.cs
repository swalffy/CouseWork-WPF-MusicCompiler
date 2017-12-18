using System.Collections.Generic;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Utils
{
	public static class Constants
	{
		public const char VariableStarterSymbol = '#';

		public const int VariableMaxLenght = 16;

		public static char EndCommandSymbol { get; } = '\n';

		public static Dictionary<string, Note> Notes { get; } = new Dictionary<string, Note>()
		{
			{"n0", Note.N0},
			{"n1", Note.N1},
			{"n2", Note.N2},
			{"n3", Note.N3},
			{"n4", Note.N4},
			{"n5", Note.N5},
			{"n6", Note.N6},
			{"n7", Note.N7}
		};

		public static Dictionary<Identificator, string> Identificators { get; } = new Dictionary<Identificator, string>()
		{
			{Identificator.Repeat, "repeat"},
			{Identificator.Sleep, "sleep"},
			{Identificator.Thread, "thread"},
		};

		public enum TokenType
		{
			Nullable,
			Error,
			Number,
			Note,
			Line,
			Identificator,
			Variable,
			Final
		}
	}
}