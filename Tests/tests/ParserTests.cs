using System.Collections.Generic;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Controller;
using CouseWork.musiccompiler.Model;
using CouseWork.musiccompiler.Model.Node;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class ParserTests
	{
		[TestMethod]
		public void RepeatParser()
		{
			string inputString = "repeat #Var 2";
			ANode actual = Parser.Parse(inputString);

			List<ANode> actualList = actual.Children;
			VariableNode variable = actualList[0] as VariableNode;
			NumberNode number = actualList[1] as NumberNode;

			string actualVariableName = variable.Name;
			int actualCountOfRepetitions = number.Value;

			Assert.AreEqual(2, actualList.Count);
			Assert.AreEqual("Var", actualVariableName);
			Assert.AreEqual(2, actualCountOfRepetitions);

			inputString = "repeat n1n2n3 8 \n repeat #Var 2";
			actual = Parser.Parse(inputString);

			actualList = actual.Children;
			MelodyNode melody = actualList[0] as MelodyNode;
			number = actualList[1] as NumberNode;

			actualCountOfRepetitions = number.Value;
			
			Assert.AreEqual(2, actualList.Count);
			Assert.AreEqual(3, melody.Notes.Count);
			Assert.AreEqual(8, actualCountOfRepetitions);


		}

	
	}
}