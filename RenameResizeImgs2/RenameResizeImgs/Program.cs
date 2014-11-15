using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace RenameResizeImgs
{
	class Program
	{
		static void Main(string[] args)
		{
			String[] DirCollection;
			String RootDirPath;

			String[] FileCollection;
			String ImgFileName;

			if (args.Length == 0)
				RootDirPath = @"B:\Caltech256";
			else
				RootDirPath = args[0];

			//取得目標資料夾下的所有子資料夾
			DirCollection = Directory.GetDirectories(RootDirPath);

			//創建資料夾
			if (!System.IO.Directory.Exists(RootDirPath + @"\OriImages"))
			{
				System.IO.Directory.CreateDirectory(RootDirPath + @"\OriImages");
			}
			if (!System.IO.Directory.Exists(RootDirPath + @"\SmallImages"))
			{
				System.IO.Directory.CreateDirectory(RootDirPath + @"\SmallImages");
			}

			Image ThisImg;
			Bitmap ImgOutput;
			int SmallerDimention;

			//對應的原檔案目錄，方便直接反查
			StreamWriter OutputFile = new StreamWriter(RootDirPath + @"\Index.TxT");
			StreamWriter LastOfEachStuffSet = new StreamWriter(RootDirPath + @"\LastOfEachStuffSet.TxT");

			int Counter=0;

			foreach (String ThisDir in DirCollection)
			{//對每個資料夾
				Console.WriteLine(ThisDir);
				FileCollection = Directory.GetFiles(ThisDir);

				foreach (String ImgFilePath in FileCollection)
				{//對每張圖片
					Counter++;
					Console.Write("╰" + new FileInfo(ImgFilePath).Name + " : ");
					
					//Read this Image
					ThisImg = Image.FromFile(ImgFilePath);
					//先複製一份放在OriImages
					File.Copy(ImgFilePath, RootDirPath + @"\OriImages\" + Counter + ".jpg", true);
					//將寬和高中較大者縮為300，較小者則被等比例縮放，然後存進SmallImages
					try
					{
						//如果寬和高都小於300，則使用原圖
						if (ThisImg.Width <= 300 && ThisImg.Height <= 300)
						{
							Console.WriteLine(ThisImg.Width+" , "+ThisImg.Height+" (No Need To Resize)");
							ImgOutput = new Bitmap(ThisImg, ThisImg.Width, ThisImg.Height);
						}
						else if (ThisImg.Width > ThisImg.Height)//橫圖
						{
							SmallerDimention = ThisImg.Height * 300 / ThisImg.Width;
							Console.WriteLine("300 , " + SmallerDimention);
							ImgOutput = new Bitmap(ThisImg, 300, SmallerDimention);
						}
						else//直圖
						{
							SmallerDimention = ThisImg.Width * 300 / ThisImg.Height;
							Console.WriteLine(SmallerDimention + " , 300");
							ImgOutput = new Bitmap(ThisImg, SmallerDimention, 300);
						}

						ImgOutput.Save(RootDirPath + @"\SmallImages\" + Counter + ".jpg", ImageFormat.Jpeg);
						ImgOutput.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine("Meow~~ Something Went Wrong");
					}
					//結束
					ThisImg.Dispose();
					OutputFile.WriteLine(new FileInfo(ImgFilePath).Name);

				}//對資料夾內的每張圖片

				LastOfEachStuffSet.WriteLine(Counter);
			}//對每個資料夾

			
			OutputFile.Close();
			LastOfEachStuffSet.Close();
			GC.Collect();

			Console.WriteLine("DONE");
			//Console.ReadKey();
		}//static void Main(string[] args)
	}//class Program
}
