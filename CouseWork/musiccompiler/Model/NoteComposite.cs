using System.Collections.Generic;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model
{
	public class NoteComposite : INote
	{
		public List<ENote> Note { get; }

		public NoteComposite()
		{
			Note = new List<ENote>();
		}

		public void Play()
		{
			foreach (var note in Note)
			{
			}
		}

		public void Add(ENote note)
		{
			Note.Add(note);
		}
	}
}