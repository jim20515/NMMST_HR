// *********************************************************************************
// 1. 程式描述：hlf303資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hlf303資料元件–無傳入值
/// </summary>
public class ndb_hlf303 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hlf303(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hlf303()
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
			
                                           new System.Data.Common.DataTableMapping("Table", "hlf303", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hlf303_trainid", "hlf303_trainid"),
                                           new System.Data.Common.DataColumnMapping("hlf303_vid", "hlf303_vid"),
                                           new System.Data.Common.DataColumnMapping("hlf303_appid", "hlf303_appid"),
                                           new System.Data.Common.DataColumnMapping("hlf303_ps", "hlf303_ps"),
                                           new System.Data.Common.DataColumnMapping("hlf303_aid", "hlf303_aid"),
                                           new System.Data.Common.DataColumnMapping("hlf303_cdt", "hlf303_cdt"),
                                           new System.Data.Common.DataColumnMapping("hlf303_uid", "hlf303_uid"),
                                           new System.Data.Common.DataColumnMapping("hlf303_udt", "hlf303_udt")
                                           })
            });
                                           
		// 
		// 刪除命令
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hlf303] WHERE (([hlf303_trainid] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hlf303_trainid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hlf303_trainid", System.Data.DataRowVersion.Original, null)
		});


		// 
		// 新增區
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hlf303] ([hlf303_trainid],[hlf303_vid],[hlf303_appid],[hlf303_ps],[hlf303_aid],[hlf303_cdt],[hlf303_uid],[hlf303_udt]) VALUES (?,?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hlf303_trainid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf303_trainid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_vid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf303_vid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_appid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf303_appid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_ps", System.Data.OleDb.OleDbType.LongVarChar, 0, "hlf303_ps"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf303_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_cdt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hlf303_cdt"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf303_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hlf303_udt")
		});


		// 
		// 查詢區
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hlf303] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// 更新區
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hlf303] SET  [hlf303_trainid] = ?, [hlf303_vid] = ?, [hlf303_appid] = ?, [hlf303_ps] = ?, [hlf303_aid] = ?, [hlf303_cdt] = ?, [hlf303_uid] = ?, [hlf303_udt] = ?  WHERE (([hlf303_trainid] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hlf303_trainid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf303_trainid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_vid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf303_vid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_appid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf303_appid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_ps", System.Data.OleDb.OleDbType.LongVarChar, 0, "hlf303_ps"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf303_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_cdt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hlf303_cdt"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hlf303_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hlf303_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hlf303_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hlf303_trainid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hlf303_trainid", System.Data.DataRowVersion.Original, null)                                                });

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
		this.ds_Data = new d_hlf303();
		this.uf_Initialize();
	}
}
