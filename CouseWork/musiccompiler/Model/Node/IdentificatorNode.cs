using static CouseWork.musiccompiler.Api.ParserConstants;

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