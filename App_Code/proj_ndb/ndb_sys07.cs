// *********************************************************************************
// 1. 程式描述：系統公告資料元件 - 無傳入值
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// 系統公告資料元件 - 無傳入值
/// </summary>
public class ndb_sys07 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_sys07(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
	}

	public ndb_sys07()
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
            new System.Data.Common.DataTableMapping("Table", "sys07", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("s07_no", "s07_no"),
                        new System.Data.Common.DataColumnMapping("s07_unit", "s07_unit"),
                        new System.Data.Common.DataColumnMapping("s07_man", "s07_man"),
                        new System.Data.Common.DataColumnMapping("s07_tounit", "s07_tounit"),
                        new System.Data.Common.DataColumnMapping("s07_pdate", "s07_pdate"),
                        new System.Data.Common.DataColumnMapping("s07_edate", "s07_edate"),
                        new System.Data.Common.DataColumnMapping("s07_title", "s07_title"),
                        new System.Data.Common.DataColumnMapping("s07_content", "s07_content"),
                        new System.Data.Common.DataColumnMapping("s07_url", "s07_url"),
                        new System.Data.Common.DataColumnMapping("s07_stop", "s07_stop"),
                        new System.Data.Common.DataColumnMapping("s07_sort", "s07_sort"),
                        new System.Data.Common.DataColumnMapping("s07_uid", "s07_uid"),
                        new System.Data.Common.DataColumnMapping("s07_udt", "s07_udt")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [sys07] WHERE (([s07_no] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_s07_no", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s07_no", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [sys07] ([s07_no], [s07_unit], [s07_man], [s07_tounit], [s07_pdate], [s07_edate], [s07_title], [s07_content], [s07_url], [s07_stop], [s07_sort], [s07_uid], [s07_udt]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("s07_no", System.Data.OleDb.OleDbType.Char, 0, "s07_no"),
            new System.Data.OleDb.OleDbParameter("s07_unit", System.Data.OleDb.OleDbType.VarChar, 0, "s07_unit"),
            new System.Data.OleDb.OleDbParameter("s07_man", System.Data.OleDb.OleDbType.VarChar, 0, "s07_man"),
            new System.Data.OleDb.OleDbParameter("s07_tounit", System.Data.OleDb.OleDbType.VarChar, 0, "s07_tounit"),
            new System.Data.OleDb.OleDbParameter("s07_pdate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "s07_pdate"),
            new System.Data.OleDb.OleDbParameter("s07_edate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "s07_edate"),
            new System.Data.OleDb.OleDbParameter("s07_title", System.Data.OleDb.OleDbType.VarChar, 0, "s07_title"),
            new System.Data.OleDb.OleDbParameter("s07_content", System.Data.OleDb.OleDbType.LongVarChar, 0, "s07_content"),
            new System.Data.OleDb.OleDbParameter("s07_url", System.Data.OleDb.OleDbType.VarChar, 0, "s07_url"),
            new System.Data.OleDb.OleDbParameter("s07_stop", System.Data.OleDb.OleDbType.Char, 0, "s07_stop"),
            new System.Data.OleDb.OleDbParameter("s07_sort", System.Data.OleDb.OleDbType.Integer, 0, "s07_sort"),
            new System.Data.OleDb.OleDbParameter("s07_uid", System.Data.OleDb.OleDbType.VarChar, 0, "s07_uid"),
            new System.Data.OleDb.OleDbParameter("s07_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "s07_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT s07_no, s07_unit, s07_man, s07_tounit, s07_pdate, s07_edate, s07_title, s07_content, s07_url, s07_stop, s07_sort, s07_uid, s07_udt FROM sys07 WHERE (1 = 1)";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [sys07] SET [s07_no] = ?, [s07_unit] = ?, [s07_man] = ?, [s07_tounit] = ?, [s07_pdate] = ?, [s07_edate] = ?, [s07_title] = ?, [s07_content] = ?, [s07_url] = ?, [s07_stop] = ?, [s07_sort] = ?, [s07_uid] = ?, [s07_udt] = ? WHERE (([s07_no] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("s07_no", System.Data.OleDb.OleDbType.Char, 0, "s07_no"),
            new System.Data.OleDb.OleDbParameter("s07_unit", System.Data.OleDb.OleDbType.VarChar, 0, "s07_unit"),
            new System.Data.OleDb.OleDbParameter("s07_man", System.Data.OleDb.OleDbType.VarChar, 0, "s07_man"),
            new System.Data.OleDb.OleDbParameter("s07_tounit", System.Data.OleDb.OleDbType.VarChar, 0, "s07_tounit"),
            new System.Data.OleDb.OleDbParameter("s07_pdate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "s07_pdate"),
            new System.Data.OleDb.OleDbParameter("s07_edate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "s07_edate"),
            new System.Data.OleDb.OleDbParameter("s07_title", System.Data.OleDb.OleDbType.VarChar, 0, "s07_title"),
            new System.Data.OleDb.OleDbParameter("s07_content", System.Data.OleDb.OleDbType.LongVarChar, 0, "s07_content"),
            new System.Data.OleDb.OleDbParameter("s07_url", System.Data.OleDb.OleDbType.VarChar, 0, "s07_url"),
            new System.Data.OleDb.OleDbParameter("s07_stop", System.Data.OleDb.OleDbType.Char, 0, "s07_stop"),
            new System.Data.OleDb.OleDbParameter("s07_sort", System.Data.OleDb.OleDbType.Integer, 0, "s07_sort"),
            new System.Data.OleDb.OleDbParameter("s07_uid", System.Data.OleDb.OleDbType.VarChar, 0, "s07_uid"),
            new System.Data.OleDb.OleDbParameter("s07_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "s07_udt"),
            new System.Data.OleDb.OleDbParameter("Original_s07_no", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "s07_no", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_sys07();
		this.uf_Initialize();
	}
}
