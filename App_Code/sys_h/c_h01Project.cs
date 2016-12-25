// *********************************************************************************
// 1. 程式描述：服務勤務管理–專案共用
// 2. 撰寫人員：demon
// *********************************************************************************
using System;
using System.Data;
using SNSCOMSERVER;

namespace WIT.Template.Project
{
	/// <summary>
	/// 系統管理–專案共用
	/// </summary>
	public class h01Project
	{
        static public SnsComObject m_sns = new SnsComObject();

		// =========================================================================
		/// <summary>
        /// 函式描述：登入 SNS 伺服器
		/// </summary>
		/// <returns>登入結果訊息</returns>
		static public int uf_SNS_Login(ref string as_msg)
		{
            string ls_server = "", ls_port = "", ls_user = "", ls_pswd = "";
            ls_server = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SNS", "Server", "");
            ls_port = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SNS", "Port", "");
            ls_user = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SNS", "id", "");
            ls_pswd = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SNS", "passwd", "");

            //登入 SNS 伺服器
            int nResult = m_sns.Login(ls_server, Int32.Parse(ls_port), ls_user, ls_pswd);

            switch (nResult)
            {
                case -1:
                    as_msg = "[無法連線 SNS]" + m_sns.RespMessage;
                    break;
                case 0:
                    as_msg = "[建立連線成功]" + m_sns.RespMessage;
                    break;
                case 1:
                    as_msg = "[帳號/密碼輸入錯誤]" + m_sns.RespMessage;
                    break;
                default:
                    as_msg = "[請參考 SNS 文件]" + m_sns.RespMessage;
                    break;
            }

            return nResult;
		}

        // =========================================================================
        /// <summary>
        /// 函式描述：傳送文字訊息至指定的受訊手機號碼
        /// </summary>
        /// <returns>登入結果訊息</returns>
        static public int uf_SNS_Submit(string as_num , string as_msg , ref string as_returnmsg )
        {

            //傳送文字訊息至指定的受訊手機號碼
            int nResult = m_sns.SubmitMessage(as_num, as_msg);

            switch (nResult)
            {
                case -1:
                    as_returnmsg = "[傳送通道發生錯誤，請重新連線]" + m_sns.RespMessage;
                    break;
                case 0:
                    as_returnmsg = m_sns.RespMessage;
                    break;
                default:
                    as_returnmsg = "[請參考 SNS 文件]" + m_sns.RespMessage;
                    break;
            }
            return nResult;
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：查詢簡訊傳送狀態
        /// </summary>
        /// <returns>登入結果訊息</returns>
        static public int uf_SNS_QueryStatus(string as_num, string as_msg, ref string as_returnmsg)
        {
            //查詢簡訊傳送狀態
            int nResult = m_sns.QryMessageStatus(as_num, as_msg);

            switch (nResult)
            {
                case -1:
                    as_returnmsg = "[無法連線 SNS，請重新連線]" + m_sns.RespMessage;
                    break;
                case 0:
                    as_returnmsg = "[簡訊成功送達受訊手機] 簡訊成功送達時間：" + m_sns.RespMessage;
                    break;
                case 1:
                    as_returnmsg = "[簡訊傳送中]" + m_sns.RespMessage;
                    break;
                case 2:
                    as_returnmsg = "[查詢資料錯誤]" + m_sns.RespMessage;
                    break;
                case 3:
                    as_returnmsg = "[簡訊傳送失敗] 簡訊失敗時間：" + m_sns.RespMessage;
                    break;
                case 4:
                    as_returnmsg = "[查詢失敗] 請稍後再查：" + m_sns.RespMessage;
                    break;
                default:
                    as_returnmsg = "[請參考 SNS 文件]" + m_sns.RespMessage;
                    break;
            }
            return nResult;
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：接收訊息
        /// </summary>
        /// <returns>結果訊息</returns>
        static public int uf_SNS_GetMsg(ref string as_returnmsg)
        {
            //接收手機上傳的簡訊
            int nResult = m_sns.GetMessage();

            switch (nResult)
            {
                case -2:
                    as_returnmsg = "[訊息內容轉碼失敗] 接收訊息不是 BIG-5 或 ASCII 編碼內容：" + m_sns.RespMessage;
                    break;
                case -1:
                    as_returnmsg = "[無法連線 SNS] 請重新連線：" + m_sns.RespMessage;
                    break;
                case 0:
                    as_returnmsg = m_sns.FromMsisdn + "|!|" + m_sns.ToMsisdn + "|!|" + m_sns.RespMessage;
                    break;
                default:
                    as_returnmsg = "[請參考 SNS 文件]" + m_sns.RespMessage;
                    break;
            }

            return nResult;
        }

        // =========================================================================
        /// <summary>
        /// 函式描述：接收訊息
        /// </summary>
        /// <returns>結果訊息</returns>
        static public void uf_SNS_Logout(ref string as_returnmsg)
        {
            m_sns.Logout();

            as_returnmsg = "切斷與 SNS Server 的連線";
        }

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
                // ------------------------------------------------- ★ 簡訊編號
                // "M" + 民國年(3位) + 流水號(9位)
                case "hlh101.hlh101_logid":

                    // 得到規格碼的長度
                    li_flen = as_startswith.Length;

                    li_len = 9;			// 流水號 9 位

                    // 找出資料庫中最大的編號–且規格碼符合傳入的值
                    ls_sql = "SELECT IsNull(Max(SubString(hlh101_logid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hlh101 " +
                                "WHERE SubString(hlh101_logid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

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
