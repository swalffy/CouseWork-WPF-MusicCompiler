using System.IO;
using System.Text;

namespace CouseWork.musiccompiler.utils
{
	class Utils
	{
		public static StreamReader GetStreamFromString(string value)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(value);
			MemoryStream memoryStream = new MemoryStream(bytes);
			return new StreamReader(memoryStream);
		}
	}
}