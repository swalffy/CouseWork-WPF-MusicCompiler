using System.Collections.Generic;

namespace CouseWork.musiccompiler.Api
{
	public static class TokenConstants
	{
		public const char VariableStarter = '#';

		public const int VariableMaxLenght = 16;

		public static char Line { get; } = '\n';

		public static Dictionary<Note, string> Notes { get; } = new Dictionary<Note, string>()
		{
			{Note.N0, "n0"},
			{Note.N1, "n1"},
			{Note.N2, "n2"},
			{Note.N3, "n3"},
			{Note.N4, "n4"},
			{Note.N5, "n5"},
			{Note.N6, "n6"},
			{Note.N7, "n7"}
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
			Variable
		}
	}
}