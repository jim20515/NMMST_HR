// *********************************************************************************
// 1. 程式描述：人員類別資料元件–無傳入值
// 2. 撰寫人員：Jing
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// 人員類別資料元件–無傳入值
/// </summary>
public class ndb_hmh101 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_hmh101(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
	}

	public ndb_hmh101()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ndb_hmh101));
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
            new System.Data.Common.DataTableMapping("Table", "hmh101", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hmh101_epid", "hmh101_epid"),
                        new System.Data.Common.DataColumnMapping("hmh101_epyear", "hmh101_epyear"),
                        new System.Data.Common.DataColumnMapping("hmh101_epno", "hmh101_epno"),
                        new System.Data.Common.DataColumnMapping("hmh101_eptitle", "hmh101_eptitle"),
                        new System.Data.Common.DataColumnMapping("hmh101_epurl", "hmh101_epurl"),
                        new System.Data.Common.DataColumnMapping("hmh101_cdt", "hmh101_cdt"),
                        new System.Data.Common.DataColumnMapping("hmh101_uid", "hmh101_uid"),
                        new System.Data.Common.DataColumnMapping("hmh101_udt", "hmh101_udt")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmh101] WHERE (([hmh101_epid] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hmh101_epid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmh101_epid", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmh101] ([hmh101_epid], [hmh101_epyear], [hmh101_epno], [hmh101_epti" +
			"tle], [hmh101_epurl], [hmh101_cdt], [hmh101_uid], [hmh101_udt]) VALUES (?, ?, ?," +
			" ?, ?, ?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmh101_epid", System.Data.OleDb.OleDbType.VarChar, 0, "hmh101_epid"),
            new System.Data.OleDb.OleDbParameter("hmh101_epyear", System.Data.OleDb.OleDbType.Char, 0, "hmh101_epyear"),
            new System.Data.OleDb.OleDbParameter("hmh101_epno", System.Data.OleDb.OleDbType.Char, 0, "hmh101_epno"),
            new System.Data.OleDb.OleDbParameter("hmh101_eptitle", System.Data.OleDb.OleDbType.VarChar, 0, "hmh101_eptitle"),
            new System.Data.OleDb.OleDbParameter("hmh101_epurl", System.Data.OleDb.OleDbType.VarChar, 0, "hmh101_epurl"),
            new System.Data.OleDb.OleDbParameter("hmh101_cdt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmh101_cdt"),
            new System.Data.OleDb.OleDbParameter("hmh101_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmh101_uid"),
            new System.Data.OleDb.OleDbParameter("hmh101_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmh101_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT         hmh101_epid, hmh101_epyear, hmh101_epno, hmh101_eptitle, hmh101_ep" +
			"url, \r\n                          hmh101_cdt, hmh101_uid, hmh101_udt\r\nFROM       " +
			"      hmh101\r\nWHERE         (1 = 1)";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmh101] SET [hmh101_epid] = ?, [hmh101_epyear] = ?, [hmh101_epno] = ?, [hmh101_epti" + 
			"tle] = ?, [hmh101_epurl] = ?, [hmh101_cdt] = ?, [hmh101_uid] = ?, [hmh101_udt] = ? WHERE (([hmh101_epid] = ?))" ;
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmh101_epid", System.Data.OleDb.OleDbType.VarChar, 0, "hmh101_epid"),
            new System.Data.OleDb.OleDbParameter("hmh101_epyear", System.Data.OleDb.OleDbType.Char, 0, "hmh101_epyear"),
            new System.Data.OleDb.OleDbParameter("hmh101_epno", System.Data.OleDb.OleDbType.Char, 0, "hmh101_epno"),
            new System.Data.OleDb.OleDbParameter("hmh101_eptitle", System.Data.OleDb.OleDbType.VarChar, 0, "hmh101_eptitle"),
            new System.Data.OleDb.OleDbParameter("hmh101_epurl", System.Data.OleDb.OleDbType.VarChar, 0, "hmh101_epurl"),
            new System.Data.OleDb.OleDbParameter("hmh101_cdt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmh101_cdt"),
            new System.Data.OleDb.OleDbParameter("hmh101_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmh101_uid"),
            new System.Data.OleDb.OleDbParameter("hmh101_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmh101_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hmh101_epid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmh101_epid", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_hmh101();
		this.uf_Initialize();
	}
}
