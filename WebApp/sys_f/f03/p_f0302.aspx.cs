
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

public partial class sys_f_f03_p_f0302 : p_sBase
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
       



        // 建立一個暫存表格1
        DataTable ldt_EmpList1 = new DataTable("EmpList1");
        DataView ldv_EmpList1 = ldt_EmpList1.DefaultView;
        DataRowView ldrv_New;

        // 增加欄位
        ldt_EmpList1.Columns.Add("課名", typeof(String));
        ldt_EmpList1.Columns.Add("日期", typeof(String));
        ldt_EmpList1.Columns.Add("時間", typeof(String));
        ldt_EmpList1.Columns.Add("修課人數", typeof(String));
        ldt_EmpList1.Columns.Add("是否登錄成績", typeof(String));
        ldt_EmpList1.Columns.Add("是否核定", typeof(String));



        ldrv_New = ldv_EmpList1.AddNew();
        ldrv_New["課名"] = "養魚課程";
        ldrv_New["日期"] = "097/11/05";
        ldrv_New["時間"] = "09:00~12:00";
        ldrv_New["修課人數"] = "32";
        ldrv_New["是否登錄成績"] = "是";
        ldrv_New["是否核定"] = "已核定";




        ldrv_New = ldv_EmpList1.AddNew();
        ldrv_New["課名"] = "抓魚課程";
        ldrv_New["日期"] = "097/11/06";
        ldrv_New["時間"] = "09:00~12:00";
        ldrv_New["修課人數"] = "15";
        ldrv_New["是否登錄成績"] = "否";
        ldrv_New["是否核定"] = "未核定";

        DataGrid1.DataSource = ldv_EmpList1;
        DataGrid1.DataBind();


      
	}






    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}
