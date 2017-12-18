using CouseWork.musiccompiler.Api;

namespace CouseWork.musiccompiler.Model
{
	public class Note : INote
	{
		public ENote Value { get; }

		public Note(ENote value)
		{
			Value = value;
		}

		public void Play()
		{
			
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}