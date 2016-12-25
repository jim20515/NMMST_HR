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

public partial class sys_f_f04_p_f0401_02 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：公告管理資料元件</summary>
    protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();
    protected ndb_hmf101a indb_hmf101a = new ndb_hmf101a();
    protected ndb_hmf401 indb_hmf401 = new ndb_hmf401();


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
            // 接收傳入值
            if (this.Request["args"] != null) //0:快選條件 1:類別
            {
                this.StoredKey = this.Request["args"];

                indb_hmf101a.uf_Retrieve(" AND hmf101a_certid = '" + this.StoredKey + "' ");

                if (indb_hmf101a.uf_RowCount() > 0)
                {
                    dwQ_aec02_code_t.Text = indb_hmf101a[0]["hmf101a_name"] + "，需曾通過以下訓練：";

                    DataSet lds_data;
                    DataView dv_data;
                    string ls_datastring = " select hmf101_name from hmf101b Inner Join hmf101 ON hmf101_courseid = hmf101b_courseid Where hmf101b_certid = '"+ this.StoredKey +"' ";

                    DbMethods.uf_Retrieve_FromSQL(out lds_data, ls_datastring);
                    dv_data = lds_data.Tables[0].DefaultView;

                    for (int i = 0; i < dv_data.Count; i++)
                    {
                        Label1.Text += Convert.ToString(i+1) + ". " +dv_data[i][0].ToString() + "　　　";
                        if ((i+1) % 4 == 0) Label1.Text += "<br />";
                    }
                }

                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(2);");
            }

            ViewState["query"] = "";
        }
        else
        {
            ViewState["query"] = uf_getQuery();
        }
		this.uf_SetLog_Function(this.StoredKey);
        uf_BindDgG();
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
        string ls_addsql = " AND hmd201_vid in ( ";
        ls_addsql += f01Project.uf_CertPeople(this.StoredKey) + " )";
        this.dgG_Retrieve = ls_addsql;
        indb_hmd201.uf_Retrieve(dgG_Retrieve);
        dgG.DataBind();
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
            ls_query += dgG.DataKeys[li_row].ToString() + "|";
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
            ls_query += dgG.DataKeys[li_row].ToString() + "|";
        }
        return ls_query;
    }

    protected void Bt_Conf_Click(object sender, EventArgs e)
    {
        if (dwF_hmf401_appid.Text.Trim() == "")
        {
            this.uf_Msg("請輸入核定文號！");
            return;
        }
        
        // ##### 宣告變數 #####
        DataRowView ldrv_Row;

        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;

            this.indb_hmf401.uf_InsertRow(out ldrv_Row);

            ldrv_Row["hmf401_vid"] = dgG.DataKeys[li_row].ToString();
            ldrv_Row["hmf401_certid"] = this.StoredKey;
            ldrv_Row["hmf401_appid"] = dwF_hmf401_appid.Text.Trim();
            ldrv_Row["hmf401_aid"] = LoginUser.ID;
            ldrv_Row["hmf401_adt"] = DbMethods.uf_GetDateTime();
            ldrv_Row["hmf401_uid"] = LoginUser.ID;
            ldrv_Row["hmf401_udt"] = DbMethods.uf_GetDateTime();

            ldrv_Row.EndEdit();
        }

		this.uf_SetLog_Function(this.StoredKey);

        // 儲存資料
        if (this.indb_hmf401.uf_Update() != 1)
        {
            this.indb_hmf401.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hmf401.ErrorMsg);
            return;
        }
        else
        {
            uf_BindDgG();
            this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); uf_SelectFrame(1);");

			this.uf_Msg("認證核定完成！");
        }
    }

	protected void uf_SetLog_Function(object ao_key)
	{
		string[] lsa_key = ao_key.ToString().Trim().Split('|');
		Log.uf_SetLogKeysValue(this.Page, lsa_key);
	}
}