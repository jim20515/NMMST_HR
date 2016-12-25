// *********************************************************************************
// 1. 程式描述：系統權限管理–使用者權限設定
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

public partial class sys_s_s01_p_s0103_sys02 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：使用者帳號資料元件</summary>
	protected ndb_user01 indb_user01 = new ndb_user01();
	/// <summary>變數描述：系統權限群組使用者資料元件</summary>
	protected ndb_sys02 indb_sys02 = new ndb_sys02();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁初始化
	/// </summary>
	private void Page_Init(object sender, EventArgs e)
	{
		Log.uf_AddLogKeysControl(this.Page);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;

		// 初始化
		this.uf_InitializeQuery(dwQ, this.indb_user01, bt_Query);
		this.dwQ_Sort = "user01_id";
		this.dwQ_Filter = "user01_sdate IS NULL";
		//this.dwQ_Filter = "user01_flag = '1' AND user01_sdate IS NULL";
		this.uf_InitializeComponent(dwF, dgG, this.indb_sys02, u_Edit_F);
		if (this.StoredKey == "")
		{
			this.dgG_Retrieve = "no";
		}
		else
		{
			this.dgG_Retrieve = " AND s02_user_id = '" + this.StoredKey + "' ";
			this.indb_sys02.dv_View.Table.Columns["s02_user_id"].DefaultValue = this.StoredKey;
		}
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

		// 將主鍵值記錄為尋找資料的條件
		this.dgG_FindValue = new object[2];
		this.dgG_FindValue[0] = (dgG.SelectedIndex >= 0 ? dgG.DataKeys[dgG.SelectedIndex].ToString().Trim() : "");
		this.dgG_FindValue[1] = this.StoredKey;

		// 記錄操作記錄主鍵值
		Log.uf_SetLogKeysValue(this.Page, this.dgG_FindValue);

		// 註冊執行事件
		this.ue_DataQuery_AfterRetrieve += new EventHandler(this.bt_Query_AfterRetrieve);

		// 如果是第一次執行此網頁，編輯按鈕組不可使用
		if (!this.IsPostBack)
		{
			u_Edit_F.uf_Enabled(false);

			// 判斷傳遞過來的參數
			if (this.Request["Qtype"] != null &&
				this.Request["Qtype"].Trim() == "NotSet")
			{
				dwQ_notset_c.Checked = true;
				this.ibt_Query_Click(this, EventArgs.Empty);
			}
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：Html 送出前所要做的動作
	/// </summary>
	protected void Page_PreRender(object sender, EventArgs e)
	{
		// 記錄操作記錄主鍵值
		Log.uf_SetLogKeysValue(this.Page, this.dgG_FindValue);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Query 《查詢》按鈕資料取出之後所做的處理
	/// </summary>
	private void bt_Query_AfterRetrieve(object sender, EventArgs e)
	{
		// 重新繫結群組資料
		dwS_user01_select.DataBind();

		// 如果有資料則取出第一筆的群組資料
		if (dwS_user01_select.Items.Count > 0)
		{
			dwS_user01_select.SelectedIndex = 0;
			this.uf_indb_s02_Retrieve();
			u_Edit_F.uf_Enabled(true);
		}
		else
		{
			// 清空顯示的使用者資料
			this.StoredKey = "";
			this.uf_DwF_NewData(dwS, this.indb_user01.dv_View);

			// 清除原先的群組資料
			this.indb_sys02.ds_Data.Clear();
			this.uf_Data_New(dwF, dgG, this.indb_sys02);
			u_Edit_F.uf_Display("IC");
			u_Edit_F.uf_Enabled(false);
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：選擇 dwS_user01_select 某筆資料所做的處理
	/// </summary>
	protected void dwS_user01_select_SelectedIndexChanged(object sender, EventArgs e)
	{
		// 重新取出資料
		this.uf_indb_s02_Retrieve();
	}

	#region ☆ Private Methods ---------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：取出 indb_sys02 資料所做的處理
	/// </summary>
	private void uf_indb_s02_Retrieve()
	{
		// 判斷 dwS_user01_select 是否有選擇的項目，沒有則離開
		if (dwS_user01_select.SelectedIndex == -1) return;


		// ##### 宣告變數 #####
		int li_index = -1;

		// 得到使用者帳號
		this.StoredKey = dwS_user01_select.SelectedValue.Trim();

		// 顯示出此使用者的基本資料 ------------------------------- (1)
		li_index = this.indb_user01.uf_FindSortIndex(this.StoredKey);

		// 判斷是否找到符合的資料，沒有則離開
		if (li_index == -1) return;


		// 取出使用者基本資料
		this.uf_DwF_GetData(dwS, this.indb_user01[li_index]);

		// 重新顯示使用者群組資料 --------------------------------- (2)

		// 相當於按下《清除》鍵
		this.uf_Data_New(dwF, dgG, this.indb_sys02);
		u_Edit_F.uf_Display("IC");

		// 設定 DataGrid 資料取出語法並取出資料
		this.dgG_Retrieve = " AND s02_user_id = '" + this.StoredKey + "' ";

		// 取出此使用者的系統權限群組資料
		this.indb_sys02.uf_Retrieve(this.dgG_Retrieve);
		this.indb_sys02.uf_Filter(this.dgG_Filter);
		this.indb_sys02.uf_Sort(this.dgG_Sort);
		this.uf_SetFocus(dwF_s02_grp_id);
	}

	#endregion

	#region ☆ Override Methods --------------------------------------- 撰寫人員：fen

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
			// 未設定權限
			if (acto_Child == dwQ_notset_c)
			{
				if (dwQ_notset_c.Checked)
					as_AddSQL += " AND user01_id NOT IN (SELECT s02_user_id FROM sys02) ";
				return true;
			}
		}
		return true;
	}

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
		if (a_Action == DwActions.Get)
		{
			// 部門
			if (acto_Child == dwS_user01_dept)
			{
				dwS_user01_dept.Text = this.uf_Dg_Bind("hca202", as_Value);
				return true;
			}
			// 群組
			if (acto_Child == dwF_s02_grp_id)
			{
				// 將主鍵值記錄為尋找資料的條件
				this.dgG_FindValue = new object[2];
				this.dgG_FindValue[0] = as_Value.Trim();
				this.dgG_FindValue[1] = this.StoredKey;
				return true;
			}
		}
		return true;
	}

	#endregion

}
