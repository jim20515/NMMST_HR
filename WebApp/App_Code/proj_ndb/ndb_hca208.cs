// *********************************************************************************
// 1. 程式描述：hca208資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hca208資料元件–無傳入值
/// </summary>
public class ndb_hca208 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hca208(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hca208()
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
			
                                           new System.Data.Common.DataTableMapping("Table", "hca208", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hca208_id", "hca208_id"),
                                           new System.Data.Common.DataColumnMapping("hca208_name", "hca208_name"),
                                           new System.Data.Common.DataColumnMapping("hca208_stop", "hca208_stop"),
                                           new System.Data.Common.DataColumnMapping("hca208_aid", "hca208_aid"),
                                           new System.Data.Common.DataColumnMapping("hca208_adt", "hca208_adt"),
                                           new System.Data.Common.DataColumnMapping("hca208_uid", "hca208_uid"),
                                           new System.Data.Common.DataColumnMapping("hca208_udt", "hca208_udt")
                                           })
            });
                                           
		// 
		// 刪除命令
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hca208] WHERE (([hca208_id] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hca208_id", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(5)), ((byte)(0)), "hca208_id", System.Data.DataRowVersion.Original, null)
		});


		// 
		// 新增區
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hca208] ([hca208_id],[hca208_name],[hca208_stop],[hca208_aid],[hca208_adt],[hca208_uid],[hca208_udt]) VALUES (?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hca208_id", System.Data.OleDb.OleDbType.SmallInt, 0, "hca208_id"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_name", System.Data.OleDb.OleDbType.VarChar, 0, "hca208_name"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_stop", System.Data.OleDb.OleDbType.Char, 0, "hca208_stop"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hca208_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca208_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hca208_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca208_udt")
		});


		// 
		// 查詢區
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hca208] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// 更新區
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hca208] SET  [hca208_id] = ?, [hca208_name] = ?, [hca208_stop] = ?, [hca208_aid] = ?, [hca208_adt] = ?, [hca208_uid] = ?, [hca208_udt] = ?  WHERE (([hca208_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hca208_id", System.Data.OleDb.OleDbType.SmallInt, 0, "hca208_id"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_name", System.Data.OleDb.OleDbType.VarChar, 0, "hca208_name"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_stop", System.Data.OleDb.OleDbType.Char, 0, "hca208_stop"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hca208_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca208_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hca208_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hca208_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca208_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hca208_id", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(5)), ((byte)(0)), "hca208_id", System.Data.DataRowVersion.Original, null)                                                });

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
		this.ds_Data = new d_hca208();
		this.uf_Initialize();
	}
}
