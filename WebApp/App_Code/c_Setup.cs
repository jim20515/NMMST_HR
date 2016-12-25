// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–專案設定
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project.Invoke
{
	/// <summary>
	/// 環域科技共用函式庫–專案設定
	/// </summary>
	public class Setup
	{
		#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

		/// <summary>變數描述：操作功能選單顯示種類–TreeView；Panel</summary>
		public enum MenuTreeKinds { TreeView, Panel };

		#endregion

		// ========================================================================= ☆ 一般(必需)
		/// <summary>變數描述：應用程式名稱</summary>
		static public string is_AppName = "國立海洋科技博物館-人力資源系統";
		/// <summary>變數描述：應用程式使用的 ini 檔名稱</summary>
		static public string is_INIFile = "NMMST_HR.ini";

		// ========================================================================= ☆ PBL
		/// <summary>變數描述：應用程式使用的 pbl 檔名稱</summary>
		static public string is_PBLFile = "NMMST_HR.pbl";
		/// <summary>變數描述：標題背景顏色</summary>
		static public string is_HeadBackColor = "31383756";
		/// <summary>變數描述：輸入框背景顏色</summary>
		static public string is_EditBackColor = "31326207";

		// ========================================================================= ☆ 資料庫
		/// <summary>變數描述：新增人員欄位名稱結尾（預設是「_aid」）</summary>
		static public string is_aid = "_aid";
		/// <summary>變數描述：新增日期欄位名稱結尾（預設是「_adt」）</summary>
		static public string is_adt = "_adt";
		/// <summary>變數描述：異動人員欄位名稱結尾（預設是「_uid」）</summary>
		static public string is_chp = "_uid";
		/// <summary>變數描述：異動日期欄位名稱結尾（預設是「_udt」）</summary>
		static public string is_chd = "_udt";
		/// <summary>變數描述：異動人員資料種類–登入帳號(id)；名稱(name)；員工編號(empno)</summary>
		static public string is_chp_vtype = "id";
		/// <summary>變數描述：資料庫是否區分大小寫</summary>
		static public bool ib_IsDbCaseSensitive = false;
		/// <summary>變數描述：是否使用密碼加密技術</summary>
		static public bool ib_IsPasswdHash = false;

		// ========================================================================= ☆ 欄位
		/// <summary>變數描述：欄位長度資源檔(需放在 App_GlobalResources)</summary>
		static public string is_r_DbColLength = "r_DbColLength";
		/// <summary>變數描述：欄位字母種類資源檔(需放在 App_GlobalResources)</summary>
		static public string is_r_DbColCase = "r_DbColCase";

		// ========================================================================= ☆ 版面
		/// <summary>變數描述：操作功能選單顯示種類–TreeView；Panel</summary>
		static public MenuTreeKinds i_MenuTreeKind = MenuTreeKinds.TreeView;
		/// <summary>變數描述：是否操作功能選單全部展開</summary>
		static public bool ib_IsMenuTreeExpandAll = true;
		/// <summary>變數描述：操作功能選單要展開的群組字串組合（中間以「,」隔開 ex."s00,s01,s02"）</summary>
		static public string is_MenuTreeExpandGroup = "";
		/// <summary>變數描述：是否使用民國年</summary>
		static public bool ib_IsROC = true;
		/// <summary>變數描述：是否顯示版本日期資訊的預設值</summary>
		static public bool ib_IsShowVersionDefault = true;
		/// <summary>變數描述：是否顯示網頁 Title 的預設值</summary>
		static public bool ib_IsShowTitleDefault = true;
		/// <summary>變數描述：是否顯示符號表</summary>
		static public bool ib_IsShowSymbol = false;
		/// <summary>變數描述：是否永遠利用 Window.Alert 方式顯示訊息</summary>
		static public bool ib_IsAlwaysAlert = true;
		/// <summary>變數描述：是否使用 AJAX Script 的預設值</summary>
		static public bool ib_IsAJAXScriptDefault = true;
		/// <summary>變數描述：是否顯示層級的操作名稱</summary>
		static public bool ib_IsShowLevelFuncName = true;
		/// <summary>變數描述：是否顯示子系統名稱</summary>
		static public bool ib_IsShowSysName = true;
		/// <summary>變數描述：層級的操作名稱分隔符號（預設是「﹒」）</summary>
		static public string is_SysFuncNameSplit = " >> ";

		// ========================================================================= ☆ Dbcfg
		/// <summary>(Dbcfg)變數描述：參數存放在 Cache 中最後一次存取的逾期時間</summary>
		static public int ii_DbcfgCacheDurationMin = 10;
		/// <summary>(Dbcfg)變數描述：排序、搜尋和篩選時字串是否區分大小寫</summary>
		static public bool ib_DbcfgIsCaseSensitive = false;
		/// <summary>(Dbcfg)變數描述：《特別》參數指定代碼(年度)之最小值(民國年用不要小於1912)</summary>
		static public int ii_DbcfgYY_Start = 2002;
		/// <summary>(Dbcfg)變數描述：《特別》參數指定代碼(年度)之最大值</summary>
		static public int ii_DbcfgYY_End = 2031;
		/// <summary>(Dbcfg)變數描述：DDDW 是否不論必要輸入一律插入空項目</summary>
		static public bool ib_IsDDDWAlwaysEmpty = false;
		/// <summary>(Dbcfg)變數描述：DDDW 插入空項目的顯示名稱(一般)</summary>
		static public string is_IsDDDWEmptyText = "《請選擇》";
		/// <summary>(Dbcfg)變數描述：DDDW 插入空項目的顯示名稱(查詢)</summary>
		static public string is_IsDDDWEmptyText_Q = "《全部》";

		// ========================================================================= ☆ 例外處理
		static public Exception LastError;

		#region ☆ Password Methods --------------------------------------- 撰寫人員：fen

		// =========================================================================
		/// <summary>
		/// 函式描述：驗證使用者輸入的密碼是否正確
		/// </summary>
		/// <param name="as_UserID">使用者帳號</param>
		/// <param name="as_KeyinPwd">使用者輸入的密碼</param>
		/// <returns>正確(true)；錯誤(false)</returns>
		static public bool uf_CheckPasswd(string as_UserID, string as_KeyinPwd)
		{
			// ##### 宣告變數 #####
			DataSet lds_user;
			string ls_KeyinPwd, ls_SavePwd;
			bool lb_IsPasswdHash = Setup.ib_IsPasswdHash;


			// 依據使用者帳號找出使用者密碼
			DbMethods.uf_Retrieve_FromSQL(out lds_user,
				"SELECT IsNull(RTrim(user01_pwd), '')" + (lb_IsPasswdHash ? ", IsNull(RTrim(user01_pwdhash), ''), IsNull(RTrim(user01_pwdsalt), '')" : "") + " " +
					"FROM user01 " +
					"WHERE RTrim(user01_id) = '" + ComMethods.uf_GetSQLInput(as_UserID) + "' ");

			// 判斷是否有找到資料
			if (lds_user.Tables[0].Rows.Count > 0)
			{
				// 得到使用者密碼
				ls_KeyinPwd = as_KeyinPwd.Trim();
				if (!lb_IsPasswdHash)
				{
					ls_SavePwd = lds_user.Tables[0].Rows[0][0].ToString().Trim();		// user01_pwd
				}
				else
				{
					if (lds_user.Tables[0].Rows[0][1].ToString().Trim() != "")
					{
						WITCrypto lo_Crypto = new WITCrypto();
						lo_Crypto.HexKey = lds_user.Tables[0].Rows[0][2].ToString().Trim();	// user01_pwdsalt
						ls_SavePwd = lo_Crypto.uf_Decrypt(lds_user.Tables[0].Rows[0][1].ToString().Trim());	// user01_pwdhash
						// 錯誤的情形
						if (ls_SavePwd == "" && lo_Crypto.uf_Encrypt(ls_SavePwd) != lds_user.Tables[0].Rows[0][1].ToString().Trim())
							ls_SavePwd = "*".PadRight(25, '*');
					}
					else
						ls_SavePwd = "";
				}
			}
			else
			{
				return false;
			}

			// 判斷找出來的密碼是否跟輸入的相同
			if (ls_KeyinPwd == ls_SavePwd)
				return true;
			else
				return false;
		}

		// =========================================================================
		/// <summary>
		/// 函式描述：設定使用者密碼（自動產生亂數密碼）
		/// </summary>
		/// <param name="as_UserID">使用者帳號</param>
		/// <returns>成功(true)；失敗(false)</returns>
		static public bool uf_SetPasswd(string as_UserID)
		{
			return uf_SetPasswd(as_UserID, "", true);
		}

		// =========================================================================
		/// <summary>
		/// 函式描述：設定使用者密碼（使用者指定密碼）
		/// </summary>
		/// <param name="as_UserID">使用者帳號</param>
		/// <param name="as_KeyinPwd">使用者輸入的密碼</param>
		/// <returns>成功(true)；失敗(false)</returns>
		static public bool uf_SetPasswd(string as_UserID, string as_KeyinPwd)
		{
			return uf_SetPasswd(as_UserID, as_KeyinPwd, false);
		}

		// =========================================================================
		/// <summary>
		/// 函式描述：設定使用者密碼
		/// </summary>
		/// <param name="as_UserID">使用者帳號</param>
		/// <param name="as_KeyinPwd">使用者輸入的密碼</param>
		/// <param name="ab_IsAutoGen">是否自動產生亂數密碼–是(true)；否(false)</param>
		/// <returns>成功(true)；失敗(false)</returns>
		static private bool uf_SetPasswd(string as_UserID, string as_KeyinPwd, bool ab_IsAutoGen)
		{
			// ##### 宣告變數 #####
			string ls_Pwd, ls_PwdHash, ls_PwdSalt;
			bool lb_IsPasswdHash = Setup.ib_IsPasswdHash;

			// 判斷如果為自動產生密碼
			if (ab_IsAutoGen)
				as_KeyinPwd = ComMethods.uf_CreateSalt(5);

			// 得到使用者密碼
			if (!lb_IsPasswdHash)
			{
				ls_Pwd = as_KeyinPwd.Trim();	// user01_pwd
				ls_PwdSalt = "";				// user01_pwdsalt
				ls_PwdHash = "";				// user01_pwdhash
			}
			else
			{
				ls_Pwd = "*****";				// user01_pwd
				WITCrypto lo_Crypto = new WITCrypto();
				lo_Crypto.uf_GenerateKey();
				ls_PwdSalt = lo_Crypto.HexKey;	// user01_pwdsalt
				ls_PwdHash = lo_Crypto.uf_Encrypt(as_KeyinPwd.Trim());	// user01_pwdhash
			}

			// 修改使用者密碼
			if (DbMethods.uf_ExecSQL("UPDATE user01 " +
										"SET user01_pwd = '" + ComMethods.uf_GetSQLInput(ls_Pwd) + "'" + (lb_IsPasswdHash ? ", user01_pwdhash = '" + ls_PwdHash + "', user01_pwdsalt = '" + ls_PwdSalt + "'" : "") + " " +
										"WHERE RTrim(user01_id) = '" + ComMethods.uf_GetSQLInput(as_UserID) + "' ") == 1)
			{
				// 取得使用者 Email 帳號寄發訊息通知
				string ls_Email = Email.uf_GetMailAddr(as_UserID);
				if (ls_Email != "")
					Email.uf_SendMail(ls_Email,
										"使用者帳號 " + as_UserID + " 的密碼已修改",
										"最新密碼為『" + as_KeyinPwd.Trim() + "』，下次請使用新密碼登入本系統！" + (ab_IsAutoGen ? Email.uf_LineEnter(2) + "註：此密碼為系統亂數產生，請登入本系統再自行修改！" : ""));
				return true;
			}
			else
				return false;
		}

		#endregion

	}
}
