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

public partial class sys_d_d02_p_d0202_01 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：公告管理資料元件</summary>
    protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();
    protected ndb_hld201 indb_hld201 = new ndb_hld201();

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

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            ViewState["query"] = "";
            uf_BindDgG();
        }
        else
        {
            ViewState["query"] = uf_getQuery();
        }

	}

	// =========================================================================
	/// <summary>
	/// 事件描述：Html 送出前所要做的動作
	/// </summary>
	protected void Page_PreRender(object sender, EventArgs e)
	{
		// 記錄下主鍵值
		ScriptManager.RegisterHiddenField(Page, "ActionLogKeys", this.StoredKey);
	}
    private void uf_BindDgG()
    {
        string ls_addsql = "";

        ls_addsql = " AND hmd201_lvid = '2' ";

        indb_hmd201.uf_Retrieve(ls_addsql);

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
            ls_query += dgG.DataKeys[li_row].ToString().Trim() + "|";
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
            ls_query += dgG.DataKeys[li_row].ToString().Trim() + "|";
        }
        return ls_query;
    }

    protected void Bt_SendMessage_Click(object sender, EventArgs e)
    {
        int li_find = -1;
        DataRowView ldrv_Row;
        string ls_vid = "" , ls_ps = "";

        indb_hmd201.uf_Retrieve(" AND hmd201_lvid = '2' ");
        indb_hmd201.uf_Sort("hmd201_vid");
        indb_hld201.uf_Retrieve("");

        if (u_Date1.Value == "")
        {
            this.uf_Msg("請填寫核定日期！");
            return;
        }

        if (dwF_ps.Text.Trim() == "")
        {
            this.uf_Msg("請填寫核定文號！");
            return;
        }

        ls_ps = dwF_ps.Text.Trim();
		this.StoredKey = "";
        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;

            ls_vid = dgG.Items[li_row].Cells[2].Text.Trim();
            li_find = indb_hmd201.uf_FindSortIndex(ls_vid);

            if (li_find >= 0)
            {
                indb_hmd201[li_find]["hmd201_lvid"] = "1";
                indb_hmd201[li_find]["hmd201_uid"] = LoginUser.ID;
                indb_hmd201[li_find]["hmd201_udt"] = DbMethods.uf_GetDateTime();
				if (this.StoredKey.Trim() != "")
					this.StoredKey += "," + ls_vid;
				else
					this.StoredKey += ls_vid;
                this.indb_hld201.uf_InsertRow(out ldrv_Row);
                ldrv_Row["hld201_vid"] = ls_vid;
                ldrv_Row["hld201_logtype"] = "N";
                ldrv_Row["hld201_logdate"] = Convert.ToDateTime(u_Date1.Value);
                ldrv_Row["hld201_ps"] = ls_ps;
                ldrv_Row["hld201_aid"] = LoginUser.ID;
                ldrv_Row["hld201_adt"] = DbMethods.uf_GetDateTime();
                ldrv_Row["hld201_uid"] = LoginUser.ID;
                ldrv_Row["hld201_udt"] = DbMethods.uf_GetDateTime();
				
                ldrv_Row.EndEdit();
            }
            else
            {
                this.uf_Msg("匯入資料異常！");
                return;
            }

        }
		this.dgG_FindValue = new object[1];
		this.dgG_FindValue[0] = this.StoredKey;
		Log.uf_SetLogKeysValue(this.Page, this.dgG_FindValue);
        // 儲存資料
        if (this.indb_hld201.uf_Update(indb_hmd201) != 1)
        {
            this.indb_hld201.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hld201.ErrorMsg);
            return;
        }
        else
        {
            uf_BindDgG();
            // 重新取出查詢及清單資料
            this.uf_Msg("資料匯入完成！");
        }

    }
}
