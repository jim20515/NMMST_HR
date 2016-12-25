// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 系統模組功能選單之 Web 使用者控制項
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

public partial class proj_right_u_ModuleBar : System.Web.UI.UserControl
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
	/// 函式描述：利用模組權限陣列建立 Module
	/// </summary>
	/// <param name="asa_UserModuleList">模組權限陣列</param>
	/// <param name="as_ModID">選擇的模組</param>
	public void uf_Build(string[,] asa_UserModuleList, string as_ModID)
	{
		// ##### 宣告變數 #####
		int			li_Row, li_RowCount, li_Index;
		string		ls_Ret, ls_Style;

		li_RowCount = (asa_UserModuleList.Length / 4);
		li_Index = 0;
		ls_Ret = "<table class=\"ModuleBar\" id=\"ModuleBar\">" + "\n";
		for (li_Row = 1; li_Row <= li_RowCount; li_Row++)  // 模組列迴圈
		{
			if (asa_UserModuleList[li_Index, 0] != as_ModID)
			{
				ls_Style = "";
			}
			else
			{
				ls_Style = "S";
			}

			ls_Ret += "	<tr>" + "\n";
			ls_Ret += "		<td class=\"MOItem" + ls_Style + "\" id=\"MOI_" + asa_UserModuleList[li_Index, 0] + "\" valign=\"center\"><img alt=\"\" src=\"" + asa_UserModuleList[li_Index, 3] + "\" />　<a tabindex=\"-1\" class=\"MOILink" + ls_Style + "\" href=\"http:" + this.Request.ApplicationPath + "/proj_home/p_Home.aspx?menu_id=" + asa_UserModuleList[li_Index, 2] + "\">" + asa_UserModuleList[li_Index, 1] + "</a></td>" + "\n";
			ls_Ret += "	</tr>" + "\n";
			li_Index += 1;

		}

		ls_Ret += "</table>" + "\n";

		litr_ModuleBar.Text = ls_Ret;
	}
}
