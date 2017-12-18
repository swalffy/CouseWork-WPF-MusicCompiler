using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using CouseWork.musiccompiler.Api;
using CouseWork.musiccompiler.Model;
using CouseWork.musiccompiler.Model.Node;

namespace CouseWork.musiccompiler.Controller
{
	public class Compiler
	{
		private static Compiler _instance;

		private Node _rootNode;
		
		private Compiler()
		{
		}

		public static Compiler Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Compiler();
				}
				return _instance;
			}
		}

		public VirtualMachine Compile(string code)
		{
			VirtualMachine vm = new VirtualMachine();
			_rootNode = Parser.Parse(code);
			List<Note> melody = new List<Note>();
			foreach (var rootNodeChild in _rootNode.Children)
			{
				melody.AddRange(rootNodeChild.Execute());
			}
			return vm;
		}
	}
}