using System.Text;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Utils;

namespace CouseWork.musiccompiler.Model
{
	public class Token
	{
		public Constants.TokenType Type { get; }

		public string Value { get; }

		public Token(string value, Constants.TokenType type)
		{
			Type = type;
			Value = value;
		}

		public override string ToString()
		{
		return $"Token : {Type} - {Value}";
		}
	}
}