using System.Collections.Generic;

namespace CouseWork.musiccompiler.Api
{
	public static class TokenConstants
	{
		public const char VariableStarter = '#';

		public const int VariableMaxLenght = 16;

		public static char Line { get; } = '\n';

		public static List<string> Notes { get; } = new List<string>()
		{
			"n0",
			"n1",
			"n2",
			"n3",
			"n4",
			"n5",
			"n6",
			"n7"
		};
		
		public static List<string> Identificators { get; } = new List<string>()
		{
			"repeat",
			"sleep",
			"thread",
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