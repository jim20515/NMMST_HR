// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 系統公告之 Web 使用者控制項
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

public partial class proj_right_u_Notice : System.Web.UI.UserControl
{
    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟（在 WebForm 的 Page_Load 之後處理）
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        // 當第一次執行此網頁時才顯示公告訊息
        if (!this.IsPostBack)
        {
            this.uf_Build();
        }
    }

    // =========================================================================
    /// <summary>
    /// 函式描述：利用系統公告資料建立 Notice
    /// </summary>
    public void uf_Build()
    {
        // ##### 宣告變數 #####
		DataSet		lds_sys07;
		DataView	ldv_sys07;
        string      ls_Ret = "";
        int         li_row, li_rowcount, li_width = 400, li_Height = 52;
        string      ls_pdate = "", ls_unit = "", ls_title = "", ls_content = "", ls_url = "";

        // 取出符合條件的公告資料
		DbMethods.uf_Retrieve_FromSQL(out lds_sys07, "SELECT * FROM sys07 WHERE s07_pdate <= GetDate() AND IsNull(s07_edate, Convert(datetime, '9999/12/31')) >= GetDate() AND IsNull(s07_stop, 'N') = 'N' AND RTrim(s07_tounit) = '0'");
		ldv_sys07 = lds_sys07.Tables[0].DefaultView;
		ldv_sys07.Sort = "s07_pdate DESC, s07_sort, s07_no DESC";

		li_rowcount = ldv_sys07.Count;

        ls_Ret += "	<img style=\"z-index: 101; left: 4px; position: absolute; top: 4px\" src=\"" + this.Request.ApplicationPath + "/proj_img/NoticeWord.gif\" />" + "\r\n";
        ls_Ret += "	<div id=\"dwNotice\" style=\"z-index: 102; left: 80px; position: absolute; top: 16px; visibility: hidden; width: " + li_width.ToString() + "px; height: " + li_Height.ToString() + "px\"></div>" + "\r\n";
        ls_Ret += "	<script language=\"javascript\" src=\"" + this.Request.ApplicationPath + "/proj_right/j_scroller.js\"></script>" + "\r\n";
        ls_Ret += "	<script language=\"javascript\" src=\"" + this.Request.ApplicationPath + "/proj_right/j_dhtmllib.js\"></script>" + "\r\n";
        ls_Ret += "	<script language=\"javascript\">" + "\r\n";
        ls_Ret += "		var myScroller = new Scroller (0, 0, " + li_width.ToString() + ", " + li_Height.ToString() + ", 0, 0, \"dwNotice\");" + "\r\n";
        ls_Ret += "		myScroller.setColors(\"\", \"\", \"\"); " + "\r\n";
        ls_Ret += "		myScroller.setFont(\"\", 2);" + "\r\n";
        ls_Ret += "		myScroller.setSpeed(80);" + "\r\n";
        ls_Ret += "		myScroller.setPause(2000);" + "\r\n";
        ls_Ret += "" + "\r\n";
        ls_Ret += "		function runmikescroll()" + "\r\n";
        ls_Ret += "		{" + "\r\n";
        ls_Ret += "			myScroller.create();" + "\r\n";
        ls_Ret += "			myScroller.hide();" + "\r\n";
        ls_Ret += "			myScroller.setzIndex(999);" + "\r\n";
        ls_Ret += "			myScroller.show();" + "\r\n";
        ls_Ret += "		}" + "\r\n";
        ls_Ret += "		window.onload=runmikescroll" + "\r\n";
        ls_Ret += "	</script>" + "\r\n";
        ls_Ret += "	<script language=\"javascript\">" + "\r\n";
        for (li_row = 0; li_row < li_rowcount; li_row++)
        {
            // 取得相關資料
            ls_unit = ldv_sys07[li_row]["s07_unit"].ToString();
            if (ls_unit != "") ls_unit = "　　<font class='PU'>>> post by " + Dbcfg.uf_Bind_TextByValue("hca202", ls_unit) + "</font>";

            ls_pdate = DateMethods.uf_YYYY_To_YYY(Convert.ToDateTime(ldv_sys07[li_row]["s07_pdate"]).ToString("yyyy/MM/dd"));
            if (ls_pdate != "") ls_pdate = "<font class='PD'>[ " + ls_pdate + " ]" + "</font><br />";

            ls_title = ldv_sys07[li_row]["s07_title"].ToString();
            ls_content = ldv_sys07[li_row]["s07_content"].ToString();

            // 轉換換行符號
            ls_content = ls_content.Replace(Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(), "<br />");
            ls_content = ls_content.Replace(Convert.ToChar(10).ToString(), "<br />");
            ls_content = ls_content.Replace(Convert.ToChar(13).ToString(), "<br />");
            ls_content = ls_content.Replace("\\n", "<br />");

            // 轉換特殊符號
            ls_content = ls_content.Replace(@"\", @"\\");
            ls_content = ls_content.Replace("'", "");
            ls_content = ls_content.Replace("\"", "");

            ls_url = ldv_sys07[li_row]["s07_url"].ToString();

            // 轉換特殊符號
            ls_url = ls_url.Replace(@"\", @"\\");
            ls_url = ls_url.Replace("'", "");
            ls_url = ls_url.Replace("\"", "");

            if (ls_url != "")
                ls_url = "<a class='PC' href='" + ls_url + "' target='_blank'> (相關連結)</a>";

            // 傳回開啟視窗語法
            if (ls_content != "")
                ls_content = "<a class='PC' href=\\\"javascript:uf_ShowWindow('公告內容', '標題：" + ls_title + "<br /><br />內容：" + ls_content + "', 'Green')\\\"> (詳見內容)</a>";

            ls_Ret += "		myScroller.addItem(\"" + ls_pdate + "<font class='PT'>＃" + Convert.ToString(li_row + 1) + "/" + li_rowcount.ToString() + "　" + ls_title + "</font>" + ls_content + ls_url + ls_unit + "\");" + "\r\n";
        }
        if (li_rowcount <= 0)
        {
            ls_Ret += "		myScroller.addItem(\"目前無系統公告\");" + "\r\n";
            dwN.Visible = false;
        }
        ls_Ret += "	</script>" + "\r\n";

        litr_NoticeItem.Text = ls_Ret;
    }
}
