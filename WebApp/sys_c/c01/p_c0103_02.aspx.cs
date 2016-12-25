
// *********************************************************************************
// 1. 程式描述：人力資源管理﹒基本資料檔管理﹒博物館之友管理﹒查詢及清單
// 2. 撰寫會員：Emily
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

public partial class sys_c_c01_p_c0103_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫會員：Emily

	/// <summary>變數描述：公告管理資料元件</summary>
    protected ndb_hmc101 indb_hmc101 = new ndb_hmc101();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        this.uf_InitializeQuery(null, this.indb_hmc101, null);
        this.uf_InitializeComponent(null, dgG, this.indb_hmc101, null);
        this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

        if (!IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)
                this.StoredKey = this.Request["args"].Trim();

            // 將頁面切換到此頁
            this.uf_AddJavaScript("uf_SelectFrame(2);");
        }

        if (this.StoredKey != "")
        {
            this.dgG_Retrieve = " AND hmc101_id > '"+ this.StoredKey +"' ";
            indb_hmc101.uf_Retrieve(dgG_Retrieve);
        }
	}    
}
