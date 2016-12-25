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

public partial class sys_b_b01_p_b0101_02 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：公告管理資料元件</summary>
    protected ndb_hmc101 indb_hmc101 = new ndb_hmc101();

    #endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	
	protected void Page_Load(object sender, EventArgs e)
    {
        // 初始化
        //this.uf_InitializeQuery(null, this.indb_hmc101, null);
        //this.uf_InitializeComponent(null, dgG, this.indb_hmc101, null);
        //this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null) //0:快選條件 1:類別
            {
                string[] lsa_Arguments = null;
                lsa_Arguments = this.Request["args"].Split('|');

                this.StoredKey = lsa_Arguments[0];
                ViewState["type"] = lsa_Arguments[1];
				ViewState["type1"] = lsa_Arguments[2];
				ViewState["stop"] = lsa_Arguments[3];

                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(2);");
            }

            //ViewState["query"] = "";

			uf_BindDgG();

        }
		//else
		//{
		//    ViewState["query"] = uf_getQuery();
		//}

	}

    private void uf_BindDgG()
    {
        string ls_addsql = "";
        if (this.StoredKey != "0")
        {
            ls_addsql = "";

            switch (this.StoredKey)
            {
                case "1"://當月壽星
                    ls_addsql = " AND Month(hmc101_bday) = "+ DbMethods.uf_GetDate().Month ;
                    break;
                case "2"://下月壽星
                    ls_addsql = " AND Month(DateAdd(mm , -1 , hmc101_bday)) = " + DbMethods.uf_GetDate().Month;
                    break;
                case "3"://男性
                    ls_addsql = " AND hmc101_gent = 'M'";
                    break;
                case "4"://女性
                    ls_addsql = " AND hmc101_gent = 'F'";
                    break;
            }
        }

        if (ViewState["type"] != null && ViewState["type"].ToString() != "")
        {
            ls_addsql += " AND hmc101_id in ( SELECT hmc101_102.hmc101_id From hmc101_102 Where hmc102_id in ( " + ViewState["type"].ToString() + " ) ) ";
        }

		if (ViewState["type1"] != null && ViewState["type1"].ToString() != "" && ViewState["type1"].ToString() == "N")
		{
			ls_addsql += " AND hmc101_id not in ( SELECT hmc101_102.hmc101_id From hmc101_102 ) ";
		}

		if (ViewState["stop"] != null && ViewState["stop"].ToString() != "")
		{
			if (ViewState["stop"].ToString() == "Y")
				ls_addsql += " AND IsNull(hmc101_stop,'') = 'Y' ";
			else
				ls_addsql += " AND IsNull(hmc101_stop,'') <> 'Y' ";
		}

		indb_hmc101.uf_Retrieve(ls_addsql);

        dgG.DataBind();

    }

	//protected void lb_all_Click(object sender, EventArgs e)
	//{
	//    ViewState["query"] = uf_getQueryAll();
	//}

	//protected void lb_unall_Click(object sender, EventArgs e)
	//{
	//    // 清除畫面上已勾選的資料
	//    for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
	//    {
	//        ((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked = false;
	//    }
	//    ViewState["query"] = "";
	//}

	//protected bool uf_check(object ao_vid)
	//{ 
	//    bool lb_return = false;
	//    if (ao_vid.ToString() != "" && ViewState["query"].ToString().IndexOf(ao_vid.ToString()) > -1 )
	//        lb_return = true;
	//    return lb_return;
	//}

	//protected string uf_getQueryAll()
	//{
	//    string ls_query = "";
	//    // 將 DataGrid 選擇的資料組成查詢字串
	//    for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
	//    {
	//        ((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked = true;
	//        // 找出此筆資料所在資料元件索引位置
	//        ls_query += dgG.Items[li_row].Cells[2].Text.Trim() + "|";
	//    }
	//    return ls_query;
	//}

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

    protected string uf_getQueryMess()
    {
        string ls_query = "";
        // 將 DataGrid 選擇的資料組成查詢字串
        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            if(!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;
            if (dgG.Items[li_row].Cells[8].Text.Trim() == "" || dgG.Items[li_row].Cells[8].Text.Trim() == "&nbsp;") continue;

            // 找出此筆資料所在資料元件索引位置
            ls_query += dgG.Items[li_row].Cells[4].Text.Trim() + "(" + dgG.Items[li_row].Cells[8].Text.Trim() + ")" + "|";
        }
        return ls_query;
    }

    protected string uf_getQueryMail()
    {
        string ls_query = "";
        // 將 DataGrid 選擇的資料組成查詢字串
        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;
            if (dgG.Items[li_row].Cells[7].Text.Trim() == "" || dgG.Items[li_row].Cells[7].Text.Trim() == "&nbsp;") continue;

            // 找出此筆資料所在資料元件索引位置
            ls_query += dgG.Items[li_row].Cells[4].Text.Trim() + "(" + dgG.Items[li_row].Cells[7].Text.Trim() + ")" + "|";
            
		}
		return ls_query;
    }

    protected void Bt_SelectFormat_Click(object sender, EventArgs e)
    {
        string ls_query = uf_getQuery();
        if (ls_query == "")
        {
            this.uf_Msg("請選擇欲列印人員！");
            return;
        }

        this.uf_AddJavaScript("uf_LinkFrame('p_b0101_03.aspx', '03Frame', '" + ls_query + "' ); ");

    }
    protected void Bt_SendMessage_Click(object sender, EventArgs e)
    {
        string ls_query = uf_getQueryMess();
        if (ls_query == "")
        {
            this.uf_Msg("請勾選已填寫手機號碼之人員！");
            return;
        }
		Session["Query"] = ls_query;
		this.uf_AddJavaScript("uf_LinkFrame('p_b0101_04.aspx', '04Frame', '" + DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "_" + LoginUser.ID + "' );");
    }

    protected void Bt_SendCard_Click(object sender, EventArgs e)
    {
        string ls_query = uf_getQueryMail();
        if (ls_query == "")
        {
            this.uf_Msg("請勾選已填寫E-Mail之人員！");
            return;
        }
		Session["Query"] = ls_query;
		this.uf_AddJavaScript("uf_LinkFrame('p_b0101_05.aspx', '05Frame', '" + DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "_" + LoginUser.ID + "' );");
    }
}