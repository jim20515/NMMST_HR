// *********************************************************************************
// 1. 程式描述：服務勤務管理–勤務紀錄管理–查詢及清單
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

public partial class sys_g_g01_p_g0103_02 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：公告管理資料元件</summary>
    protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();
    protected ndb_hmg101b indb_hmg101b = new ndb_hmg101b();
    protected ndb_hmg101a indb_hmg101a = new ndb_hmg101a();

    #endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	
	protected void Page_Load(object sender, EventArgs e)
    {
        // 初始化
        //this.uf_InitializeQuery(null, this.indb_hmd201, null);
        //this.uf_InitializeComponent(null, dgG, this.indb_hmd201, null);
        //this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

        this.Bt_SendMessage.Attributes["OnClick"] = "if (! confirm('是否確定考核? ')) return false;";

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            if (this.Request["args"] != null)
                this.StoredKey = this.Request["args"].Trim();

            ViewState["query"] = "";
            uf_BindDgG();

            // 將頁面切換到此頁
            this.uf_AddJavaScript("uf_SelectFrame(2);");
        }
        else
        {
            ViewState["query"] = uf_getQuery();
        }

	}

    private void uf_BindDgG()
    {
        indb_hmg101a.uf_Retrieve(" And hmg101a_kid = '"+ this.StoredKey +"' ");
        indb_hmg101b.uf_Retrieve(" And hmg101b_kid = '" + this.StoredKey + "' ");
        indb_hmg101b.uf_Sort("hmg101b_kid,hmg101b_vid");

        if (indb_hmg101b.uf_RowCount() > 0 && !this.IsPostBack)
        {
            string ls_query = "";
            for (int li_row = 0; li_row < indb_hmg101b.uf_RowCount(); li_row++)
            {
                if (indb_hmg101b[li_row]["hmg101b_passed"].ToString().Trim() == "Y")
                    ls_query += indb_hmg101b[li_row]["hmg101b_vid"].ToString() + "|";
            }
            ViewState["query"] = ls_query;
        }

        if (indb_hmg101a.uf_RowCount() > 0)
        {
            dwQ_hmd101_tid_t.Text = indb_hmg101a[0]["hmg101a_name"].ToString();

            indb_hmd201.uf_Retrieve(" AND hmd201_vid in ( Select hmg101b_vid From hmg101b Where hmg101b_kid = '"+ this.StoredKey +"' ) ");
            indb_hmd201.uf_Sort("hmd201_vid");
        }

        dgG.DataBind();

    }

    protected void lb_all_Click(object sender, EventArgs e)
    {
        ViewState["query"] = uf_getQueryAll();
        uf_BindDgG();
    }

    protected void lb_unall_Click(object sender, EventArgs e)
    {
        ViewState["query"] = "";
        uf_BindDgG();
    }

    protected bool uf_check(object ao_vid)
    { 
        bool lb_return = false;
        if (ao_vid.ToString() != "" && ViewState["query"].ToString().IndexOf(ao_vid.ToString()) > -1 )
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
            ls_query += dgG.Items[li_row].Cells[2].Text.Trim() + "|";
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
            ls_query += dgG.Items[li_row].Cells[2].Text.Trim() + "|";
        }
        return ls_query;
    }

    protected void Bt_SendMessage_Click(object sender, EventArgs e)
    {
        if (this.StoredKey.Trim() == "")
        {
            uf_Msg("請選擇欲考核資料！");
            return;
        }

        int li_find = -1;
        DataRowView ldrv_Row;
        string ls_vid = "";

        indb_hmg101b.uf_Retrieve(" And hmg101b_kid = '" + this.StoredKey + "' ");
        indb_hmg101b.uf_Sort("hmg101b_kid,hmg101b_vid");

        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            ls_vid = dgG.Items[li_row].Cells[2].Text.Trim();

            this.dgG_FindValue = new object[2];
            this.dgG_FindValue[0] = this.StoredKey;
            this.dgG_FindValue[1] = ls_vid;

            li_find = indb_hmg101b.uf_FindSortIndex(dgG_FindValue);

            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) //若存在，則刪除
            {
                if (li_find > -1)
                {
                    if (indb_hmg101b[li_row]["hmg101b_passed"].ToString() != "Y")
                    {
                        indb_hmg101b[li_row]["hmg101b_passed"] = "N";
                    }
                }
            }
            else
            {
                if (li_find > -1)
                {
                    indb_hmg101b[li_row]["hmg101b_passed"] = "Y";
                }
            }
        }

        // 儲存資料
        if (this.indb_hmg101b.uf_Update() != 1)
        {
            this.indb_hmg101b.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hmg101b.ErrorMsg);
            return;
        }
        else
        {
            uf_BindDgG();
            // 重新取出查詢及清單資料
            this.uf_Msg("考核結果編輯完成！");
        }

    }
    
}
