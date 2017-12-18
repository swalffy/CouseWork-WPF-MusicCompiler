using System.Collections.Generic;

namespace CouseWork.musiccompiler.Api
{
	public static class TokenConstants
	{
		public const char VariableStarter = '#';

		public const int VariableMaxLenght = 16;

		public static char Line { get; } = '\n';

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

		public enum Type
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