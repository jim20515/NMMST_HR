// *********************************************************************************
// 1. 程式描述：系統管理–專案共用
// 2. 撰寫人員：QFLin
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project
{
    /// <summary>
    /// 系統管理–專案共用
    /// </summary>
    public class d01Project
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
            string ls_sql = "";
            string ls_no, ls_maxno = null;
            int li_len = 0, li_flen = 0;	// li_len：流水號的長度，li_flen：編號規格碼的長度
            string[] lsa_startswith;

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

                //註解: T098-00000
                case "hmd101.hmd101_tid":

                    // 得到規格碼的長度
                    li_flen = as_startswith.Length;
                    li_len = 5;				// 流水號位數

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    //ls_sql = "SELECT 'T' + RIGHT('0'+Cast((Year(getDate())-1911) as varchar(3)),3) + '-' + RIGHT('00000'+ Convert(varchar(10), IsNull(Max(Cast(Right(hmd101_tid,5) as int)), 0) + 1) , 5 ) as no " +
                    //			"FROM hmd101 ";

                    ls_sql = "SELECT CAST(IsNull(Max(Cast(Right(hmd101_tid,5) as int)), '0') as varchar(5)) FROM hmd101 ";

                    break;

                // ------------------------------------------------- ★ 職位編號
                // "P" + 民國年(3位) + 流水號(9位)
                case "hmd100a.hmd100a_posid":

                    // 得到規格碼的長度
                    as_startswith = "P" + Convert.ToInt16(DbMethods.uf_GetDate().Year - 1911).ToString("000") + "-";

                    // 得到規格碼的長度
                    li_flen = as_startswith.Length;

                    li_len = 9;			// 流水號 9 位

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    ls_sql = "SELECT IsNull(Max(SubString(hmd100a_posid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hmd100a " +
                                "WHERE SubString(hmd100a_posid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;

                default:
                    break;
            }

            // 實際取出最大編號的資料 ------------------------------ ☆ 2
            DbMethods.uf_ExecSQL(ls_sql, ref ls_maxno);

            // 判斷是否有最大的編號，沒有則從 1 開始 --------------- ☆ 3
            if (ls_maxno == null || ls_maxno == "")				// 表格中沒有資料
                ls_no = as_startswith + Convert.ToString(1).PadLeft(li_len, '0');
            else
                ls_no = as_startswith + Convert.ToString(Convert.ToInt64(ls_maxno) + 1).PadLeft(li_len, '0');

            return ls_no;
        }
    }
}
