// *********************************************************************************
// 1. 程式描述：hle201資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hle201資料元件–無傳入值
/// </summary>
public class ndb_hle201 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hle201(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hle201()
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
			
                                           new System.Data.Common.DataTableMapping("Table", "hle201", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hle201_lid", "hle201_lid"),
                                           new System.Data.Common.DataColumnMapping("hle201_vid", "hle201_vid"),
                                           new System.Data.Common.DataColumnMapping("hle201_sdatetime", "hle201_sdatetime"),
                                           new System.Data.Common.DataColumnMapping("hle201_type", "hle201_type"),
                                           new System.Data.Common.DataColumnMapping("hle201_ps", "hle201_ps"),
                                           new System.Data.Common.DataColumnMapping("hle201_cancel", "hle201_cancel"),
                                           new System.Data.Common.DataColumnMapping("hle201_checkflag", "hle201_checkflag"),
                                           new System.Data.Common.DataColumnMapping("hle201_ip", "hle201_ip"),
                                           new System.Data.Common.DataColumnMapping("hle201_cway", "hle201_cway"),
                                           new System.Data.Common.DataColumnMapping("hle201_aid", "hle201_aid"),
                                           new System.Data.Common.DataColumnMapping("hle201_adt", "hle201_adt"),
                                           new System.Data.Common.DataColumnMapping("hle201_uid", "hle201_uid"),
                                           new System.Data.Common.DataColumnMapping("hle201_udt", "hle201_udt")
                                           })
            });
                                           
		// 
		// 刪除命令
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hle201] WHERE (([hle201_lid] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hle201_lid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hle201_lid", System.Data.DataRowVersion.Original, null)
		});


		// 
		// 新增區
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hle201] ([hle201_lid],[hle201_vid],[hle201_sdatetime],[hle201_type],[hle201_ps],[hle201_cancel],[hle201_checkflag],[hle201_ip],[hle201_cway],[hle201_aid],[hle201_adt],[hle201_uid],[hle201_udt]) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hle201_lid", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_lid"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_vid", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_vid"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_sdatetime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hle201_sdatetime"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_type", System.Data.OleDb.OleDbType.Char, 0, "hle201_type"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_ps", System.Data.OleDb.OleDbType.LongVarChar, 0, "hle201_ps"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_cancel", System.Data.OleDb.OleDbType.Char, 0, "hle201_cancel"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_checkflag", System.Data.OleDb.OleDbType.Char, 0, "hle201_checkflag"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_ip", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_ip"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_cway", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_cway"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hle201_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hle201_udt")
		});


		// 
		// 查詢區
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hle201] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// 更新區
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hle201] SET  [hle201_lid] = ?, [hle201_vid] = ?, [hle201_sdatetime] = ?, [hle201_type] = ?, [hle201_ps] = ?, [hle201_cancel] = ?, [hle201_checkflag] = ?, [hle201_ip] = ?, [hle201_cway] = ?, [hle201_aid] = ?, [hle201_adt] = ?, [hle201_uid] = ?, [hle201_udt] = ?  WHERE (([hle201_lid] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hle201_lid", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_lid"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_vid", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_vid"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_sdatetime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hle201_sdatetime"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_type", System.Data.OleDb.OleDbType.Char, 0, "hle201_type"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_ps", System.Data.OleDb.OleDbType.LongVarChar, 0, "hle201_ps"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_cancel", System.Data.OleDb.OleDbType.Char, 0, "hle201_cancel"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_checkflag", System.Data.OleDb.OleDbType.Char, 0, "hle201_checkflag"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_ip", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_ip"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_cway", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_cway"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hle201_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hle201_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hle201_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hle201_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hle201_lid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hle201_lid", System.Data.DataRowVersion.Original, null)                                                });

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
		this.ds_Data = new d_hle201();
		this.uf_Initialize();
	}
}
