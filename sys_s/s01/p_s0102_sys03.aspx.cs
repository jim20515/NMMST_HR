// *********************************************************************************
// 1. 程式描述：系統權限管理–系統群組權限設定
// 2. 撰寫人員：fen
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

public partial class sys_s_s01_p_s0102_sys03 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：系統權限群組資料元件</summary>
	protected ndb_sys01 indb_sys01 = new ndb_sys01();
	/// <summary>變數描述：系統權限群組操作資料元件–傳入值「群組代碼」</summary>
	protected ndb_sys03 indb_sys03 = new ndb_sys03();
	/// <summary>變數描述：系統系統資料元件</summary>
	protected ndb_sys04 indb_sys04 = new ndb_sys04();
	/// <summary>變數描述：記錄 DataGrid 資料繫結時目前資料的系統代碼</summary>
	protected string is_sys_id = "";

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;

		// 初始化
		this.uf_InitializeQuery(dwQ, this.indb_sys01, bt_Query);
		this.dwQ_Sort = "s01_grp_name";
		this.uf_InitializeComponent(null, dgG, this.indb_sys04, null);
		this.dgG_Retrieve = "no";
		this.dgG_Sort = "s04_func_seq";

		// 註冊執行事件
		this.ue_DataQuery_AfterRetrieve += new EventHandler(this.bt_Query_AfterRetrieve);

		// 從參數管理中得到 indb_sys04 的資料
		this.indb_sys04.ds_Data.Clear();
		this.indb_sys04.ds_Data.Merge(Dbcfg.uf_Retrieve("sys04_f").Table);

		// 如果是第一次執行此網頁
		if (!this.IsPostBack)
		{
			// 清除 Session["sds_data"]
			this.Session.Remove("sds_data");
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：Html 送出前所要做的動作
	/// </summary>
	protected void Page_PreRender(object sender, EventArgs e)
	{
		// 記錄下目前的權限資料
		this.Session["sds_data"] = this.indb_sys03.ds_Data.Copy();

		// 記錄下主鍵值
		ScriptManager.RegisterHiddenField(Page, "ActionLogKeys", this.StoredKey);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Query 《查詢》按鈕資料取出之後所做的處理
	/// </summary>
	private void bt_Query_AfterRetrieve(object sender, EventArgs e)
	{
		// 重新繫結群組資料
		dwF_s01_grp_id.DataBind();

		// 清除 Session["sds_data"]
		this.Session.Remove("sds_data");

		// 如果有資料則取出第一筆的權限資料
		if (dwF_s01_grp_id.Items.Count > 0)
		{
			dwF_s01_grp_id.SelectedIndex = 0;
			this.uf_indb_s03_Retrieve();
			bt_Save.Enabled = true;
		}
		else
		{
			bt_Save.Enabled = false;
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：選擇 dwF_s01_grp_id 某筆資料所做的處理
	/// </summary>
	protected void dwF_s01_grp_id_SelectedIndexChanged(object sender, EventArgs e)
	{
		// 清除 Session["sds_data"]
		this.Session.Remove("sds_data");

		// 重新取出資料
		this.uf_indb_s03_Retrieve();
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 dgG 某筆資料所做的處理
	/// </summary>
	protected void dgG_ItemCommand(object source, DataGridCommandEventArgs e)
	{
		// ##### 宣告變數 #####
		string ls_sys_id;
		object[] loa_Find = new object[2];
		int li_index;

		this.uf_indb_s03_Retrieve();

		// 取得系統代碼並過濾出符合此系統的資料
		ls_sys_id = this.indb_sys04[e.Item.ItemIndex]["s04_sys_id"].ToString().Trim();
		this.indb_sys04.uf_Filter("Trim(s04_sys_id) = '" + ls_sys_id + "'");

		// 依序判斷資料是否存在 indb_sys03 中
		for (int li_row = 0; li_row <= (this.indb_sys04.uf_RowCount() - 1); li_row++)
		{
			loa_Find[0] = this.indb_sys04[li_row]["s04_sys_id"];
			loa_Find[1] = this.indb_sys04[li_row]["s04_func_id"];

			li_index = this.indb_sys03.dv_View.Find(loa_Find);

			// 如果為全選且不存在
			if (e.CommandName == "CheckSysAll" && li_index == -1)
			{
				this.indb_sys03.uf_InsertRow(this.StoredKey, this.indb_sys04[li_row]["s04_sys_id"], this.indb_sys04[li_row]["s04_func_id"]);
			}
			// 如果為不選且存在
			else if (e.CommandName == "UnCheckSysAll" && li_index != -1)
			{
				this.indb_sys03.uf_DeleteRow(li_index);
			}
		}
		this.indb_sys04.uf_Filter("");
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Save 《儲存》按鈕所做的處理
	/// </summary>
	protected void bt_Save_Click(object sender, EventArgs e)
	{
		// 先將系統權限操作資料全部刪除
		this.uf_indb_s03_Retrieve();
		this.indb_sys03.uf_DeleteRowAll();

		// 將 DataGrid 選擇的資料新增到系統權限操作資料
		for (int li_row = 0; li_row < this.indb_sys04.uf_RowCount(); li_row++)
		{
			if (((CheckBox)dgG.Items[li_row].FindControl("dwG_s04_in_s03_c")).Checked)
			{
				this.indb_sys03.uf_InsertRow(this.StoredKey, this.indb_sys04[li_row]["s04_sys_id"], this.indb_sys04[li_row]["s04_func_id"]);
			}
		}

		// 儲存資料
		if (this.indb_sys03.uf_Update() != 1)
		{
			this.indb_sys03.dv_View.Table.RejectChanges();
			this.uf_Msg(this.indb_sys03.ErrorMsg);
		}
	}

	#region ☆ DataGrid Bind Methods ---------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：資料繫結–利用 Value 值得到資料是否為第一筆 Bool 對應的內容（去空白比對）
	/// </summary>
	/// <param name="ab_IsAlwaysShow">查詢有無值是否都要顯示</param>
	/// <param name="ab_IsRecord">是否記錄下新的 Value 值</param>
	/// <param name="ao_Value">資料值</param>
	/// <returns>對應值(true;false)</returns>
	protected bool uf_Dg_BindFirstBool(bool ab_IsAlwaysShow, bool ab_IsRecord, object ao_Value)
	{
		if (!ab_IsAlwaysShow)
		{
			if (!uf_Dg_BindBool(",0", dwF_s01_grp_id.Items.Count))
			{
				if (ab_IsRecord)
					is_sys_id = ao_Value.ToString().Trim();
				return false;
			}
		}

		if (ao_Value.ToString().Trim() != is_sys_id)
		{
			if (ab_IsRecord)
				is_sys_id = ao_Value.ToString().Trim();
			return true;
		}
		else
		{
			return false;
		}
	}

	#endregion

	#region ☆ Private Methods ---------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：取出 indb_sys03 資料所做的處理
	/// </summary>
	private void uf_indb_s03_Retrieve()
	{
		// 判斷 dwF_s01_grp_id 是否有選擇的項目，沒有則離開
		if (dwF_s01_grp_id.SelectedIndex == -1) return;

		// 得到群組代碼
		this.StoredKey = dwF_s01_grp_id.SelectedValue.Trim();

		// 如果有記錄 Session["sds_data"] 則將資料取回 
		if (this.Session["sds_data"] != null)
		{
			this.indb_sys03.ds_Data.Clear();
			this.indb_sys03.ds_Data.Merge((DataSet)this.Session["sds_data"]);
		}
		else
		{
			// 取出此群組的系統權限操作資料
			this.indb_sys03.uf_Retrieve("", this.StoredKey);
		}
		this.indb_sys03.uf_Sort("s03_sys_id, s03_func_id");
	}

	#endregion

}
