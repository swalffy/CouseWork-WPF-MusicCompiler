using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace CouseWork
{
	/// <summary>
	/// Interaction logic for SaveForm.xaml
	/// </summary>
	public partial class SaveForm : Window
	{
		private string _code;

		public SaveForm()
		{
			InitializeComponent();
		}

		public SaveForm(string code)
		{
			InitializeComponent();
			_code = code;
		}

		private void FileName_GotFocus(object sender, RoutedEventArgs e)
		{
			FileName.Text = String.Empty;
		}

		private void Button_Cansel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Button_Save_Click(object sender, RoutedEventArgs e)
		{
			using (StreamWriter file =
				new StreamWriter(Properties.Resources.ResourcesFolderPath + @"/saved/" + FileName.Text + ".txt"))
			{
				file.Write(_code);
			}
			Close();
		}
	}
}