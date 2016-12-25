// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排班表樣板管理–排班主檔查詢–查詢及清單
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

public partial class sys_e_e01_p_e0105_01 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：排班主檔資料元件</summary>
    protected ndb_hme105a indb_hme105a = new ndb_hme105a();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 初始化
        this.uf_InitializeQuery(dwQ, this.indb_hme105a, bt_Query);
        this.uf_InitializeComponent(null, dgG, this.indb_hme105a, null);
        this.dgG_Sort = "hme105a_tid , hme105a_name ";

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
        }

        // 註冊執行事件
        //this.ue_PageLoad_AfterQueryRetrieve += new EventHandler(this.PageLoad_AfterQueryRetrieve);
    }

    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟取出 Query 資料後處理事件
    /// </summary>
    //private void PageLoad_AfterQueryRetrieve(object sender, System.EventArgs e)
    //{
    //    // 如果是第一次執行此網頁
    //    if (!this.IsPostBack)
    //    {
    //        // 驅動查詢事件
    //        this.ibt_Query_Click(sender, EventArgs.Empty);
    //    }
    //}

	// =========================================================================
	/// <summary>
	/// 事件描述：dgG 選擇某筆資料所要做的處理
	/// </summary>
	protected override void idgG_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.uf_AddJavaScript("uf_LinkFrame('p_e0105_02.aspx', '02Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "'); uf_LinkFrame('p_e0105_03.aspx', '03Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "|" + dgG.Items[dgG.SelectedIndex].Cells[1].Text.Trim() + "|" + dgG.Items[dgG.SelectedIndex].Cells[2].Text.Trim() + "|" + "')");
	}
}
