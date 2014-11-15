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


	}
}
