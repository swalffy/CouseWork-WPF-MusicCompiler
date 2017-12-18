using System.Collections.Generic;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Controller;
using CouseWork.musiccompiler.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.tests
{
	[TestClass]
	public class CompilerTests
	{
		[TestMethod]
		public void SimpleCompile()
		{
			string input = "repeat n1n2n3 3";
			VirtualMachine vm = Compiler.Instance.Compile(input);

			Assert.AreEqual(9, vm.Notes.Count);
			Assert.AreEqual(Note.N1, vm.Notes[0]);
			Assert.AreEqual(Note.N3, vm.Notes[vm.Notes.Count-1]);

			input = "sleep 3";
			notes = Compiler.Instance.Compile(input);

			Assert.AreEqual(3, notes.Count);
			Assert.AreEqual(Note.N0, notes[0]);
			Assert.AreEqual(Note.N0, notes[1]);
			Assert.AreEqual(Note.N0, notes[2]);
		}
	}
}
