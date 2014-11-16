using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BatchCrop {
	class ImageCrop {

		public static bool hasStart = false;
		public static int xL, xR, yT, yB;
		public static int xLP, xRP, yTP, yBP;

		public static void clear(Label upper, Label lower, Label left, Label right) { //▶重設
			hasStart = false;
			upper.Text = "X(左) : ";
			lower.Text = "X(右) : ";
			left.Text = "Y(上) : ";
			right.Text = "Y(下) : ";
		}

		public static void start( int x, int y ) { //▶開始
			xL = x;
			xR = x;
			yT = y;
			yB = y;
			hasStart = true;
		}

		public static void dig(int x, int y) { //▶挖洞標記
			if (ImageUtils.resizedImage == null) return;

			//試挖
			if (!hasStart) start(x, y); 
			xL = (x < xL) ? x : xL;
			xR = (x > xR) ? x : xR;
			yT = (y < yT) ? y : yT;
			yB = (y > yB) ? y : yB;

			//檢查
			xL = (xL < 0) ? 0 : xL;
			xR = (xR > ImageUtils.resizedImage.Width-1) ? ImageUtils.resizedImage.Width-1 : xR;

			yT = (yT < 0) ? 0 : yT;
			yB = (yB > ImageUtils.resizedImage.Height-1) ? ImageUtils.resizedImage.Height-1 : yB;

			//計算%數
			xLP = (int)((double)xL*100) / (ImageUtils.resizedImage.Width - 1);
			xRP = (int)((double)xR * 100) / (ImageUtils.resizedImage.Width - 1);
			yTP = (int)((double)yT * 100) / (ImageUtils.resizedImage.Height - 1);
			yBP = (int)((double)yB * 100) / (ImageUtils.resizedImage.Height - 1);
		}

		public static void setLabelText(Label upper, Label lower, Label left, Label right) { //▶字
			upper.Text = "Y(上) : " + ImageCrop.yTP + @"%";
			lower.Text = "Y(下) : " + ImageCrop.yBP + @"%";
			left.Text = "X(左) : " + ImageCrop.xLP + @"%";
			right.Text = "X(右) : " + ImageCrop.xRP + @"%";
		}

		public static void recoverXY() { //▶還原縮放後的座標為原始座標
			double ratio = (double)ImageUtils.oriImage.Width / ImageUtils.resizedImage.Width;

			xL = (int)(xL * ratio);
			xR = (int)(xR * ratio);
			yT = (int)(yT * ratio);
			yB = (int)(yB * ratio);
			xR = (xR < ImageUtils.oriImage.Width) ? xR : ImageUtils.oriImage.Width - 1;
			yB = (yB < ImageUtils.oriImage.Height) ? yB : ImageUtils.oriImage.Height - 1;
		}

	}
}
