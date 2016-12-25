
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

public partial class sys_i_i01_p_i0102 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫會員：Emily

	/// <summary>變數描述：公告管理資料元件</summary>
    protected ndb_hmi102 indb_hmi102 = new ndb_hmi102();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        this.uf_InitializeQuery(dwQ, this.indb_hmi102, bt_Query);
        this.uf_InitializeComponent(dwF, dgG, this.indb_hmi102, null);
        this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
        
        
        // 註冊執行事件
       //this.ue_DataQuery_AfterRetrieve += new EventHandler(this.bt_Query_AfterRetrieve);
        
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)
                this.StoredKey = this.Request["args"].Trim();

            // 將頁面切換到此頁
            //this.uf_AddJavaScript("uf_SelectFrame(2);");

            //DataSet ds_type;
            //DataView dv_type;

            //DbMethods.uf_Retrieve_FromSQL(out ds_type, " SELECT hmc102_name, hmc102_id FROM hmc102 WHERE (1=1) and (hmc102_id not in (1, 2, 3) )");
            //dv_type = ds_type.Tables[0].DefaultView;
            //dv_type.Sort = "hmc102_id";
            //dwQ_hmc101_type.DataSource = dv_type;
            //dwQ_hmc101_type.DataTextField = "hmc102_name";
            //dwQ_hmc101_type.DataValueField = "hmc102_id";
            //dwQ_hmc101_type.DataBind();
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
    //     //重新繫結群組資料
    //    dwF_hmi102_select.DataBind();

    //    // 如果有資料則取出第一筆的群組資料
    //    if (dwF_hmi102_select.Items.Count > 0)
    //    {
    //        dwF_hmi102_select.SelectedIndex = 0;
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
    /// 函式描述：資料控制項容器控制項組合出查詢語法之後針對特殊或不能處理的子控制項再修改組合出的查詢語法（一個控制項處理一次）（覆蓋上層）
    /// </summary>
    /// <param name="acto_Child">資料控制項容器上的子控制項</param>
    /// <param name="as_ColType">子控制項對應欄位的型態種類–清空時(空字串)；字串等於(S)；字串相似(SL)；日期時間(DT)；日期(D)；時間(T)；數值(N)</param>
    /// <param name="as_Value">子控制項對應欄位的值(已去空白)–傳入的值已處理不安全內容，如有變更需自行確認其安全性</param>
    /// <param name="a_Action">處理種類–清空(New)；查詢(Set)</param>
    /// <param name="as_AddSQL">清空(New)為空字串；查詢(Set)則傳入之前組合出的查詢語法(尚未加入此控制項語法)</param>
    /// <param name="ab_IsAdd">是否加入此控制項語法或參數–是(true)；否(false)</param>
    /// <param name="a_Kind">資料查詢種類–語法(AddSQL)；參數(AddArg)</param>
    /// <returns>成功(true)；失敗(false)</returns>
    //protected override bool uf_DwQ_SQLAfter(Control acto_Child, ref string as_ColType, ref string as_Value, DwActions a_Action, ref string as_AddSQL, ref bool ab_IsAdd, DwQKinds a_Kind)
    //{
    //    if (a_Action == DwActions.Set)
    //    {
    //        // 人員分類checkbox
    //        if (acto_Child == dwQ_hmc101_type)
    //        {
    //            if (dwQ_hmc101_type.SelectedIndex != -1)
    //            {
    //                string ls_value = "";
    //                foreach (ListItem li_item in dwQ_hmc101_type.Items)
    //                {
    //                    if (li_item.Selected)
    //                    {
    //                        if (ls_value != "") ls_value += ",";
    //                        ls_value += li_item.Value;
    //                    }
    //                }
    //                as_AddSQL += " AND b.hmc102_id in (" + ls_value + ") ";
    //            }
    //            return true;
    //        }
           
    //    }
    //    return true;
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
            //志工隊
            if (acto_Child == dwF_hmd201_tid_name)
            {
                dwF_hmd201_tid_name.Text = uf_Dg_BindFindColumn("hmd101", "hmd101_tname", adrv_Row["hmd201_tid"]);
                return true;
            }
            //志工狀態
            if (acto_Child == dwF_hmd201_Status_name)
            {
                dwF_hmd201_Status_name.Text = uf_Dg_BindFindColumn("hca207", "hca207_name", adrv_Row["hmd201_Status"]);
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
