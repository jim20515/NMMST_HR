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

public partial class sys_e_e03_p_e0301 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：WITSETER (QFLin)

	/// <summary>變數描述：資料元件</summary>
    protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	
	protected void Page_Load(object sender, EventArgs e)
    {
		// 初始化
        this.uf_InitializeQuery(dwQ, this.indb_hmd201, bt_Query);
        this.uf_InitializeComponent(null, dgG, this.indb_hmd201, null);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

        //在點列印時同時觸發lb_unall_Click全不選
        bt_print.Click += new System.EventHandler(lb_unall_Click);

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            ViewState["query"] = "";
        }
        else
        {
            ViewState["query"] = uf_getQuery();
        }
	}

    protected void bt_print_Click(object sender, EventArgs e)
    {
        string ls_query = uf_getQuery();
        if (ls_query == "")
        {
            this.uf_Msg("請選擇欲列印志工！");
            return;
        }

        this.uf_AddJavaScript("uf_OpenWindow('p_e0301_report.aspx?query=" + ls_query + "','',1024,768,'no','no');");       
    }

    protected void lb_all_Click(object sender, EventArgs e)
    {
        ViewState["query"] = uf_getQueryAll();
    }

    protected void lb_unall_Click(object sender, EventArgs e)
    {
        ViewState["query"] = "";
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

}
