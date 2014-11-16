using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace BatchCrop {
	class StringUtils {

		//檔案路徑陣列 → 檔案名稱陣列 → 檔案名稱字串
		public static string filePathArrayToFileString(string[] stringArray) {
			string arrayString = "";
			foreach (string s in stringArray) {
				arrayString += Path.GetFileName(s) + "\r\n";
			}
			return arrayString;
		}

		public static string filePathToName(string pathString) {
			string fileName = Path.GetFileName(pathString);
			int lastDot = fileName.LastIndexOf("."); //副檔名點最後一次出現的位置
			return fileName.Substring(0, lastDot-1); //傳回到最後一個點之前的字串
		}


	}
}
