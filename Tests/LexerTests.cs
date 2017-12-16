using System;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class LexerTests
	{
		[TestMethod]
		public void SingleNote()
		{
			const string actualToken = "n2";

			var actualModel = new Lexer(actualToken).GetNextToken();

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Note, actualType);
			Assert.AreEqual(actualToken, actualValue);
		}

		[TestMethod]
		public void FewNotes()
		{
			const string actualToken = "n1n2";

			Lexer lexer = new Lexer(actualToken);
			var actualModel = lexer.GetNextToken();

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Note, actualType);
			Assert.AreEqual(actualToken[0].ToString() + actualToken[1].ToString(), actualValue);

			actualModel = lexer.GetNextToken();
			actualType = actualModel.Type;
			actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Note, actualType);
			Assert.AreEqual(actualToken[2].ToString() + actualToken[3].ToString(), actualValue);
		}

		[TestMethod]
		public void OneSymbolNumber()
		{
			const string actualToken = "5";

			var actualModel = new Lexer(actualToken).GetNextToken();

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Number, actualType);
			Assert.AreEqual(actualToken, actualValue);
		}

		[TestMethod]
		public void IntegerNumber()
		{
			const string actualToken = "4568";

			var actualModel = new Lexer(actualToken).GetNextToken();

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Number, actualType);
			Assert.AreEqual(actualToken, actualValue);
		}

		[TestMethod]
		public void CorrectIdentificator()
		{
			const string actualToken = "repeat";

			var actualModel = new Lexer(actualToken).GetNextToken();

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Identificator, actualType);
			Assert.AreEqual(actualToken, actualValue);
		}

		[TestMethod]
		public void VariableToken()
		{
			const string actualToken = "#Var";

			var actualModel = new Lexer(actualToken).GetNextToken();

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Variable, actualType);
			Assert.AreEqual("Var", actualValue);
		}

		[TestMethod]
		public void WrongVariable()
		{
			const string actualToken = "#25";

			var actualModel = new Lexer(actualToken).GetNextToken();

			var actualType = actualModel.Type;
			var actualValue = actualModel.Value;

			Assert.AreEqual(TokenConstants.Type.Error, actualType);
		}

		[TestMethod]
		public void WrongToken()
		{
			const string actualToken = "IasdF";

			var actualModel = new Lexer(actualToken).GetNextToken();

			var actualType = actualModel.Type;

			Assert.AreEqual(TokenConstants.Type.Error, actualType);
		}
	}
}