// *********************************************************************************
// 1. 程式描述：系統管理–專案共用
// 2. 撰寫人員：Jing
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project
{
	/// <summary>
	/// 系統管理–專案共用
	/// </summary>
	public class a02Project
	{
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

				// ------------------------------------------------- ★ 人員類別代碼
				// 流水號(smallint)
				case "hca201.hca201_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca201_id), 0)) as no " +
								"FROM hca201 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★ 員工部門代碼
				// 流水號(smallint)
				case "hca202.hca202_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca202_id), 0)) as no " +
								"FROM hca202 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★ 學歷代碼
				// 流水號(smallint)
				case "hca203.hca203_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca203_id), 0)) as no " +
								"FROM hca203 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★ 職業代碼
				// 流水號(smallint)
				case "hca204.hca204_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca204_id), 0)) as no " +
								"FROM hca204 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★ 通訊地址代碼
				// 流水號(smallint)
				case "hca205.hca205_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca205_id), 0)) as no " +
								"FROM hca205 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★志工階級代碼
				// 流水號(smallint)
				case "hca206.hca206_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca206_id), 0)) as no " +
								"FROM hca206 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★志工代碼
				// 流水號(smallint)
				case "hca207.hca207_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca207_id), 0)) as no " +
								"FROM hca207 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★離隊原因代碼
				// 流水號(smallint)
				case "hca208.hca208_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca208_id), 0)) as no " +
								"FROM hca208 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★報到地點代碼
				// 流水號(smallint)
				case "hca209.hca209_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca209_id), 0)) as no " +
								"FROM hca209 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★費用金額代碼
				// 流水號(smallint)
				case "hca210.hca210_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca210_id), 0)) as no " +
								"FROM hca210 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				// ------------------------------------------------- ★錯誤代碼
				// 流水號(smallint)
				case "hca211.hca211_id":

					// 得到規格碼的長度
					li_flen = as_startswith.Length;

					li_len = 0;				// 流水號 0 位

					// 找出資料庫中最大的編號–且規格碼符合傳入的值
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca211_id), 0)) as no " +
								"FROM hca211 ";

					// 清除掉規格碼
					as_startswith = "";

					break;

				
                 //●EntityAddHere!

                 //註解：
                 case "hmd100a.hmd100a_posid":

                 	li_flen = as_startswith.Length;
                 	li_len = 5;
                 	ls_sql = "SELECT CAST(IsNull(Max(Cast(Right(hmd100a_posid,5) as int)), '0') as varchar(5)) FROM hmd100a ";
                 	
                 	break;



                           default:
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
	}
}
