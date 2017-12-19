using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CouseWork.musiccompiler.Controller;
using CouseWork.musiccompiler.Model;

namespace CouseWork
{
	public partial class MainWindow : Window
	{
		private MusicPlayer _player;

		private TextBox _console;

		public static string Filename;

		public MainWindow()
		{
			InitializeComponent();
			_console = ConsoleTextBox;
			PlayButton.IsEnabled = false;
		}

		private void Compile_Button_Click(object sender, RoutedEventArgs e)
		{
			ConsoleTextBox.Text = String.Empty;
			string code = EditorTextEdit.Text;
			try
			{
				_player = Compiler.Instance.Compile(code);
				if (_player.Notes.Count > 0)
				{
					PlayButton.IsEnabled = true;
				}
				else
				{
					ConsoleTextBox.Text = "You should correct your code mistakes";
				}
			}
			catch (Exception ex)
			{
				ConsoleTextBox.Text = ex.Message;
				PlayButton.IsEnabled = false;
			}
		}

		private void Exit_Button_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void Play_Button_Click(object sender, RoutedEventArgs e)
		{
			_player.PlayMusic();
		}

		private void Editor_TextEdit_TextChanged(object sender, TextChangedEventArgs e)
		{
			PlayButton.IsEnabled = false;
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.F1)
			{
				this._console.Text = "Help";
			}
		}

		private void Save_Button_Click(object sender, RoutedEventArgs e)
		{
			SaveForm save = new SaveForm(EditorTextEdit.Text);
			save.ShowDialog();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ImportForm import = new ImportForm(EditorTextEdit);
			import.ShowDialog();
		}
	}
}