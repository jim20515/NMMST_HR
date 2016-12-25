// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 標點符號表之 Web 使用者控制項
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

public partial class proj_right_u_Symbol : System.Web.UI.UserControl
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
	/// 函式描述：利用標點符號表資料建立 Symbol 選單
	/// </summary>
	/// <param name="as_UserID">使用者帳號</param>
	/// <param name="as_Frame">標點符號表作用的 Frame</param>
	public void uf_Build(string as_UserID, string as_Frame)
	{
		// ##### 宣告變數 #####
		System.Text.Encoding l_Encoding;
		DataSet		lds_sys08;
		DataView	ldv_sys08;
		int			li_Row, li_Col, li_RowCount, li_ColCount, li_Index;
		string		ls_Ret;
		int			li_width;

		// 得到指定的編碼方式
		l_Encoding = System.Text.Encoding.GetEncoding(950);

		// 連接到資料庫並取出全部標點符號表資料 ----------------------------- ☆
		DbMethods.uf_Retrieve_FromSQL(out lds_sys08, "SELECT * FROM sys08");
		ldv_sys08 = lds_sys08.Tables[0].DefaultView;

		// 產生標點符號表 --------------------------------------------------- ☆
		li_RowCount = 1;
		li_ColCount = ldv_sys08.Count + 2;
		li_Index = 0;

		// 標點符號表 Symbol
		ls_Ret = "<table class=\"Symbol\" id=\"Symbol\">" + "\n";

		for (li_Row = 1; li_Row <= li_RowCount; li_Row++)		// 列迴圈
		{
			ls_Ret += "	<tr>" + "\n";

			for (li_Col = 1; li_Col <= li_ColCount; li_Col++)		// 欄迴圈
			{
				if (li_Row == 1 && li_Col == 1)								// 往前欄位
				{
					// 設定顯示的寬度
					li_width = 20;

					// 增加一個空白項目
					//ls_Ret += "		<td class=\"SBItem\" id=\"SBI_first\" style=\"width:" + li_width.ToString() + "px;\"><input type=\"button\" value=\"<<\" style=\"background-color: #c6d0c7; border-style: outset; border-width: 1px; font-size: 13px;\" height=\"100%\" width=\"100%\"></td>" + "\n";
				}
				else if (li_Row == li_RowCount && li_Col == li_ColCount)	// 往後欄位
				{
					// 增加一個空白項目
					ls_Ret += "		<td class=\"SBItem\" id=\"SBI_empty\"></td>" + "\n";

					// 設定顯示的寬度
					li_width = 20;

					//ls_Ret += "		<td class=\"SBItem\" id=\"SBI_last\" style=\"width:" + li_width.ToString() + "px;\"><input type=\"button\" value=\">>\" style=\"background-color: #c6d0c7; border-style: outset; border-width: 1px; font-size: 13px;\" height=\"100%\" width=\"100%\"></td>" + "\n";
				}
				else														// 符號欄位
				{
					// 設定顯示的寬度(計算轉成 Big5 的長度來推算)
					li_width = 5 * l_Encoding.GetByteCount(ldv_sys08[li_Index][0].ToString().Trim()) + 30;

					ls_Ret += "		<td class=\"SBItem\" id=\"SBI_" + Convert.ToString(li_Index + 1) + "\" style=\"width:" + li_width.ToString() + "px;\" onmouseover=\"uf_GetFocus(" + as_Frame + "); uf_SelectItem('SBI_" + Convert.ToString(li_Index + 1) + "', true);\" onmouseout=\"uf_SelectItem('SBI_" + Convert.ToString(li_Index + 1) + "', false);\" onclick=\"uf_Insert('" + ldv_sys08[li_Index][0].ToString().Trim() + "');\">" + ldv_sys08[li_Index][0].ToString().Trim() + "</td>" + "\n";
					li_Index += 1;
				}
			}

			ls_Ret += "	</tr>" + "\n";
		}

		ls_Ret += "</table>" + "\n";

		ls_Ret += "<script language=\"javascript\" src=\"j_Symbol.js\"></script>";

		litr_Symbol.Text = ls_Ret;

		if (ldv_sys08.Count <= 0) return;


		// 產生開啟按鈕 ----------------------------------------------------- ☆
		ls_Ret = "<table border=\"0\" style=\"border-collapse: collapse\" height=\"100%\">" + "\n";
		ls_Ret += "	<tr>" + "\n";
		ls_Ret += "		<td valign=\"center\" style=\"padding-left: 4px\"><img alt=\"\" src=\"" + this.Request.ApplicationPath + "/proj_img/Symbol.gif\" align=\"absMiddle\" style=\"cursor: hand\" title=\"標點符號表（需先將焦點設到文字輸入欄位才可開啟）\" onmouseover=\"uf_GetFocus(" + as_Frame + ");\" onclick=\"if (io_focus != null) {io_focus.focus(); uf_SetSymbolVisible(true);}\" /></td>" + "\n";
		ls_Ret += "	</tr>" + "\n";
		ls_Ret += "</table>" + "\n";

		litr_Img.Text = ls_Ret;
	}
}
