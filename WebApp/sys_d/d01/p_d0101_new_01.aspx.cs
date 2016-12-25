// *********************************************************************************
// 1. 程式描述：廠所作業 － 初編建檔及修正 － 專案計畫
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

public partial class sys_d_d01_p_d0101_new_01 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：

	/// <summary>變數描述：各單位科目預算資料元件</summary>

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        this.IsAJAXScript = true;

        // 不驗證使用者
        this.IsCheckUser = false;
        // 不驗證 Frame
        this.IsCheckFrame = false;
        // 不顯示 Version
        this.IsShowVersion = false;
        // 不顯示網頁 Title
        this.IsShowTitle = false;


        // 建立一個暫存表格
        DataTable ldt_EmpList = new DataTable("EmpList");
        DataView ldv_EmpList = ldt_EmpList.DefaultView;
        DataRowView ldrv_New;

        // 增加欄位
        ldt_EmpList.Columns.Add("員工代號", typeof(String));
        ldt_EmpList.Columns.Add("員工姓名", typeof(String));


        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["員工代號"] = "A000001";
        ldrv_New["員工姓名"] = "林小峰";


        ldrv_New = ldv_EmpList.AddNew();
        ldrv_New["員工代號"] = "A000002";
        ldrv_New["員工姓名"] = "王小儀";


        dgG.DataSource = ldv_EmpList;
        dgG.DataBind();
	}
    protected void dgG_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.uf_AddJavaScript("close();");
    }
}
