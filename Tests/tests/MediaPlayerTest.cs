using System;
using CouseWork.musiccompiler.Controller;
using CouseWork.musiccompiler.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.tests
{
	[TestClass]
	public class MediaPlayerTest
	{
		[TestMethod]
		public void SoundTest()
		{
			string input = "n1";
			MusicPlayer player = Compiler.Instance.Compile(input);
			player.PlayMusic();

			input = "repeat n1n1n2n2n3n3n4n5n6n6n7 3";
			player = Compiler.Instance.Compile(input);
			player.PlayMusic();

		}

		[TestMethod]
		public void ParallelSound()
		{
			string input = "#var n1n5n7 \n #qwe n2n3n1 \n thread #var #qwe";
			MusicPlayer player = Compiler.Instance.Compile(input);
			player.PlayMusic();
		}
	}
}
