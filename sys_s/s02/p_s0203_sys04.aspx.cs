// *********************************************************************************
// 1. 程式描述：系統選單管理–系統功能設定
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

public partial class sys_s_s02_p_s0203_sys04 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：系統操作資料元件</summary>
	protected ndb_sys04 indb_sys04 = new ndb_sys04();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;

		// 初始化
		this.uf_InitializeComponent(dwF, dgG, this.indb_sys04, u_Edit_F);
		this.dgG_Sort = "s04_func_seq";

		// 註冊執行事件
		this.ue_DataInsert_PreSetData += new DataHandler(this.u_Edit_F_PreSetData);
		this.ue_DataInsert_PreSave += new DataHandler(this.u_Edit_F_PreSave);
		this.ue_DataUpdate_PreSave += new DataHandler(this.u_Edit_F_PreSave);
		this.ue_DataDelete_PreSave += new DataHandler(this.u_Edit_F_PreSave);
		this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：選擇 dwF_s04_sys_id 某筆資料所做的處理
	/// </summary>
	protected void dwF_s04_sys_id_SelectedIndexChanged(object sender, EventArgs e)
	{
		// 判斷 dwF_s04_sys_id 是否有選擇的項目，沒有則離開
		if (dwF_s04_sys_id.SelectedIndex == -1) return;

		// 依據選擇的系統列出父層功能
		dwF_s04_func_parent.DataTextField = "";
		Dbcfg.uf_Bind(dwF_s04_func_parent, "sys04_p", "s04_sys_id = '" + dwF_s04_sys_id.SelectedValue + "' AND s04_func_flag = 'N'", false);
		this.uf_SetFocus(dwF_s04_func_id);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：選擇 dwF_s04_func_parent 某筆資料所做的處理
	/// </summary>
	protected void dwF_s04_func_parent_SelectedIndexChanged(object sender, EventArgs e)
	{
		// 判斷 dwF_s04_func_parent 是否有選擇的項目，沒有則離開
		if (dwF_s04_func_parent.SelectedIndex == -1) return;

		// ##### 宣告變數 #####
		string ls_parentid;
		int li_seqstart = 1, li_i, li_seqend;

		// 得到資料筆數
		li_seqend = this.indb_sys04.uf_RowCount();

		// 找到此父層功能的功能序號
		ls_parentid = dwF_s04_func_parent.SelectedValue.Trim();
		if (ls_parentid != "")
		{
			// 設定功能代碼
			if (dwF_s04_func_id.Text.Trim() == "")
				dwF_s04_func_id.Text = ls_parentid.Remove(0, dwF_s04_sys_id.SelectedValue.Trim().Length);

			this.indb_sys04.uf_Filter("(Trim(s04_sys_id) + Trim(s04_func_id)) = '" + ls_parentid + "'");

			if (this.indb_sys04.uf_RowCount() > 0)
				li_seqstart = Convert.ToInt32(this.indb_sys04[0]["s04_func_seq"]) + 1;

			this.indb_sys04.uf_Filter("");
		}

		// 先刪除所有項目再新增
		dwF_s04_func_seq.Items.Clear();
		for (li_i = li_seqstart; li_i <= li_seqend; li_i++)
			dwF_s04_func_seq.Items.Add(li_i.ToString());

		// 再插入最後項目
		dwF_s04_func_seq.Items.Add(new ListItem("最後", li_i.ToString()));

		// 最後插入空白項目
		if (dwF_s04_func_seq.Items.FindByValue("") == null)
			dwF_s04_func_seq.Items.Insert(0, new ListItem("自動", ""));

		this.uf_SetFocus(dwF_s04_func_id);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料儲存之前所做的處理（新增）
	/// </summary>
	private bool u_Edit_F_PreSetData(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		if (adrv_Row == null) return true;

		// 將空項目轉換成新增的一筆序號
		if (dwF_s04_func_seq.SelectedItem == null || dwF_s04_func_seq.SelectedValue == "")
		{
			// ##### 宣告變數 #####
			ListItem lli_Item;

			// 將最後項目移除
			lli_Item = dwF_s04_func_seq.Items.FindByText("最後");
			if (lli_Item != null) dwF_s04_func_seq.Items.Remove(lli_Item);

			string ls_addseq = this.indb_sys04.uf_RowCount().ToString();
			// 找到要增加的序號
			if (dwF_s04_func_seq.Items.FindByValue(ls_addseq) == null)
				dwF_s04_func_seq.Items.Add(ls_addseq);

			dwF_s04_func_seq.SelectedIndex = dwF_s04_func_seq.Items.Count - 1;
			// 再插入最後項目
			dwF_s04_func_seq.Items.Add(new ListItem("最後", Convert.ToString(Convert.ToInt32(ls_addseq) + 1)));
		}
		return true;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料儲存之前所做的處理（新增、修改、刪除）
	/// </summary>
	private bool u_Edit_F_PreSave(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		// ##### 宣告變數 #####
		int li_seq = 0, li_seq_old = 0, li_seq_start = 1;
		int li_rowcount;

		// 增加欄位
		andb_Data.dv_View.Table.Columns.Add("s04_func_seq_c", System.Type.GetType("System.Int16"));
		andb_Data.dv_View.Table.Columns.Add("s04_upd_flag_c", System.Type.GetType("System.Int16"));

		// 得到原來的功能序號
		if (adr_Row.HasVersion(DataRowVersion.Original)
			&& adr_Row["s04_func_seq", DataRowVersion.Original] != DBNull.Value)
			li_seq_old = Convert.ToInt32(adr_Row["s04_func_seq", DataRowVersion.Original]);
		else
			li_seq_old = 0;

		// 如果不為刪除，則找出大於等於異動資料的功能序號的資料
		if (adr_Row.RowState != DataRowState.Deleted)
		{
			// 取得此筆資料設定的功能序號
			li_seq = Convert.ToInt32(adr_Row["s04_func_seq"]);

			// 判斷此功能序號如果等於原來的功能序號則不處理離開
			if (li_seq == li_seq_old) return true;

			// 設定此欄位異動
			adr_Row["s04_upd_flag_c"] = 0;

			// 判斷新功能序號和舊功能序號哪一個比較小，決定開始功能序號，舊功能序號如果為 0 表示為新增
			if (li_seq_old == 0 || li_seq <= li_seq_old)
				li_seq_start = li_seq;
			else
				li_seq_start = li_seq_old;

			// 過濾出大於等於開始功能序號的資料
			andb_Data.uf_Filter("s04_func_seq >= " + li_seq_start.ToString());
		}

		// 如果開始功能序號等於 0 則從 1 開始
		if (li_seq_start == 0) li_seq_start = 1;

		// 依據開始功能序號和資料筆數判斷出最大功能序號為何
		li_rowcount = andb_Data.uf_RowCount();
		if ((li_rowcount - 1) > 0)
			li_seq_start += li_rowcount - 1;

		// 依據功能序號、異動否 Flag 排序資料
		andb_Data.uf_Sort("s04_func_seq, s04_upd_flag_c DESC");

		// 重新編排資料(暫存)功能序號
		for (int li_row = li_rowcount - 1; li_row >= 0; li_row--)
		{
			// 判斷如果資料等於異動的資料列則重新記錄功能序號
			if (andb_Data[li_row].Row.RowState != DataRowState.Unchanged) li_seq = li_seq_start;

			// 給(暫存)序號
			andb_Data[li_row]["s04_func_seq_c"] = li_seq_start;
			li_seq_start--;
		}

		// 依據(暫存)功能序號排序資料
		andb_Data.uf_Sort("s04_func_seq_c");

		// 重新編排資料功能序號
		for (int li_row = 0; li_row < li_rowcount; li_row++)
		{
			// 給序號
			andb_Data[li_row]["s04_func_seq"] = andb_Data[li_row]["s04_func_seq_c"];
		}

		// 過濾回全部資料
		andb_Data.uf_Filter("");

		// 依據功能序號排序資料
		andb_Data.uf_Sort("s04_func_seq");

		// 記錄下當筆資料索引值
		this.dgG_FindValue = new object[1];
		this.dgG_FindValue[0] = li_seq;

		return true;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料儲存之後所做的處理（新增、修改）
	/// </summary>
	private bool u_Edit_F_AfterSave(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		// 重新依據選擇的系統列出父層功能
		this.uf_DwF_GetData(adwF, adrv_Row);
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
			// 系統
			if (acto_Child == dwF_s04_sys_id)
			{
				this.dwF_s04_sys_id_SelectedIndexChanged(this, EventArgs.Empty);
				return true;
			}
			// 父層功能
			if (acto_Child == dwF_s04_func_parent)
			{
				this.dwF_s04_func_parent_SelectedIndexChanged(this, EventArgs.Empty);
				return true;
			}
			// 功能註記
			if (acto_Child == dwF_s04_func_flag)
			{
				dwF_s04_func_flag.Checked = this.uf_Dg_BindBool("Y", as_Value);
				return true;
			}
		}
		else if (a_Action == DwActions.Set)
		{
			// 功能註記
			if (acto_Child == dwF_s04_func_flag)
			{
				as_Value = this.uf_Dg_BindBool("Y,N", dwF_s04_func_flag.Checked);
				return true;
			}
		}
		return true;
	}

	#endregion

}
