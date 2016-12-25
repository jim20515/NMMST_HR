
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

public partial class sys_g_g01_p_g0101_p2 : p_sBase
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
        ldt_EmpList.Columns.Add("姓名", typeof(String));
        ldt_EmpList.Columns.Add("志工代碼", typeof(String));
        ldt_EmpList.Columns.Add("志工隊", typeof(String));
        ldt_EmpList.Columns.Add("階級", typeof(String));
        
        //ldt_EmpList.Columns.Add("支票號碼", typeof(String));
        //ldt_EmpList.Columns.Add("支票開立日期", typeof(String));
        //ldt_EmpList.Columns.Add("受(繳)款人", typeof(String));
        //ldt_EmpList.Columns.Add("支票金額", typeof(String));
        //ldt_EmpList.Columns.Add("支票兌現到期日", typeof(String));
        //ldt_EmpList.Columns.Add("劃線", typeof(String));
        //ldt_EmpList.Columns.Add("禁背", typeof(String));
        //ldt_EmpList.Columns.Add("郵寄日期", typeof(String));


        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["姓名"] = "海大志";
        ldrv_New["志工代碼"] = "V097_00000001";
        ldrv_New["志工隊"] = "行政志工隊";
        ldrv_New["階級"] = "講師級";

        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["姓名"] = "海中天";
        ldrv_New["志工代碼"] = "V097_00000002";
        ldrv_New["志工隊"] = "行政志工隊";
        ldrv_New["階級"] = "正式志工";


        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["姓名"] = "海小花";
        ldrv_New["志工代碼"] = "V097_00000003";
        ldrv_New["志工隊"] = "行政志工隊";
        ldrv_New["階級"] = "正式志工";

        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["姓名"] = "海公公";
        ldrv_New["志工代碼"] = "V097_00000004";
        ldrv_New["志工隊"] = "行政志工隊";
        ldrv_New["階級"] = "講師級";


        
        dgG.DataSource = ldv_EmpList;
        dgG.DataBind();


      
	}






    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
}
