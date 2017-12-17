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
			Node root = Parser.Parse(inputString);

			Node actual = root.Children[0];
			VariableNode variable = actual.Children[0] as VariableNode;
			NumberNode number = actual.Children[1] as NumberNode;

			string actualVariableName = variable.Name;
			int actualCountOfRepetitions = number.Value;

			Assert.AreEqual(2, actual.Children.Count);
			Assert.AreEqual("Var", actualVariableName);
			Assert.AreEqual(2, actualCountOfRepetitions);

			inputString = "repeat n1n2n3 8 \n repeat #vari 5";
			root = Parser.Parse(inputString);

			actual = root.Children[0];
			MelodyNode melody = actual.Children[0] as MelodyNode;
			number = actual.Children[1] as NumberNode;

			actualCountOfRepetitions = number.Value;

			Assert.AreEqual(2, actual.Children.Count);
			Assert.AreEqual(3, melody.Notes.Count);
			Assert.AreEqual("n1", melody.Notes[0].Value);
			Assert.AreEqual(8, actualCountOfRepetitions);

			actual = root.Children[1];
			variable = actual.Children[0] as VariableNode;
			number = actual.Children[1] as NumberNode;

			actualVariableName = variable.Name;
			actualCountOfRepetitions = number.Value;

			Assert.AreEqual(2, actual.Children.Count);
			Assert.AreEqual("vari", actualVariableName);
			Assert.AreEqual(5, actualCountOfRepetitions);
		}

		[TestMethod]
		public void SleepParser()
		{
			string inputString = "sleep 1";
			Node actual = Parser.Parse(inputString).Children[0];

			NumberNode actualNumberNode = actual.Children[0] as NumberNode;
			int actualNumber = actualNumberNode.Value;

			Assert.AreEqual(1, actualNumber);
		}

		[TestMethod]
		public void ThreadParser()
		{
			string inputString = "thread #abc #adb #qwe";
			Node actual = Parser.Parse(inputString).Children[0];

			VariableNode actualVar1 = actual.Children[0] as VariableNode;
			VariableNode actualVar2 = actual.Children[1] as VariableNode;
			VariableNode actualVar3 = actual.Children[2] as VariableNode;

			string var1 = actualVar1.Name;
			string var2 = actualVar2.Name;
			string var3 = actualVar3.Name;

			Assert.AreEqual("abc", var1);
			Assert.AreEqual("adb", var2);
			Assert.AreEqual("qwe", var3);
		}


		[TestMethod]
		public void CompositeParser()
		{
			string inputString = "thread #abc #qwe \n sleep 2 \n repeat #abc 3\n sleep 1 \n repeat n2n1 2\n";
			Node root = Parser.Parse(inputString);

			var actualThread = root.Children[0] as IdentificatorNode;
			var actualSleep1 = root.Children[1] as IdentificatorNode;
			var actualRepeat1 = root.Children[2] as IdentificatorNode;
			var actualSleep2 = root.Children[3] as IdentificatorNode;
			var actualRepeat2 = root.Children[4] as IdentificatorNode;

			Assert.AreEqual("thread", actualThread.Identificator.ToString().ToLower());
			Assert.AreEqual("sleep", actualSleep1.Identificator.ToString().ToLower());
			Assert.AreEqual("repeat", actualRepeat1.Identificator.ToString().ToLower());
			Assert.AreEqual("sleep", actualSleep2.Identificator.ToString().ToLower());
			Assert.AreEqual("repeat", actualRepeat2.Identificator.ToString().ToLower());

			Assert.AreEqual(2, actualThread.Children.Count);
			Assert.AreEqual("qwe", ((VariableNode) actualThread.Children[1]).Name);

			Assert.AreEqual(2, ((NumberNode) actualSleep1.Children[0]).Value);

			Assert.AreEqual("abc", ((VariableNode) actualRepeat1.Children[0]).Name);
			Assert.AreEqual(3, ((NumberNode) actualRepeat1.Children[1]).Value);

			Assert.AreEqual(1, ((NumberNode)actualSleep2.Children[0]).Value);

			Assert.AreEqual(2, actualRepeat2.Children.Count);
			Assert.AreEqual(2, ((MelodyNode) actualRepeat2.Children[0]).Notes.Count);
			Assert.AreEqual("n2", ((MelodyNode) actualRepeat2.Children[0]).Notes[0].Value);
			Assert.AreEqual(2, ((NumberNode) actualRepeat2.Children[1]).Value);
		
		}
	}
}