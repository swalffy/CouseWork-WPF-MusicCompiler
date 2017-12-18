using System.Collections.Generic;

namespace CouseWork.musiccompiler.Api
{
	public class NoteComposite : INote
	{
		public List<Note> Note { get; }

		public NoteComposite()
		{
			Note = new List<Note>();
		}

		public void Play()
		{
			foreach (var note in Note)
			{
			}
		}

		public void Add(Note note)
		{
			Note.Add(note);
		}
	}
}