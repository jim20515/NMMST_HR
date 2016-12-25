// *********************************************************************************
// 1. 程式描述：簡訊賀卡系統–簡訊發送 - 簡訊即時發送
// 2. 撰寫人員：demon
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

public partial class sys_h_h02_p_h0201_03 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：人員主檔資料元件</summary>
    protected ndb_hmc101 indb_hmc101 = new ndb_hmc101();
    private string is_ReturnObjectID;
    private string is_ReturnObjectID1;
    private string is_ReturnFormID;
    private string ls_ID;
    private string ls_name;

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        // 不驗證 Frame
        this.IsCheckFrame = false;
        // 不顯示 Version
        this.IsShowVersion = false;
        // 不顯示網頁 Title
        this.IsShowTitle = false;

        //初始化
        this.uf_InitializeQuery(dwQ, this.indb_hmc101, bt_Query);
        this.uf_InitializeComponent(null, dgG, this.indb_hmc101, null);

         // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {

            this.StoredKey = this.Request["ReturnFormID"];

            if (this.Request["ReturnObjectID"] != null)
                ViewState["ReturnObjectID"] = this.Request["ReturnObjectID"].Trim();
            else
                ViewState["ReturnObjectID"] = "";

            if (this.Request["ObjectValue"] != null)
            {
                ViewState["query"] = this.Request["ObjectValue"].Trim();
            }
        }
        else
        {
            ViewState["query"] = uf_getQuery();
        }

        // 註冊執行事件
        this.ue_PageLoad_AfterQueryRetrieve += new EventHandler(this.PageLoad_AfterQueryRetrieve);

	}

    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟取出 Query 資料後處理事件
    /// </summary>
    private void PageLoad_AfterQueryRetrieve(object sender, System.EventArgs e)
    {
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 驅動查詢事件
            this.ibt_Query_Click(sender, EventArgs.Empty);
        }
    }

    protected void lb_all_Click(object sender, EventArgs e)
    {
        ViewState["query"] = uf_getQueryAll();
    }

    protected void lb_unall_Click(object sender, EventArgs e)
    {
        ViewState["query"] = "";
    }

    protected bool uf_check(object ao_cname)
    {
        bool lb_return = false;
        if (ao_cname.ToString() != "" && ViewState["query"].ToString().IndexOf(ao_cname.ToString()) > -1)
            lb_return = true;
        return lb_return;
    }

    protected string uf_getQueryAll()
    {
        string ls_query = "";
        // 將 DataGrid 選擇的資料組成查詢字串
        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            // 找出此筆資料所在資料元件索引位置
            ls_query += dgG.Items[li_row].Cells[3].Text.Trim() + "(" + dgG.Items[li_row].Cells[4].Text.Trim() + ")" + "\\r\\n";
        }
        return ls_query;
    }

    protected string uf_getQuery()
    {
        string ls_query = "";
        // 將 DataGrid 選擇的資料組成查詢字串
        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;

            // 找出此筆資料所在資料元件索引位置
            ls_query += dgG.Items[li_row].Cells[3].Text.Trim() + "(" + dgG.Items[li_row].Cells[4].Text.Trim() + ")" + "\\r\\n";
        }
        return ls_query;
    }

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
    protected override bool uf_DwQ_SQLAfter(Control acto_Child, ref string as_ColType, ref string as_Value, DwActions a_Action, ref string as_AddSQL, ref bool ab_IsAdd, DwQKinds a_Kind)
    {
        if (a_Action == DwActions.Set)
        {
            // 人員姓名
            if (acto_Child == dwQ_hmc101_tid)
            {
                if (dwQ_hmc101_tid.SelectedValue != "")
                {
                    as_AddSQL += " AND hmc101_id in ( Select hmd201_id From hmd201 Where hmd201_tid = '" + dwQ_hmc101_tid.SelectedValue + "' ) ";
                }
                return true;
            }

        }
        return true;
    }

    //加上Query查詢條件
    protected override bool uf_DwQ_SQLAfter(ref string as_AddSQL)
    {
        // 只顯示非正式班表
        as_AddSQL += " and IsNull(hmc101_email , '') <> '' ";

        return true;
    }	// End of uf_DwQ_SQLAfter

    protected void Bt_Conf_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        string ls_JavaScript = "";

        // 取得選擇的人員
        ls_name = uf_getQuery();

        // 組成 JavaScript

        ls_JavaScript += "	if (opener.document.getElementById(\"" + this.ViewState["ReturnObjectID"].ToString().Trim() + "\") != null)" + "\r\n";
        ls_JavaScript += "		opener.document.all." + this.ViewState["ReturnObjectID"].ToString().Trim() + ".value=\"" + ls_name + "\";" + "\r\n";
        ls_JavaScript += " close();" + "\r\n";
        this.uf_AddJavaScript(ls_JavaScript);

    }
}
