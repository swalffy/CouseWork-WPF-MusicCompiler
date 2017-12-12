using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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