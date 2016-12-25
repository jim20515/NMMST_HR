// *********************************************************************************
// 1. 程式描述：系統管理–參數設定–人員類別–明細
// 2. 撰寫人員：Emily
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

public partial class sys_c_c01_p_c0102_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：Emily

	/// <summary>變數描述：人員類別資料元件</summary>
    protected ndb_hmc102 indb_hmc102 = new ndb_hmc102();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 初始化
		this.uf_InitializeQuery(null, this.indb_hmc102, null);
		this.uf_InitializeComponent(dwF, null, this.indb_hmc102, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
        indb_hmc102.uf_Retrieve("");

		// 註冊執行事件
        this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
        this.ue_DataUpdate_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
		this.ue_DataDelete_PreDelete += new DataHandler(this.u_Edit_F_PreDelete);
        this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        this.ue_DataDelete_AfterSave += new DataHandler(this.u_Edit_F_AfterDelete);

        this.indb_hmc102.dv_View.Table.Columns["hmc102_blocked"].DefaultValue = "N";
        this.indb_hmc102.dv_View.Table.Columns["hmc102_parentid"].DefaultValue = "0";

		// 如果是第一次執行此網頁
		if (!this.IsPostBack)
		{
			// 接收傳入值
			if (this.Request["args"] != null)
				this.StoredKey = this.Request["args"].Trim();

            string ls_add_sql = "";

            if (this.StoredKey != "")
                ls_add_sql = " AND hmc102_id <> " + this.StoredKey + " ";

            Dbcfg.uf_Bind(dwF_hmc102_parentid, "hmc102", "", ls_add_sql, true);

			// 將頁面切換到此頁
			this.uf_AddJavaScript("uf_SelectFrame(2);");
		}

		// 將主鍵值記錄為尋找資料的條件
		this.dgG_FindValue = new object[1];
		this.dgG_FindValue[0] = this.StoredKey;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（新增）
	/// </summary>
	private bool u_Edit_F_PreEndEdit(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		if (adrv_Row == null) return true;


		// 如果資料為新增的
		if (adrv_Row.IsNew)
		{
			// 取得流水號的系統編號–資料庫最大值+1
            adrv_Row["hmc102_id"] = Convert.ToInt16(c01Project.uf_Get_SystemNo("hmc102.hmc102_id", ""));
            dwF_hmc102_id.Text = adrv_Row["hmc102_id"].ToString();
		}

        if (adrv_Row["hmc102_id"].ToString() == adrv_Row["hmc102_parentid"].ToString())
        {
            uf_Msg("父分類階層不能是本身！");
            return false;
        }

		return true;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（刪除）
	/// </summary>
	private bool u_Edit_F_PreDelete(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		if (adrv_Row == null) return true;

		// add by rong 2009/09/04不可刪除已有子節點資料
		int li_count = 0;
		DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hmc102 WHERE hmc102_parentid =" + dwF_hmc102_id.Text, ref li_count);
		if (li_count > 0)
		{
			uf_Msg("已有下層分類不可刪除！");
			return false;
		}

		li_count = 0;
		DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hmc101_102 WHERE hmc102_id =" + dwF_hmc102_id.Text, ref li_count);
		if (li_count > 0)
		{
			uf_Msg("已有使用該分類人力資源資料，故無法刪除！");
			return false;
		}
		return true;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料儲存之後所做的處理（新增、修改）
	/// </summary>
	private bool u_Edit_F_AfterSave(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		// 重新取出查詢及清單資料
        dwF_hmc102_parentid.DataTextField = "";
        Dbcfg.uf_Bind(dwF_hmc102_parentid, "hmc102", "", "", true);
        ListItem lli_Item = dwF_hmc102_parentid.Items.FindByValue(adrv_Row["hmc102_parentid"].ToString());
        dwF_hmc102_parentid.SelectedIndex = dwF_hmc102_parentid.Items.IndexOf(lli_Item);
		this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); uf_SelectFrame(1);");
		return true;
	}

    // =========================================================================
    /// <summary>
    /// 事件描述：按下 u_Edit_F 按鈕資料儲存之後所做的處理（刪除）
    /// </summary>
    private bool u_Edit_F_AfterDelete(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
    {
        // 重新取出查詢及清單資料
        dwF_hmc102_parentid.DataTextField = "";
        Dbcfg.uf_Bind(dwF_hmc102_parentid, "hmc102", "", "", true);
        this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); uf_SelectFrame(1);");
        return true;
    }

	#region ☆ Override Methods --------------------------------------- 撰寫人員：fen

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
			// 是否停用
			if (acto_Child == dwF_hmc102_stop)
			{
				dwF_hmc102_stop.Checked = this.uf_Dg_BindBool("Y", as_Value);
				return true;
			}
		}
		else if (a_Action == DwActions.Set)
		{
			// 是否停用
			if (acto_Child == dwF_hmc102_stop)
			{
				as_Value = this.uf_Dg_BindBool("Y,N", dwF_hmc102_stop.Checked);
				return true;
			}
		}
		return true;
	}

	#endregion

}
