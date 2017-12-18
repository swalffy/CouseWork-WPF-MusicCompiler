using System.Collections.Generic;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Controller;
using CouseWork.musiccompiler.Model;
using CouseWork.musiccompiler.Utils;
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
			List<INote> notes = vm.Notes;

			Assert.AreEqual(9, notes.Count);
			Assert.AreEqual(Note.N1, ((NoteClass) notes[0]).Note);
			Assert.AreEqual(Note.N3, ((NoteClass) notes[8]).Note);

			input = "#Var n1n2n3 \n repeat #Var 3";
			vm = Compiler.Instance.Compile(input);
			notes = vm.Notes;

			Assert.AreEqual(9, notes.Count);
			Assert.AreEqual(Note.N1, ((NoteClass) notes[0]).Note);
			Assert.AreEqual(Note.N3, ((NoteClass) notes[8]).Note);
		}

		[TestMethod]
		public void SleepTest()
		{
			string input = "sleep 3";
			VirtualMachine vm = Compiler.Instance.Compile(input);
			List<INote> notes = vm.Notes;

			Assert.AreEqual(3, notes.Count);
			Assert.AreEqual(Note.N0, ((NoteClass)notes[0]).Note);
			Assert.AreEqual(Note.N0, ((NoteClass)notes[1]).Note);
			Assert.AreEqual(Note.N0, ((NoteClass)notes[2]).Note);
		}

		[TestMethod]
		public void ThreadTest()
		{
			string input = "#var n2n3n1n2 \n #qwe n1n2n3 \n thread #var #qwe";
			VariableMemory.ReserMemory();
			VirtualMachine vm = Compiler.Instance.Compile(input);
			var notes = vm.Notes;

			Assert.AreEqual(4, notes.Count);
			Assert.AreEqual(Note.N2, ((NoteComposite) notes[0]).Note[0]);
			Assert.AreEqual(Note.N1, ((NoteComposite) notes[0]).Note[1]);

			Assert.AreEqual(Note.N3, ((NoteComposite) notes[1]).Note[0]);
			Assert.AreEqual(Note.N2, ((NoteComposite) notes[1]).Note[1]);

			Assert.AreEqual(Note.N1, ((NoteComposite) notes[2]).Note[0]);
			Assert.AreEqual(Note.N3, ((NoteComposite) notes[2]).Note[1]);

			Assert.AreEqual(Note.N2, ((NoteComposite) notes[3]).Note[0]);
			Assert.AreEqual(Note.N0, ((NoteComposite) notes[3]).Note[1]);
		}
	}
}