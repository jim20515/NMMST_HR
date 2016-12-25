
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

public partial class sys_e_e05_p_e0501_03 : p_sBase
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
        ldt_EmpList.Columns.Add("志工姓名", typeof(String));
        ldt_EmpList.Columns.Add("第一季", typeof(String));
         ldt_EmpList.Columns.Add("第二季", typeof(String));
         ldt_EmpList.Columns.Add("第三季", typeof(String));
         ldt_EmpList.Columns.Add("第四季", typeof(String));
         ldt_EmpList.Columns.Add("服勤時數", typeof(String));
         ldt_EmpList.Columns.Add("缺勤時數", typeof(String));
         ldt_EmpList.Columns.Add("連續不及格", typeof(String));
        ldt_EmpList.Columns.Add("備註", typeof(String));
       

        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["志工代碼"] = "V097-00000001";
        ldrv_New["志工姓名"] = "海大志";
        ldrv_New["第一季"] = "";
        ldrv_New["第二季"] = "";
        ldrv_New["第三季"] = "";
        ldrv_New["第四季"] = "";
        ldrv_New["服勤時數"] = "";
        ldrv_New["缺勤時數"] = "";
        ldrv_New["連續不及格"] = "";
        ldrv_New["備註"] = "";


        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["志工代碼"] = "V097-00000002";
        ldrv_New["志工姓名"] = "海小花";
        ldrv_New["第一季"] = "";
        ldrv_New["第二季"] = "";
        ldrv_New["第三季"] = "";
        ldrv_New["第四季"] = "";
        ldrv_New["服勤時數"] = "";
        ldrv_New["缺勤時數"] = "";
        ldrv_New["連續不及格"] = "";
        ldrv_New["備註"] = "";

        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["志工代碼"] = "V097-00000003";
        ldrv_New["志工姓名"] = "海瓜籽";
        ldrv_New["第一季"] = "";
        ldrv_New["第二季"] = "";
        ldrv_New["第三季"] = "";
        ldrv_New["第四季"] = "";
        ldrv_New["服勤時數"] = "";
        ldrv_New["缺勤時數"] = "";
        ldrv_New["連續不及格"] = "";
        ldrv_New["備註"] = "";

        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["志工代碼"] = "V097-00000004";
        ldrv_New["志工姓名"] = "海蜇皮";
        ldrv_New["第一季"] = "";
        ldrv_New["第二季"] = "";
        ldrv_New["第三季"] = "";
        ldrv_New["第四季"] = "";
        ldrv_New["服勤時數"] = "";
        ldrv_New["缺勤時數"] = "";
        ldrv_New["連續不及格"] = "";
        ldrv_New["備註"] = "";
   



        
        dgG.DataSource = ldv_EmpList;
        dgG.DataBind();


      
	}






    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
