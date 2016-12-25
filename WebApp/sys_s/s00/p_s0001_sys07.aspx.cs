// *********************************************************************************
// 1. 程式描述：系統公告管理–最新公告
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

public partial class sys_s_s00_p_s0001_sys07 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：公告管理資料元件</summary>
	protected ndb_sys07 indb_sys07 = new ndb_sys07();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;

		// 初始化
		this.uf_InitializeQuery(dwQ, this.indb_sys07, bt_Query);
		this.uf_InitializeComponent(dwF, dgG, this.indb_sys07, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

		// 設定資料初始值
		this.indb_sys07.dv_View.Table.Columns["s07_man"].DefaultValue = LoginUser.Name;
		this.indb_sys07.dv_View.Table.Columns["s07_pdate"].DefaultValue = DbMethods.uf_GetDate();
		this.indb_sys07.dv_View.Table.Columns["s07_stop"].DefaultValue = "N";
		this.indb_sys07.dv_View.Table.Columns["s07_sort"].DefaultValue = 0;

		// 註冊執行事件
		this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
		this.ue_DataUpdate_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（新增、修改）
	/// </summary>
	private bool u_Edit_F_PreEndEdit(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		if (adrv_Row == null) return true;


		// 如果資料為新增的
		if (adrv_Row.IsNew)
		{
			// 取得流水號的系統編號–資料庫最大值+1
			adrv_Row["s07_no"] = WIT.Template.Project.sys_s.sProject.uf_Get_SystemNo("sys07.s07_no", "");
			dwF_s07_no.Text = adrv_Row["s07_no"].ToString();
		}

		return true;
	}

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
			// 公告日期起
			if (acto_Child == dwQ_s07_spdate)
			{
				if (as_Value != "")
					as_AddSQL += " AND Convert(char(10), s07_pdate, 111) >= '" + as_Value + "' ";
				return true;
			}
			// 公告日期迄
			if (acto_Child == dwQ_s07_epdate)
			{
				if (as_Value != "")
					as_AddSQL += " AND Convert(char(10), s07_pdate, 111) <= '" + as_Value + " 23:59:59' ";
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
		if (a_Action == DwActions.New || a_Action == DwActions.Get)
		{
			// 公告部門
			if (acto_Child == dwF_s07_unit)
			{
				dwF_s07_unit.Items[0].Text = "《全部》";
				return true;
			}
			// 公告對象
			if (acto_Child == dwF_s07_tounit)
			{
				dwF_s07_tounit.Items[0].Text = "《全部》";
				if (!this.IsPostBack)
					dwF_s07_tounit.Items.Insert(1, new ListItem("《登入頁顯示》", "0"));
				return true;
			}
			// 暫停
			if (acto_Child == dwF_s07_stop)
			{
				dwF_s07_stop.Checked = this.uf_Dg_BindBool("Y", as_Value);
				return true;
			}
		}
		else if (a_Action == DwActions.Set)
		{
			// 暫停
			if (acto_Child == dwF_s07_stop)
			{
				as_Value = this.uf_Dg_BindBool("Y,N", dwF_s07_stop.Checked);
				return true;
			}
		}
		return true;
	}

	#endregion

}
