// *********************************************************************************
// 1. 程式描述：服務勤務管理–專案共用
// 2. 撰寫人員：demon
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project
{
	/// <summary>
	/// 系統管理–專案共用
	/// </summary>
	public class e01Project
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

                // ------------------------------------------------- ★ 預排班表編號
                // "S" + 民國年(3位) + 流水號(6位)
                case "hme101a.hme101a_psid":

                    // 得到規格碼的長度
                    li_flen = as_startswith.Length;

                    li_len = 6;			// 流水號 6 位

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    ls_sql = "SELECT IsNull(Max(SubString(hme101a_psid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hme101a " +
                                "WHERE SubString(hme101a_psid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;

                // ------------------------------------------------- ★ 需求班次編號
                // "SR" + 民國年(3位) + 流水號(6位)
                case "hme101b.hme101b_pdid":

                    // 得到規格碼的長度
                    li_flen = as_startswith.Length;

                    li_len = 6;			// 流水號 6 位

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    ls_sql = "SELECT IsNull(Max(SubString(hme101b_pdid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hme101b " +
                                "WHERE SubString(hme101b_pdid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;


                // ------------------------------------------------- ★ 班表樣板編號
                // "ST" + 民國年(3位) + 流水號(6位)
                case "hme105a.hme105a_ssid":

                    // 得到規格碼的長度
                    as_startswith = "ST" + Convert.ToInt16(DbMethods.uf_GetDate().Year - 1911).ToString("000");

                    li_flen = as_startswith.Length;

                    li_len = 6;			// 流水號 6 位

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    ls_sql = "SELECT IsNull(Max(SubString(hme105a_ssid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hme105a " +
                                "WHERE SubString(hme105a_ssid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;

                // ------------------------------------------------- ★ 樣板需求編號
                // "TR" + 民國年(3位) + 流水號(6位)
                case "hme105b.hme105b_sdid":

                    // 得到規格碼的長度
                    as_startswith = "TR" + Convert.ToInt16(DbMethods.uf_GetDate().Year - 1911).ToString("000");

                    li_flen = as_startswith.Length;

                    li_len = 6;			// 流水號 6 位

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    ls_sql = "SELECT IsNull(Max(SubString(hme105b_sdid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hme105b " +
                                "WHERE SubString(hme105b_sdid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;

                // ------------------------------------------------- ★ 勤務紀錄編號
                // "Slog" + 流水號(9位)
                case "hle201.hle201_lid":

                    // 得到規格碼的長度
                    li_flen = as_startswith.Length;

                    li_len = 9;			// 流水號 9 位

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    ls_sql = "SELECT IsNull(Max(SubString(hle201_lid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hle201 " +
                                "WHERE SubString(hle201_lid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;

                // ------------------------------------------------- ★ 服勤表現編號
                // "R" + 民國年(3位) + 流水號(6位)
                case "hle501.hle501_plid":

                    // 得到規格碼的長度
                    li_flen = as_startswith.Length;

                    li_len = 6;			// 流水號 6 位

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    ls_sql = "SELECT IsNull(Max(SubString(hle501_plid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hle501 " +
                                "WHERE SubString(hle501_plid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

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
        /// 函式描述：計算需求班次
        /// </summary>
        /// <param name="ao_psid">排班表代碼</param>
        /// <returns>班次數量</returns>
        static public string uf_rcount(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "'", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算不足人數班次
        /// </summary>
        /// <param name="ao_psid">排班表代碼</param>
        /// <returns>班次數量</returns>
        static public string uf_rcount_short(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "' And hme101b_needno > ( SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid = hme101b_pdid ) ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算過多人數班次
        /// </summary>
        /// <param name="ao_psid">排班表代碼</param>
        /// <returns>班次數量</returns>
        static public string uf_rcount_more(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "' And hme101b_needno < ( SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid = hme101b_pdid )", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算滿足人數班次
        /// </summary>
        /// <param name="ao_psid">排班表代碼</param>
        /// <returns>班次數量</returns>
        static public string uf_rcount_satisfy(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "' And hme101b_needno = ( SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid = hme101b_pdid ) ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算需求人次
        /// </summary>
        /// <param name="ao_psid">排班表代碼</param>
        /// <returns>人次數量</returns>
        static public string uf_pcount(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT IsNull(SUM(hme101b_needno) , 0) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "'", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算已排人次
        /// </summary>
        /// <param name="ao_psid">排班表代碼</param>
        /// <returns>人次數量</returns>
        static public string uf_pcount_actual(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid in ( SELECT hme101b_pdid FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "' ) ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算已排人次
        /// </summary>
        /// <param name="ao_psid">排班需求代碼</param>
        /// <returns>人次數量</returns>
        static public string uf_pcount_hme101c(object ao_pdid)
        {
            int li_count = 0;
            if (ao_pdid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid  = '" + ao_pdid.ToString().Trim() + "' ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算已排人名
        /// </summary>
        /// <param name="ao_psid">排班需求代碼</param>
        /// <returns>人名</returns>
        static public string uf_pname_hme101c(object ao_pdid)
        {
            DataSet lds_data;
            int li_rowcount;
            string ls_datastring = "";

            if (ao_pdid != null)
            {
                // 利用 SQL 語法產生資料集
                DbMethods.uf_Retrieve_FromSQL(out lds_data, "SELECT hmc101.hmc101_cname FROM hme101c Inner Join hmd201 ON hmd201_vid = hme101c_vid Inner Join hmc101 ON hmc101_id = hmd201_id WHERE hme101c_pdid = '" + ao_pdid.ToString() + "' ");

                // 取得總筆數
                li_rowcount = lds_data.Tables[0].Rows.Count;

                ls_datastring = "";
                for (int li_row = 0; li_row <= (li_rowcount - 1); li_row++)
                {
                    ls_datastring += lds_data.Tables[0].Rows[li_row]["hmc101_cname"].ToString().Trim() + "、";
                }

                if (ls_datastring != "")
                {
                    ls_datastring = ls_datastring.Substring(0, ls_datastring.Length - 1);
                }
            }
            return ls_datastring;
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算該人在特定志工排班表下已排班次
        /// </summary>
        /// <param name="ao_vid">志工代碼</param>
        /// <param name="ao_psid">排班表代碼</param>
        /// <returns>班次數量</returns>
        static public string uf_pc_vid_all(object ao_vid, object ao_psid)
        {
            int li_count = 0;
            if (ao_vid != null && ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE hme101c_vid = '" + ao_vid.ToString() + "' AND hme101c_pdid in ( SELECT hme101b_pdid FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString() + "' )  ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算該人在特定志工排班表下已排時數
        /// </summary>
        /// <param name="ao_vid">志工代碼</param>
        /// <param name="ao_psid">排班表代碼</param>
        /// <returns>已排班時數</returns>
        static public string uf_ts_vid_all(object ao_vid, object ao_psid)
        {
            int li_count = 0;
            string ls_sql = "";
            if (ao_vid != null && ao_psid != null)
            {
                ls_sql = " SELECT IsNull(SUM(DateDiff(hh ,hme101b_starttime , hme101b_endtime)),0) " + 
                         "   FROM hme101b " +
                         "  WHERE hme101b_pdid in ( SELECT hme101c_pdid FROM hme101c WHERE hme101c_vid = '" + ao_vid.ToString() + "' ) " +
                         "    AND hme101b_psid = '" + ao_psid.ToString() + "'";
                DbMethods.uf_ExecSQL( ls_sql, ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算該人在特定志工排班表下已排班次，過濾傳入需求單號
        /// </summary>
        /// <param name="ao_vid">志工代碼</param>
        /// <param name="ao_psid">排班表代碼</param>
        /// <param name="ao_pdid">排班需求代碼</param>
        /// <returns>班次數量</returns>
        static public string uf_pc_vid_all(object ao_vid, object ao_psid, object ao_pdid)
        {
            int li_count = 0;
            if (ao_vid != null && ao_psid != null && ao_pdid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE hme101c_vid = '" + ao_vid.ToString() + "' AND hme101c_pdid in ( SELECT hme101b_pdid FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString() + "' ) AND hme101c_pdid <> '" + ao_pdid.ToString() + "' ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算該人在特定志工排班表下已排時數，過濾傳入需求單號
        /// </summary>
        /// <param name="ao_vid">志工代碼</param>
        /// <param name="ao_psid">排班表代碼</param>
        /// <param name="ao_pdid">排班需求代碼</param>
        /// <returns>已排班時數</returns>
        static public string uf_ts_vid_all(object ao_vid, object ao_psid, object ao_pdid)
        {
            int li_count = 0;
            string ls_sql = "";
            if (ao_vid != null && ao_psid != null && ao_pdid != null)
            {
                ls_sql = " SELECT IsNull(SUM(DateDiff(hh ,hme101b_starttime , hme101b_endtime)),0) " +
                         "   FROM hme101b " +
                         "  WHERE hme101b_pdid in ( SELECT hme101c_pdid FROM hme101c WHERE hme101c_vid = '" + ao_vid.ToString() + "' ) " +
                         "    AND hme101b_psid = '" + ao_psid.ToString() + "'" +
                         "    AND hme101b_pdid <> '" + ao_pdid.ToString() + "'";
                DbMethods.uf_ExecSQL(ls_sql, ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：需求班次時間
        /// </summary>
        /// <param name="ao_psid">排班需求代碼</param>
        /// <returns>需求班次時間</returns>
        static public string uf_get_hme101b_time(object ao_pdid)
        {
            DataSet lds_data;
            string ls_datastring = "";

            if (ao_pdid != null)
            {
                // 利用 SQL 語法產生資料集
                DbMethods.uf_Retrieve_FromSQL(out lds_data, "SELECT hme101b_sdate , hme101b_starttime , hme101b_endtime FROM hme101b WHERE hme101b_pdid = '" + ao_pdid.ToString() + "' ");

                if(  lds_data.Tables[0].Rows.Count > 0  )
                {
                    ls_datastring = DateMethods.uf_YYYY_To_YYY(lds_data.Tables[0].Rows[0]["hme101b_sdate"], false) + " " + Convert.ToDateTime(lds_data.Tables[0].Rows[0]["hme101b_starttime"]).ToString("HHmm") + " ~ " + Convert.ToDateTime(lds_data.Tables[0].Rows[0]["hme101b_endtime"]).ToString("HHmm");
                }
            }
            return ls_datastring;
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算特定志工隊、年度、季別之服勤表現總人數
        /// </summary>
        /// <param name="ao_tid">志工隊代碼</param>
        /// <param name="ao_syear">年度</param>
        /// <param name="ao_sseason">季別</param>
        /// <returns>服勤總人數</returns>
        static public string uf_hle501_pcount(object ao_tid , object ao_syear , object ao_sseason)
        {
            int li_count = 0;
            if (ao_tid != null && ao_syear != null && ao_sseason != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hle501 WHERE hle501_tid = '" + ao_tid.ToString().Trim() + "' And hle501_syear ='" + ao_syear.ToString() + "' AND hle501_sseason = '"+ ao_sseason.ToString() +"'", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算特定志工隊、年度、季別之服勤表現完成人數
        /// </summary>
        /// <param name="ao_tid">志工隊代碼</param>
        /// <param name="ao_syear">年度</param>
        /// <param name="ao_sseason">季別</param>
        /// <returns>服勤總人數</returns>
        static public string uf_hle501_fcount(object ao_tid, object ao_syear, object ao_sseason)
        {
            int li_count = 0;
            if (ao_tid != null && ao_syear != null && ao_sseason != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hle501 WHERE hle501_tid = '" + ao_tid.ToString().Trim() + "' And hle501_syear ='" + ao_syear.ToString() + "' AND hle501_sseason = '" + ao_sseason.ToString() + "' AND hle501_score is not null ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：計算兩個日期區間的時數，最小單位為0.5小時
        /// </summary>
        /// <param name="adt_sdate">開始日期</param>
        /// <param name="adt_edate">結束日期</param>
        /// <returns>相差時數</returns>
        static public float uf_GetHourPeriod(DateTime adt_sdate, DateTime adt_edate)
        {
            float lf_return = 0 ;
            int li_min = 0;
            TimeSpan lts_period;

            if (adt_sdate != null && adt_edate != null)
            {
                if (adt_sdate <= adt_edate)
                {
                    // 計算相差時間
                    lts_period = adt_edate - adt_sdate;
                    lf_return = lts_period.Hours;

                    li_min = lts_period.Minutes;
                    if (li_min >= 30)
                        lf_return += (float)0.5;
                }
            }
            return lf_return;
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：顯示人員基本分類
        /// </summary>
        /// <param name="ao_psid">基本資料代碼</param>
        /// <returns>基本分類</returns>
        static public string uf_get_hmc102(object ao_id)
        {
            DataSet lds_data;
            int li_rowcount , li_seq = 0;
            string ls_datastring = "";

            if (ao_id != null && ao_id.ToString() != "")
            {
                // 利用 SQL 語法產生資料集
                DbMethods.uf_Retrieve_FromSQL(out lds_data, "Select hmc102_name From hmc102 Where hmc102_id in ( SELECT hmc101_102.hmc102_id From hmc101_102 Where hmc101_102.hmc101_id = '" + ao_id.ToString() + "' ) AND hmc102_id <> 0");

                // 取得總筆數
                li_rowcount = lds_data.Tables[0].Rows.Count;

                ls_datastring = "";
                for (int li_row = 0; li_row <= (li_rowcount - 1); li_row++)
                {
                    if (li_seq > 5)
                    {
                        ls_datastring += "<BR />";
                        li_seq = 0;
                    }
                    li_seq++;
                    ls_datastring += lds_data.Tables[0].Rows[li_row]["hmc102_name"].ToString().Trim() + "，";
                }

                if (ls_datastring != "")
                {
                    ls_datastring = ls_datastring.Substring(0, ls_datastring.Length - 1);
                }
            }
            return ls_datastring;
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：顯示檔案格式
        /// </summary>
        /// <param name="mineType">格式</param>
        /// <returns>格式</returns>
        static public string GetExtensions(string mineType)
        {
            string retVal = "";

            switch (mineType)
            {
                case "text/html":
                    retVal = "html";
                    break;
                case "multipart/related":
                    retVal = "html";
                    break;
                case "text/xml":
                    retVal = "xml";
                    break;
                case "text/plain":
                    retVal = "csv";
                    break;
                case "image/tiff":
                    retVal = "tif";
                    break;
                case "application/pdf":
                    retVal = "pdf";
                    break;
                case "application/vnd.ms-excel":
                    retVal = "xls";
                    break;
            }

            return retVal;
        }


        // =========================================================================
        // 函式
        // =========================================================================
        /// <summary>
        /// 函式描述：取得日期所屬的週次
        /// </summary>
        /// <param name="adt_Date">日期</param>
        /// <returns>日期所屬的週次</returns>
        static public int uf_GetWeek(DateTime adt_Date)
        {
            // ##### 宣告變數 #####
            DateTime ldt_MonthFirstDay, ldt_FirstWeekStartDay;
            int li_weekday;
            TimeSpan lts_period;

            // 取得當月第一天，並判斷是星期幾
            ldt_MonthFirstDay = new DateTime(adt_Date.Year, adt_Date.Month, 1);
            li_weekday = Convert.ToInt16(ldt_MonthFirstDay.DayOfWeek);

            // 取得當月第一週的第一天(星期日)的日期
            ldt_FirstWeekStartDay = ldt_MonthFirstDay.AddDays(-li_weekday);

            // 計算日期跟第一週的第一天相差幾天並計算出週次
            lts_period = adt_Date - ldt_FirstWeekStartDay;

            return 1 + Convert.ToInt16(Decimal.Truncate(Convert.ToDecimal(lts_period.TotalDays / 7)));
        }	// End of uf_GetWeek

        // =========================================================================
        // 函式
        // =========================================================================
        /// <summary>
        /// 函式描述：取得指定日期所屬的週次的開始及結束日期
        /// </summary>
        /// <param name="adt_Date">日期</param>
        /// <param name="adt_sDate">回傳開始日期(星期日)</param>
        /// <param name="adt_eDate">回傳結束日期(星期六)</param>
        static public void uf_GetWeekPeriod(DateTime adt_Date, out DateTime adt_sDate, out DateTime adt_eDate)
        {
            uf_GetWeekPeriod(adt_Date.Year, adt_Date.Month, uf_GetWeek(adt_Date), out adt_sDate, out adt_eDate);
        }	// End of uf_GetWeekPeriod(1)

        // =========================================================================
        // 函式
        // =========================================================================
        /// <summary>
        /// 函式描述：取得指定年度、月份、週次的開始及結束日期
        /// </summary>
        /// <param name="ao_Year">西元年度</param>
        /// <param name="ao_Month">月份</param>
        /// <param name="ao_Week">週次</param>
        /// <param name="adt_sDate">回傳開始日期(星期日)</param>
        /// <param name="adt_eDate">回傳結束日期(星期六)</param>
        static public void uf_GetWeekPeriod(object ao_Year, object ao_Month, object ao_Week, out DateTime adt_sDate, out DateTime adt_eDate)
        {
            // ##### 宣告變數 #####
            DateTime ldt_MonthFirstDay, ldt_FirstWeekStartDay;
            int li_weekday;

            // 取得當月第一天，並判斷是星期幾
            ldt_MonthFirstDay = new DateTime(Convert.ToInt16(ao_Year), Convert.ToInt16(ao_Month), 1);
            li_weekday = Convert.ToInt16(ldt_MonthFirstDay.DayOfWeek);

            // 取得當月第一週的第一天(星期日)的日期
            ldt_FirstWeekStartDay = ldt_MonthFirstDay.AddDays(-li_weekday);

            // 計算出開始日期
            adt_sDate = ldt_FirstWeekStartDay.AddDays(7 * (Convert.ToInt16(ao_Week) - 1));

            // 計算出開始日期
            adt_eDate = adt_sDate.AddDays(6);
        }	// End of uf_GetWeekPeriod(2)
	}
}
