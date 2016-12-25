// *********************************************************************************
// 1. 程式描述：hmd100b資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hmd100b資料元件–無傳入值
/// </summary>
public class ndb_hmd100b : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hmd100b(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hmd100b()
	{
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	#region Component Designer generated code
	
	/// <summary>
	/// 此為設計工具支援所必需的方法 - 請勿使用程式碼編輯器修改
	/// 這個方法的內容。
	/// </summary>
	private void InitializeComponent()
	{
		this.da_SQL_current = new System.Data.OleDb.OleDbDataAdapter();
		this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
		this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
		this.oleDbSelectCommand = new System.Data.OleDb.OleDbCommand();
		this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
		
		((System.ComponentModel.ISupportInitialize)(this.ds_Data)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.dv_View)).BeginInit();

		// 
		// 容器
		// 
		this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
			
                                           new System.Data.Common.DataTableMapping("Table", "hmd100b", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hmd100b_posid", "hmd100b_posid"),
                                           new System.Data.Common.DataColumnMapping("hmd100b_belone", "hmd100b_belone"),
                                           new System.Data.Common.DataColumnMapping("hmd100b_vid", "hmd100b_vid"),
                                           new System.Data.Common.DataColumnMapping("hmd100b_cname", "hmd100b_cname"),
                                           new System.Data.Common.DataColumnMapping("hmd100b_active", "hmd100b_active"),
                                           new System.Data.Common.DataColumnMapping("hmd100b_sdt", "hmd100b_sdt"),
                                           new System.Data.Common.DataColumnMapping("hmd100b_tdt", "hmd100b_tdt"),
                                           new System.Data.Common.DataColumnMapping("hmd100b_aid", "hmd100b_aid"),
                                           new System.Data.Common.DataColumnMapping("hmd100b_adt", "hmd100b_adt"),
                                           new System.Data.Common.DataColumnMapping("hmd100b_uid", "hmd100b_uid"),
                                           new System.Data.Common.DataColumnMapping("hmd100b_udt", "hmd100b_udt")
                                           })
            });
                                           
		// 
		// 刪除命令
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmd100b] WHERE (([hmd100b_posid] = ?))  AND (([hmd100b_vid] = ?))  AND (([hmd100b_sdt] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hmd100b_posid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hmd100b_posid", System.Data.DataRowVersion.Original, null),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmd100b_vid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(12)), ((byte)(0)), "hmd100b_vid", System.Data.DataRowVersion.Original, null),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmd100b_sdt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((byte)(23)), ((byte)(3)), "hmd100b_sdt", System.Data.DataRowVersion.Original, null)

		});


		// 
		// 新增區
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmd100b] ([hmd100b_posid],[hmd100b_belone],[hmd100b_vid],[hmd100b_cname],[hmd100b_active],[hmd100b_sdt],[hmd100b_tdt],[hmd100b_aid],[hmd100b_adt],[hmd100b_uid],[hmd100b_udt]) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hmd100b_posid", System.Data.OleDb.OleDbType.VarChar, 0, "hmd100b_posid"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_belone", System.Data.OleDb.OleDbType.Char, 0, "hmd100b_belone"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_vid", System.Data.OleDb.OleDbType.VarChar, 0, "hmd100b_vid"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_cname", System.Data.OleDb.OleDbType.VarChar, 0, "hmd100b_cname"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_active", System.Data.OleDb.OleDbType.Char, 0, "hmd100b_active"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_sdt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd100b_sdt"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_tdt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd100b_tdt"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hmd100b_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd100b_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmd100b_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd100b_udt")
		});


		// 
		// 查詢區
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hmd100b] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// 更新區
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmd100b] SET  [hmd100b_posid] = ?, [hmd100b_belone] = ?, [hmd100b_vid] = ?, [hmd100b_cname] = ?, [hmd100b_active] = ?, [hmd100b_sdt] = ?, [hmd100b_tdt] = ?, [hmd100b_aid] = ?, [hmd100b_adt] = ?, [hmd100b_uid] = ?, [hmd100b_udt] = ?  WHERE (([hmd100b_posid] = ?)) AND (([hmd100b_vid] = ?))  AND (([hmd100b_sdt] = ?)) ";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hmd100b_posid", System.Data.OleDb.OleDbType.VarChar, 0, "hmd100b_posid"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_belone", System.Data.OleDb.OleDbType.Char, 0, "hmd100b_belone"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_vid", System.Data.OleDb.OleDbType.VarChar, 0, "hmd100b_vid"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_cname", System.Data.OleDb.OleDbType.VarChar, 0, "hmd100b_cname"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_active", System.Data.OleDb.OleDbType.Char, 0, "hmd100b_active"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_sdt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd100b_sdt"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_tdt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd100b_tdt"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hmd100b_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd100b_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmd100b_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hmd100b_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd100b_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmd100b_posid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hmd100b_posid", System.Data.DataRowVersion.Original, null),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmd100b_vid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(12)), ((byte)(0)), "hmd100b_vid", System.Data.DataRowVersion.Original, null),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmd100b_sdt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((byte)(23)), ((byte)(3)), "hmd100b_sdt", System.Data.DataRowVersion.Original, null)
                                                });

		((System.ComponentModel.ISupportInitialize)(this.ds_Data)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.dv_View)).EndInit();


	}
	#endregion

	// =========================================================================
	/// <summary>
	/// 函式描述：自訂初始化函式（覆蓋上層）
	/// </summary>
	protected override void uf_InitializeComponent()
	{
		// 先將 DataSet 宣告為指定的結構再初始化
		this.ds_Data = new d_hmd100b();
		this.uf_Initialize();
	}
}
