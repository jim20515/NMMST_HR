// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 系統功能選單之 Web 使用者控制項
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

public partial class proj_right_u_MenuBar : System.Web.UI.UserControl
{
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟（在 WebForm 的 Page_Load 之後處理）
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {

    }

	// =========================================================================
	/// <summary>
	/// 函式描述：利用使用者權限資料建立 MenuBar 選單
	/// </summary>
	/// <param name="as_UserID">使用者帳號</param>
	public void uf_Build(string as_UserID)
	{
		// ##### 宣告變數 #####
		string ls_ModID = "";

		// 找 Request 傳入值的「Module ID」
		if (this.Request["menu_id"] != null)
			ls_ModID = this.Request["menu_id"].ToString().Trim();
		// 如果傳入的「Module ID」不正確，則再找 Session
		if (ls_ModID == "")
		{
			if (this.Session["ss_mod_id"] != null)
				ls_ModID = this.Session["ss_mod_id"].ToString().Trim();
		}
		// 如果 Session 的「Module ID」不正確，則指定找第一個模組
		if (ls_ModID == "") ls_ModID = "0";

		this.uf_Build(as_UserID, ls_ModID);
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：利用使用者權限資料建立 MenuBar 選單
	/// </summary>
	/// <param name="as_UserID">使用者帳號</param>
	/// <param name="as_ModID">選擇的 Module ID</param>
	public void uf_Build(string as_UserID, string as_ModID)
	{
		// ##### 宣告變數 #####
		System.Text.Encoding l_Encoding;
		ndb_userright lndb_UserRight;
		int li_ModuleCount;
		int li_Row, li_Col, li_RowCount, li_ColCount, li_Index;
		string ls_Ret, ls_Style, ls_Sid = "";
		int li_width;
		string ls_MenuID = "", ls_SysID = "";
		int li_Pos;

		lndb_UserRight = new ndb_userright();

		// 得到指定的編碼方式
		l_Encoding = System.Text.Encoding.GetEncoding(950);

		// 指定權限語法，連接到資料庫並取出全部模組資料 --------------------- ☆
		lndb_UserRight.uf_Retrieve("", as_UserID, "menubar", "");
		lndb_UserRight.dv_View = lndb_UserRight.ds_Data.Tables[0].DefaultView;

		// 設定資料處理條件
		lndb_UserRight.uf_Sort("mod_id, sys_id, seq");

		// 如果傳入的選擇的 Module ID 為「0」表示顯示第一個模組
		if (as_ModID == "0" && lndb_UserRight.uf_RowCount() > 0)
			as_ModID = lndb_UserRight[0]["mod_id"].ToString().Trim();

		// 先過濾出模組的資料
		lndb_UserRight.uf_Filter("func_flag = 'M'");
		li_ModuleCount = lndb_UserRight.uf_RowCount();

		// 再過濾出系統的資料
		lndb_UserRight.uf_Filter("func_flag = 'S' AND mod_id = '" + as_ModID + "'");

		// 建立 Session
		this.Session["ss_mod_id"] = as_ModID;


		// 判斷是否有記錄 Session「Menu ID」用來快速導引 -------------------- ☆

		// 找 Session 「Menu ID」的「系統代碼」.「系統代碼」+「操作代碼」
		if (this.Session["ss_menu_id"] != null)
			ls_MenuID = this.Session["ss_menu_id"].ToString().Trim();

		if (ls_MenuID != "")
		{
			// 先得到操作代碼「.」之前的系統代碼
			li_Pos = ls_MenuID.IndexOf(".");
			if (li_Pos >= 0)
				ls_SysID = ls_MenuID.Substring(0, li_Pos);
			else
				ls_SysID = ls_MenuID;
		}
		else if (lndb_UserRight.uf_RowCount() > 0)
		{
			ls_SysID = lndb_UserRight[0]["rid"].ToString().Trim();
		}


		// 指定權限語法，連接到資料庫並取出資料 ----------------------------- ☆
		li_RowCount = 1;
		li_ColCount = lndb_UserRight.uf_RowCount() + 2;
		li_Index = 0;

		// 系統權限 MenuBar
		ls_Ret = "<table class=\"MenuBar\" id=\"MenuBar\" sid=\"\">" + "\n";

		for (li_Row = 1; li_Row <= li_RowCount; li_Row++)		// 列迴圈
		{
			ls_Ret += "	<tr>" + "\n";

			for (li_Col = 1; li_Col <= li_ColCount; li_Col++)	// 欄迴圈
			{
				if (li_Row == 1 && li_Col == 1)					// 首頁欄位
				{
					ls_Style = "";

					// 設定顯示的寬度
					li_width = 20;

					// 增加一個空白項目
					if (li_ModuleCount > 1)
						ls_Ret += "		<td class=\"MBItem\" id=\"MBI_mod\" style=\"width:" + li_width.ToString() + "px; cursor=hand\" title=\"切換系統模組\" onclick=\"uf_SetModuleVisible(true);\">◎</td>" + "\n";
					else
						ls_Ret += "		<td class=\"MBItem\" id=\"MBI_mod\" style=\"width:" + li_width.ToString() + "px;\">※</td>" + "\n";

					// 設定顯示的寬度
					li_width = 50;

					//ls_Ret += "		<td class=\"MBItem" + ls_Style + "\" id=\"MBI_home\" style=\"width:" + li_width.ToString() + "px;\"><a tabindex=\"-1\" class=\"MBILink" + ls_Style + "\" id=\"MBI_home_link\" href=\"" + this.Request.ApplicationPath + "/proj_home/p_Home.aspx\" onclick=\"uf_SelectItem('MBI_home');\">首頁</a></td>" + "\n";
				}
				else if (li_Row == li_RowCount && li_Col == li_ColCount)  // 登出欄位
				{
					ls_Style = "";

					// 增加一個空白項目
					ls_Ret += "		<td class=\"MBItem\" id=\"MBI_empty\"></td>" + "\n";

					// 設定顯示的寬度
					li_width = 50;

					ls_Ret += "		<td class=\"MBItem" + ls_Style + "\" id=\"MBI_out\" style=\"width:" + li_width.ToString() + "px;\"><a tabindex=\"-1\" class=\"MBILink" + ls_Style + "\" id=\"MBI_out_link\" href=\"" + this.Request.ApplicationPath + "/Login.aspx\" target=\"_top\">登出</a></td>" + "\n";
				}
				else											// 系統欄位
				{
					if (ls_SysID == lndb_UserRight[li_Index]["rid"].ToString().Trim())
					{
						ls_Style = "S";
						ls_Sid = "MBI_" + lndb_UserRight[li_Index]["rid"].ToString().Trim();
					}
					else
						ls_Style = "";

					// 設定顯示的寬度(計算轉成 Big5 的長度來推算)
					li_width = 5 * l_Encoding.GetByteCount(lndb_UserRight[li_Index]["sys_text"].ToString().Trim()) + 30;

					ls_Ret += "		<td class=\"MBItem" + ls_Style + "\" id=\"MBI_" + lndb_UserRight[li_Index]["rid"].ToString().Trim() + "\" style=\"width:" + li_width.ToString() + "px;\"><a tabindex=\"-1\" class=\"MBILink" + ls_Style + "\" id=\"MBI_" + lndb_UserRight[li_Index]["rid"].ToString().Trim() + "_link\" href=\"" + this.Request.ApplicationPath + "/" + lndb_UserRight[li_Index]["sys_url"].ToString().Trim() + "\" target=\"menutreeFrame\" onclick=\"uf_SelectItem('MBI_" + lndb_UserRight[li_Index]["rid"].ToString().Trim() + "');\">" + lndb_UserRight[li_Index]["sys_text"].ToString().Trim() + "</a></td>" + "\n";
					li_Index += 1;
				}
			}

			ls_Ret += "	</tr>" + "\n";
		}

		ls_Ret += "</table>" + "\n";

		ls_Ret += "<script language=\"javascript\" src=\"j_MenuBar.js\"></script>";
		ls_Ret += "<script language=\"javascript\">uf_SelectItem(\"" + ls_Sid + "\")</script>";

		litr_MenuBar.Text = ls_Ret;
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：利用系統權限陣列建立 MenuBar 選單（舊方法，適用在非 Frame 框架下）
	/// </summary>
	/// <param name="asa_UserSysList">系統權限陣列</param>
	/// <param name="as_Position">選擇的項目</param>
	/// <param name="ai_ModuleCount">模組數量</param>
	public void uf_Build(string[,] asa_UserSysList, string as_Position, int ai_ModuleCount)
	{
		// ##### 宣告變數 #####
		System.Text.Encoding l_Encoding;
		int li_Row, li_Col, li_RowCount, li_ColCount, li_Index;
		string ls_Ret, ls_Style;
		int li_width;

		// 得到指定的編碼方式
		l_Encoding = System.Text.Encoding.GetEncoding(950);

		li_RowCount = 1;
		li_ColCount = (asa_UserSysList.Length / 3) + 2;
		li_Index = 0;
		ls_Ret = "<table class=\"MenuBar\" id=\"MenuBar\">" + "\n";
		for (li_Row = 1; li_Row <= li_RowCount; li_Row++)  // 列迴圈
		{
			ls_Ret += "	<tr>" + "\n";

			for (li_Col = 1; li_Col <= li_ColCount; li_Col++)  // 欄迴圈
			{
				if (li_Row == 1 && li_Col == 1)			// 首頁欄位
				{
					if (as_Position == "home")
					{
						ls_Style = "S";
					}
					else
					{
						ls_Style = "";
					}

					// 設定顯示的寬度
					li_width = 20;

					// 增加一個空白項目
					if (ai_ModuleCount > 4)
						ls_Ret += "		<td class=\"MBItem\" id=\"MBI_mod\" style=\"width:" + li_width.ToString() + "px; cursor=hand\" title=\"切換系統模組\" onclick=\"uf_SetModuleVisible(true);\">◎</td>" + "\n";
					else
						ls_Ret += "		<td class=\"MBItem\" id=\"MBI_mod\" style=\"width:" + li_width.ToString() + "px;\">※</td>" + "\n";

					// 設定顯示的寬度
					li_width = 50;

					//ls_Ret += "		<td class=\"MBItem" + ls_Style + "\" id=\"MBI_home\" style=\"width:" + li_width.ToString() + "px;\"><a tabindex=\"-1\" class=\"MBILink" + ls_Style + "\" href=\"" + this.Request.ApplicationPath + "/proj_home/p_Home.aspx\">首頁</a></td>" + "\n";
				}
				else if (li_Row == li_RowCount && li_Col == li_ColCount)  // 登出欄位
				{
					if (as_Position == "out")
					{
						ls_Style = "S";
					}
					else
					{
						ls_Style = "";
					}

					// 增加一個空白項目
					ls_Ret += "		<td class=\"MBItem\" id=\"MBI_empty\"></td>" + "\n";

					// 設定顯示的寬度
					li_width = 50;

					ls_Ret += "		<td class=\"MBItem" + ls_Style + "\" id=\"MBI_out\" style=\"width:" + li_width.ToString() + "px;\"><a tabindex=\"-1\" class=\"MBILink" + ls_Style + "\" href=\"" + this.Request.ApplicationPath + "/Login.aspx\">登出</a></td>" + "\n";
				}
				else									// 系統欄位
				{
					if (asa_UserSysList[li_Index, 0] != as_Position)
					{
						ls_Style = "";
					}
					else
					{
						ls_Style = "S";
					}

					// 設定顯示的寬度(計算轉成 Big5 的長度來推算)
					li_width = 5 * l_Encoding.GetByteCount(asa_UserSysList[li_Index, 1]) + 30;

					ls_Ret += "		<td class=\"MBItem" + ls_Style + "\" id=\"MBI_" + asa_UserSysList[li_Index, 0] + "\" style=\"width:" + li_width.ToString() + "px;\"><a tabindex=\"-1\" class=\"MBILink" + ls_Style + "\" href=\"" + asa_UserSysList[li_Index, 2] + "\">" + asa_UserSysList[li_Index, 1] + "</a></td>" + "\n";
					li_Index += 1;
				}
			}

			ls_Ret += "	</tr>" + "\n";
		}

		ls_Ret += "</table>" + "\n";

		litr_MenuBar.Text = ls_Ret;
	}
}
