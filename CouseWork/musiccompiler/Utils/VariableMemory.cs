using System.Collections.Generic;
using CouseWork.musiccompiler.Model.Node;

namespace CouseWork.musiccompiler.Utils
{
	public static class VariableMemory
	{
		private static readonly Dictionary<string, MelodyNode> Memory = new Dictionary<string, MelodyNode>();

		public static MelodyNode GetRecord(string name)
		{
			return Memory[name];
		}

		public static void Add(string name, MelodyNode melody)
		{
			Memory.Add(name, melody);
		}

		public static bool Contains(string name)
		{
			return Memory.ContainsKey(name);
		}

		public static Dictionary<string, MelodyNode> GetMemory()
		{
			return Memory;
		}

		public static void ReserMemory()
		{
			Memory.Clear();
		}
	}
}