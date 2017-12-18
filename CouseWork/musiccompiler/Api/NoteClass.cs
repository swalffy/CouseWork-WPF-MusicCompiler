namespace CouseWork.musiccompiler.Api
{
	public class NoteClass : INote
	{
		public Note Note { get; }

		public NoteClass(Note note)
		{
			Note = note;
		}

		public void Play()
		{
		}

		public override string ToString()
		{
			return Note.ToString();
		}
	}
}