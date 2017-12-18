using System.Collections.Generic;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model
{
	public class VirtualMachine
	{
		public List<INote> Notes { get; set; }

		public VirtualMachine()
		{
			Notes = new List<INote>();
		}

		public void Add(INote note)
		{
			Notes.Add(note);
		}

		public void Add(List<INote> notes)
		{
			Notes.AddRange(notes);
		}

		public void Execute()
		{
			foreach (var note in Notes)
			{
				note.Play();
			}
		}
	}
}