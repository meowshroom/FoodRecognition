using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BatchCrop {
	class ImageUtils {

		public static Bitmap oriImage;
		public static Bitmap resizedImage;

		public static Image resizeImage(Image oriImg, int w, int h) { //▶裁切影像至適合預覽框大小
			oriImage = new Bitmap(oriImg);

			if (oriImg.Width < oriImg.Height) { //直向Image
				if (oriImg.Height > h) //太大即縮小
					resizedImage = new Bitmap(oriImage, oriImage.Width * h / oriImg.Height, h);
				else
					resizedImage = oriImage;
			}
			else { //橫向Image
				if (oriImg.Width > w) //太大即縮小
					resizedImage = new Bitmap(oriImage, w, oriImg.Height * w / oriImage.Width);
				else
					resizedImage = oriImage;
			}
				return resizedImage;
		}


	}
}
