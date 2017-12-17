using CouseWork.musiccompiler.Api;
using static CouseWork.musiccompiler.Api.Identificator;

namespace CouseWork.musiccompiler.Model.Node
{
	public class IdentificatorNode : ANode
	{
		private Identificator _identificator;

		public IdentificatorNode(Identificator identificator)
		{
			_identificator = identificator;
		}
	}
}