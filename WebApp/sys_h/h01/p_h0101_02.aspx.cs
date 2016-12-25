
// *********************************************************************************
// 1. 程式描述：志工網管理–志工電子報管理
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

public partial class sys_h_h01_p_h0101_02 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：排班主檔資料元件</summary>
    protected ndb_hlh101 indb_hlh101 = new ndb_hlh101();

    #endregion

    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        // 初始化
        this.uf_InitializeQuery(dwQ, this.indb_hlh101, bt_Query);
        this.uf_InitializeComponent(null, dgG, this.indb_hlh101, null);
        this.dgG_Sort = "hlh101_udt desc , hlh101_uid";

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 驅動查詢事件
            //this.ibt_Query_Click(sender, EventArgs.Empty);
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

    //加上Query查詢條件
    protected override bool uf_DwQ_SQLAfter(ref string as_AddSQL)
    {
        // 日期區間
        if (u_Date2.Value != "")
            as_AddSQL += " and hlh101_adt >= '" + u_Date2.Value + "' ";

        if (u_Date1.Value != "")
            as_AddSQL += " and hlh101_adt <= '" + u_Date1.Value + "' ";

        return true;
    }	// End of uf_DwQ_SQLAfter

    // =========================================================================
    /// <summary>
    /// 事件描述：dgG 選擇某筆資料所要做的處理
    /// </summary>
    protected override void idgG_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.uf_AddJavaScript("uf_LinkFrame('p_h0101_03.aspx', '03Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "');");
    }

    public string uf_cut(object ao_string)
    {
        string ls_return = "";
        int li_count = 0;
        if (ao_string != null)
        {
            for (int li_row = 0; li_row < ao_string.ToString().Length; li_row++)
            {
                if (li_count > 25)
                {
                    ls_return += ao_string.ToString().Substring(li_row, 1) + "<br />";
                    li_count = 0;
                }
                else
                {
                    ls_return += ao_string.ToString().Substring(li_row, 1);
                    li_count++;
                }
            }
        }
        return ls_return;
    }

    public string uf_cutNum(object ao_string)
    {
        string ls_return = "";
        int li_countAll = 0;
        string[] lsa_num;

        if (ao_string != null)
        {
            lsa_num = ao_string.ToString().Split(';');

            for (int li_count = 0; li_count < lsa_num.Length; li_count++)
            {
                if (lsa_num[li_count] != "" )
                    ls_return += lsa_num[li_count] + ";<br />";
            }
        }
        return ls_return;
    }
}
