using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model
{
	public class Token
	{
		public TokenConstants.Type Type { get; }

		public string Value { get; }

		public Token(string value, TokenConstants.Type type)
		{
			Type = type;
			Value = value;
		}
	}
}