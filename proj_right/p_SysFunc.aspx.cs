// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 使用者權限操作功能標題頁
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

public partial class proj_right_p_SysFunc : p_MenuPage
{
	/// <summary>變數描述：操作項目 Left 位置初始值</summary>
	private int ii_Left = (Setup.ib_IsShowSymbol ? 50 : 4);
	/// <summary>變數描述：操作項目 Top 位置初始值(原值12)</summary>
	private int ii_Top = 32;
	/// <summary>變數描述：操作項目 Height 初始值(原值18)</summary>
	private int ii_Height = 18;
	/// <summary>變數描述：操作項目 Width 位移多少</summary>
	private int ii_LeftSub = 4;
	/// <summary>變數描述：操作項目 Height 位置初始值</summary>
	private int ii_TopSub = 4;

	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：是否顯示層級的操作名稱</summary>
	private bool ib_IsShowLevelFuncName = WIT.Template.Project.Invoke.Setup.ib_IsShowLevelFuncName;
	/// <summary>變數描述：是否顯示子系統名稱</summary>
	private bool ib_IsShowSysName = WIT.Template.Project.Invoke.Setup.ib_IsShowSysName;
	/// <summary>變數描述：層級的操作名稱分隔符號</summary>
	private string is_Split = WIT.Template.Project.Invoke.Setup.is_SysFuncNameSplit;

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
	/// <param name="andb_UserRight">操作權限資料元件</param>
	private void uf_BuildFrame(ndb_userright_func andb_UserRight)
	{
		// ##### 宣告變數 #####
		System.Text.Encoding l_Encoding;
		string		ls_items = "", ls_mainpage, ls_text, ls_src, ls_level, ls_sysname;
		string[]	lsa_item = new string[1];
		string		ls_itemobjs = "null", ls_srcs = "\"\"", ls_levels = "0";
		int			li_i, li_count, li_pos, li_index = 0, li_left = this.ii_Left, li_top = this.ii_Top, li_width, li_height = this.ii_Height;
		bool		lb_IsMain = false;

		litr_SysFunc.Text = "";
		lsa_item[0] = "";

		if (andb_UserRight.uf_RowCount() <= 0)
		{
			litr_SysFunc.Text = "<font color=\"#ff0000\">您沒有權限使用本功能！</font>";
			return;
		}

		// 得到指定的編碼方式
		l_Encoding = System.Text.Encoding.GetEncoding(950);

		ls_mainpage = andb_UserRight[0]["func_url"].ToString().Trim();
		// 將操作項目依據「|」區分出項目來，操作項目例子："查詢=query|清單=list;1|明細資料=edit;2|
		lsa_item = andb_UserRight[0]["func_item"].ToString().Trim().Split('|');

		// 依據操作項目數量產生不同切換 Frame 按鍵
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
				if (li_pos < 0)
				{
					ls_level = "0";
				}
				else
				{
					// 拆解出項目代號和項目層級(錯誤的指定值皆轉換成 0)
					try
					{
						ls_level = Convert.ToInt32(ls_src.Substring(li_pos + 1).Trim()).ToString();
					}
					catch
					{
						ls_level = "0";
					}
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

				// 設定顯示的寬度(計算轉成 Big5 的長度來推算)
				li_width = 6 * l_Encoding.GetByteCount(ls_text) + 30;

				// 利用項目代號代號組合出 Frame 名稱
				li_index++;

				ls_itemobjs += ",document.all." + "MFI_" + ls_src;
				ls_srcs += ",\"" + ls_mainpage.Replace(".aspx", "_" + ls_src + ".aspx") + "\"";
				ls_levels += "," + ls_level;
				ls_items += "			<span class=\"MFItem MFItem" + li_index.ToString() + "\" id=\"MFI_" + ls_src + "\" style=\"z-index: " + li_index.ToString() + "; left: " + li_left.ToString() + "; top: " + li_top.ToString() + "; width: " + li_width.ToString() + "; height: " + li_height.ToString() + ";\" onclick=\"{ib_click = true; uf_ShowFrame('" + this.Request.ApplicationPath + "/" + "', " + li_index.ToString() + ");}\" onmouseover=\"{this.orgcolor=this.style.color; this.style.color=255;}\" onmouseout=\"{this.style.color=this.orgcolor;}\" orgclass=\"MFItem" + li_index.ToString() + "\" orgindex=\"" + li_index.ToString() + "\" orgleft=\"" + li_left.ToString() + "\" orgtop=\"" + li_top.ToString() + "\" orgwidth=\"" + li_width.ToString() + "\" orgheight=\"" + li_height.ToString() + "\" orgcolor=\"\">" + ls_text + "</span>" + "\r\n";

				li_left += li_width - 1;
			}

			ls_items += "			<span class=\"MFItemLine\" style=\"z-index: 0; position: absolute; left: 0; top: " + Convert.ToString(li_top + li_height - 1) + "; width: 100%; height: 1;\"></span>" + "\r\n";
		}

