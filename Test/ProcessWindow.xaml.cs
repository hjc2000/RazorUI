using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Test;
/// <summary>
/// ProcessWindow.xaml 的交互逻辑
/// </summary>
public partial class ProcessWindow : Window
{
	public ProcessWindow()
	{
		InitializeComponent();
		// 定义图像的宽度和高度
		int width = 320;
		int height = 240;

		// 计算图像的总像素数
		int totalPixels = width * height;

		// 创建一个字节数组，每个像素占用4个字节（R, G, B, A）
		byte[] pixels = new byte[totalPixels * 4];

		// 设置每个像素为绿色（RGB：0, 255, 0）
		for (int i = 0; i < totalPixels; i++)
		{
			// Green color: R=0, G=255, B=0, A=255 (fully opaque)
			pixels[(i * 4) + 0] = 0;   // Red
			pixels[(i * 4) + 1] = 255; // Green
			pixels[(i * 4) + 2] = 0;   // Blue
			pixels[(i * 4) + 3] = 255; // Alpha
		}

		// 创建 BitmapSource 对象
		BitmapSource greenImage = BitmapSource.Create(
			width,
			height,
			96, // DPI (dots per inch) in X dimension
			96, // DPI in Y dimension
			PixelFormats.Bgra32, // Pixel format (BGRA with 32 bits per pixel)
			null, // No palette required for this format
			pixels, // Pixel data
			width * 4); // Pixel stride (number of bytes per line)

		// 创建 Image 控件并设置其源
		image.Source = greenImage;
	}
}
