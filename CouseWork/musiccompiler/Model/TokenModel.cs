using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model
{
	public class TokenModel
	{
		public TokenConstants.Type Type { get; }

		public string Value { get; }

		public TokenModel(string value, TokenConstants.Type type)
		{
			Type = type;
			Value = value;
		}
	}
}