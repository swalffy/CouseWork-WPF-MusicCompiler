using System.Collections.Generic;

namespace CouseWork.musiccompiler.Api
{
	public interface ICompiler
	{
		List<INote> Compile();
	}
}