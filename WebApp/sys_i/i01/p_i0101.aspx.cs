
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

public partial class sys_i_i01_p_i0101 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫會員：Emily

	/// <summary>變數描述：公告管理資料元件</summary>
    protected ndb_hmi101 indb_hmi101 = new ndb_hmi101();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        this.uf_InitializeQuery(dwQ, this.indb_hmi101, bt_Query);
        this.uf_InitializeComponent(dwF, dgG, this.indb_hmi101, null);
        this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
        
        
        // 註冊執行事件
    //    this.ue_DataQuery_AfterRetrieve += new EventHandler(this.bt_Query_AfterRetrieve);
        
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)
                this.StoredKey = this.Request["args"].Trim();

            // 將頁面切換到此頁
            //this.uf_AddJavaScript("uf_SelectFrame(2);");
        }

        // 將主鍵值記錄為尋找資料的條件
        this.dgG_FindValue = new object[1];
        this.dgG_FindValue[0] = this.StoredKey;             
	}

    // =========================================================================
    /// <summary>
    /// 事件描述：按下 bt_Query 《查詢》按鈕資料取出之後所做的處理
    /// </summary>
    //private void bt_Query_AfterRetrieve(object sender, EventArgs e)
    //{
    //    // 重新繫結群組資料
    //    //dwF_hmi101_select.DataBind();

    //    // 如果有資料則取出第一筆的群組資料
    //    if (dwF_hmi101_select.Items.Count > 0)
    //    {
    //        dwF_hmi101_select.SelectedIndex = 0;
    //        this.uf_indb_hmi101_Retrieve();
    //        //u_Edit_F.uf_Enabled(true);
    //    }
    //    else
    //    {
    //        // 清空顯示的使用者資料
    //        this.StoredKey = "";
    //        this.uf_DwF_NewData(dwF, this.indb_hmi101.dv_View);

    //        // 清除原先的群組資料
    //        this.indb_hmi101.ds_Data.Clear();
    //        this.uf_Data_New(dwF, dgG, this.indb_hmi101);
    //        //u_Edit_F.uf_Display("IC");
    //        //u_Edit_F.uf_Enabled(false);
    //    }
    //}



    // =========================================================================
    /// <summary>
    /// 事件描述：選擇 dwF_hmi101_select 某筆資料所做的處理
    /// </summary>
    //protected void dwF_hmi101_select_SelectedIndexChanged(object sender, EventArgs e)
    //{
        // 重新取出資料
        //this.uf_indb_hmi101_Retrieve();
       // dwF_hmi101_id.Text = "hmi101_id".ToString();
    //}

    // =========================================================================
    /// <summary>
    /// 函式描述：資料控制項容器做相關處理之後針對特殊或不能處理的子控制項做相關處理（覆蓋上層）
    /// </summary>
    /// <param name="acto_Child">資料控制項容器上的子控制項</param>
    /// <param name="as_Value">子控制項對應欄位的值(如為取出則沒去空白)</param>
    /// <param name="a_Action">處理種類–新增(New)；取出(Get)；放入(Set)；繫結(Bind)</param>
    /// <param name="adrv_Row">當筆資料列</param>
    /// <returns>成功(true)；失敗(false)</returns>
    protected override bool uf_DwF_DataAfter(Control acto_Child, ref string as_Value, DwActions a_Action, DataRowView adrv_Row)
    {
        if (a_Action == DwActions.New || a_Action == DwActions.Get)
        {
             //公告部門
            if (acto_Child == dwF_hmc101_deptname)
            {
                dwF_hmc101_deptname.Text = uf_Dg_BindFindColumn("hca202", "hca202_name", adrv_Row["hmc101_deptid"]);
                return true;
            }
            //通訊地址
            if (acto_Child == dwF_hmc101_addid_addot)
            {
                dwF_hmc101_addid_addot.Text = uf_Dg_BindFindColumn("hca205", "hca205_name", adrv_Row["hmc101_addid"])+adrv_Row["hmc101_addot"].ToString();; 
                
                return true;
            }
        }
        return true;
    }

  //  #region ☆ Private Methods ---------------------------------------- 撰寫人員：fen






   
}
