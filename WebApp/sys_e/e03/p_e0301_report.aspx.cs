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

public partial class sys_e_e03_p_e0301_report : p_sBase
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
        if (this.Request["query"] != null)
            ViewState["query"] = this.Request["query"].Trim();

        ExportReport(Response, "PDF"); 
    }

    private void ExportReport(HttpResponse response, string type)
    {

        ReportViewer1.LocalReport.DataSources.Clear();
        DataTable dt = uf_getTable();

        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("rd_e0301_ml_hmd201_ml", dt));
        ReportViewer1.LocalReport.Refresh();

        //Out params to pass into the Render method 
        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;

        //Call the Render method and save the return value in our byte array 
        byte[] bytes = ReportViewer1.LocalReport.Render(type, null, out mimeType, out encoding, out extension, out streamids, out warnings);

        /* Clear the Response object, set the ContentType, attach a header so the browser thinks it's downloading a file, write the byte array to the Response object and tell the bowser we're done by calling the End method */
        response.Clear();
        response.ContentType = mimeType;
        response.AppendHeader("Content-Disposition", String.Format("filename=report.{0}", extension));
        response.BinaryWrite(bytes);
        response.End();
    } 

    private DataTable uf_getTable()
    {
        string ls_datastring = @" select (ROW_NUMBER() OVER (ORDER BY hmd201_vid) - 1) / 2 + 1 AS TitleRow, (ROW_NUMBER() OVER (ORDER BY hmd201_vid) - 1) % 2 + 1 AS TitleColumn, hmd201_vid , hmd201_cname , hmd201_tid , ( SELECT hmd101_tname From hmd101 Where hmd101_tid = hmd201_tid ) as tname , hmd201_enCodeID From hmd201 Where ( 1 = 1 )  ", ls_query = "";
        DataSet lds_data;
        string[] lsa_query = ViewState["query"].ToString().Split('|');

        for (int li_c = 0; li_c < lsa_query.Length; li_c++)
        {
            ls_query += "'" + lsa_query[li_c] + "' ,";
        }

        if (ls_query != "")
        {
            ls_query = ls_query.Substring(0, ls_query.Length - 1);
            ls_datastring += " AND hmd201_vid in (" + ls_query + ") ";
        }

        // 利用 SQL 語法產生資料集
        DbMethods.uf_Retrieve_FromSQL(out lds_data, ls_datastring);

        return lds_data.Tables[0];

    }
}
