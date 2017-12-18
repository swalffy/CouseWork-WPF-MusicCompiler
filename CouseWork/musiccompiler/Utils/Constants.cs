using System.Collections.Generic;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Utils
{
	public static class Constants
	{
		public const char VariableStarterSymbol = '#';

		public const int VariableMaxLenght = 16;

		public static char EndCommandSymbol { get; } = '\n';

		public static Dictionary<string, ENote> Notes { get; } = new Dictionary<string, ENote>()
		{
			{"n0", ENote.N0},
			{"n1", ENote.N1},
			{"n2", ENote.N2},
			{"n3", ENote.N3},
			{"n4", ENote.N4},
			{"n5", ENote.N5},
			{"n6", ENote.N6},
			{"n7", ENote.N7}
		};

		public static Dictionary<EIdentificator, string> Identificators { get; } = new Dictionary<EIdentificator, string>()
		{
			{EIdentificator.Repeat, "repeat"},
			{EIdentificator.Sleep, "sleep"},
			{EIdentificator.Thread, "thread"},
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