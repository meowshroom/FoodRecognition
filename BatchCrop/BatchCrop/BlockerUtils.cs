using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BatchCrop {
	class BlockerUtils {

		public static void setBlockerPosition(Label upper, Label lower, Label left, Label right, PictureBox picBox) {
			upper.Left = upper.Top = lower.Left = left.Left = 0;
			upper.Width = ImageUtils.resizedImage.Width;
			upper.Height = ImageCrop.yT;

			lower.Width = ImageUtils.resizedImage.Width;
			lower.Top = ImageCrop.yB;
			lower.Height = ImageUtils.resizedImage.Height - ImageCrop.yB;

			left.Top = right.Top = ImageCrop.yT;
			left.Height = right.Height =ImageCrop.yB - ImageCrop.yT;

			left.Width = ImageCrop.xL;
			right.Width = ImageUtils.resizedImage.Width - ImageCrop.xR;

			right.Left = ImageCrop.xR;
		}


		public static void setBlockerVisibility(Label upper, Label lower, Label left, Label right, Boolean visibility) {
			upper.Visible = visibility;
			lower.Visible = visibility;
			left.Visible = visibility;
			right.Visible = visibility;
		}

		public static void setBlockerColor(Label upper, Label lower, Label left, Label right, Color color) {
			upper.BackColor = color;
			lower.BackColor = color;
			left.BackColor = color;
			right.BackColor = color;
		}

	}
}
