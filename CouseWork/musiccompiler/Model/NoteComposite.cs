using System.Collections.Generic;
using System.Media;
using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model
{
	public class NoteComposite : INote
	{
		public List<ENote> Note { get; }

		private static SoundPlayer _player = new SoundPlayer();

		public NoteComposite()
		{
			Note = new List<ENote>();
		}

		public void Play()
		{
			foreach (var note in Note)
			{
				_player.SoundLocation = Properties.Resources.ResourcesFolderPath + note + ".wav";
				_player.PlaySync();
			}
		}

		public void Add(ENote note)
		{
			Note.Add(note);
		}
	}
}