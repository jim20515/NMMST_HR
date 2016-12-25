// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排班表設定–排班主檔查詢–查詢及清單
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
using RSService;

public partial class sys_b_b02_p_b0201_03 : p_hrBase
{
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null) //0:人員
            {
                this.StoredKey = this.Request["args"];

                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(3);");
            }
        }
    }

    protected void Bt_Export_Click(object sender, EventArgs e)
    {
		if (this.StoredKey.ToString().Trim() == "")
		{
			this.uf_Msg("請選擇匯出檔案人員資料！");
			return;
		}
        string ls_format = "";
        if (dwQ_type.SelectedIndex == -1)
        {
            this.uf_Msg("請選擇匯出檔案格式！");
            return;
        }

        ls_format = dwQ_format.SelectedValue;

        //this.uf_AddJavaScript("uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_uctrl/p_render.aspx?path=" + "/NMMST_HR_Report/rs_b0101_" + dwQ_type.SelectedValue + "&format=" + ls_format + "&query=as_id=" + this.StoredKey + "','',1024,768,'no','no');");
		if (dwQ_type.SelectedValue == "5" && ls_format == "Pdf")
		{
			string ls_pkey = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "_" + LoginUser.ID;
			DbMethods.uf_ExecSQL(" INSERT INTO hmb101(hmb101_pkey, hmb101_data) VALUES('" + ls_pkey + "','" + this.StoredKey + "')");

			uf_AddJavaScript("uf_report(\"cr_b0101_5.rpt\", \"" + ls_pkey + "\", '', \"pdf\");");
		}
		else
			this.uf_AddJavaScript("uf_rsreport('" + "/NMMST_HR_Report/rs_b0101_" + dwQ_type.SelectedValue + "','" + ls_format + "','as_id=" + this.StoredKey + "')");
   
    }
}
