// *********************************************************************************
// 1. 程式描述：服務勤務管理–服勤表現管理–查詢及清單
// 2. 撰寫人員：demon
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

public partial class sys_e_e05_p_e0501_01 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            Dbcfg.uf_Bind(dwQ_hle501_tid, "hmd101", "(1=1)", true);

            int li_year = DbMethods.uf_GetDate().Year - 1911;
            this.dwQ_hle501_syear.Text = li_year.ToString("000");

            // 驅動查詢事件
            this.bt_Query_Click(sender, EventArgs.Empty);
        }

        dwQ_hle501_syear.Attributes["onBlur"] = "uf_GetNumeric(" + dwQ_hle501_syear.ClientID + ");";
	}
	
    protected void bt_Query_Click(object sender, EventArgs e)
    {
        if (dwQ_hle501_syear.Text.Trim() == "")
        {
            uf_Msg("請輸入年度！");
            return;
        }

        // 建立一個暫存表格1
        DataTable ldt_hle501 = new DataTable("hle501");
        DataView ldv_hle501 = ldt_hle501.DefaultView;
        DataRowView ldrv_New;
        int li_year = 0;
        li_year = Convert.ToInt16(dwQ_hle501_syear.Text);
        string ls_year = li_year.ToString("000");

        // 增加欄位
        ldt_hle501.Columns.Add("hle501_tid", typeof(String));
        ldt_hle501.Columns.Add("hle501_syear", typeof(String));
        ldt_hle501.Columns.Add("hle501_sseason", typeof(String));
        ldt_hle501.Columns.Add("hle501_sname", typeof(String));

        for (int li_season = 1; li_season <= 4; li_season++)
        {
            ldrv_New = ldv_hle501.AddNew();
            ldrv_New["hle501_tid"] = dwQ_hle501_tid.SelectedValue;
            ldrv_New["hle501_syear"] = ls_year;
            ldrv_New["hle501_sseason"] = li_season.ToString();
            if (li_season == 4)
                ldrv_New["hle501_sname"] = "全年度考核";
            else
                ldrv_New["hle501_sname"] = li_season.ToString();
        }

        dgG.DataSource = ldv_hle501;
        dgG.DataBind();

    }

    protected void dgG_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.uf_AddJavaScript("uf_LinkFrame('p_e0501_02.aspx', '02Frame', '" + dgG.Items[dgG.SelectedIndex].Cells[1].Text.Trim() + "|" + dgG.Items[dgG.SelectedIndex].Cells[3].Text.Trim() + "|" + dgG.Items[dgG.SelectedIndex].Cells[4].Text.Trim() + "');");
    }
}
