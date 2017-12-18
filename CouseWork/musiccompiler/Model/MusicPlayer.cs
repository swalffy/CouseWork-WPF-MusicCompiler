using System.Collections.Generic;
using System.Media;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model
{
	public class MusicPlayer
	{
		
		public List<INote> Notes { get; set; }

		public MusicPlayer()
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

		public void PlayMusic()
		{
			foreach (var note in Notes)
			{
				note.Play();
			}
		}
	}
}