// *********************************************************************************
// 1. 程式描述：志工資料匯出 – 共用
// 2. 撰寫人員：rong
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project
{
	/// <summary>
	/// 系統管理–專案共用
	/// </summary>
	public class d03Project
	{

		// =========================================================================
		/// <summary>
		/// 函式描述：取出志工基本資料對應內政部資料
		/// </summary>
		/// <param name="as_kind">要處理的種類(A:人員類別、B:縣市、C可服務時段)</param>
		/// <param name="as_data">處理內容</param>
		/// <returns>轉換後資訊</returns>
		static public string uf_Get_Volteer(string as_kind, string as_data)
		{
			// ##### 宣告變數 #####
			string ls_return = "";

			// 判斷傳入參數是否正確
			if (as_kind == null)
				as_kind = "";

			if (as_data == null)
				as_data = "";

			// 判斷是哪種要處理的種類，回傳其內容轉換後的資料 -------------- ☆ 1
			switch (as_kind.ToUpper())
			{
				// 人員類別，以內政部代碼_人員類別為準
				case "A":
					DataSet lds_data;
					DbMethods.uf_Retrieve_FromSQL(out lds_data, "SELECT RTrim(IsNull(hmd100a_posname,'')) as hmd100a_posname FROM hmd100a, hmd100b WHERE hmd100a_posid = hmd100b_posid AND hmd100b_active = '1' AND IsNull(hmd100a_stop,'N') = 'N' AND hmd100b_vid = '" + as_data.Trim() + "'");

					for (int i = 0; i < lds_data.Tables[0].Rows.Count; i++)
					{
						if (lds_data.Tables[0].Rows[i][0].ToString() == "志工隊隊長")
							ls_return += "L";
						else if (lds_data.Tables[0].Rows[i][0].ToString() == "志工隊副隊長")
							ls_return += "P";
					}

					// 沒有任何的職位時，就以志工類別代碼V回傳
					if (ls_return == "")
						ls_return = "V";

					break;

				// 縣市，以內政部代碼_縣市為準，比對志工系統內部對應的縣市代碼
				case "B":
					DbMethods.uf_ExecSQL("SELECT RTrim(IsNull(hca205_hca212id,'')) as hca205_hca212id FROM hca205 WHERE hca205_id = Substring('" + as_data.Trim() + "',1,3)", ref ls_return);

					switch (ls_return)
					{
						case "63000": ls_return = "A"; break;  //台北市
						case "10019": ls_return = "B"; break;  //台中市
						case "10017": ls_return = "C"; break;  //基隆市
						case "10021": ls_return = "D"; break;  //台南市
						case "64000": ls_return = "E"; break;  //高雄市
						case "10001": ls_return = "F"; break;  //台北縣
						case "10002": ls_return = "G"; break;  //宜蘭縣
						case "10003": ls_return = "H"; break;  //桃園縣
						case "10020": ls_return = "I"; break;  //嘉義市
						case "10004": ls_return = "J"; break;  //新竹縣
						case "10005": ls_return = "K"; break;  //苗栗縣
						case "10006": ls_return = "L"; break;  //台中縣
						case "10008": ls_return = "M"; break;  //南投縣
						case "10007": ls_return = "N"; break;  //彰化縣
						case "10018": ls_return = "O"; break;  //新竹市
						case "10009": ls_return = "P"; break;  //雲林縣
						case "10010": ls_return = "Q"; break;  //嘉義縣
						case "10011": ls_return = "R"; break;  //台南縣
						case "10012": ls_return = "S"; break;  //高雄縣
						case "10013": ls_return = "T"; break;  //屏東縣
						case "10015": ls_return = "U"; break;  //花蓮縣
						case "10014": ls_return = "V"; break;  //台東縣
						case "09020": ls_return = "W"; break;  //金門縣
						case "10016": ls_return = "X"; break;  //澎湖縣
						case "09007": ls_return = "Z"; break;  //連江縣
						default:
							break;
					}
					break;

				// 可服務時段，以內政部代碼_可服務時段為準，比對志工系統內部當初志工勾選可服務時間之給產生原則
				case "C":
					string ls_char = "";
					for (int i = 0; i < as_data.Length ; i++)
					{
						ls_char = as_data.Substring(i, 1);
						if (ls_return != "") ls_return += ",";
						if (ls_char.Trim() == "A") ls_return += "0_1";
						else if (ls_char.Trim() == "H") ls_return += "0_2";
						else if (ls_char.Trim() == "B") ls_return += "1_1";
						else if (ls_char.Trim() == "I") ls_return += "1_2";
						else if (ls_char.Trim() == "C") ls_return += "2_1";
						else if (ls_char.Trim() == "J") ls_return += "2_2";
						else if (ls_char.Trim() == "D") ls_return += "3_1";
						else if (ls_char.Trim() == "K") ls_return += "3_2";
						else if (ls_char.Trim() == "E") ls_return += "4_1";
						else if (ls_char.Trim() == "L") ls_return += "4_2";
						else if (ls_char.Trim() == "F") ls_return += "5_1";
						else if (ls_char.Trim() == "M") ls_return += "5_2";
						else if (ls_char.Trim() == "G") ls_return += "6_1";
						else if (ls_char.Trim() == "N") ls_return += "6_2";
					}
					break;
				//其它就直接關掉
				default:
					break;
			}

			return ls_return;
		}
	}
}
