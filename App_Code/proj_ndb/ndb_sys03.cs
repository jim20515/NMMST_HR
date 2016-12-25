// *********************************************************************************
// 1. 程式描述：系統權限群組操作資料元件–傳入值「群組代碼」
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// 系統權限群組操作資料元件–傳入值「群組代碼」
/// </summary>
public class ndb_sys03 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_sys03(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
	}

	public ndb_sys03()
	{
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
	}

	#region Component Designer generated code
	///// <summary>
	///// 設計工具所需的變數。
	///// </summary>
	//private System.ComponentModel.Container components = null;

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
		// da_SQL_current
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;
		this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "sys03", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("s03_grp_id", "s03_grp_id"),
                        new System.Data.Common.DataColumnMapping("s03_sys_id", "s03_sys_id"),
                        new System.Data.Common.DataColumnMapping("s03_func_id", "s03_func_id")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [sys03] WHERE (([s03_grp_id] = ?) AND ([s03_sys_id] = ?) AND ([s03_fu" +
			"nc_id] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_s03_grp_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s03_grp_id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_s03_sys_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s03_sys_id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_s03_func_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s03_func_id", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [sys03] ([s03_grp_id], [s03_sys_id], [s03_func_id]) VALUES (?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("s03_grp_id", System.Data.OleDb.OleDbType.Char, 0, "s03_grp_id"),
            new System.Data.OleDb.OleDbParameter("s03_sys_id", System.Data.OleDb.OleDbType.Char, 0, "s03_sys_id"),
            new System.Data.OleDb.OleDbParameter("s03_func_id", System.Data.OleDb.OleDbType.Char, 0, "s03_func_id")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT         s03_grp_id, s03_sys_id, s03_func_id\r\nFROM             sys03\r\nWHERE" +
			"         (s03_grp_id = ?)";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		this.oleDbSelectCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("s03_grp_id", System.Data.OleDb.OleDbType.Char, 10, "s03_grp_id")});
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [sys03] SET [s03_grp_id] = ?, [s03_sys_id] = ?, [s03_func_id] = ? WHERE ((" +
			"[s03_grp_id] = ?) AND ([s03_sys_id] = ?) AND ([s03_func_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("s03_grp_id", System.Data.OleDb.OleDbType.Char, 0, "s03_grp_id"),
            new System.Data.OleDb.OleDbParameter("s03_sys_id", System.Data.OleDb.OleDbType.Char, 0, "s03_sys_id"),
            new System.Data.OleDb.OleDbParameter("s03_func_id", System.Data.OleDb.OleDbType.Char, 0, "s03_func_id"),
            new System.Data.OleDb.OleDbParameter("Original_s03_grp_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s03_grp_id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_s03_sys_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s03_sys_id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_s03_func_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s03_func_id", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_sys03();
		this.uf_Initialize();
	}
}
