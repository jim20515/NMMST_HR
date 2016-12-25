// *********************************************************************************
// 1. 程式描述：用戶來源分析測試項目
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

public partial class sys_a_p_sample04 : p_sBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // ##### 宣告變數 #####
            DataSet lds_YM;
            string ls_year, ls_month;
            DateTime ldt_sdate, ldt_edate;

            // 帶入初始值
            // 找到資料中最新的年月
            DbMethods.Timeout = 0;
            DbMethods.uf_Retrieve_FromSQL(out lds_YM, " SELECT Top 1 SYear, SMonth FROM MCE_Log..LogFileName ORDER BY SDate DESC ");

            // 判斷是否有找到資料
            if (lds_YM.Tables[0].Rows.Count > 0)
            {
                ls_year = lds_YM.Tables[0].Rows[0][0].ToString().Trim();
                ls_month = lds_YM.Tables[0].Rows[0][1].ToString().Trim();

                //組成日期區間
                ldt_sdate = Convert.ToDateTime(ls_year + "/" + ls_month + "/" + "01");
                ldt_edate = ldt_sdate.AddMonths(1).AddDays(-1);

                u_Date3.Value = ldt_sdate.ToString("yyyy/MM/dd");
                u_Date4.Value = ldt_edate.ToString("yyyy/MM/dd");

                this.bt_Query_Click(this, EventArgs.Empty);
            }
            DbMethods.Timeout = DbMethods.Timeout_Default;
        }

    }
    protected void bt_Query_Click(object sender, EventArgs e)
    {
        if (u_Date3.Value == "" || u_Date4.Value == "")
        {
            uf_Msg("請輸入查詢區間");
            return;
        }

        // ##### 宣告變數 #####
        // Array of report parameters
        Microsoft.Reporting.WebForms.ReportParameter[] rsparams = new Microsoft.Reporting.WebForms.ReportParameter[2];

        rsparams[0] = new Microsoft.Reporting.WebForms.ReportParameter("sdate", u_Date3.Value.Substring(0,10), true);
        rsparams[1] = new Microsoft.Reporting.WebForms.ReportParameter("edate", u_Date4.Value.Substring(0, 10), true);
        ReportViewer1.ServerReport.SetParameters(rsparams);
        ReportViewer1.ServerReport.Refresh();

    }
}
