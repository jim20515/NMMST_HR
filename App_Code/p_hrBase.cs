// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–Web Form 範本(繼承用)–NMMST 專用
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WIT.Template.Project
{
	/// <summary>
	/// 系統管理–Web Form 範本(繼承用)
	/// </summary>
	public class p_hrBase : p_sBase
	{
		#region ☆ Declare Events ----------------------------------------- 撰寫人員：fen

		/// <summary>事件描述：異動資料處理事件</summary>
		protected new event DataHandler ue_DataInsert_PreSetData;
		/// <summary>事件描述：異動資料處理事件</summary>
		protected new event DataHandler ue_DataInsert_PreEndEdit;
		/// <summary>事件描述：異動資料處理事件（排序索引鍵如不是唯一 adrv_Row 可能非當前筆）</summary>
		protected new event DataHandler ue_DataInsert_PreSave;
		/// <summary>事件描述：異動資料處理事件（排序索引鍵如不是唯一 adrv_Row 可能非當前筆）</summary>
		protected new event DataHandler ue_DataInsert_AfterSave;
		/// <summary>事件描述：異動資料處理事件</summary>
		protected new event DataHandler ue_DataUpdate_PreSetData;
		/// <summary>事件描述：異動資料處理事件</summary>
		protected new event DataHandler ue_DataUpdate_PreEndEdit;
		/// <summary>事件描述：異動資料處理事件（排序索引鍵如不是唯一 adrv_Row 可能非當前筆）</summary>
		protected new event DataHandler ue_DataUpdate_PreSave;
		/// <summary>事件描述：異動資料處理事件（排序索引鍵如不是唯一 adrv_Row 可能非當前筆）</summary>
		protected new event DataHandler ue_DataUpdate_AfterSave;
		/// <summary>事件描述：異動資料處理事件</summary>
		protected new event DataHandler ue_DataDelete_PreDelete;
		/// <summary>事件描述：異動資料處理事件（adrv_Row 為 null）</summary>
		protected new event DataHandler ue_DataDelete_PreSave;
		/// <summary>事件描述：異動資料處理事件（adrv_Row 為 null）</summary>
		protected new event DataHandler ue_DataDelete_AfterSave;

		#endregion

		#region ☆ (限定) Declare Properties ------------------------------ 撰寫人員：fen

		// =========================================================================
		/// <summary>屬性描述：[ViewState] DataGrid 選擇的資料索引(預設為-2表未使用)</summary>
		protected int dgG_SelectedIndex
		{
			get
			{
				if (this.ViewState["dgG_SelectedIndex"] != null)
					return Convert.ToInt16(this.ViewState["dgG_SelectedIndex"]);
				else
					return -2;
			}

			set
			{
				this.ViewState["dgG_SelectedIndex"] = value;
			}
		}

		#endregion

		// =========================================================================
		/// <summary>
		/// 事件描述：網頁初始化
		/// </summary>
		private void p_hrBase_Init(object sender, EventArgs e)
		{
			Log.uf_AddLogKeysControl(this.Page);
		}

		// =========================================================================
		/// <summary>
		/// 事件描述：網頁開啟
		/// </summary>
		private void p_hrBase_Load(object sender, EventArgs e)
		{
			// 記錄操作記錄主鍵值
			Log.uf_SetLogKeysValue(this.Page, this.dgG_FindValue);

			// 註冊執行事件
			this.ue_PageLoad_AfterBase += new EventHandler(this.PageLoad_AfterBase);
			this.ue_Page_PreRender_AfterBase += new EventHandler(this.Page_PreRender_AfterBase);
		}

		// =========================================================================
		/// <summary>
		/// 事件描述：Html 送出前所要做的動作
		/// </summary>
		private void p_hrBase_PreRender(object sender, EventArgs e)
		{
		}

		// =========================================================================
		/// <summary>
		/// 事件描述：網頁開啟（繼承處理後）
		/// </summary>
		protected virtual void PageLoad_AfterBase(object sender, EventArgs e)
		{
			// 如果是第一次執行此網頁
			if (!this.IsPostBack)
			{
				// 找到排序索引鍵值所在資料索引
				if (this.dgG_FindValue != null)
				{
					int li_index = -1;

					try { li_index = this.base_ndb_Data.uf_FindSortIndex(this.dgG_FindValue); }
					catch { li_index = -1; }

					this.dgG_SelectedIndex = li_index;
					if (this.dgG_SelectedIndex >= 0)
					{
						this.uf_DwF_GetData(base_dwF, this.base_ndb_Data[this.dgG_SelectedIndex]);

						// 顯示控制項按鈕
						if (base_u_Edit_F != null)
							base_u_Edit_F.uf_Display("IDUC");
					}
				}
			}
		}

		// =========================================================================
		/// <summary>
		/// 事件描述：Html 送出前所要做的動作（繼承處理後）
		/// </summary>
		protected virtual void Page_PreRender_AfterBase(object sender, EventArgs e)
		{
			// 如果不是第一次執行此網頁
			if (this.IsPostBack)
			{
				// 找到排序索引鍵值所在資料索引
				if (this.dgG_FindValue != null)
				{
					int li_index = -1;

					try { li_index = this.base_ndb_Data.uf_FindSortIndex(this.dgG_FindValue); }
					catch { li_index = -1; }

					this.dgG_SelectedIndex = li_index;
				}
			}

			// 記錄操作記錄主鍵值
			Log.uf_SetLogKeysValue(this.Page, this.dgG_FindValue);
		}

		#region Web Form Designer generated code
		/// <summary>
		/// 事件描述：OnInit
		/// </summary>
		/// <param name="e">EventArgs</param>
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 此呼叫為 ASP.NET Web Form 設計工具的必要項。
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// 此為設計工具支援所必需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Init += new System.EventHandler(this.p_hrBase_Init);
			this.Load += new System.EventHandler(this.p_hrBase_Load);
			this.PreRender += new System.EventHandler(this.p_hrBase_PreRender);

		}
		#endregion

		// =========================================================================
		/// <summary>
		/// 函式描述：《清除》資料處理
		/// </summary>
		/// <param name="adwF">FreeForm 資料容器</param>
		/// <param name="adgG">DataGrid 控制項</param>
		/// <param name="andb_Data">資料元件</param>
		/// <returns>成功(true)；失敗(false)</returns>
		protected override bool uf_Data_New(Control adwF, DataGrid adgG, n_dbbase andb_Data)
		{
			// 清空所有資料並離開
			this.uf_DwF_NewData(adwF, andb_Data.dv_View);
			if (adgG != null)
				adgG.SelectedIndex = -1;
			else if (dgG_SelectedIndex != -2)	// 20080209, fen add
				dgG_SelectedIndex = -1;
			return true;
		}

		// =========================================================================
		/// <summary>
		/// 函式描述：《選擇》資料處理
		/// </summary>
		/// <param name="adwF">FreeForm 資料容器</param>
		/// <param name="adgG">DataGrid 控制項</param>
		/// <param name="andb_Data">資料元件</param>
		/// <returns>成功(true)；失敗(false)</returns>
		protected override bool uf_Data_Select(Control adwF, DataGrid adgG, n_dbbase andb_Data)
		{
			// ##### 宣告變數 #####
			int		li_index = -1;

			if (adgG != null)
				li_index = adgG.SelectedIndex;
			else if (dgG_SelectedIndex != -2)	// 20080209, fen add
				li_index = dgG_SelectedIndex;
			else if (andb_Data.uf_RowCount() > 0)
				li_index = 0;

			// 判斷是否有選擇的資料
			if (li_index < 0 || andb_Data.uf_RowCount() <= 0)
			{
				this.uf_Msg("(Info) 沒有選擇的資料列！");
				return false;
			}

			// 找出當筆資料
			if (! this.uf_DwF_GetData(adwF, andb_Data[li_index]))
			{
				return false;
			}
			return true;
		}

		// =========================================================================
		/// <summary>
		/// 函式描述：《新增》資料處理（同父層）
		/// </summary>
		/// <param name="adwF">FreeForm 資料容器</param>
		/// <param name="adgG">DataGrid 控制項</param>
		/// <param name="andb_Data">資料元件</param>
		/// <param name="andba_Save">一起儲存的資料元件</param>
		/// <returns>成功(true)；失敗(false)</returns>
		protected override bool uf_Data_Insert(Control adwF, DataGrid adgG, n_dbbase andb_Data, params n_dbbase[] andba_Save)
		{
			// ##### 宣告變數 #####
			DataRowView ldrv_Row;

			// 新增一筆資料
			andb_Data.uf_InsertRow(out ldrv_Row);
			DataRow ldr_Row = ldrv_Row.Row;
			// 新增資料給值之前特殊欄位處理事件
			if (this.ue_DataInsert_PreSetData != null)
			{
				if (!this.ue_DataInsert_PreSetData(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}
			if (! this.uf_DwF_SetData(adwF, ldrv_Row)) goto Exit_Fail;
			// 新增資料自動給完值之後特殊欄位處理事件
			if (this.ue_DataInsert_PreEndEdit != null)
			{
				if (!this.ue_DataInsert_PreEndEdit(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}
			try
			{
				// 在 EndEdit 之前記錄下 DataRow，在 EndEdit 之後再重新取得 DataRowView
				ldrv_Row.EndEdit();
				// 記錄下當筆資料索引值
				if (this.dgG_Find != null)
				{
					this.dgG_FindValue = new object[this.dgG_Find.Length];
					for (int li_i = 0; li_i <= (this.dgG_Find.Length - 1); li_i++)
					{
						this.dgG_FindValue[li_i] = ldr_Row[this.dgG_Find[li_i].Trim()];	// 取得 DataRow 值（因此時 DataRowView 可能改變）
					}
					ldrv_Row = andb_Data.dv_View.FindRows(this.dgG_FindValue)[0];
				}
			}
			catch (System.Exception e)
			{
				if (e.Message.IndexOf("被限制為唯一") >= 0)
				{
					this.uf_Msg("(System) " + ldrv_Row.Row.Table.TableName + " EndEdit 失敗–主鍵值重複。\\n\\n◎ Error Message: \\n" + e.Message);
				}
				else
				{
					this.uf_Msg("(System) " + ldrv_Row.Row.Table.TableName + " EndEdit 失敗。\\n\\n◎ Error Message: \\n" + e.Message);
				}
				goto Exit_Fail;
			}

			// 儲存資料前處理事件
			if (this.ue_DataInsert_PreSave != null)
			{
				if (!this.ue_DataInsert_PreSave(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}

			// 儲存資料
			if (andb_Data.uf_Update(andba_Save) == 1)
			{
				// 儲存成功需移除主表格相關 Cache
				Dbcfg.uf_Bind_CacheRemoveGroup(andb_Data.dv_View.Table.TableName);

				// 儲存資料後處理事件
				if (this.ue_DataInsert_AfterSave != null)
				{
					this.ue_DataInsert_AfterSave(adwF, andb_Data, ldr_Row, ldrv_Row);
				}
				return true;
			}
			else
			{
				this.uf_Msg(andb_Data.ErrorMsg);
				goto Exit_Fail;
			}

			Exit_Fail:
				if (ldrv_Row.IsEdit)
					ldrv_Row.CancelEdit();
				else
					ldrv_Row.Delete();
			andb_Data.dv_View.Table.RejectChanges();
			this.dgG_FindValue = null;
			return false;
		}

		// =========================================================================
		/// <summary>
		/// 函式描述：《修改》資料處理
		/// </summary>
		/// <param name="adwF">FreeForm 資料容器</param>
		/// <param name="adgG">DataGrid 控制項</param>
		/// <param name="andb_Data">資料元件</param>
		/// <param name="andba_Save">一起儲存的資料元件</param>
		/// <returns>成功(true)；失敗(false)</returns>
		protected override bool uf_Data_Update(Control adwF, DataGrid adgG, n_dbbase andb_Data, params n_dbbase[] andba_Save)
		{
			// ##### 宣告變數 #####
			DataRowView ldrv_Row;
			int li_index = -1;

			if (adgG != null)
				li_index = adgG.SelectedIndex;
			else if (dgG_SelectedIndex != -2)	// 20080209, fen add
				li_index = dgG_SelectedIndex;
			else if (andb_Data.uf_RowCount() > 0)
				li_index = 0;

			// 判斷是否有選擇的資料
			if (li_index < 0 || andb_Data.uf_RowCount() <= 0)
			{
				this.uf_Msg("(Info) 沒有選擇的資料列！");
				return false;
			}
			
			// 找出當筆資料
			ldrv_Row = andb_Data[li_index];
			ldrv_Row.BeginEdit();
			DataRow ldr_Row = ldrv_Row.Row;
			// 修改資料給值之前特殊欄位處理事件
			if (this.ue_DataUpdate_PreSetData != null)
			{
				if (!this.ue_DataUpdate_PreSetData(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}
			if (! this.uf_DwF_SetData(adwF, ldrv_Row)) goto Exit_Fail;
			// 修改資料自動給完值之後特殊欄位處理事件
			if (this.ue_DataUpdate_PreEndEdit != null)
			{
				if (!this.ue_DataUpdate_PreEndEdit(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}
			try
			{
				// 在 EndEdit 之前記錄下 DataRow，在 EndEdit 之後再重新取得 DataRowView
				ldrv_Row.EndEdit();
				// 記錄下當筆資料索引值
				if (this.dgG_Find != null)
				{
					this.dgG_FindValue = new object[this.dgG_Find.Length];
					for (int li_i = 0; li_i <= (this.dgG_Find.Length - 1); li_i++)
					{
						this.dgG_FindValue[li_i] = ldr_Row[this.dgG_Find[li_i].Trim()];	// 取得 DataRow 值（因此時 DataRowView 可能改變）
					}
					ldrv_Row = andb_Data.dv_View.FindRows(this.dgG_FindValue)[0];
				}
			}
			catch (System.Exception e)
			{
				if (e.Message.IndexOf("被限制為唯一") >= 0)
				{
					this.uf_Msg("(System) " + ldrv_Row.Row.Table.TableName + " EndEdit 失敗–主鍵值重複。\\n\\n◎ Error Message: \\n" + e.Message);
				}
				else
				{
					this.uf_Msg("(System) " + ldrv_Row.Row.Table.TableName + " EndEdit 失敗。\\n\\n◎ Error Message: \\n" + e.Message);
				}
				goto Exit_Fail;
			}

			// 儲存資料前處理事件
			if (this.ue_DataUpdate_PreSave != null)
			{
				if (!this.ue_DataUpdate_PreSave(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}

			// 儲存資料
			if (andb_Data.uf_Update(andba_Save) == 1)
			{
				// 儲存成功需移除主表格相關 Cache
				Dbcfg.uf_Bind_CacheRemoveGroup(andb_Data.dv_View.Table.TableName);

				// 儲存資料後處理事件
				if (this.ue_DataUpdate_AfterSave != null)
				{
					this.ue_DataUpdate_AfterSave(adwF, andb_Data, ldr_Row, ldrv_Row);
				}
				return true;
			}
			else
			{
				this.uf_Msg(andb_Data.ErrorMsg);
				goto Exit_Fail;
			}

			Exit_Fail:
				if (ldrv_Row.IsEdit)
					ldrv_Row.CancelEdit();
			andb_Data.dv_View.Table.RejectChanges();
			this.dgG_FindValue = null;
			return false;
		}

		// =========================================================================
		/// <summary>
		/// 函式描述：《刪除》資料處理
		/// </summary>
		/// <param name="adwF">FreeForm 資料容器</param>
		/// <param name="adgG">DataGrid 控制項</param>
		/// <param name="andb_Data">資料元件</param>
		/// <param name="andba_Save">一起儲存的資料元件</param>
		/// <returns>成功(true)；失敗(false)</returns>
		protected override bool uf_Data_Delete(Control adwF, DataGrid adgG, n_dbbase andb_Data, params n_dbbase[] andba_Save)
		{
			// ##### 宣告變數 #####
			DataRowView ldrv_Row;
			int li_index = -1;

			if (adgG != null)
				li_index = adgG.SelectedIndex;
			else if (dgG_SelectedIndex != -2)	// 20080209, fen add
				li_index = dgG_SelectedIndex;
			else if (andb_Data.uf_RowCount() > 0)
				li_index = 0;

			// 判斷是否有選擇的資料
			if (li_index < 0 || andb_Data.uf_RowCount() <= 0)
			{
				this.uf_Msg("(Info) 沒有選擇的資料列！");
				return false;
			}
			
			// 找出當筆資料
			ldrv_Row = andb_Data[li_index];
			DataRow ldr_Row = ldrv_Row.Row;
			// 刪除資料之前特殊欄位處理事件
			if (this.ue_DataDelete_PreDelete != null)
			{
				if (!this.ue_DataDelete_PreDelete(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}
			// 在 Delete 之前記錄下 DataRow
			ldrv_Row.Delete();
			// 儲存資料前處理事件
			if (this.ue_DataDelete_PreSave != null)
			{
				// 在 Delete 之後 DataRowView 不存在，所以不傳
				if (!this.ue_DataDelete_PreSave(adwF, andb_Data, ldr_Row, null)) goto Exit_Fail;
			}

			// 儲存資料
			if (andb_Data.uf_Update(andba_Save) == 1)
			{
				// 儲存成功需移除主表格相關 Cache
				Dbcfg.uf_Bind_CacheRemoveGroup(andb_Data.dv_View.Table.TableName);

				// 儲存資料後處理事件
				if (this.ue_DataDelete_AfterSave != null)
				{
					// 在 Delete 之後 DataRowView 不存在，所以不傳
					this.ue_DataDelete_AfterSave(adwF, andb_Data, ldr_Row, null);
				}
				this.uf_DwF_NewData(adwF, andb_Data.dv_View);
				if (adgG != null)
					adgG.SelectedIndex = -1;
				else if (dgG_SelectedIndex != -2)	// 20080209, fen add
					dgG_SelectedIndex = -1;
				return true;
			}
			else
			{
				this.uf_Msg(andb_Data.ErrorMsg);
				goto Exit_Fail;
			}

			Exit_Fail:
				andb_Data.dv_View.Table.RejectChanges();
			return false;
		}
	}
}
