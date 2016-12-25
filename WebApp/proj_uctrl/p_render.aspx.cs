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
using RSService;

public partial class proj_uctrl_p_render : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String ls_path = "", ls_format = "" , ls_query = "";

        if (this.Request["path"] != null)
            ls_path = this.Request["path"].Trim();
        if (this.Request["format"] != null)
            ls_format = this.Request["format"].Trim();
        if (this.Request["query"] != null)
            ls_query = this.Request["query"].Trim();

        // 建立 ReportingService 物件
        ReportingService rs = new ReportingService();

        //設定傳遞至 Reporting Service 認證
        rs.Credentials = System.Net.CredentialCache.DefaultCredentials;

        ParameterValue[] parameters = GetParameters(ls_query);
        string encoding;
        string mineType;
        ParameterValue[] parametersUseed;
        Warning[] warings;
        string[] streamIds;

        //轉譯報表
        byte[] data;
        data = rs.Render(ls_path, ls_format, null, null, parameters, null, null, out encoding, out mineType, out parametersUseed, out warings, out streamIds);

        //判定格式是轉譯至Web或是檔案中
        string extension = GetExtensions(mineType);
        string reportName = ls_path.Substring(ls_path.LastIndexOf("/")+1);
        string fileName = reportName + "." + extension;

        //將報表寫回reponse物件
        Response.Clear();
        Response.ContentType = mineType;

        //如果不是web瀏覽格式，將檔案名稱加入response中
        if (mineType != "text/html")
            Response.AddHeader("Content-Disposition" , "filename=" + fileName);

        Response.BinaryWrite(data);
    }

    protected ParameterValue[] GetParameters(string as_query)
    {
        string[] lsa_query = as_query.Split(';');
        int li_len = lsa_query.Length;
        if (as_query == "") li_len = 0;
        ParameterValue[] returnValues = new ParameterValue[li_len];
        for (int i = 0; i < li_len; i ++ )
        {
            string[] lsa_col = lsa_query[i].Split('=');
            returnValues[i] = new ParameterValue();
            returnValues[i].Name = lsa_col[0];
            returnValues[i].Value = lsa_col[1];
        }
        return returnValues;
    }

    protected string GetExtensions(string mineType)
    {
        string retVal = "";

        switch (mineType)
        {
            case "text/html":
                retVal = "html";
                break;
            case "multipart/related":
                retVal = "html";
                break;
            case "text/xml":
                retVal = "xml";
                break;
            case "text/plain":
                retVal = "csv";
                break;
            case "image/tiff":
                retVal = "tif";
                break;
            case "application/pdf":
                retVal = "pdf";
                break;
            case "application/vnd.ms-excel":
                retVal = "xls";
                break;
        }

        return retVal;
    }
}
