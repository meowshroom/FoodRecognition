using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace BatchCrop {
	public partial class MainWndForm : Form {
		public MainWndForm() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {

		}

		private void btn_save_Click(object sender, EventArgs e) {

		}

		private void ImageRootLabel_Click(object sender, EventArgs e) { //選擇根目錄
			Dirs.getSubdirCollection();
			ImageRootLabel.Text = Dirs.rootDirPath;
			DirList.Text = StringUtils.filePathArrayToFileString(Dirs.dirCollection);

		}


		private void StartLabel_Click(object sender, EventArgs e) {//開始

			foreach (String thisDir in Dirs.dirCollection){ //對每個子資料夾
				Dirs.getImgCollection(thisDir); //取得下面的所有影像
				ImageList.Text = StringUtils.filePathArrayToFileString(Dirs.imgCollectionInDir); //顯示影像檔案列表

				//創建bb_info.txt
				StreamWriter sw = new StreamWriter(thisDir + @"\bb_info.txt");

				foreach (String thisImgPath in Dirs.imgCollectionInDir){
					//顯示在右方
					Image thisImg = Image.FromFile(thisImgPath);
					//顯示XY座標

					//寫入檔案
				}

			}

		}



	}
}
