using System.IO;
using System.Media;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Utils;

namespace CouseWork.musiccompiler.Model
{
	public class Note : INote
	{
		public ENote Value { get; }

		private static readonly SoundPlayer Player = new SoundPlayer();

		public Note(ENote value)
		{
			Value = value;
		}

		public void Play()
		{

			Player.SoundLocation = Properties.Resources.SoundsFolderPath + Value + ".wav";
			Player.PlaySync();
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}