		if (lb_IsMain)
			ls_items = "";

		// 得到顯示的操作名稱
		ls_sysname = this.uf_BuildText(andb_UserRight, lb_IsMain);

		// 操作權限功能標題頁
		litr_SysFunc.Text += "			<table border=\"0\" align=\"right\" style=\"border-collapse: collapse; padding: 0 0 0 0; margin: 0 0 0 0;\">" + "\r\n";
		litr_SysFunc.Text += "				<tr>" + "\r\n";
		litr_SysFunc.Text += "					<td class=\"Frame_SysImg\" valign=\"middle\"><img alt=\"\" src=\"" + this.Request.ApplicationPath + "/proj_img/Funcname.gif\" align=\"absmiddle\" />" + "</td>" + "\r\n";
		litr_SysFunc.Text += "					<td class=\"Frame_SysName\" valign=\"middle\">&nbsp;<span id=\"sysname\" oldvalue=\"" + ls_sysname + "\">" + ls_sysname + "</span></td>" + "\r\n";
		litr_SysFunc.Text += "					<td class=\"Frame_SysId\" valign=\"middle\">(" + andb_UserRight[0]["rid"].ToString().Trim() + ")</td>" + "\r\n";
		string ls_href = this.Request.ApplicationPath + "/" + DbMethods.uf_ProfileString(DbMethods.is_INIPath, "UserGuide", "Src", "app_doc/userguide/").Trim() + andb_UserRight[0]["rid"].ToString().Trim() + "." + DbMethods.uf_ProfileString(DbMethods.is_INIPath, "UserGuide", "Type", "pdf").Trim();
		if (System.IO.File.Exists(Server.MapPath(ls_href)))
			litr_SysFunc.Text += "					<td class=\"Frame_Sys\" valign=\"middle\"><a href=\"" + ls_href + "\" target=\"_blank\"><img alt=\"\" src=\"" + this.Request.ApplicationPath + "/proj_img/Help.gif\" align=\"absmiddle\" style=\"cursor: hand; border: 0px\" title=\"使用者操作手冊\" onclick=\"\" />" + "</a></td>" + "\r\n";
		litr_SysFunc.Text += "				</tr>" + "\r\n";
		litr_SysFunc.Text += "			</table>" + "\r\n";
		litr_SysFunc.Text += ls_items;

