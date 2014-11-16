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
		public MainWndForm() {//▶Constructor
			InitializeComponent();
			pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
			pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
			pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);

			//這樣設定(Parent關係)，透明度才會有作用
			Blocker_Upper.Parent = Blocker_Lower.Parent = Blocker_Left.Parent = Blocker_Right.Parent = pictureBox1;

			Blocker_Upper.BackColor = Blocker_Lower.BackColor = Blocker_Left.BackColor
				= Blocker_Right.BackColor = Color.FromArgb(160, Color.DarkCyan);

			BlockerUtils.setBlockerVisibility(Blocker_Upper, Blocker_Lower, Blocker_Left, Blocker_Right, false); //遮擋塊不可見
		}

		private void Form1_Load(object sender, EventArgs e) {//▶OnLoad
		}

		private void ImageRootLabel_Click(object sender, EventArgs e) { //▶選擇根目錄
			Dirs.getSubdirCollection();
			ImageRootLabel.Text = Dirs.rootDirPath;
			DirList.Text = StringUtils.filePathArrayToFileString(Dirs.dirCollection);//顯示目錄列表
			//允許開始
			StartLabel.Enabled = true;
		}


		private void StartLabel_Click(object sender, EventArgs e) {//▶開始
			StartLabel.Enabled = ImageRootLabel.Enabled = false;
			pictureBox1.Enabled = btn_save.Enabled = btn_again.Enabled = true;

			Dirs.dirIndex = 0;
			Dirs.imgIndex = 0;

			Dirs.nextDir(true); //指向第1(0)個資料夾
			ImageList.Text = Dirs.imgFileNameList; //顯示影像檔案列表

			Image thisImg = Image.FromFile(Dirs.thisImg()); //讀取影像
			thisImg = ImageUtils.resizeImage(thisImg, pictureBox1.Width, pictureBox1.Height);//縮放至適合大小
			pictureBox1.Image = thisImg;//顯示影像
		}

		/*▶↓圖片預覽框的滑鼠事件*/
		private bool isMouseDown;
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
			isMouseDown = true;
			pictureBox1_MouseMove(sender, e);
			BlockerUtils.setBlockerVisibility(Blocker_Upper, Blocker_Lower, Blocker_Left, Blocker_Right, true); //遮擋塊可見
		}
		private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
			if (!isMouseDown) return;
			ImageCrop.dig(e.X, e.Y);
			ImageCrop.setLabelText(YT_Label, YB_Label, XL_Label, XR_Label); //邊界顯示文字(上下左右)
			BlockerUtils.setBlockerPosition(Blocker_Upper, Blocker_Lower, Blocker_Left, Blocker_Right, pictureBox1); //遮擋塊位置
		}
		private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
			isMouseDown = false;
		}
		/*▶↑圖片預覽框的滑鼠事件*/

		private void btn_save_Click(object sender, EventArgs e) {//▶儲存，下一張圖片
			ImageCrop.clear(YT_Label, YB_Label, XL_Label, XR_Label);
			BlockerUtils.setBlockerVisibility(Blocker_Upper, Blocker_Lower, Blocker_Left, Blocker_Right, false); //遮擋塊不可見

			ImageCrop.recoverXY(); //將縮放後的座標回復為影像座標

			Dirs.thisDirDisplayStr += //用來顯示的文字
				"(" + ImageCrop.xL + "," + ImageCrop.yT + ") , (" + ImageCrop.xR + "," + ImageCrop.yB + ")\r\n";

			Dirs.thisDirBbInfoText += StringUtils.filePathToName(Dirs.thisImg()) +	" " + //即將寫入檔案的文字
				ImageCrop.xL + " " + ImageCrop.yT + " " + ImageCrop.xR + " " + ImageCrop.yB + "\r\n";

			if (Dirs.nextImg() == null) { this.Close(); return; }; //沒有下一張了，結束程式
			ImageList.Text = Dirs.imgFileNameList; //顯示(重製)影像檔案列表
			ImageBbList.Text = Dirs.thisDirDisplayStr; //顯示即將寫入檔案的文字

			Image thisImg = Image.FromFile(Dirs.thisImg()); //讀取影像
			thisImg = ImageUtils.resizeImage(thisImg, pictureBox1.Width, pictureBox1.Height);//縮放至適合大小
			pictureBox1.Image = thisImg;//顯示影像
		}

		private void btn_again_Click(object sender, EventArgs e) {//▶重來，清空
			ImageCrop.clear(YT_Label, YB_Label, XL_Label, XR_Label);
			BlockerUtils.setBlockerVisibility(Blocker_Upper, Blocker_Lower, Blocker_Left, Blocker_Right, false); //遮擋塊不可見
		}

	}
}
