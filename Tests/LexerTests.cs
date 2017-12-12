using System;
using CouseWork.musiccompiler.lexer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class LexerTests
	{
		[TestMethod]
		public void SingleSimbol()
		{
			const string actualToken = "+";

			var actualModel = Lexer.GetToken(actualToken);

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Symbol, actualType);
			Assert.IsTrue(TokenConstants.Symbols.ContainsKey(Char.Parse(actualToken)));
			Assert.AreEqual(actualToken, actualValue);
		}

		[TestMethod]
		public void FewSimbols()
		{
			const string actualToken = "+-";

			var actualModel = Lexer.GetToken(actualToken);

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Symbol, actualType);
			Assert.IsTrue(TokenConstants.Symbols.ContainsKey(actualToken[0]));
			Assert.AreEqual(actualToken[0].ToString(), actualValue);
		}

		[TestMethod]
		public void OneSymbolNumber()
		{
			const string actualToken = "5";

			var actualModel = Lexer.GetToken(actualToken);

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Number, actualType);
			Assert.AreEqual(actualToken, actualValue);
		}

		[TestMethod]
		public void IntegerNumber()
		{
			const string actualToken = "4568";

			var actualModel = Lexer.GetToken(actualToken);

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Number, actualType);
			Assert.AreEqual(actualToken, actualValue);
		}

		[TestMethod]
		public void CorrectIdentificator()
		{
			const string actualToken = "if";

			var actualModel = Lexer.GetToken(actualToken);

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;
			
			Assert.AreEqual(TokenConstants.Type.Identificator, actualType);
			Assert.AreEqual(actualToken, actualValue);
		}

		[TestMethod]
		public void WrongToken()
		{
			const string actualToken = "IasdF";

			var actualModel = Lexer.GetToken(actualToken);

			var actualType = actualModel.Type;

			Assert.AreEqual(TokenConstants.Type.Nullable, actualType);
		}
	}
}