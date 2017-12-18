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
			MusicPlayer vm = Compiler.Instance.Compile(input);
			List<INote> notes = vm.Notes;

			Assert.AreEqual(9, notes.Count);
			Assert.AreEqual(ENote.N1, ((Note) notes[0]).Value);
			Assert.AreEqual(ENote.N3, ((Note) notes[8]).Value);

			input = "#Var n1n2n3 \n repeat #Var 3";
			vm = Compiler.Instance.Compile(input);
			notes = vm.Notes;

			Assert.AreEqual(9, notes.Count);
			Assert.AreEqual(ENote.N1, ((Note) notes[0]).Value);
			Assert.AreEqual(ENote.N3, ((Note) notes[8]).Value);
		}

		[TestMethod]
		public void SleepTest()
		{
			string input = "sleep 3";
			MusicPlayer vm = Compiler.Instance.Compile(input);
			List<INote> notes = vm.Notes;

			Assert.AreEqual(3, notes.Count);
			Assert.AreEqual(ENote.N0, ((Note)notes[0]).Value);
			Assert.AreEqual(ENote.N0, ((Note)notes[1]).Value);
			Assert.AreEqual(ENote.N0, ((Note)notes[2]).Value);
		}

		[TestMethod]
		public void ThreadTest()
		{
			string input = "#var n2n3n1n2 \n #qwe n1n2n3 \n thread #var #qwe";
			VariableMemory.ReserMemory();
			MusicPlayer vm = Compiler.Instance.Compile(input);
			var notes = vm.Notes;

			Assert.AreEqual(4, notes.Count);
			Assert.AreEqual(ENote.N2, ((NoteComposite) notes[0]).Note[0]);
			Assert.AreEqual(ENote.N1, ((NoteComposite) notes[0]).Note[1]);

			Assert.AreEqual(ENote.N3, ((NoteComposite) notes[1]).Note[0]);
			Assert.AreEqual(ENote.N2, ((NoteComposite) notes[1]).Note[1]);

			Assert.AreEqual(ENote.N1, ((NoteComposite) notes[2]).Note[0]);
			Assert.AreEqual(ENote.N3, ((NoteComposite) notes[2]).Note[1]);

			Assert.AreEqual(ENote.N2, ((NoteComposite) notes[3]).Note[0]);
			Assert.AreEqual(ENote.N0, ((NoteComposite) notes[3]).Note[1]);
		}
	}
}