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
	/// Interaction logic for ImportForm.xaml
	/// </summary>
	public partial class ImportForm : Window
	{
		public ImportForm()
		{
			InitializeComponent();
		}

		private TextBox _target;
		private string _filename;

		public ImportForm(TextBox textbox)
		{
			InitializeComponent();
			_target = textbox;
		}

		private void CanselButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void OpenButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				StringBuilder sb = new StringBuilder();
				using (StreamReader sr =
					File.OpenText(Properties.Resources.ResourcesFolderPath + @"/saved/" + FileName.Text + ".txt"))
				{
					string line = "";
					while ((line = sr.ReadLine()) != null)
					{
						sb.Append(line);
					}
				}
				_target.Text = sb.ToString();
			}
			catch (Exception)
			{
				_target.Text = "Wrong file";
			}
			Close();
		}

		private void FileName_GotFocus(object sender, RoutedEventArgs e)
		{
			FileName.Text = string.Empty;
		}
	}
}