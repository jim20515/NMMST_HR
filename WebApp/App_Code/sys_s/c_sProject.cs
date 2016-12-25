// *********************************************************************************
// 1. 程式描述：系統管理–專案共用
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project.sys_s
{
	/// <summary>
	/// 系統管理–專案共用
	/// </summary>
	public class sProject
	{
		#region ☆ 編號處理 Methods --------------------------------------- 撰寫人員：fen

		// =========================================================================
		/// <summary>
		/// 函式描述：取出專案資料庫系統編號
		/// </summary>
		/// <param name="as_nokind">要取得系統編號的種類</param>
		/// <param name="as_startswith">系統編號開始規格碼</param>
		/// <returns>系統編號(找資料庫最大編碼再加上 1)</returns>
		static public string uf_Get_SystemNo(string as_nokind, string as_startswith)
		{
			// ##### 宣告變數 #####
			string		ls_sql = "";
			string		ls_no, ls_maxno = null;
			int			li_len = 0, li_flen = 0;	// li_len：流水號的長度，li_flen：編號規格碼的長度
			string[]	lsa_startswith;

			// 判斷傳入參數是否正確
			if (as_nokind == null)
				as_nokind = "";

			if (as_startswith == null)
				as_startswith = "";
			
			// 分解 as_startswith 到陣列中
			lsa_startswith = as_startswith.Split(',');
			
			// 判斷是哪個編號，設定取出最大編號的方式 -------------- ☆ 1
			switch (as_nokind.ToLower())
			{

				// ------------------------------------------------- ★ 公告編號
				// 西元年(4位) + 月(2位) + 日(2位) + 流水號(2位)
				case "sys07.s07_no" :

					// 得到規格碼的長度
					as_startswith = DbMethods.uf_GetDate().ToString("yyyyMMdd");
					li_flen = as_startswith.Length;

					li_len = 2;			// 流水號 2 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT IsNull(Max(SubString(s07_no, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
								"FROM sys07 " +
								"WHERE SubString(s07_no, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

					break;

				// ------------------------------------------------- ★ 現金支出核准權限表流水號
				// 流水號(int)
				case "trc36.c36_seq_no" :

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(c36_seq_no), 0)) as no " +
								"FROM trc36 " +
								"WHERE c36_com_code = " + lsa_startswith[0] + " " +
									"AND c36_sc_code = '" + lsa_startswith[1] + "' ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★ 匯款序號
				// 西元年(4位) + 月(2位) + 日(2位) + 流水號(4位)
				case "trm04.m04_output_no" :

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 4;			// 流水號 4 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT IsNull(Max(SubString(m04_output_no, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
								"FROM trm04 " +
								"WHERE SubString(m04_output_no, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

					break;

				// ------------------------------------------------- ★ 付款審核單分錄序號
				// 流水號(smallint)
				case "trm09.m09_seq_no" :

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(m09_seq_no), 0)) as no " +
								"FROM trm09 " +
								"WHERE m09_com_code = " + lsa_startswith[0] + " " +
									"AND m09_bill_no = " + lsa_startswith[1] + " ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				default :
					break;
			}

			// 實際取出最大編號的資料 ------------------------------ ☆ 2
			DbMethods.uf_ExecSQL(ls_sql, ref ls_maxno);

			// 判斷是否有找到符合的資料
			ls_maxno = ls_maxno.Trim();

			// 判斷是否有最大的編號，沒有則從 1 開始 --------------- ☆ 3
			if (ls_maxno == null || ls_maxno == "")				// 表格中沒有資料
				ls_no = as_startswith + Convert.ToString(1).PadLeft(li_len, '0');
			else
				ls_no = as_startswith + Convert.ToString(Convert.ToInt64(ls_maxno) + 1).PadLeft(li_len, '0');

			return ls_no;
		}

		#endregion

		#region ☆ 資料找尋 Methods --------------------------------------- 撰寫人員：fen

		#endregion

	}
}
