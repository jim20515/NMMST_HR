
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

public partial class sys_f_f03_p_f0301 : p_sBase
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
        ldt_EmpList.Columns.Add("志工代碼", typeof(String));
        ldt_EmpList.Columns.Add("成績", typeof(String));
        ldt_EmpList.Columns.Add("志工姓名", typeof(String));
        ldt_EmpList.Columns.Add("備註", typeof(String));
        //ldt_EmpList.Columns.Add("支票號碼", typeof(String));
        //ldt_EmpList.Columns.Add("支票開立日期", typeof(String));
        //ldt_EmpList.Columns.Add("受(繳)款人", typeof(String));
        //ldt_EmpList.Columns.Add("支票金額", typeof(String));
        //ldt_EmpList.Columns.Add("支票兌現到期日", typeof(String));
        //ldt_EmpList.Columns.Add("劃線", typeof(String));
        //ldt_EmpList.Columns.Add("禁背", typeof(String));
        //ldt_EmpList.Columns.Add("郵寄日期", typeof(String));


        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["志工代碼"] = "V097-00000001";
        ldrv_New["成績"] = "95";
        ldrv_New["志工姓名"] = "海大志";
        ldrv_New["備註"] = "第一名";
        //ldrv_New["支票號碼"] = "0000001";
        //ldrv_New["支票開立日期"] = "097/06/16";
        //ldrv_New["受(繳)款人"] = "XXX工程公司";
        //ldrv_New["支票金額"] = "1,000,000";
        //ldrv_New["支票兌現到期日"] = "097/09/22";
        //ldrv_New["劃線"] = "Y";
        //ldrv_New["禁背"] = "Y";
        //ldrv_New["郵寄日期"] = "097/06/30";



        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["志工代碼"] = "V097-00000002";
        ldrv_New["成績"] = "70";
        ldrv_New["志工姓名"] = "海小志";
        ldrv_New["備註"] = "不熟練";
        //ldrv_New["支票號碼"] = "0000001";
        //ldrv_New["支票開立日期"] = "097/06/16";
        //ldrv_New["受(繳)款人"] = "XXX工程公司";
        //ldrv_New["支票金額"] = "1,000,000";
        //ldrv_New["支票兌現到期日"] = "097/09/22";
        //ldrv_New["劃線"] = "Y";
        //ldrv_New["禁背"] = "Y";
        //ldrv_New["郵寄日期"] = "097/06/30";



        
        dgG.DataSource = ldv_EmpList;
        dgG.DataBind();

        // 建立一個暫存表格1
        DataTable ldt_EmpList1 = new DataTable("EmpList1");
        DataView ldv_EmpList1 = ldt_EmpList1.DefaultView;
        DataRowView ldrv_New1;

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
    protected void dgG_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
