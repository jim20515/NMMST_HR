// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 使用者權限操作功能導引頁
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

public partial class proj_right_p_MenuLead : p_MenuPage
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：要寫出的 HTML 語法</summary>
	private string is_Html;

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {

    }

	// =========================================================================
	/// <summary>
	/// 函式描述：產生操作功能導引頁
	/// </summary>
	private void uf_BuildFrame(ndb_userright_func andb_UserRight)
	{
		// ##### 宣告變數 #####
		string ls_ret = "", ls_frames = "", ls_funcpage, ls_mainpage, ls_text, ls_src;
		string[] lsa_item = new string[1];
		string ls_rows = "30,*";
		int li_i, li_count, li_pos, li_index = 0;
		bool lb_IsMain = false;

		lsa_item[0] = "";

		if (andb_UserRight.uf_RowCount() <= 0)
		{
			ls_funcpage = this.Request.ApplicationPath + "/proj_right/p_SysFunc.aspx";
			ls_mainpage = this.Request.ApplicationPath + "/Empty.htm";
		}
		else
		{
			ls_funcpage = this.Request.ApplicationPath + "/proj_right/p_SysFunc.aspx";
			ls_mainpage = this.Request.ApplicationPath + "/" + andb_UserRight[0]["func_url"].ToString().Trim();
			// 將操作項目依據「|」區分出項目來，操作項目例子："查詢=query|清單=list;1|明細資料=edit;2|
			lsa_item = andb_UserRight[0]["func_item"].ToString().Trim().Split('|');
		}

		// 依據操作項目數量產生不同 Frame 區域
		li_count = lsa_item.Length;
		if (li_count <= 0 || (li_count == 1 && lsa_item[0].Trim() == ""))
		{
			lb_IsMain = true;
		}
		else
		{
			for (li_i = 0; li_i < li_count; li_i++)
			{
				// 找出「=」所在位置
				li_pos = lsa_item[li_i].IndexOf("=");

				// 如果沒有符合條件的資料則不處理
				if (li_pos < 0)
				{
					if (li_count == 1)
					{
						lb_IsMain = true;
						break;
					}
					else
						continue;
				}

				// 拆解出項目名稱和項目代號
				ls_text = lsa_item[li_i].Substring(0, li_pos).Trim();
				ls_src = lsa_item[li_i].Substring(li_pos + 1).Trim();

				// 如果任一值為空字串
				if (ls_text == "" || ls_src == "")
				{
					if (li_count == 1)
					{
						lb_IsMain = true;
						break;
					}
					else
						continue;
				}

				// 找出「;」所在位置
				li_pos = ls_src.IndexOf(";");

				// 如果沒有符合條件的資料則設為 0
				if (li_pos >= 0)
				{
					// 拆解出項目代號和項目層級(用不到)
					ls_src = ls_src.Substring(0, li_pos);

					// 如果項目代號為空字串
					if (ls_src == "")
					{
						if (li_count == 1)
						{
							lb_IsMain = true;
							break;
						}
						else
							continue;
					}
				}

				// 利用項目代號代號組合出 Frame 名稱
				li_index++;
				if (li_index > 1) ls_rows += ",0";

				ls_frames += "	<frame name=\"" + ls_src + "Frame\" src=\"about:blank\" scrolling=\"auto\" marginheight=\"0\">" + "\r\n";
			}

			// 如果操作項目大於一個則改變大小–目前不用第二行而把功能名稱往後移
			if (li_index > 1) ls_rows = ls_rows.Replace("30,*", "50,*");
		}

		if (lb_IsMain)
			ls_frames = "	<frame name=\"mainFrame\" src=\"" + ls_mainpage + "\" scrolling=\"auto\" marginheight=\"0\">" + "\r\n";

		// 操作權限功能導引頁
		ls_ret += "<html>\n";
		ls_ret += "<script language=\"javascript\">\n";
		ls_ret += "	if (top.location.toString().indexOf(\"frame.htm\") == -1)\n";
		ls_ret += "		top.location = \"" + this.Request.ApplicationPath + "/frame.htm\";\n";
		ls_ret += "</script>\n";
		ls_ret += "<frameset rows=\"" + ls_rows + "\" frameborder=\"no\" framespacing=\"0\" border=\"0\">" + "\r\n";
		ls_ret += "	<frame name=\"funcFrame\" src=\"" + ls_funcpage + "\" scrolling=\"no\" noresize=\"noresize\">" + "\r\n";
		ls_ret += ls_frames;
		ls_ret += "</frameset>" + "\r\n";
		ls_ret += "<noframes>" + "\r\n";
		ls_ret += "</noframes>" + "\r\n";
		ls_ret += "</html>";

		is_Html = ls_ret;

		//<frameset rows="30px,*" cols="*" frameborder="no" framespacing="0" border="0">
		//	<frame name="funcFrame" src="../proj_right/sysfunc.jsp" scrolling="no" noresize="noresize">
		//	<frame name="mainFrame" src="../sys_a/a01/a0101.jsp" scrolling="auto" marginheight="0">
		//	<frame name="queryFrame" src="../sys_a/a01/a0101_query.jsp" scrolling="auto" marginheight="0">
		//	<frame name="listFrame" src="../sys_a/a01/a0101_list.jsp" scrolling="auto" marginheight="0">
		//	<frame name="editFrame" src="../sys_a/a01/a0101_edit.jsp" scrolling="auto" marginheight="0">
		//</frameset>
	}
	
	#region ☆ Override Methods --------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 事件描述：指定輸出的 HTML（覆蓋上層）
	/// </summary>
	/// <param name="output">指定要輸出的 HTML 寫入器 (HTMLTextWriter)</param>
	protected override void Render(System.Web.UI.HtmlTextWriter output)
	{
		if (is_Html == "")
			base.Render(output);
		else
			output.Write(is_Html);

		if (LoginUser.ID == null)
		{
			output.WriteLine("<script language=\"javascript\">");
			output.WriteLine("	top.location = \"" + this.Request.ApplicationPath + "/Login.aspx" + "\";");
			output.WriteLine("</script>");
		}
	}
	
	// =========================================================================
	/// <summary>
	/// 函式描述：驗證登入資訊正確所要做的處理（覆蓋上層）
	/// </summary>
	protected override void uf_CheckLogin_Success()
	{
		// ##### 宣告變數 #####
		string ls_MenuID = "", ls_SysID = "", ls_FuncID = "";
		int li_Pos;

		// 找 Request 傳入值的「系統代碼」.「系統代碼」+「操作代碼」
		if (this.Request["menu_id"] != null)
			ls_MenuID = this.Request["menu_id"].ToString().Trim();

		// 先得到操作代碼「.」之後需去掉系統代碼的長度
		li_Pos = ls_MenuID.IndexOf(".");
		if (li_Pos >= 0)
		{
			ls_FuncID = ls_MenuID.Substring(li_Pos + 1 + (li_Pos));
			// 再得到系統代碼
			ls_SysID = ls_MenuID.Substring(0, li_Pos);
		}

		// ##### 宣告變數 #####
		ndb_userright_func lndb_UserRight = new ndb_userright_func();

		// 指定權限語法，連接到資料庫並取出指定操作資料 --------------------- ☆
		lndb_UserRight.uf_Retrieve("", LoginUser.ID, ls_SysID, ls_FuncID, false);
		lndb_UserRight.dv_View = lndb_UserRight.ds_Data.Tables[0].DefaultView;
		lndb_UserRight.uf_Sort("func_level, upd_flag DESC, check_flag DESC");

		// 如果有找到符合的資料，表示有此權限則建立 Session 記錄下來
		if (lndb_UserRight.uf_RowCount() > 0)
			this.Session["ss_menu_id"] = ls_MenuID;
		else
			this.Session.Remove("ss_menu_id");

		// 產生操作功能導引頁
		this.uf_BuildFrame(lndb_UserRight);
	}

	#endregion

}
