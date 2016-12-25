// *********************************************************************************
// 1. 程式描述：hca213資料元件–無傳入值
// 2. 撰寫人員：rong
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// ndb_hca213 的摘要描述
/// </summary>

public class ndb_hca213: WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hca213(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hca213()
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
		this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
		this.oleDbSelectCommand = new System.Data.OleDb.OleDbCommand();
		this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
		this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
		((System.ComponentModel.ISupportInitialize)(this.ds_Data)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.dv_View)).BeginInit();
		// 
		// da_SQL_current
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "hca213", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hca213_id", "hca213_id"),
                        new System.Data.Common.DataColumnMapping("hca213_cname", "hca213_cname"),
                        new System.Data.Common.DataColumnMapping("hca213_sort", "hca213_sort"),
                        new System.Data.Common.DataColumnMapping("hca213_stop", "hca213_stop"),
                        new System.Data.Common.DataColumnMapping("hca213_aid", "hca213_aid"),
                        new System.Data.Common.DataColumnMapping("hca213_adt", "hca213_adt"),
                        new System.Data.Common.DataColumnMapping("hca213_uid", "hca213_uid"),
                        new System.Data.Common.DataColumnMapping("hca213_udt", "hca213_udt")})});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hca213] ([hca213_id], [hca213_cname], [hca213_sort], [hca213_stop], " +
			"[hca213_aid], [hca213_adt], [hca213_uid], [hca213_udt]) VALUES (?, ?, ?, ?, ?, ?" +
			", ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hca213_id", System.Data.OleDb.OleDbType.WChar, 0, "hca213_id"),
            new System.Data.OleDb.OleDbParameter("hca213_cname", System.Data.OleDb.OleDbType.VarWChar, 0, "hca213_cname"),
            new System.Data.OleDb.OleDbParameter("hca213_sort", System.Data.OleDb.OleDbType.SmallInt, 0, "hca213_sort"),
            new System.Data.OleDb.OleDbParameter("hca213_stop", System.Data.OleDb.OleDbType.WChar, 0, "hca213_stop"),
            new System.Data.OleDb.OleDbParameter("hca213_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca213_aid"),
            new System.Data.OleDb.OleDbParameter("hca213_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca213_adt"),
            new System.Data.OleDb.OleDbParameter("hca213_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca213_uid"),
            new System.Data.OleDb.OleDbParameter("hca213_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca213_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT hca213_id, hca213_cname, hca213_sort, hca213_stop, hca213_aid, hca213_adt," +
			" hca213_uid, hca213_udt FROM hca213 WHERE (1 = 1)";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hca213] WHERE (([hca213_id] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hca213_id", System.Data.OleDb.OleDbType.WChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hca213_id", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hca213] SET [hca213_id] = ?, [hca213_cname] = ?, [hca213_sort] = ?, [hca21" +
			"3_stop] = ?, [hca213_aid] = ?, [hca213_adt] = ?, [hca213_uid] = ?, [hca213_udt] " +
			"= ? WHERE (([hca213_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hca213_id", System.Data.OleDb.OleDbType.WChar, 0, "hca213_id"),
            new System.Data.OleDb.OleDbParameter("hca213_cname", System.Data.OleDb.OleDbType.WChar, 0, "hca213_cname"),
            new System.Data.OleDb.OleDbParameter("hca213_sort", System.Data.OleDb.OleDbType.SmallInt, 0, "hca213_sort"),
            new System.Data.OleDb.OleDbParameter("hca213_stop", System.Data.OleDb.OleDbType.WChar, 0, "hca213_stop"),
            new System.Data.OleDb.OleDbParameter("hca213_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca213_aid"),
            new System.Data.OleDb.OleDbParameter("hca213_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca213_adt"),
            new System.Data.OleDb.OleDbParameter("hca213_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca213_uid"),
            new System.Data.OleDb.OleDbParameter("hca213_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca213_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hca213_id", System.Data.OleDb.OleDbType.WChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hca213_id", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_hca213();
		this.uf_Initialize();
	}
}
