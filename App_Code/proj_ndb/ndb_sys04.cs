// *********************************************************************************
// 1. 程式描述：系統操作資料元件–無傳入值
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// 系統操作資料元件–無傳入值
/// </summary>
public class ndb_sys04 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_sys04(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
	}

	public ndb_sys04()
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
            new System.Data.Common.DataTableMapping("Table", "sys04", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("s04_sys_id", "s04_sys_id"),
                        new System.Data.Common.DataColumnMapping("s04_func_id", "s04_func_id"),
                        new System.Data.Common.DataColumnMapping("s04_func_text", "s04_func_text"),
                        new System.Data.Common.DataColumnMapping("s04_func_url", "s04_func_url"),
                        new System.Data.Common.DataColumnMapping("s04_func_parent", "s04_func_parent"),
                        new System.Data.Common.DataColumnMapping("s04_func_flag", "s04_func_flag"),
                        new System.Data.Common.DataColumnMapping("s04_func_seq", "s04_func_seq"),
                        new System.Data.Common.DataColumnMapping("s04_func_item", "s04_func_item")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [sys04] WHERE (([s04_sys_id] = ?) AND ([s04_func_id] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_s04_sys_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s04_sys_id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_s04_func_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s04_func_id", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [sys04] ([s04_sys_id], [s04_func_id], [s04_func_text], [s04_func_url]" +
			", [s04_func_parent], [s04_func_flag], [s04_func_seq], [s04_func_item]) VALUES (?" +
			", ?, ?, ?, ?, ?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("s04_sys_id", System.Data.OleDb.OleDbType.Char, 0, "s04_sys_id"),
            new System.Data.OleDb.OleDbParameter("s04_func_id", System.Data.OleDb.OleDbType.Char, 0, "s04_func_id"),
            new System.Data.OleDb.OleDbParameter("s04_func_text", System.Data.OleDb.OleDbType.VarChar, 0, "s04_func_text"),
            new System.Data.OleDb.OleDbParameter("s04_func_url", System.Data.OleDb.OleDbType.VarChar, 0, "s04_func_url"),
            new System.Data.OleDb.OleDbParameter("s04_func_parent", System.Data.OleDb.OleDbType.VarChar, 0, "s04_func_parent"),
            new System.Data.OleDb.OleDbParameter("s04_func_flag", System.Data.OleDb.OleDbType.Char, 0, "s04_func_flag"),
            new System.Data.OleDb.OleDbParameter("s04_func_seq", System.Data.OleDb.OleDbType.SmallInt, 0, "s04_func_seq"),
            new System.Data.OleDb.OleDbParameter("s04_func_item", System.Data.OleDb.OleDbType.VarChar, 0, "s04_func_item")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = @"SELECT         s04_sys_id, s04_func_id, s04_func_text, s04_func_url, s04_func_parent, 
                          s04_func_flag, s04_func_seq, s04_func_item
FROM             sys04
WHERE         (1 = 1)";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [sys04] SET [s04_sys_id] = ?, [s04_func_id] = ?, [s04_func_text] = ?, [s04_func_url] = ?, [s04_func_parent] = ?, [s04_func_flag] = ?, [s04_func_seq] = ?, [s04_func_item] = ? WHERE (([s04_sys_id] = ?) AND ([s04_func_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("s04_sys_id", System.Data.OleDb.OleDbType.Char, 0, "s04_sys_id"),
            new System.Data.OleDb.OleDbParameter("s04_func_id", System.Data.OleDb.OleDbType.Char, 0, "s04_func_id"),
            new System.Data.OleDb.OleDbParameter("s04_func_text", System.Data.OleDb.OleDbType.VarChar, 0, "s04_func_text"),
            new System.Data.OleDb.OleDbParameter("s04_func_url", System.Data.OleDb.OleDbType.VarChar, 0, "s04_func_url"),
            new System.Data.OleDb.OleDbParameter("s04_func_parent", System.Data.OleDb.OleDbType.VarChar, 0, "s04_func_parent"),
            new System.Data.OleDb.OleDbParameter("s04_func_flag", System.Data.OleDb.OleDbType.Char, 0, "s04_func_flag"),
            new System.Data.OleDb.OleDbParameter("s04_func_seq", System.Data.OleDb.OleDbType.SmallInt, 0, "s04_func_seq"),
            new System.Data.OleDb.OleDbParameter("s04_func_item", System.Data.OleDb.OleDbType.VarChar, 0, "s04_func_item"),
            new System.Data.OleDb.OleDbParameter("Original_s04_sys_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s04_sys_id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_s04_func_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s04_func_id", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_sys04();
		this.uf_Initialize();
	}
}
