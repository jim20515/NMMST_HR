// *********************************************************************************
// 1. 程式描述：服務勤務管理–專案共用
// 2. 撰寫人員：Emily
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project
{
	/// <summary>
	/// 系統管理–專案共用
	/// </summary>
	public class c01Project
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

                // ------------------------------------------------- ★ 博物館之友代碼
                // "F" + 民國年(3位) + 流水號(6位)
                case "hmc101.hmc101_id":

                    // 得到規格碼的長度
                    as_startswith = "F" + Convert.ToString(DbMethods.uf_GetDate().Year - 1911).PadLeft(3, '0')+"-";
                    li_flen = as_startswith.Length;

                    li_len = 6;			// 流水號 6 位

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    ls_sql = "SELECT IsNull(Max(SubString(hmc101_id, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hmc101 " +
                                "WHERE SubString(hmc101_id, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;    
                

                 //------------------------------------------------- ★ hmc102分類階層代碼
                // int 流水號
                case "hmc102.hmc102_id":

                    // 得到規格碼的長度
                    li_flen = as_startswith.Length;

                    li_len = 0;			// 流水號 0 位

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    ls_sql = " SELECT IsNull(Convert(varchar(5) , Max(hmc102_id)), '0') as no FROM hmc102 ";

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

        // =========================================================================
        /// <summary>
        /// 函式描述：計算班次
        /// </summary>
        /// <param name="ao_psid">排班表代碼</param>
        /// <returns>班次數量</returns>
        //static public string uf_rcount(object ao_psid)
        //{
        //    int li_count = 0;
        //    if (ao_psid != null)
        //    {
        //        DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "'", ref li_count);
        //    }
        //    return li_count.ToString();
        //}

        // =========================================================================
        /// <summary>
        /// 函式描述：計算人次
        /// </summary>
        /// <param name="ao_psid">排班表代碼</param>
        /// <returns>人次數量</returns>
        //static public string uf_pcount(object ao_psid)
        //{
        //    int li_count = 0;
        //    if (ao_psid != null)
        //    {
        //        DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE (hme101c_pdid IN (SELECT hme101b_pdid FROM hme101b WHERE (hme101b_psid = '" + ao_psid.ToString().Trim() + "')))", ref li_count);
        //    }
        //    return li_count.ToString();
        //}

        // =========================================================================
        // 函式
        // =========================================================================
        /// <summary>
        /// 函式描述：取得日期所屬的週次
        /// </summary>
        /// <param name="adt_Date">日期</param>
        /// <returns>日期所屬的週次</returns>
    //    static public int uf_GetWeek(DateTime adt_Date)
    //    {
    //        // ##### 宣告變數 #####
    //        DateTime ldt_MonthFirstDay, ldt_FirstWeekStartDay;
    //        int li_weekday;
    //        TimeSpan lts_period;

    //        // 取得當月第一天，並判斷是星期幾
    //        ldt_MonthFirstDay = new DateTime(adt_Date.Year, adt_Date.Month, 1);
    //        li_weekday = Convert.ToInt16(ldt_MonthFirstDay.DayOfWeek);

    //        // 取得當月第一週的第一天(星期日)的日期
    //        ldt_FirstWeekStartDay = ldt_MonthFirstDay.AddDays(-li_weekday);

    //        // 計算日期跟第一週的第一天相差幾天並計算出週次
    //        lts_period = adt_Date - ldt_FirstWeekStartDay;

    //        return 1 + Convert.ToInt16(Decimal.Truncate(Convert.ToDecimal(lts_period.TotalDays / 7)));
    //    }	// End of uf_GetWeek

    //    // =========================================================================
    //    // 函式
    //    // =========================================================================
    //    /// <summary>
    //    /// 函式描述：取得指定日期所屬的週次的開始及結束日期
    //    /// </summary>
    //    /// <param name="adt_Date">日期</param>
    //    /// <param name="adt_sDate">回傳開始日期(星期日)</param>
    //    /// <param name="adt_eDate">回傳結束日期(星期六)</param>
    //    static public void uf_GetWeekPeriod(DateTime adt_Date, out DateTime adt_sDate, out DateTime adt_eDate)
    //    {
    //        uf_GetWeekPeriod(adt_Date.Year, adt_Date.Month, uf_GetWeek(adt_Date), out adt_sDate, out adt_eDate);
    //    }	// End of uf_GetWeekPeriod(1)

    //    // =========================================================================
    //    // 函式
    //    // =========================================================================
    //    /// <summary>
    //    /// 函式描述：取得指定年度、月份、週次的開始及結束日期
    //    /// </summary>
    //    /// <param name="ao_Year">西元年度</param>
    //    /// <param name="ao_Month">月份</param>
    //    /// <param name="ao_Week">週次</param>
    //    /// <param name="adt_sDate">回傳開始日期(星期日)</param>
    //    /// <param name="adt_eDate">回傳結束日期(星期六)</param>
    //    static public void uf_GetWeekPeriod(object ao_Year, object ao_Month, object ao_Week, out DateTime adt_sDate, out DateTime adt_eDate)
    //    {
    //        // ##### 宣告變數 #####
    //        DateTime ldt_MonthFirstDay, ldt_FirstWeekStartDay;
    //        int li_weekday;

    //        // 取得當月第一天，並判斷是星期幾
    //        ldt_MonthFirstDay = new DateTime(Convert.ToInt16(ao_Year), Convert.ToInt16(ao_Month), 1);
    //        li_weekday = Convert.ToInt16(ldt_MonthFirstDay.DayOfWeek);

    //        // 取得當月第一週的第一天(星期日)的日期
    //        ldt_FirstWeekStartDay = ldt_MonthFirstDay.AddDays(-li_weekday);

    //        // 計算出開始日期
    //        adt_sDate = ldt_FirstWeekStartDay.AddDays(7 * (Convert.ToInt16(ao_Week) - 1));

    //        // 計算出開始日期
    //        adt_eDate = adt_sDate.AddDays(6);
    //    }	// End of uf_GetWeekPeriod(2)
    }
}