		// 操作權限功能標題頁切換 Frame JavaScript
		if (ls_items != "")
		{
			litr_SysFunc.Text += "			<script language=\"javascript\">" + "\r\n";
			litr_SysFunc.Text += "				var ib_click = false;" + "\r\n";
			litr_SysFunc.Text += "				var ib_stop = false;" + "\r\n";
			litr_SysFunc.Text += "				var io_currentObj;" + "\r\n";
			litr_SysFunc.Text += "				var ii_currentFrame = 0;" + "\r\n";
			litr_SysFunc.Text += "				var is_funcFrameHeight = \"" + Convert.ToString(li_top + li_height) + "\";" + "\r\n";
			litr_SysFunc.Text += "				var is_mainlFrameHeight = \"*\";" + "\r\n";
			litr_SysFunc.Text += "				var ioa_itemList = new Array(" + ls_itemobjs + ");" + "\r\n";
			litr_SysFunc.Text += "				var isa_frameList = new Array(" + ls_srcs + ");" + "\r\n";
			litr_SysFunc.Text += "				var iia_levelList = new Array(" + ls_levels + ");" + "\r\n";
			litr_SysFunc.Text += "				var ii_itemcount = " + li_index.ToString() + ";" + "\r\n";
			litr_SysFunc.Text += "				" + "\r\n";
			litr_SysFunc.Text += "				function uf_ShowFrame(as_rootpath, ai_frameno)" + "\r\n";
			litr_SysFunc.Text += "				{" + "\r\n";
			litr_SysFunc.Text += "					uf_ShowFrame(as_rootpath, ai_frameno, null);" + "\r\n";
			litr_SysFunc.Text += "				}" + "\r\n";
			litr_SysFunc.Text += "				" + "\r\n";
			litr_SysFunc.Text += "				function uf_ShowFrame(as_rootpath, ai_frameno, as_argument)" + "\r\n";
			litr_SysFunc.Text += "				{" + "\r\n";
			litr_SysFunc.Text += "					var lb_itemclick = ib_click;" + "\r\n";
			litr_SysFunc.Text += "					ib_click = false;" + "\r\n";
			litr_SysFunc.Text += "					" + "\r\n";
			litr_SysFunc.Text += "					if (ib_stop)" + "\r\n";
			litr_SysFunc.Text += "					{" + "\r\n";
			litr_SysFunc.Text += "						ib_stop = false;" + "\r\n";
			litr_SysFunc.Text += "						return;" + "\r\n";
			litr_SysFunc.Text += "					}" + "\r\n";
			litr_SysFunc.Text += "					if (as_argument == \"undefined\" || as_argument == null)" + "\r\n";
			litr_SysFunc.Text += "					{" + "\r\n";
			litr_SysFunc.Text += "						if (ii_currentFrame == ai_frameno) return;" + "\r\n";
			litr_SysFunc.Text += "					}" + "\r\n";
			litr_SysFunc.Text += "					" + "\r\n";
			litr_SysFunc.Text += "					if (io_currentObj != null)" + "\r\n";
			litr_SysFunc.Text += "					{" + "\r\n";
			litr_SysFunc.Text += "						// Reset current object" + "\r\n";
			litr_SysFunc.Text += "						io_currentObj.style.zIndex = parseInt(io_currentObj.orgindex);" + "\r\n";
			litr_SysFunc.Text += "						io_currentObj.style.left = parseInt(io_currentObj.orgleft);" + "\r\n";
			litr_SysFunc.Text += "						io_currentObj.style.top = parseInt(io_currentObj.orgtop);" + "\r\n";
			litr_SysFunc.Text += "						io_currentObj.style.width = parseInt(io_currentObj.orgwidth);" + "\r\n";
			litr_SysFunc.Text += "						io_currentObj.style.height = parseInt(io_currentObj.orgheight);" + "\r\n";
			litr_SysFunc.Text += "						io_currentObj.className = \"MFItem \" + io_currentObj.orgclass;" + "\r\n";
			litr_SysFunc.Text += "					}" + "\r\n";
			litr_SysFunc.Text += "					" + "\r\n";
			litr_SysFunc.Text += "					var ls_coltext = is_funcFrameHeight;" + "\r\n";
			litr_SysFunc.Text += "					var li_j;" + "\r\n";
			litr_SysFunc.Text += "					for (li_j = 0; li_j < ii_itemcount; li_j++)" + "\r\n";
			litr_SysFunc.Text += "					{" + "\r\n";
			litr_SysFunc.Text += "						if (ai_frameno == (li_j+1))" + "\r\n";
			litr_SysFunc.Text += "						{ " + "\r\n";
			litr_SysFunc.Text += "							ls_coltext += \",\" + is_mainlFrameHeight;" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "						else" + "\r\n";
			litr_SysFunc.Text += "						{" + "\r\n";
			litr_SysFunc.Text += "							ls_coltext += \",0\";" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "					}" + "\r\n";
			litr_SysFunc.Text += "					" + "\r\n";
			litr_SysFunc.Text += "					// Recode current object" + "\r\n";
			litr_SysFunc.Text += "					ii_currentFrame = ai_frameno;" + "\r\n";
			litr_SysFunc.Text += "					io_currentObj = ioa_itemList[ai_frameno];" + "\r\n";
			litr_SysFunc.Text += "					" + "\r\n";
			litr_SysFunc.Text += "					// Set current object" + "\r\n";
			litr_SysFunc.Text += "					io_currentObj.style.zIndex = 999;" + "\r\n";
			litr_SysFunc.Text += "					io_currentObj.style.left = parseInt(io_currentObj.orgleft) - " + Convert.ToString(this.ii_LeftSub) + ";" + "\r\n";
			litr_SysFunc.Text += "					io_currentObj.style.top = parseInt(io_currentObj.orgtop) - " + Convert.ToString(this.ii_TopSub) + ";" + "\r\n";
			litr_SysFunc.Text += "					io_currentObj.style.width = parseInt(io_currentObj.orgwidth) + " + Convert.ToString(this.ii_LeftSub * 2) + ";" + "\r\n";
			litr_SysFunc.Text += "					io_currentObj.style.height = parseInt(io_currentObj.orgheight) + " + Convert.ToString(this.ii_TopSub + 1) + ";" + "\r\n";
			litr_SysFunc.Text += "					io_currentObj.className = \"MFItem \" + io_currentObj.orgclass + \" \" + io_currentObj.orgclass + \"S MFItemS\";" + "\r\n";
			litr_SysFunc.Text += "					" + "\r\n";
			litr_SysFunc.Text += "					var lo_currentframe = top.menuleadFrame.frames[ai_frameno];" + "\r\n";
			litr_SysFunc.Text += "					" + "\r\n";
			litr_SysFunc.Text += "					if (as_argument != \"no\" && as_rootpath != null)" + "\r\n";
			litr_SysFunc.Text += "					{" + "\r\n";
			litr_SysFunc.Text += "						// Have Argument" + "\r\n";
			litr_SysFunc.Text += "						if (as_argument != null && as_argument != \"undefined\")" + "\r\n";
			litr_SysFunc.Text += "						{" + "\r\n";
			litr_SysFunc.Text += "							lo_currentframe.location = as_rootpath + isa_frameList[ai_frameno] + ((as_argument != \"\") ? \"?\" + as_argument : \"\");" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "						// First time" + "\r\n";
			litr_SysFunc.Text += "						else if (lo_currentframe.location == \"about:blank\")" + "\r\n";
			litr_SysFunc.Text += "						{" + "\r\n";
			litr_SysFunc.Text += "							lo_currentframe.location = as_rootpath + isa_frameList[ai_frameno];" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "						// First time" + "\r\n";
			litr_SysFunc.Text += "						else if (lo_currentframe.ib_new != null && lo_currentframe.ib_new)" + "\r\n";
			litr_SysFunc.Text += "						{" + "\r\n";
			litr_SysFunc.Text += "							lo_currentframe.location = as_rootpath + isa_frameList[ai_frameno];" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "						// Retrieve time" + "\r\n";
			litr_SysFunc.Text += "						else if (lo_currentframe.ib_retrieve != null && lo_currentframe.ib_retrieve)" + "\r\n";
			litr_SysFunc.Text += "						{" + "\r\n";
			litr_SysFunc.Text += "							if (lo_currentframe.htmldw == null)" + "\r\n";
			litr_SysFunc.Text += "								lo_currentframe.location.reload();" + "\r\n";
			litr_SysFunc.Text += "							else" + "\r\n";
			litr_SysFunc.Text += "								lo_currentframe.htmldw.Retrieve();" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "						else" + "\r\n";
			litr_SysFunc.Text += "						{" + "\r\n";
			litr_SysFunc.Text += "							uf_ShowFrameTitle(ai_frameno);" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "					}" + "\r\n";
			litr_SysFunc.Text += "					else" + "\r\n";
			litr_SysFunc.Text += "					{" + "\r\n";
			litr_SysFunc.Text += "						uf_ShowFrameTitle(ai_frameno);" + "\r\n";
			litr_SysFunc.Text += "					}" + "\r\n";
			litr_SysFunc.Text += "					" + "\r\n";
			litr_SysFunc.Text += "					top.menuleadFrame.document.body.rows = ls_coltext;" + "\r\n";
			litr_SysFunc.Text += "					" + "\r\n";
			litr_SysFunc.Text += "					if (! lb_itemclick && (lo_currentframe.IsPostBack == \"undefined\" || ! lo_currentframe.IsPostBack))" + "\r\n";
			litr_SysFunc.Text += "					{" + "\r\n";
			litr_SysFunc.Text += "						if (lo_currentframe.ib_childframe == \"undefined\" || lo_currentframe.ib_childframe)" + "\r\n";
			litr_SysFunc.Text += "						{" + "\r\n";
			litr_SysFunc.Text += "							lo_currentframe.ib_childframe = false;" + "\r\n";
			litr_SysFunc.Text += "							uf_ChildFrameDo(ai_frameno);" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "					}" + "\r\n";
			litr_SysFunc.Text += "				}" + "\r\n";
			litr_SysFunc.Text += "				" + "\r\n";
			litr_SysFunc.Text += "				function uf_ShowFrameTitle(ai_frameno)" + "\r\n";
			litr_SysFunc.Text += "				{" + "\r\n";
			litr_SysFunc.Text += "					var lo_currentframe = top.menuleadFrame.frames[ai_frameno];" + "\r\n";
			litr_SysFunc.Text += "					var lo_obj = document.getElementById(\"sysname\");" + "\r\n";
			litr_SysFunc.Text += "					if (lo_obj != null)" + "\r\n";
			litr_SysFunc.Text += "					{" + "\r\n";
			litr_SysFunc.Text += "						if (lo_currentframe.IsShowTitle != null && lo_currentframe.IsShowTitle && lo_currentframe.document.title != \"\")" + "\r\n";
			litr_SysFunc.Text += "						{" + "\r\n";
			litr_SysFunc.Text += "							if ((\"" + this.is_Split + "\" + lo_obj.oldvalue).lastIndexOf(\"" + this.is_Split + "\" + lo_currentframe.document.title) == -1)" + "\r\n";
			litr_SysFunc.Text += "								lo_obj.innerText = lo_obj.oldvalue + \"" + this.is_Split + "\" + lo_currentframe.document.title;" + "\r\n";
			litr_SysFunc.Text += "							else" + "\r\n";
			litr_SysFunc.Text += "								lo_obj.innerText = lo_obj.oldvalue;" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "						else" + "\r\n";
			litr_SysFunc.Text += "						{" + "\r\n";
			litr_SysFunc.Text += "							lo_obj.innerText = lo_obj.oldvalue;" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "					}" + "\r\n";
			litr_SysFunc.Text += "				}" + "\r\n";
			litr_SysFunc.Text += "				" + "\r\n";
			litr_SysFunc.Text += "				function uf_ChildFrameDo(ai_frameno)" + "\r\n";
			litr_SysFunc.Text += "				{" + "\r\n";
			litr_SysFunc.Text += "					var li_level = iia_levelList[ai_frameno];" + "\r\n";
			litr_SysFunc.Text += "					if (li_level <= 0) return;" + "\r\n";
			litr_SysFunc.Text += "					" + "\r\n";
			litr_SysFunc.Text += "					var li_j;" + "\r\n";
			litr_SysFunc.Text += "					for (li_j = 0; li_j < ii_itemcount; li_j++)" + "\r\n";
			litr_SysFunc.Text += "					{" + "\r\n";
			litr_SysFunc.Text += "						if (li_level < iia_levelList[li_j+1])" + "\r\n";
			litr_SysFunc.Text += "						{ " + "\r\n";
			litr_SysFunc.Text += "							if (top.menuleadFrame.frames[li_j+1].ib_new != null)" + "\r\n";
			litr_SysFunc.Text += "								top.menuleadFrame.frames[li_j+1].ib_new = true;" + "\r\n";
			litr_SysFunc.Text += "						}" + "\r\n";
			litr_SysFunc.Text += "					}" + "\r\n";
			litr_SysFunc.Text += "				}" + "\r\n";
			litr_SysFunc.Text += "				" + "\r\n";
			litr_SysFunc.Text += "				// Select First Item" + "\r\n";
			litr_SysFunc.Text += "				uf_ShowFrame('" + this.Request.ApplicationPath + "/', 1);" + "\r\n";
			litr_SysFunc.Text += "			</script>" + "\r\n";
		}

