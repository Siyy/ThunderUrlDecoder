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
			Loaded += Page_Loaded;
			//SizeChanged += Page_SizeChanged;
		}

		//private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
		//{
		//	实际效果很差：既没有达到设计目标（保持夹缩的区域正中圆形不变），
		//	却带来了无法避免输入输出文本被圆心按钮遮挡的问题（过大、过小窗体的极端情况下更明显）。
		//	Pinch.AspectRatio = MainPanel.ActualHeight/(double)MainPanel.ActualWidth;
		//}

		dynamic VM => DataContext;

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DataContext = new System.Dynamic.ExpandoObject();
			VM.Input = "支持多行迅雷地址。";
			VM.Output = "输出多行解码后地址。";
		}

		private void Decoder_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			var sr = new StringReader(VM.Input);
			var sb = new StringBuilder();
			try
			{
				for (var s = ""; null != s; s = sr.ReadLine())
				{
					var bs = Convert.FromBase64String(s);
					var l = System.Text.Encoding.UTF8.GetString(bs);
					sb.AppendLine(l);
				}
				VM.Output = sb.ToString();
			}
			catch (Exception err)
			{
				VM.Output = err.Message;
			}

		}
	}
}
