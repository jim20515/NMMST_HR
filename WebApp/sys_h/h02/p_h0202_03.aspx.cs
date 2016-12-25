
// *********************************************************************************
// 1. 程式描述：系統公告管理–系統公告
// 2. 撰寫人員：
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

public partial class sys_h_h02_p_h0202_03 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：Linda

	/// <summary>變數描述：公告管理資料元件</summary>
    //protected ndb_aec02 indb_aec02 = new ndb_aec02();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;
		
		//U_DateSelect_ROC3.Value = "2008 / 06 / 30";

		// 建立一個暫存表格1
        DataTable ldt_EmpList = new DataTable("EmpList");
        DataView ldv_EmpList = ldt_EmpList.DefaultView;
        DataRowView ldrv_New;

        // 增加欄位
        ldt_EmpList.Columns.Add("序號", typeof(String));
        ldt_EmpList.Columns.Add("姓名", typeof(String));
        ldt_EmpList.Columns.Add("email", typeof(String));
    

        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["序號"] = "";
        ldrv_New["姓名"] = "海大志";
        ldrv_New["email"] = "aged@ated.com";



        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["序號"] = "";
        ldrv_New["姓名"] = "海小志";
        ldrv_New["email"] = "dola@tyad.com";
       


        
        dgG.DataSource = ldv_EmpList;
        dgG.DataBind();


      
	}






    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
}
