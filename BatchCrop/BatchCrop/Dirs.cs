using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace BatchCrop {
	class Dirs {

		public static String rootDirPath;
		public static String[] dirCollection;
		public static String[] imgCollectionInDir;
		
		public static void getSubdirCollection() {
			//選擇圖片資料夾根目錄
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = @"W:\食物辨識\20141112飯&蛋糕";
			DialogResult result = fbd.ShowDialog();

			//取得目標資料夾下的所有子資料夾
			rootDirPath = fbd.SelectedPath;
			dirCollection = Directory.GetDirectories(rootDirPath);
		}

		public static void getImgCollection(string subDir) {
			imgCollectionInDir = Directory.GetFiles(subDir);
		}

		
	}
}
