//// *********************************************************************************
//// 1. 程式描述：環域科技共用函式庫–專案共用
//// 2. 撰寫人員：fen
//// *********************************************************************************
//using System;
//using System.Data;
//using System.Text;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace WIT.Template.Project.Invoke
//{
//	/// <summary>
//	/// 環域科技共用函式庫–專案共用
//	/// </summary>
//	public class Project
//	{
//		// =========================================================================
//		/// <summary>
//		/// 函式描述：利用表格名稱取得欄位名稱起始字串
//		/// </summary>
//		/// <param name="as_TableName">表格名稱</param>
//		/// <returns>欄位名稱起始字串</returns>
//		static public string uf_Get_ColNameStartsWith(string as_TableName)
//		{
//			// 如果表格開頭是 sys 則去前2碼即為欄位名稱起始字串
//			if (as_TableName.StartsWith("sys"))
//				as_TableName = as_TableName.Substring(2);

//			return as_TableName;
//		}

//		#region ☆ Mail Methods ------------------------------------------- 撰寫人員：fen

//		// =========================================================================
//		/// <summary>
//		/// 函式描述：取得指定使用者帳號陣列的所有 Email Address 字串（中間以;隔開）
//		///	return: Email Address 字串(中間以;隔開)
//		/// </summary>
//		/// <param name="asa_UserID">使用者帳號陣列</param>
//		/// <returns>Email Address 字串(中間以;隔開)</returns>
//		static public string uf_GetMailAddr(params string[] asa_UserID)
//		{
//			// ##### 宣告變數 #####
//			string ls_datastring = "", ls_data;
//			DataSet lds_data;
//			int li_rowcount;

//			// 錯誤的傳入值
//			if (asa_UserID.Length == 0) return "";

//			// 取得所有使用者帳號字串
//			for (int li_row = 0; li_row <= (asa_UserID.Length - 1); li_row++)
//			{
//				// 取得使用者帳號
//				ls_data = asa_UserID[li_row].Trim();
//				if (ls_data != "")
//				{
//					if (ls_datastring != "") ls_datastring += "', '";
//					ls_datastring += ComMethods.uf_GetSQLInput(ls_data);
//				}
//			}

//			// 利用 SQL 語法產生資料集
//			DbMethods.uf_Retrieve_FromSQL(out lds_data, "SELECT user01_email FROM user01 WHERE user01_id in ('" + ls_datastring + "') ");

//			// 取得總筆數
//			li_rowcount = lds_data.Tables[0].Rows.Count;

//			// 取得所有 Email Address 字串
//			ls_datastring = "";
//			for (int li_row = 0; li_row <= (li_rowcount - 1); li_row++)
//			{
//				// 取得 Email
//				ls_data = lds_data.Tables[0].Rows[li_row]["user01_email"].ToString().Trim();
//				if (ls_data != "")
//				{
//					if (ls_datastring != "") ls_datastring += ";";
//					ls_datastring += ls_data;
//				}
//			}

//			return ls_datastring;
//		}

//		// =========================================================================
//		/// <summary>
//		/// 函式描述：從指定的 SMTP Server 傳送電子郵件失敗所做的處理
//		/// </summary>
//		/// <param name="as_MailFrom">寄件者的電子郵件地址</param>
//		/// <param name="as_MailTo">收件者的電子郵件地址</param>
//		/// <param name="as_MailSubject">電子郵件訊息的主旨</param>
//		/// <param name="as_MailMessage">Message</param>
//		/// <param name="as_MailException">Exception</param>
//		/// <param name="as_MailInnerException">InnerException</param>
//		static public void uf_SendMailError(string as_MailFrom, string as_MailTo, string as_MailSubject, string as_MailMessage, string as_MailException, string as_MailInnerException)
//		{

//		}

//		#endregion

//		#region ☆ JavaScript Methods ------------------------------------- 撰寫人員：fen

//		// =========================================================================
//		/// <summary>
//		/// 函式描述：產生 JavaScript 語法
//		/// </summary>
//		/// <param name="ap_Form">視窗</param>
//		/// <param name="as_Script">JavaScript 語法(不包含 ScriptTags)</param>
//		/// <param name="ab_IsAJAX">是否使用 AJAX–是(true)；否(false)</param>
//		static public void uf_ClientScript(Page ap_Form, string as_Script, bool ab_IsAJAX)
//		{
//			if (ab_IsAJAX)
//			{
//			    string ls_key = "AJAX";
//			    if (as_Script.ToLower().Contains("alert("))
//			        ls_key += "1";
//			    else if (as_Script.ToLower().Contains(".focus()"))
//			        ls_key += "2";
//			    else
//			        ls_key += "3";
//			    ScriptManager.RegisterStartupScript(ap_Form, ap_Form.GetType(), ls_key + "_" + DateTime.Today.ToString("mmss") + DateTime.Now.Millisecond.ToString(), as_Script, true);
//			}
//			else
//			{
//				//int li_key = DateTime.Now.Millisecond;
//				//while (ap_Form.ClientScript.IsStartupScriptRegistered(ap_Form.GetType(), "NoAJAX_" + DateTime.Today.ToString("mmss") + li_key.ToString()))
//				//    li_key++;
//				//ap_Form.ClientScript.RegisterStartupScript(ap_Form.GetType(), "NoAJAX_" + DateTime.Today.ToString("mmss") + li_key.ToString(), "<script language=\"JavaScript\" type=\"text/javascript\">\n" + as_Script + "\n" + "</script>\n");
//				Literal litr_Script = new Literal();
//				litr_Script.Text = "<script language=\"JavaScript\" type=\"text/javascript\">\n" + as_Script + "\n" + "</script>\n";
//				ap_Form.Controls.Add(litr_Script);
//			}
//		}

//		// =========================================================================
//		/// <summary>
//		/// 函式描述：產生 JavaScript 語法
//		/// </summary>
//		/// <param name="ac_Control">控制項</param>
//		/// <param name="as_Script">JavaScript 語法(不包含 ScriptTags)</param>
//		/// <param name="ab_IsAJAX">是否使用 AJAX–是(true)；否(false)</param>
//		static public void uf_ControlScript(Control ac_Control, string as_Script, bool ab_IsAJAX)
//		{
//			if (ab_IsAJAX)
//			{
//			    string ls_key = ac_Control.ClientID + "AJAX";
//			    if (as_Script.ToLower().Contains("alert("))
//			        ls_key += "1";
//			    else if (as_Script.ToLower().Contains(".focus()"))
//			        ls_key += "2";
//			    else
//			        ls_key += "3";
//			    ScriptManager.RegisterStartupScript(ac_Control, ac_Control.GetType(), ls_key + "_" + DateTime.Today.ToString("mmss") + DateTime.Now.Millisecond.ToString(), as_Script, true);
//			}
//			else
//			{
//				Literal litr_Script = new Literal();
//				litr_Script.Text = "<script language=\"JavaScript\" type=\"text/javascript\">\n" + as_Script + "\n" + "</script>\n";
//				ac_Control.Controls.Add(litr_Script);
//			}
//		}

//		#endregion

//	}
//}
