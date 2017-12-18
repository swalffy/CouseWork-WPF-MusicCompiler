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

		public MusicPlayer Compile(string code)
		{
			MusicPlayer vm = new MusicPlayer();
			_rootNode = Parser.Parse(code);
			foreach (var rootNodeChild in _rootNode.Children)
			{
				vm.Add(rootNodeChild.Compile());
			}
			return vm;
		}
	}
}