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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jiuyong
{
	/// <summary>
	/// ThunderUrlDecoderPage.xaml 的交互逻辑
	/// </summary>
	public partial class ThunderUrlDecoderPage : Page
	{
		public ThunderUrlDecoderPage()
		{
			InitializeComponent();
		}

		private void Decoder_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			var sr = new StringReader(inputBox.Text);
			var sb = new StringBuilder();
			for (var s = ""; null != s;s = sr.ReadLine())
			{
				var bs = Convert.FromBase64String(s);
				var l = System.Text.Encoding.UTF8.GetString(bs);
				sb.AppendLine(l);
			}
			outputBox.Text = sb.ToString();
		}
	}
}
