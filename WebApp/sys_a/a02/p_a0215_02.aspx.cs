﻿// *********************************************************************************
// 1. 程式描述：代碼維護 - 訓練課程種類 - 明細
// 2. 撰寫人員：rong
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

public partial class sys_a_a02_p_a0215_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：WITSETER (by QFLin)

	/// <summary>變數描述：人員類別資料元件</summary>
	protected ndb_hca215 indb_hca215 = new ndb_hca215();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
	{
		// 初始化
		this.uf_InitializeQuery(null, this.indb_hca215, null);
		this.uf_InitializeComponent(dwF, null, this.indb_hca215, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
		this.IsQuery_SessionRemove = false;

		// 註冊執行事件
		this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataDelete_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);

		// 如果是第一次執行此網頁
		if (!this.IsPostBack)
		{
			// 接收傳入值
			if (this.Request["args"] != null)
				this.StoredKey = this.Request["args"].Trim();

			// 將頁面切換到此頁
			this.uf_AddJavaScript("uf_SelectFrame(2);");
		}

		// 將主鍵值記錄為尋找資料的條件
		this.dgG_FindValue = new object[1];
		this.dgG_FindValue[0] = this.StoredKey;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料儲存之後所做的處理（新增、修改、刪除）
	/// </summary>
	private bool u_Edit_F_AfterSave(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		// 重新取出查詢及清單資料
		this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); uf_SelectFrame(1);");
		return true;
	}

	#region ☆ Override Methods --------------------------------------- 撰寫人員：rong

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
		if (a_Action == DwActions.New)
		{
			if (acto_Child == dwF_hca215_stop)
			{
				dwF_hca215_stop.Checked = this.uf_Dg_BindBool("Y", as_Value);
				return true;
			}

		}
		else if (a_Action == DwActions.Get)
		{
			if (acto_Child == dwF_hca215_stop)
			{
				dwF_hca215_stop.Checked = this.uf_Dg_BindBool("Y", as_Value);
				return true;
			}

		}
		else if (a_Action == DwActions.Set)
		{
			if (acto_Child == dwF_hca215_stop)
			{
				as_Value = this.uf_Dg_BindBool("Y,N", dwF_hca215_stop.Checked);
				return true;
			}

		}
		else if (a_Action == DwActions.Bind)
		{

		}


		return true;
	}

	#endregion

}
