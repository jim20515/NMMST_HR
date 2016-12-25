// *********************************************************************************
// 1. 程式描述：hca215資料元件–無傳入值
// 2. 撰寫人員：rong
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// ndb_hca215 的摘要描述
/// </summary>
public class ndb_hca215: WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hca215(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hca215()
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
		// da_SQL_current
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;
		this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "hca215", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hca215_id", "hca215_id"),
                        new System.Data.Common.DataColumnMapping("hca215_cname", "hca215_cname"),
                        new System.Data.Common.DataColumnMapping("hca215_sort", "hca215_sort"),
                        new System.Data.Common.DataColumnMapping("hca215_stop", "hca215_stop"),
                        new System.Data.Common.DataColumnMapping("hca215_aid", "hca215_aid"),
                        new System.Data.Common.DataColumnMapping("hca215_adt", "hca215_adt"),
                        new System.Data.Common.DataColumnMapping("hca215_uid", "hca215_uid"),
                        new System.Data.Common.DataColumnMapping("hca215_udt", "hca215_udt")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hca215] WHERE (([hca215_id] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hca215_id", System.Data.OleDb.OleDbType.WChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hca215_id", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hca215] ([hca215_id], [hca215_cname], [hca215_sort], [hca215_stop], " +
			"[hca215_aid], [hca215_adt], [hca215_uid], [hca215_udt]) VALUES (?, ?, ?, ?, ?, ?" +
			", ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hca215_id", System.Data.OleDb.OleDbType.WChar, 0, "hca215_id"),
            new System.Data.OleDb.OleDbParameter("hca215_cname", System.Data.OleDb.OleDbType.VarWChar, 0, "hca215_cname"),
            new System.Data.OleDb.OleDbParameter("hca215_sort", System.Data.OleDb.OleDbType.SmallInt, 0, "hca215_sort"),
            new System.Data.OleDb.OleDbParameter("hca215_stop", System.Data.OleDb.OleDbType.WChar, 0, "hca215_stop"),
            new System.Data.OleDb.OleDbParameter("hca215_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca215_aid"),
            new System.Data.OleDb.OleDbParameter("hca215_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca215_adt"),
            new System.Data.OleDb.OleDbParameter("hca215_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca215_uid"),
            new System.Data.OleDb.OleDbParameter("hca215_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca215_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT             hca215.*\r\nFROM                 hca215\r\nWHERE             (1 = " +
			"1)";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hca215] SET [hca215_id] = ?, [hca215_cname] = ?, [hca215_sort] = ?, [hca2" +
			"15_stop] = ?, [hca215_aid] = ?, [hca215_adt] = ?, [hca215_uid] = ?, [hca215_udt]" +
			" = ? WHERE (([hca215_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hca215_id", System.Data.OleDb.OleDbType.WChar, 0, "hca215_id"),
            new System.Data.OleDb.OleDbParameter("hca215_cname", System.Data.OleDb.OleDbType.VarWChar, 0, "hca215_cname"),
            new System.Data.OleDb.OleDbParameter("hca215_sort", System.Data.OleDb.OleDbType.SmallInt, 0, "hca215_sort"),
            new System.Data.OleDb.OleDbParameter("hca215_stop", System.Data.OleDb.OleDbType.WChar, 0, "hca215_stop"),
            new System.Data.OleDb.OleDbParameter("hca215_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca215_aid"),
            new System.Data.OleDb.OleDbParameter("hca215_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca215_adt"),
            new System.Data.OleDb.OleDbParameter("hca215_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca215_uid"),
            new System.Data.OleDb.OleDbParameter("hca215_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca215_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hca215_id", System.Data.OleDb.OleDbType.WChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hca215_id", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_hca215();
		this.uf_Initialize();
	}
}
