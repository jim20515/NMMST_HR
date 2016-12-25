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
using Microsoft.Reporting.WebForms;

public partial class sys_e_e04_p_e0401_report : p_sBase
{
    // =========================================================================
    /// <summary>
    /// 事件描述：網頁初始化
    /// </summary>
    protected void Page_Init(object sender, EventArgs e)
    {
        // 不驗證使用者
        this.IsCheckUser = false;
        // 不執行 KeyDown 事件
        this.IsOnKeyDown = false;
        // 不驗證 Frame
        this.IsCheckFrame = false;
        // 不顯示 Version
        this.IsShowVersion = false;
        // 不顯示網頁 Title
        this.IsShowTitle = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request["year"] != null)
            ViewState["year"] = this.Request["year"].Trim();

        if (this.Request["month"] != null)
            ViewState["month"] = this.Request["month"].Trim();

		if (this.Request["yeare"] != null)
			ViewState["yeare"] = this.Request["yeare"].Trim();

		if (this.Request["monthe"] != null)
			ViewState["monthe"] = this.Request["monthe"].Trim();

        ExportReport(Response, "PDF"); 
    }

    private void ExportReport(HttpResponse response, string type)
    {
        // ##### 宣告變數 #####
        // Array of report parameters
        ReportParameter[] rsparams = new Microsoft.Reporting.WebForms.ReportParameter[4];

        rsparams[0] = new Microsoft.Reporting.WebForms.ReportParameter("Syear", ViewState["year"].ToString(), true);
        rsparams[1] = new Microsoft.Reporting.WebForms.ReportParameter("Smonth", ViewState["month"].ToString(), true);
		rsparams[2] = new Microsoft.Reporting.WebForms.ReportParameter("Eyear", ViewState["yeare"].ToString(), true);
		rsparams[3] = new Microsoft.Reporting.WebForms.ReportParameter("Emonth", ViewState["monthe"].ToString(), true);
       
		ReportViewer1.ServerReport.SetParameters(rsparams);
        ReportViewer1.ServerReport.Refresh();


        //ReportViewer1.LocalReport.DataSources.Clear();
        //DataTable dt1 = uf_getTable(1);
        //DataTable dt2 = uf_getTable(2);

        //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("rd_e0401_hme101c", dt1));
        //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("rd_e0401_ym_DataTable1", dt2));
        //ReportViewer1.LocalReport.Refresh();

        //Out params to pass into the Render method 
        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;

        //Call the Render method and save the return value in our byte array 
        byte[] bytes = ReportViewer1.ServerReport.Render(type, null, out mimeType, out encoding, out extension, out streamids, out warnings);

        /* Clear the Response object, set the ContentType, attach a header so the browser thinks it's downloading a file, write the byte array to the Response object and tell the bowser we're done by calling the End method */
        response.Clear();
        response.ContentType = mimeType;
        response.AppendHeader("Content-Disposition", String.Format("filename=report.{0}", extension));
        response.BinaryWrite(bytes);
        response.End();
    } 
}
