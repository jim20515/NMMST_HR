
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

public partial class sys_e_e02_p_e0201 : p_sBase
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
		U_DateSelect_ROC1.Value = "2008 / 05 / 01";
		u_Date4.Value = "2008 / 05 / 31";
		//U_DateSelect_ROC2.Value = "2008 / 09 / 22";
		//U_DateSelect_ROC3.Value = "2008 / 06 / 16";

		// 建立一個暫存表格1
        DataTable ldt_EmpList = new DataTable("EmpList");
        DataView ldv_EmpList = ldt_EmpList.DefaultView;
        DataRowView ldrv_New;

        // 增加欄位
        //ldt_EmpList.Columns.Add("勾選", typeof(String));
        ldt_EmpList.Columns.Add("志工代碼", typeof(String));
        ldt_EmpList.Columns.Add("姓名", typeof(String));
		ldt_EmpList.Columns.Add("記錄日期", typeof(String));
        ldt_EmpList.Columns.Add("種類", typeof(String));
		ldt_EmpList.Columns.Add("刷卡時間", typeof(String));
        ldt_EmpList.Columns.Add("補登方式", typeof(String));
        ldt_EmpList.Columns.Add("是否取消", typeof(String));
        //ldt_EmpList.Columns.Add("繳款方式", typeof(String));
	    //ldt_EmpList.Columns.Add("保固年限", typeof(String));
		//ldt_EmpList.Columns.Add("銀行帳號", typeof(String));


        ldrv_New = ldv_EmpList.AddNew();
		//ldrv_New["勾選"] = "";
        ldrv_New["志工代碼"] = "V097-00000001";
        ldrv_New["姓名"] = "海大志";
        ldrv_New["記錄日期"] = "097/11/03";
        ldrv_New["種類"] = "上班";
        ldrv_New["刷卡時間"] = "07:55";
        ldrv_New["補登方式"] = "手動補登";
        ldrv_New["是否取消"] = "否";

        ldrv_New = ldv_EmpList.AddNew();
        //ldrv_New["勾選"] = "";
        ldrv_New["志工代碼"] = "V097-00000003";
        ldrv_New["姓名"] = "海小花";
        ldrv_New["記錄日期"] = "097/11/03";
        ldrv_New["種類"] = "上班";
        ldrv_New["刷卡時間"] = "08:03";
        ldrv_New["補登方式"] = "手動補登";
        ldrv_New["是否取消"] = "否";
        
        ldrv_New = ldv_EmpList.AddNew();
        //ldrv_New["勾選"] = "";
        ldrv_New["志工代碼"] = "V097-00000005";
        ldrv_New["姓名"] = "海二爺";
        ldrv_New["記錄日期"] = "097/11/03";
        ldrv_New["種類"] = "上班";
        ldrv_New["刷卡時間"] = "08:03";
        ldrv_New["補登方式"] = "刷卡登錄";
        ldrv_New["是否取消"] = "否";

        ldrv_New = ldv_EmpList.AddNew();
        //ldrv_New["勾選"] = "";
        ldrv_New["志工代碼"] = "V097-00000001";
        ldrv_New["姓名"] = "海大志";
        ldrv_New["記錄日期"] = "097/11/03";
        ldrv_New["種類"] = "下班";
        ldrv_New["刷卡時間"] = "11:03";
        ldrv_New["補登方式"] = "刷卡登錄";
        ldrv_New["是否取消"] = "否";

        dgG.DataSource = ldv_EmpList;
        dgG.DataBind();

        //Button1.Attributes["OnClick"] = "window.open('p_ra0203_new_01.aspx','','top=140,left=90,height=320,width=620,location=no','')";
        //Button4.Attributes["OnClick"] = "window.open('p_ra0202_new_02.aspx','','top=140,left=90,height=320,width=620,location=no','')";

        //if (!IsPostBack)
        //    Dbcfg.uf_Bind(DropDownList3, "ac01", "", "AND SUBSTRING (ec01_code,1,2) IN ('01','98')", true);

	}






    protected void u_Date4_Load(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void u_Edit_F_Load(object sender, EventArgs e)
    {

    }
    protected void dgG_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Button4.Attributes["OnClick"] = "window.open('p_e0201_new_01.aspx','','top=140,left=90,height=320,width=620,location=no','')";
    }
}
