// *********************************************************************************
// 1. 程式描述：海科館 NMMST 人力資源系統 - 登入視窗
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WIT.Template.Project;
using Invoke = WIT.Template.Project.Invoke;

// Class Name 如果為 Login 則會有編譯錯誤
public partial class p_Login : p_BasePage
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：是否自動登入系統</summary>
	private bool ib_IsAutoLogin = false;

	/// <summary>變數描述：是否自動登入系統</summary>
	ADUtility ADUY = new ADUtility();
	/// <summary>變數描述：自動登入功能類別</summary>
	//private string is_LoginKind = "";
	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁初始化
	/// </summary>
	protected void Page_Init(object sender, EventArgs e)
	{
		// 不驗證使用者
		this.IsCheckUser = false;
		// 不執行 KeyDown 事件
		this.IsOnKeyDown = false;
		// 不驗證 Frame
		this.IsCheckFrame = false;
		// 不顯示 Version
		this.IsShowVersion = false;
		// 不顯示網頁 Title
		this.IsShowTitle = false;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
	{
		// ##### 宣告變數 #####
		string ls_user;

		ls_user = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "User", "id", "").Trim();

		// 當第一次執行此網頁時
		if (!this.IsPostBack)
		{
			// 不顯示登入視窗
			//if (DbMethods.uf_ProfileString(DbMethods.is_INIPath, "HideSetup", "ShowLoginPage", "").ToUpper() != "Y")
			//{
			//	dwF.Visible = false;
			//	dwS.Visible = true;
			//}

			// 判斷是否有 Cookie 存在，有則從中抓取帳號
			if (this.Request.Cookies["UserSettings"] != null && this.Request.Cookies["UserSettings"]["UserID"] != null)
			{
				dwF_UserID.Text = this.Request.Cookies["UserSettings"]["UserID"].Trim();
				cbx_SaveID.Checked = true;
			}
			else
			{
				if (ls_user != "")
					dwF_UserID.Text = ls_user;
			}

			if (this.Request.Url.IsDefaultPort)
				Email.WebServerAddress = this.Request.Url.Host;
			else
				Email.WebServerAddress = this.Request.Url.Host + ":" + this.Request.Url.Port;

			// 取得傳遞過來的參數–從別的網站來的 *********************************
			#region Sample Script
			// ac=系統帳號、tx=系統密碼
			if (this.Request["Login_ID"] != null && this.Request["ID_No"] != null)
			{
				// ##### 宣告變數 #####
				Status.Business.EncryptSymmetric objEip = new Status.Business.EncryptSymmetric();
				string ls_other = (this.Request["SecLogin_ID"] != null ? objEip.ExecuteDecode(this.Request["SecLogin_ID"]) : "");	// 20091021, fen add

				dwF_UserID.Text = (String.IsNullOrEmpty(ls_other) ? objEip.ExecuteDecode(this.Request["Login_ID"]) : ls_other);		// 20091021, fen modify
				dwF_UserPwd.Text = this.Request["ID_No"];

				if (String.IsNullOrEmpty(dwF_UserID.Text.Trim()))
					this.Response.Redirect(this.Request.ApplicationPath + "/proj_home/p_Home.aspx?" + this.Request.QueryString + "&opener=" + this.ClassName);

				// 設定為自動登入系統
				this.ib_IsAutoLogin = true;
				this.Session.RemoveAll();

				// 觸發登入事件
				this.bt_Login_Click(this, System.EventArgs.Empty);
				return;
			}

			#endregion
			//*********************************************************************
			if (dwS.Visible)
			{
				if (this.Request["login"] != null)
				{
					dwF.Visible = true;
					dwS.Visible = false;
				}
				else
				{
					this.uf_AddJavaScript("window.close();");
				}
			}
			//*********************************************************************

			// 寫入登出資訊 *******************************************************
			Log.uf_LogoutLog();
			//*********************************************************************

			// 取消目前工作階段–新 Session 會在下個 Request 才產生，不適用自動登入
			this.Session.RemoveAll();
			this.Session.Abandon();

			// 設定焦點所在位置
			if (dwF.Visible) this.uf_SetFocus(dwF_UserID);
		}
		else
		{
			// 如果登入的帳號和記錄在 ini 檔中的一樣
			if (dwF_UserID.Text.Trim() == ls_user && dwF_UserPwd.Text.Trim() == "")
				dwF_UserPwd.Text = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "User", "passwd", "");
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 lbt_SendPwd 《忘記密碼？》按鈕所做的處理
	/// </summary>
	protected void lbt_SendPwd_Click(object sender, System.EventArgs e)
	{
		// ##### 宣告變數 #####
		DataSet lds_user;
		string ls_userid, ls_username, ls_Email, ls_userpwd;

		// 得到使用者帳號
		ls_userid = dwF_UserID.Text.Trim();
		if (ls_userid == "")
		{
			this.uf_Msg("(Info) 請輸入帳號！");
			this.uf_SetFocus(dwF_UserID);
			return;
		}
		else if (ls_userid.IndexOfAny(new char[3] { '\'', '"', '\\' }) >= 0)
		{
			this.uf_Msg("(Info) 輸入不合法的字元「' \" \\」！");
			this.uf_SetFocus(dwF_UserID);
			return;
		}

		// 依據使用者帳號找出使用者密碼
		DbMethods.uf_Retrieve_FromSQL(out lds_user, "SELECT IsNull(RTrim(user01_id), ''), IsNull(RTrim(user01_name), ''), IsNull(RTrim(user01_email), ''), IsNull(RTrim(user01_pwd), ''), IsNull(RTrim(user01_pwdhash), ''), IsNull(RTrim(user01_pwdsalt), '') FROM user01 WHERE user01_id = '" + ls_userid + "' ");

		// 判斷是否有找到資料
		if (lds_user.Tables[0].Rows.Count > 0)
		{
			// 得到使用者帳號、名稱和密碼
			ls_userid = lds_user.Tables[0].Rows[0][0].ToString().Trim();
			ls_username = lds_user.Tables[0].Rows[0][1].ToString().Trim();
			ls_Email = lds_user.Tables[0].Rows[0][2].ToString().Trim();
			if (!Setup.ib_IsPasswdHash)
				ls_userpwd = lds_user.Tables[0].Rows[0][3].ToString().Trim();	// user01_pwd
			else
			{
				if (lds_user.Tables[0].Rows[0][4].ToString().Trim() != "")
				{
					WITCrypto lo_Crypto = new WITCrypto();
					lo_Crypto.HexKey = lds_user.Tables[0].Rows[0][5].ToString().Trim();	// user01_pwdsalt
					ls_userpwd = lo_Crypto.uf_Decrypt(lds_user.Tables[0].Rows[0][4].ToString().Trim());	// user01_pwdhash
					// 錯誤的情形
					if (ls_userpwd == "" && lo_Crypto.uf_Encrypt(ls_userpwd) != lds_user.Tables[0].Rows[0][4].ToString().Trim())
						ls_userpwd = "已損毀，請洽系統管理者重新設定";
				}
				else
					ls_userpwd = "";
			}
		}
		else
		{
			this.uf_Msg("(WIT) 登入帳號錯誤！");
			this.uf_SetFocus(dwF_UserID);
			return;
		}

		// 取得使用者 Email 帳號寄發訊息通知
		if (ls_Email != "")
		{
			Email.uf_SendMail(ls_Email,
							ls_username + "的使用者帳號 " + ls_userid + " 密碼已送達",
							"您的密碼為『" + ls_userpwd + "』" + Email.uf_LineEnter(2) + "請牢記密碼！");
			this.uf_Msg("(OK) 您的密碼已寄到註冊之 E-mail 信箱，請等候！");
		}
		else
		{
			this.uf_Msg("(WIT) 您的 E-mail 信箱並未填寫無法寄送密碼，請洽資訊人員！");
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Login 《登入》按鈕所做的處理
	/// </summary>
	protected void bt_Login_Click(object sender, System.EventArgs e)
	{
		// ##### 宣告變數 #####
		DataSet lds_user;
		string ls_userid, ls_username, ls_deptid, ls_deptname;
		string ls_url;

		// 得到使用者帳號
		ls_userid = dwF_UserID.Text.Trim();
		if (ls_userid == "")
		{
			this.uf_Msg("(Info) 請輸入帳號！");
			this.uf_SetFocus(dwF_UserID);
			return;
		}
		else if (ls_userid.IndexOfAny(new char[3] { '\'', '"', '\\' }) >= 0)
		{
			this.uf_Msg("(Info) 輸入不合法的字元「' \" \\」！");
			this.uf_SetFocus(dwF_UserID);
			return;
		}

		// 依據使用者帳號找出使用者密碼
		DbMethods.uf_Retrieve_FromSQL(out lds_user, "SELECT IsNull(RTrim(user01_id), ''), IsNull(RTrim(user01_name), ''), IsNull(RTrim(user01_dept), ''), '未抓取部門名稱', user01_sdate = (CASE WHEN IsNull(user01_sdate, '9999/12/13') > Convert(char(10), GetDate(), 111) THEN Null ELSE user01_sdate END) FROM user01 WHERE user01_id = '" + ls_userid + "' ");

		// 判斷是否有找到資料
		if (lds_user.Tables[0].Rows.Count > 0)
		{
			// 得到使用者帳號、名稱和密碼
			ls_userid = lds_user.Tables[0].Rows[0][0].ToString().Trim();
			ls_username = lds_user.Tables[0].Rows[0][1].ToString().Trim();
			ls_deptid = lds_user.Tables[0].Rows[0][2].ToString().Trim();
			ls_deptname = lds_user.Tables[0].Rows[0][3].ToString().Trim();
			if (lds_user.Tables[0].Rows[0][4] != DBNull.Value)
			{
				this.uf_Msg("(WIT) 登入帳號停用！");
				this.uf_SetFocus(dwF_UserID);
				return;
			}
		}
		else
		{
			this.uf_Msg("(WIT) 登入帳號錯誤！");
			this.uf_SetFocus(dwF_UserID);
			return;
		}

		// 如果不為自動登入，則判斷找出來的密碼是否跟輸入的相同
		// modify by rong 修改成也要判斷AD的帳密
		//if (!this.ib_IsAutoLogin && !Invoke.Setup.uf_CheckPasswd(ls_userid, dwF_UserPwd.Text.Trim()))
		if (!this.ib_IsAutoLogin && !Invoke.Setup.uf_CheckPasswd(ls_userid, dwF_UserPwd.Text.Trim()) && ADUY.GetADEntry(System.Configuration.ConfigurationManager.AppSettings["ADDomain"].Trim(), ls_userid, dwF_UserPwd.Text.Trim()) == 0)
		{
			if (DbMethods.uf_ProfileString(DbMethods.is_INIPath, "Passwd", "WITCheckPwd", "") != "N")
			{
				this.uf_Msg("(WIT) 登入密碼錯誤！");
				this.uf_SetFocus(dwF_UserPwd);
				return;
			}
		}

		// 建立／刪除 Cookie
		if (!this.ib_IsAutoLogin && cbx_SaveID.Checked)
		{
			this.Response.Cookies["UserSettings"]["UserID"] = ls_userid;
			this.Response.Cookies["UserSettings"].Expires = DateTime.Now.AddYears(10);
		}
		else
		{
			if (this.Request.Cookies["UserSettings"] != null)
			{
				HttpCookie myCookie = new HttpCookie("UserSettings");
				myCookie.Expires = DateTime.Now.AddDays(-1);
				this.Response.Cookies.Add(myCookie);
			}
		}

		// 建立 Session
		this.Session.RemoveAll();
		this.Session["ss_user_id"] = ls_userid;
		this.Session["ss_user_name"] = ls_username;
		this.Session["ss_user_dept"] = ls_deptid;
		this.Session["ss_user_deptname"] = ls_deptname;

		// 取得記錄在 ini 檔中的 Url
		ls_url = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "User", "subsys", "");
		if (ls_url.Trim() != "")
		{
			this.Session["ss_mod_id"] = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "User", "mod", "");
			this.Session["ss_menu_id"] = ls_url;
		}
		else
		{
			// 判斷自動登入功能類別，導向到指定功能
			#region Sample Script
			//switch (this.is_LoginKind)
			//{
			//    case "A" :
			//        // 如果有待審清單權限則導向
			//        if (DbMethods.uf_Retrieve_FromSQL(out lds_user, "SELECT 1 FROM sys03 WHERE s03_sys_id = 'c' AND s03_func_id = '0501' AND s03_grp_id in (SELECT s02_grp_id FROM sys02 WHERE s02_user_id = '" + ls_userid + "') ") > 0)
			//        {
			//            this.Session["ss_mod_id"] = "A";
			//            this.Session["ss_menu_id"] = "c.c0501";
			//        }
			//        break;
			//
			//    default :
			//        // 如果有待審清單權限則導向
			//        if (DbMethods.uf_Retrieve_FromSQL(out lds_user, "SELECT 1 FROM sys03 WHERE s03_sys_id = 'c' AND s03_func_id = '110200' AND s03_grp_id in (SELECT s02_grp_id FROM sys02 WHERE s02_user_id = '" + ls_userid + "') ") > 0)
			//        {
			//            this.Session["ss_mod_id"] = "A";
			//            this.Session["ss_menu_id"] = "c.c110200";
			//        }
			//        break;
			//}
			#endregion
		}

		// 寫入登入資訊 *******************************************************
		Log.uf_LoginLog();
		//*********************************************************************

		// 導向到 frame.htm
		this.Response.Redirect(this.Request.Url.Authority + "/frame.htm");
	}
}
