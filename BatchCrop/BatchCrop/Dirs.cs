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
		public static int dirIndex;

		public static String[] imgCollectionInDir;
		public static String imgFileNameList;
		public static int imgIndex;

		public static String thisDirDisplayStr; //用來顯示的字串
		public static String thisDirBbInfoText; //即將寫入檔案的字串

		public static StreamWriter thisBBInfoWriter;

		public static void getSubdirCollection() {//選擇圖片資料夾根目錄
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = @"X:\FoodRecognition\BatchCrop\待裁切的圖片"; //測試時使用
			DialogResult result = fbd.ShowDialog();

			//取得目標資料夾下的所有子資料夾
			rootDirPath = fbd.SelectedPath;
			dirCollection = Directory.GetDirectories(rootDirPath);
		}

		public static void getImgCollection() {//選擇目錄下的所有圖片
			var ext = new List<string> { ".jpg", ".jpeg", ".gif", ".png" };
			imgCollectionInDir = Directory.GetFiles(dirCollection[dirIndex]).Where(s => ext.Any(e => s.EndsWith(e))).ToArray();
		}

		public static String thisImg() {
			return imgCollectionInDir[imgIndex];
		}

		public static String nextImg() {//下一張圖片
			imgIndex++;
			if (imgIndex<imgCollectionInDir.Length)//這個資料夾有下一張圖片
				return thisImg();

			else if (nextDir(false)) //這個資料夾沒有下一張圖片，有下一個資料夾
				return thisImg();

			else//沒有下一個資料夾
				return null;
		}

		public static bool nextDir( bool isInit/*是否是開始*/ ) {//檢查有沒有下一個資料夾
			if (isInit) dirIndex = 0;
			else {//寫入檔案
				thisBBInfoWriter = new StreamWriter(dirCollection[dirIndex] + @"\bb_info.txt");//開檔
				thisBBInfoWriter.WriteLine("img x1 y1 x2 y2");
				thisBBInfoWriter.Write(thisDirBbInfoText);
				thisBBInfoWriter.Close();//關檔

				thisDirDisplayStr = ""; //即將寫入檔案的字串
				dirIndex++;
			}

			if (dirIndex < dirCollection.Length) Dirs.getImgCollection();//掃描資料夾下所有檔案
			else return false;//沒有資料夾了

			imgIndex = 0; //歸零imgIndex
			imgFileNameList = StringUtils.filePathArrayToFileString(imgCollectionInDir); //顯示 檔案名稱字串

			return true;
		}

	}
}
