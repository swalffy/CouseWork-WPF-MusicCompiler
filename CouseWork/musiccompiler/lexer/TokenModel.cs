namespace CouseWork.musiccompiler.lexer
{
	public class TokenModel
	{
		public TokenConstants.Type Type { get; set; }

		public string Value { get; set; }

		public TokenModel()
		{
			Type = TokenConstants.Type.Nullable;
			Value = "";
		}
	}
}