// *********************************************************************************
// 1. �{���y�z�G�����ަ@�Ψ禡�w�VWeb Form �d��(�~�ӥ�)�VNMMST �M��
// 2. ���g�H���Gfen
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
	/// �t�κ޲z�VWeb Form �d��(�~�ӥ�)
	/// </summary>
	public class p_hrBase : p_sBase
	{
		#region �� Declare Events ----------------------------------------- ���g�H���Gfen

		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�</summary>
		protected new event DataHandler ue_DataInsert_PreSetData;
		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�</summary>
		protected new event DataHandler ue_DataInsert_PreEndEdit;
		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�]�Ƨǯ�����p���O�ߤ@ adrv_Row �i��D��e���^</summary>
		protected new event DataHandler ue_DataInsert_PreSave;
		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�]�Ƨǯ�����p���O�ߤ@ adrv_Row �i��D��e���^</summary>
		protected new event DataHandler ue_DataInsert_AfterSave;
		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�</summary>
		protected new event DataHandler ue_DataUpdate_PreSetData;
		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�</summary>
		protected new event DataHandler ue_DataUpdate_PreEndEdit;
		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�]�Ƨǯ�����p���O�ߤ@ adrv_Row �i��D��e���^</summary>
		protected new event DataHandler ue_DataUpdate_PreSave;
		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�]�Ƨǯ�����p���O�ߤ@ adrv_Row �i��D��e���^</summary>
		protected new event DataHandler ue_DataUpdate_AfterSave;
		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�</summary>
		protected new event DataHandler ue_DataDelete_PreDelete;
		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�]adrv_Row �� null�^</summary>
		protected new event DataHandler ue_DataDelete_PreSave;
		/// <summary>�ƥ�y�z�G���ʸ�ƳB�z�ƥ�]adrv_Row �� null�^</summary>
		protected new event DataHandler ue_DataDelete_AfterSave;

		#endregion

		#region �� (���w) Declare Properties ------------------------------ ���g�H���Gfen

		// =========================================================================
		/// <summary>�ݩʴy�z�G[ViewState] DataGrid ��ܪ���Ư���(�w�]��-2���ϥ�)</summary>
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
		/// �ƥ�y�z�G������l��
		/// </summary>
		private void p_hrBase_Init(object sender, EventArgs e)
		{
			Log.uf_AddLogKeysControl(this.Page);
		}

		// =========================================================================
		/// <summary>
		/// �ƥ�y�z�G�����}��
		/// </summary>
		private void p_hrBase_Load(object sender, EventArgs e)
		{
			// �O���ާ@�O���D���
			Log.uf_SetLogKeysValue(this.Page, this.dgG_FindValue);

			// ���U����ƥ�
			this.ue_PageLoad_AfterBase += new EventHandler(this.PageLoad_AfterBase);
			this.ue_Page_PreRender_AfterBase += new EventHandler(this.Page_PreRender_AfterBase);
		}

		// =========================================================================
		/// <summary>
		/// �ƥ�y�z�GHtml �e�X�e�ҭn�����ʧ@
		/// </summary>
		private void p_hrBase_PreRender(object sender, EventArgs e)
		{
		}

		// =========================================================================
		/// <summary>
		/// �ƥ�y�z�G�����}�ҡ]�~�ӳB�z��^
		/// </summary>
		protected virtual void PageLoad_AfterBase(object sender, EventArgs e)
		{
			// �p�G�O�Ĥ@�����榹����
			if (!this.IsPostBack)
			{
				// ���Ƨǯ�����ȩҦb��Ư���
				if (this.dgG_FindValue != null)
				{
					int li_index = -1;

					try { li_index = this.base_ndb_Data.uf_FindSortIndex(this.dgG_FindValue); }
					catch { li_index = -1; }

					this.dgG_SelectedIndex = li_index;
					if (this.dgG_SelectedIndex >= 0)
					{
						this.uf_DwF_GetData(base_dwF, this.base_ndb_Data[this.dgG_SelectedIndex]);

						// ��ܱ�����s
						if (base_u_Edit_F != null)
							base_u_Edit_F.uf_Display("IDUC");
					}
				}
			}
		}

		// =========================================================================
		/// <summary>
		/// �ƥ�y�z�GHtml �e�X�e�ҭn�����ʧ@�]�~�ӳB�z��^
		/// </summary>
		protected virtual void Page_PreRender_AfterBase(object sender, EventArgs e)
		{
			// �p�G���O�Ĥ@�����榹����
			if (this.IsPostBack)
			{
				// ���Ƨǯ�����ȩҦb��Ư���
				if (this.dgG_FindValue != null)
				{
					int li_index = -1;

					try { li_index = this.base_ndb_Data.uf_FindSortIndex(this.dgG_FindValue); }
					catch { li_index = -1; }

					this.dgG_SelectedIndex = li_index;
				}
			}

			// �O���ާ@�O���D���
			Log.uf_SetLogKeysValue(this.Page, this.dgG_FindValue);
		}

		#region Web Form Designer generated code
		/// <summary>
		/// �ƥ�y�z�GOnInit
		/// </summary>
		/// <param name="e">EventArgs</param>
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: ���I�s�� ASP.NET Web Form �]�p�u�㪺���n���C
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// �����]�p�u��䴩�ҥ��ݪ���k - �ФŨϥε{���X�s�边�ק�
		/// �o�Ӥ�k�����e�C
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
		/// �禡�y�z�G�m�M���n��ƳB�z
		/// </summary>
		/// <param name="adwF">FreeForm ��Ʈe��</param>
		/// <param name="adgG">DataGrid ���</param>
		/// <param name="andb_Data">��Ƥ���</param>
		/// <returns>���\(true)�F����(false)</returns>
		protected override bool uf_Data_New(Control adwF, DataGrid adgG, n_dbbase andb_Data)
		{
			// �M�ũҦ���ƨ����}
			this.uf_DwF_NewData(adwF, andb_Data.dv_View);
			if (adgG != null)
				adgG.SelectedIndex = -1;
			else if (dgG_SelectedIndex != -2)	// 20080209, fen add
				dgG_SelectedIndex = -1;
			return true;
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�m��ܡn��ƳB�z
		/// </summary>
		/// <param name="adwF">FreeForm ��Ʈe��</param>
		/// <param name="adgG">DataGrid ���</param>
		/// <param name="andb_Data">��Ƥ���</param>
		/// <returns>���\(true)�F����(false)</returns>
		protected override bool uf_Data_Select(Control adwF, DataGrid adgG, n_dbbase andb_Data)
		{
			// ##### �ŧi�ܼ� #####
			int		li_index = -1;

			if (adgG != null)
				li_index = adgG.SelectedIndex;
			else if (dgG_SelectedIndex != -2)	// 20080209, fen add
				li_index = dgG_SelectedIndex;
			else if (andb_Data.uf_RowCount() > 0)
				li_index = 0;

			// �P�_�O�_����ܪ����
			if (li_index < 0 || andb_Data.uf_RowCount() <= 0)
			{
				this.uf_Msg("(Info) �S����ܪ���ƦC�I");
				return false;
			}

			// ��X�����
			if (! this.uf_DwF_GetData(adwF, andb_Data[li_index]))
			{
				return false;
			}
			return true;
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�m�s�W�n��ƳB�z�]�P���h�^
		/// </summary>
		/// <param name="adwF">FreeForm ��Ʈe��</param>
		/// <param name="adgG">DataGrid ���</param>
		/// <param name="andb_Data">��Ƥ���</param>
		/// <param name="andba_Save">�@�_�x�s����Ƥ���</param>
		/// <returns>���\(true)�F����(false)</returns>
		protected override bool uf_Data_Insert(Control adwF, DataGrid adgG, n_dbbase andb_Data, params n_dbbase[] andba_Save)
		{
			// ##### �ŧi�ܼ� #####
			DataRowView ldrv_Row;

			// �s�W�@�����
			andb_Data.uf_InsertRow(out ldrv_Row);
			DataRow ldr_Row = ldrv_Row.Row;
			// �s�W��Ƶ��Ȥ��e�S�����B�z�ƥ�
			if (this.ue_DataInsert_PreSetData != null)
			{
				if (!this.ue_DataInsert_PreSetData(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}
			if (! this.uf_DwF_SetData(adwF, ldrv_Row)) goto Exit_Fail;
			// �s�W��Ʀ۰ʵ����Ȥ���S�����B�z�ƥ�
			if (this.ue_DataInsert_PreEndEdit != null)
			{
				if (!this.ue_DataInsert_PreEndEdit(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}
			try
			{
				// �b EndEdit ���e�O���U DataRow�A�b EndEdit ����A���s���o DataRowView
				ldrv_Row.EndEdit();
				// �O���U����Ư��ޭ�
				if (this.dgG_Find != null)
				{
					this.dgG_FindValue = new object[this.dgG_Find.Length];
					for (int li_i = 0; li_i <= (this.dgG_Find.Length - 1); li_i++)
					{
						this.dgG_FindValue[li_i] = ldr_Row[this.dgG_Find[li_i].Trim()];	// ���o DataRow �ȡ]�]���� DataRowView �i����ܡ^
					}
					ldrv_Row = andb_Data.dv_View.FindRows(this.dgG_FindValue)[0];
				}
			}
			catch (System.Exception e)
			{
				if (e.Message.IndexOf("�Q����ߤ@") >= 0)
				{
					this.uf_Msg("(System) " + ldrv_Row.Row.Table.TableName + " EndEdit ���ѡV�D��ȭ��ơC\\n\\n�� Error Message: \\n" + e.Message);
				}
				else
				{
					this.uf_Msg("(System) " + ldrv_Row.Row.Table.TableName + " EndEdit ���ѡC\\n\\n�� Error Message: \\n" + e.Message);
				}
				goto Exit_Fail;
			}

			// �x�s��ƫe�B�z�ƥ�
			if (this.ue_DataInsert_PreSave != null)
			{
				if (!this.ue_DataInsert_PreSave(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}

			// �x�s���
			if (andb_Data.uf_Update(andba_Save) == 1)
			{
				// �x�s���\�ݲ����D������ Cache
				Dbcfg.uf_Bind_CacheRemoveGroup(andb_Data.dv_View.Table.TableName);

				// �x�s��ƫ�B�z�ƥ�
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
		/// �禡�y�z�G�m�ק�n��ƳB�z
		/// </summary>
		/// <param name="adwF">FreeForm ��Ʈe��</param>
		/// <param name="adgG">DataGrid ���</param>
		/// <param name="andb_Data">��Ƥ���</param>
		/// <param name="andba_Save">�@�_�x�s����Ƥ���</param>
		/// <returns>���\(true)�F����(false)</returns>
		protected override bool uf_Data_Update(Control adwF, DataGrid adgG, n_dbbase andb_Data, params n_dbbase[] andba_Save)
		{
			// ##### �ŧi�ܼ� #####
			DataRowView ldrv_Row;
			int li_index = -1;

			if (adgG != null)
				li_index = adgG.SelectedIndex;
			else if (dgG_SelectedIndex != -2)	// 20080209, fen add
				li_index = dgG_SelectedIndex;
			else if (andb_Data.uf_RowCount() > 0)
				li_index = 0;

			// �P�_�O�_����ܪ����
			if (li_index < 0 || andb_Data.uf_RowCount() <= 0)
			{
				this.uf_Msg("(Info) �S����ܪ���ƦC�I");
				return false;
			}
			
			// ��X�����
			ldrv_Row = andb_Data[li_index];
			ldrv_Row.BeginEdit();
			DataRow ldr_Row = ldrv_Row.Row;
			// �ק��Ƶ��Ȥ��e�S�����B�z�ƥ�
			if (this.ue_DataUpdate_PreSetData != null)
			{
				if (!this.ue_DataUpdate_PreSetData(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}
			if (! this.uf_DwF_SetData(adwF, ldrv_Row)) goto Exit_Fail;
			// �ק��Ʀ۰ʵ����Ȥ���S�����B�z�ƥ�
			if (this.ue_DataUpdate_PreEndEdit != null)
			{
				if (!this.ue_DataUpdate_PreEndEdit(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}
			try
			{
				// �b EndEdit ���e�O���U DataRow�A�b EndEdit ����A���s���o DataRowView
				ldrv_Row.EndEdit();
				// �O���U����Ư��ޭ�
				if (this.dgG_Find != null)
				{
					this.dgG_FindValue = new object[this.dgG_Find.Length];
					for (int li_i = 0; li_i <= (this.dgG_Find.Length - 1); li_i++)
					{
						this.dgG_FindValue[li_i] = ldr_Row[this.dgG_Find[li_i].Trim()];	// ���o DataRow �ȡ]�]���� DataRowView �i����ܡ^
					}
					ldrv_Row = andb_Data.dv_View.FindRows(this.dgG_FindValue)[0];
				}
			}
			catch (System.Exception e)
			{
				if (e.Message.IndexOf("�Q����ߤ@") >= 0)
				{
					this.uf_Msg("(System) " + ldrv_Row.Row.Table.TableName + " EndEdit ���ѡV�D��ȭ��ơC\\n\\n�� Error Message: \\n" + e.Message);
				}
				else
				{
					this.uf_Msg("(System) " + ldrv_Row.Row.Table.TableName + " EndEdit ���ѡC\\n\\n�� Error Message: \\n" + e.Message);
				}
				goto Exit_Fail;
			}

			// �x�s��ƫe�B�z�ƥ�
			if (this.ue_DataUpdate_PreSave != null)
			{
				if (!this.ue_DataUpdate_PreSave(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}

			// �x�s���
			if (andb_Data.uf_Update(andba_Save) == 1)
			{
				// �x�s���\�ݲ����D������ Cache
				Dbcfg.uf_Bind_CacheRemoveGroup(andb_Data.dv_View.Table.TableName);

				// �x�s��ƫ�B�z�ƥ�
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
		/// �禡�y�z�G�m�R���n��ƳB�z
		/// </summary>
		/// <param name="adwF">FreeForm ��Ʈe��</param>
		/// <param name="adgG">DataGrid ���</param>
		/// <param name="andb_Data">��Ƥ���</param>
		/// <param name="andba_Save">�@�_�x�s����Ƥ���</param>
		/// <returns>���\(true)�F����(false)</returns>
		protected override bool uf_Data_Delete(Control adwF, DataGrid adgG, n_dbbase andb_Data, params n_dbbase[] andba_Save)
		{
			// ##### �ŧi�ܼ� #####
			DataRowView ldrv_Row;
			int li_index = -1;

			if (adgG != null)
				li_index = adgG.SelectedIndex;
			else if (dgG_SelectedIndex != -2)	// 20080209, fen add
				li_index = dgG_SelectedIndex;
			else if (andb_Data.uf_RowCount() > 0)
				li_index = 0;

			// �P�_�O�_����ܪ����
			if (li_index < 0 || andb_Data.uf_RowCount() <= 0)
			{
				this.uf_Msg("(Info) �S����ܪ���ƦC�I");
				return false;
			}
			
			// ��X�����
			ldrv_Row = andb_Data[li_index];
			DataRow ldr_Row = ldrv_Row.Row;
			// �R����Ƥ��e�S�����B�z�ƥ�
			if (this.ue_DataDelete_PreDelete != null)
			{
				if (!this.ue_DataDelete_PreDelete(adwF, andb_Data, ldr_Row, ldrv_Row)) goto Exit_Fail;
			}
			// �b Delete ���e�O���U DataRow
			ldrv_Row.Delete();
			// �x�s��ƫe�B�z�ƥ�
			if (this.ue_DataDelete_PreSave != null)
			{
				// �b Delete ���� DataRowView ���s�b�A�ҥH����
				if (!this.ue_DataDelete_PreSave(adwF, andb_Data, ldr_Row, null)) goto Exit_Fail;
			}

			// �x�s���
			if (andb_Data.uf_Update(andba_Save) == 1)
			{
				// �x�s���\�ݲ����D������ Cache
				Dbcfg.uf_Bind_CacheRemoveGroup(andb_Data.dv_View.Table.TableName);

				// �x�s��ƫ�B�z�ƥ�
				if (this.ue_DataDelete_AfterSave != null)
				{
					// �b Delete ���� DataRowView ���s�b�A�ҥH����
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