		// 產生標點符號表
		if (Setup.ib_IsShowSymbol)
		{
			if (ls_items != "")
				u_Symbol.uf_Build(LoginUser.ID, "top.menuleadFrame.frames[top.menuleadFrame.funcFrame.ii_currentFrame]");
			else
				u_Symbol.uf_Build(LoginUser.ID, "top.menuleadFrame.frames[1]");
		}
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：產生顯示的操作名稱（含層級）
	/// </summary>
	/// <param name="andb_UserRight">操作權限資料元件</param>
	/// <param name="ab_IsMain">只有一頁–是(true)；否(false)</param>
	/// <returns>顯示的操作名稱（含層級）</returns>
	private string uf_BuildText(ndb_userright_func andb_UserRight, bool ab_IsMain)
	{
		// ##### 宣告變數 #####
		string		ls_text, ls_tmp_text;

		// 先設定成操作名稱
		ls_text = andb_UserRight[0]["func_text"].ToString().Trim();

		// 如果只有一頁才顯示父層，因為怕空間不夠顯示
		if (ab_IsMain || this.ib_IsShowLevelFuncName)
		{
			for (int li_row = 1; li_row < andb_UserRight.uf_RowCount(); li_row++)
			{
				ls_tmp_text = andb_UserRight[li_row]["func_text"].ToString().Trim();
				if (ls_tmp_text != "")
					ls_text = ls_tmp_text + this.is_Split + ls_text;
			}
		}

		// 最後再加上子系統名稱
		if (this.ib_IsShowSysName)
		{
			ls_tmp_text = andb_UserRight[0]["sys_text"].ToString().Trim();
			if (ls_tmp_text != "")
				ls_text = ls_tmp_text + this.is_Split + ls_text;
		}

		return ls_text;
	}

