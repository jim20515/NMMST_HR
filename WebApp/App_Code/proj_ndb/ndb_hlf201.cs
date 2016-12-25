// *********************************************************************************
// 1. 程式描述：hlf201資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hlf201資料元件–無傳入值
/// </summary>
public class ndb_hlf201 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hlf201(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hlf201()
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
			
                                           new System.Data.Common.DataTableMapping("Table", "hlf201", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hlf201_lid", "hlf201_lid"),
                                           new System.Data.Common.DataColumnMapping("hlf201_vid", "hlf201_vid"),
                                           new System.Data.Common.DataColumnMapping("hlf201_sdatetime", "hlf201_sdatetime"),
                                           new System.Data.Common.DataColumnMapping("hlf201_type", "hlf201_type"),
                                           new System.Data.Common.DataColumnMapping("hlf201_ps", "hlf201_ps"),
                                           new System.Data.Common.DataColumnMapping("hlf201_cancel", "hlf201_cancel"),
                                           new System.Data.Common.DataColumnMapping("hlf201_checkflag", "hlf201_checkflag"),
                                           new System.Data.Common.DataColumnMapping("hlf201_ip", "hlf201_ip"),
                                           new System.Data.Common.DataColumnMapping("hlf201_cway", "hlf201_cway"),
                                           new System.Data.Common.DataColumnMapping("hlf201_aid", "hlf201_aid"),
                                           new System.Data.Common.DataColumnMapping("hlf201_adt", "hlf201_adt"),
                                           new System.Data.Common.DataColumnMapping("hlf201_uid", "hlf201_uid"),
                                           new System.Data.Common.DataColumnMapping("hlf201_udt", "hlf201_udt")
                                           })
            });
                                           
		// 
		// 刪除命令
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hlf201] WHERE (([hlf201_lid] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hlf201_lid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hlf201_lid", System.Data.DataRowVersion.Original, null)
		});


		// 
		// 新增區
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hlf201] ([hlf201_lid],[hlf201_vid],[hlf201_sdatetime],[hlf201_type],[hlf201_ps],[hlf201_cancel],[hlf201_checkflag],[hlf201_ip],[hlf201_cway],[hlf201_aid],[hlf201_adt],[hlf201_uid],[hlf201_udt]) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hlf201_lid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_lid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_vid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_vid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_sdatetime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hlf201_sdatetime"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_type", System.Data.OleDb.OleDbType.Char, 0, "hlf201_type"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_ps", System.Data.OleDb.OleDbType.LongVarChar, 0, "hlf201_ps"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_cancel", System.Data.OleDb.OleDbType.Char, 0, "hlf201_cancel"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_checkflag", System.Data.OleDb.OleDbType.Char, 0, "hlf201_checkflag"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_ip", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_ip"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_cway", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_cway"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hlf201_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hlf201_udt")
		});


		// 
		// 查詢區
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hlf201] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// 更新區
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hlf201] SET  [hlf201_lid] = ?, [hlf201_vid] = ?, [hlf201_sdatetime] = ?, [hlf201_type] = ?, [hlf201_ps] = ?, [hlf201_cancel] = ?, [hlf201_checkflag] = ?, [hlf201_ip] = ?, [hlf201_cway] = ?, [hlf201_aid] = ?, [hlf201_adt] = ?, [hlf201_uid] = ?, [hlf201_udt] = ?  WHERE (([hlf201_lid] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hlf201_lid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_lid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_vid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_vid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_sdatetime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hlf201_sdatetime"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_type", System.Data.OleDb.OleDbType.Char, 0, "hlf201_type"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_ps", System.Data.OleDb.OleDbType.LongVarChar, 0, "hlf201_ps"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_cancel", System.Data.OleDb.OleDbType.Char, 0, "hlf201_cancel"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_checkflag", System.Data.OleDb.OleDbType.Char, 0, "hlf201_checkflag"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_ip", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_ip"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_cway", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_cway"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hlf201_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf201_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf201_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hlf201_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hlf201_lid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hlf201_lid", System.Data.DataRowVersion.Original, null)                                                });

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
		this.ds_Data = new d_hlf201();
		this.uf_Initialize();
	}
}
