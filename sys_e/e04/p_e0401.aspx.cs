// *********************************************************************************
// 1. 程式描述：服務勤務管理–勤務紀錄管理–查詢及清單
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

public partial class sys_e_e04_p_e0401 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：WITSETER (QFLin)

	/// <summary>變數描述：資料元件</summary>
    protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	
	protected void Page_Load(object sender, EventArgs e)
    {
        dwQ_year.Attributes["onBlur"] = "uf_GetNumeric(" + dwQ_year.ClientID + ");";
        dwQ_month.Attributes["onBlur"] = "uf_GetNumeric(" + dwQ_month.ClientID + ");";

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            int li_year = DbMethods.uf_GetDate().Year - 1911;
            this.dwQ_year.Text = li_year.ToString("000");
            this.dwQ_month.Text = DbMethods.uf_GetDate().Month.ToString("00");
			this.dwQ_yeare.Text = li_year.ToString("000");
			this.dwQ_monthe.Text = DbMethods.uf_GetDate().Month.ToString("00");
            this.bt_Query_Click(sender, EventArgs.Empty);
        }
	}

    protected void bt_print_Click(object sender, EventArgs e)
    {
		if (dwQ_year.Text.Trim() == "" || dwQ_month.Text.Trim() == "" || dwQ_yeare.Text.Trim() == "" || dwQ_monthe.Text.Trim() == "")
        {
            this.uf_Msg("請輸入查詢年度及月份！");
            return;
        }

		this.uf_AddJavaScript("uf_OpenWindow('p_e0401_report.aspx?year=" + Convert.ToString(Convert.ToInt16(dwQ_year.Text) + 1911) + "&month=" + Convert.ToInt16(dwQ_month.Text).ToString("00") + "&yeare=" + Convert.ToString(Convert.ToInt16(dwQ_yeare.Text) + 1911) + "&monthe=" + Convert.ToInt16(dwQ_monthe.Text).ToString("00") + "','',1024,768,'no','no');");
    }


    protected void bt_Query_Click(object sender, EventArgs e)
    {
		if (dwQ_year.Text.Trim() == "" || dwQ_month.Text.Trim() == "" || dwQ_yeare.Text.Trim() == "" || dwQ_monthe.Text.Trim() == "")
        {
            this.uf_Msg("請輸入查詢年度及月份！");
            return;
        }

        DataSet lds_data;
        DataView ldv_dataview;
        // 利用 SQL 語法產生資料集
        //DbMethods.uf_Retrieve_FromSQL(out lds_data, " Select hme101c_vid as vid , ( SELECT hmd201_cname From hmd201 Where hmd201_vid = hme101c_vid ) as vname , SUM( hme101b_foodCT ) as foodCT , SUM( hme101b_foodCT ) * ( Select Top 1 hca210_cost From hca210 Where hca210_name like '%誤餐費%' ) as foodMoney From hme101b , hme101c Where hme101b_pdid = hme101c_pdid  AND Year(hme101b_sdate) = " + Convert.ToString(Convert.ToInt16(dwQ_year.Text) + 1911) + " AND Month(hme101b_sdate) = " + dwQ_month.Text + " AND hme101c_onduty > 0 AND hme101b_foodCT > 0 GROUP BY hme101c_vid ");
		DbMethods.uf_Retrieve_FromSQL(out lds_data, " Select hme101c_vid as vid , ( SELECT hmd201_cname From hmd201 Where hmd201_vid = hme101c_vid ) as vname , SUM( hme101b_foodCT ) as foodCT , SUM( hme101b_foodCT ) * ( Select Top 1 hca210_cost From hca210 Where hca210_name like '%誤餐費%' ) as foodMoney From hme101b , hme101c Where hme101b_pdid = hme101c_pdid  AND Convert(char(6),hme101b_sdate,112) >= " + Convert.ToString(Convert.ToInt16(dwQ_year.Text) + 1911) + Convert.ToInt16(dwQ_month.Text).ToString("00") + " AND Convert(char(6),hme101b_sdate,112) <= " + Convert.ToString(Convert.ToInt16(dwQ_yeare.Text) + 1911) + Convert.ToInt16(dwQ_monthe.Text).ToString("00") + " AND hme101c_onduty > 0 AND hme101b_foodCT > 0 GROUP BY hme101c_vid ");
        ldv_dataview = lds_data.Tables[0].DefaultView;
        dgG.DataSource = ldv_dataview;
        dgG.DataBind();
    }
}
