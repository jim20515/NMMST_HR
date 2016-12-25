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

public partial class sys_a_p_sample01 : p_sBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            this.bt_Query_Click(this, EventArgs.Empty);
        }
    }
    protected void bt_Query_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        // Array of report parameters
        //Microsoft.Reporting.WebForms.ReportParameter[] rsparams = new Microsoft.Reporting.WebForms.ReportParameter[2];

        //rsparams[0] = new Microsoft.Reporting.WebForms.ReportParameter("sdate", u_Date3.Value.Substring(0,10), true);
        //rsparams[1] = new Microsoft.Reporting.WebForms.ReportParameter("edate", u_Date4.Value.Substring(0, 10), true);
        //ReportViewer1.ServerReport.SetParameters(rsparams);
        ReportViewer1.ServerReport.Refresh();

    }
}
