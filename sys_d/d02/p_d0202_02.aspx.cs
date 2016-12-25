
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

public partial class sys_d_d02_p_d0202_02 : p_sBase
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
        ldt_EmpList.Columns.Add("志工隊名稱", typeof(String));
        ldt_EmpList.Columns.Add("志工姓名", typeof(String));
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
        ldrv_New["志工隊名稱"] = "技術志工";
        ldrv_New["志工姓名"] = "王大同";
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
        ldrv_New["志工隊名稱"] = "行政志工";
            ldrv_New["志工姓名"] = "JJ林";
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


      
	}






    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
}
