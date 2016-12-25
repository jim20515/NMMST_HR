// *********************************************************************************
// 1. 程式描述：hca210資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hca210資料元件–無傳入值
/// </summary>
public class ndb_hca210 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hca210(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hca210()
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
			
                                           new System.Data.Common.DataTableMapping("Table", "hca210", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hca210_id", "hca210_id"),
                                           new System.Data.Common.DataColumnMapping("hca210_name", "hca210_name"),
                                           new System.Data.Common.DataColumnMapping("hca210_cost", "hca210_cost"),
                                           new System.Data.Common.DataColumnMapping("hca210_stop", "hca210_stop"),
                                           new System.Data.Common.DataColumnMapping("hca210_aid", "hca210_aid"),
                                           new System.Data.Common.DataColumnMapping("hca210_adt", "hca210_adt"),
                                           new System.Data.Common.DataColumnMapping("hca210_uid", "hca210_uid"),
                                           new System.Data.Common.DataColumnMapping("hca210_udt", "hca210_udt")
                                           })
            });
                                           
		// 
		// 刪除命令
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hca210] WHERE (([hca210_id] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hca210_id", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(5)), ((byte)(0)), "hca210_id", System.Data.DataRowVersion.Original, null)
		});


		// 
		// 新增區
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hca210] ([hca210_id],[hca210_name],[hca210_cost],[hca210_stop],[hca210_aid],[hca210_adt],[hca210_uid],[hca210_udt]) VALUES (?,?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hca210_id", System.Data.OleDb.OleDbType.SmallInt, 0, "hca210_id"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_name", System.Data.OleDb.OleDbType.VarChar, 0, "hca210_name"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_cost", System.Data.OleDb.OleDbType.Double, 0, "hca210_cost"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_stop", System.Data.OleDb.OleDbType.Char, 0, "hca210_stop"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hca210_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca210_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hca210_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca210_udt")
		});


		// 
		// 查詢區
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hca210] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// 更新區
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hca210] SET  [hca210_id] = ?, [hca210_name] = ?, [hca210_cost] = ?, [hca210_stop] = ?, [hca210_aid] = ?, [hca210_adt] = ?, [hca210_uid] = ?, [hca210_udt] = ?  WHERE (([hca210_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hca210_id", System.Data.OleDb.OleDbType.SmallInt, 0, "hca210_id"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_name", System.Data.OleDb.OleDbType.VarChar, 0, "hca210_name"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_cost", System.Data.OleDb.OleDbType.Double, 0, "hca210_cost"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_stop", System.Data.OleDb.OleDbType.Char, 0, "hca210_stop"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hca210_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca210_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hca210_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hca210_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca210_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hca210_id", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(5)), ((byte)(0)), "hca210_id", System.Data.DataRowVersion.Original, null)                                                });

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
		this.ds_Data = new d_hca210();
		this.uf_Initialize();
	}
}