	#region ☆ Override Methods --------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：驗證登入資訊正確所要做的處理（覆蓋上層）
	/// </summary>
	protected override void uf_CheckLogin_Success()
	{
		// ##### 宣告變數 #####
		string		ls_MenuID = "", ls_SysID = "", ls_FuncID = "";
		int			li_Pos;

		// 找 Session 記錄的 [ss_menu_id] 值「子系統代碼」.「子系統代碼」+「操作代碼」
		if (this.Session["ss_menu_id"] != null)
			ls_MenuID = this.Session["ss_menu_id"].ToString().Trim();

		// 先得到操作代碼「.」之後需去掉子系統代碼的長度
		li_Pos = ls_MenuID.IndexOf(".");
		if (li_Pos >= 0)
		{
			ls_FuncID = ls_MenuID.Substring(li_Pos + 1 + (li_Pos));
			// 再得到子系統代碼
			ls_SysID = ls_MenuID.Substring(0, li_Pos);
		}

		// ##### 宣告變數 #####
		ndb_userright_func lndb_UserRight = new ndb_userright_func();

		// 指定權限語法，連接到資料庫並取出指定操作資料 --------------------- ☆
		lndb_UserRight.uf_Retrieve("", LoginUser.ID, ls_SysID, ls_FuncID, true);
		lndb_UserRight.dv_View = lndb_UserRight.ds_Data.Tables[0].DefaultView;
		lndb_UserRight.uf_Sort("func_level, upd_flag DESC, check_flag DESC");

		// 產生操作功能導引頁
		this.uf_BuildFrame(lndb_UserRight);
	}

	#endregion

}
