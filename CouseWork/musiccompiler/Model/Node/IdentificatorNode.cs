using CouseWork.musiccompiler.Api;
using static CouseWork.musiccompiler.Api.Identificator;

namespace CouseWork.musiccompiler.Model.Node
{
	public class IdentificatorNode : Api.Node
	{
		public Identificator Identificator { get; }

		public IdentificatorNode(Identificator identificator)
		{
			Identificator = identificator;
		}
	}
}