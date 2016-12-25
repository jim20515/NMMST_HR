// *********************************************************************************
// 1. 程式描述：hca214資料元件–無傳入值
// 2. 撰寫人員：rong
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;


/// <summary>
/// ndb_hca214 的摘要描述
/// </summary>
public class ndb_hca214: WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hca214(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hca214()
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
            new System.Data.Common.DataTableMapping("Table", "hca214", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hca214_id", "hca214_id"),
                        new System.Data.Common.DataColumnMapping("hca214_cname", "hca214_cname"),
                        new System.Data.Common.DataColumnMapping("hca214_sort", "hca214_sort"),
                        new System.Data.Common.DataColumnMapping("hca214_stop", "hca214_stop"),
                        new System.Data.Common.DataColumnMapping("hca214_aid", "hca214_aid"),
                        new System.Data.Common.DataColumnMapping("hca214_adt", "hca214_adt"),
                        new System.Data.Common.DataColumnMapping("hca214_uid", "hca214_uid"),
                        new System.Data.Common.DataColumnMapping("hca214_udt", "hca214_udt")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hca214] WHERE (([hca214_id] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hca214_id", System.Data.OleDb.OleDbType.WChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hca214_id", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hca214] ([hca214_id], [hca214_cname], [hca214_sort], [hca214_stop], " +
			"[hca214_aid], [hca214_adt], [hca214_uid], [hca214_udt]) VALUES (?, ?, ?, ?, ?, ?" +
			", ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hca214_id", System.Data.OleDb.OleDbType.WChar, 0, "hca214_id"),
            new System.Data.OleDb.OleDbParameter("hca214_cname", System.Data.OleDb.OleDbType.VarWChar, 0, "hca214_cname"),
            new System.Data.OleDb.OleDbParameter("hca214_sort", System.Data.OleDb.OleDbType.SmallInt, 0, "hca214_sort"),
            new System.Data.OleDb.OleDbParameter("hca214_stop", System.Data.OleDb.OleDbType.WChar, 0, "hca214_stop"),
            new System.Data.OleDb.OleDbParameter("hca214_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca214_aid"),
            new System.Data.OleDb.OleDbParameter("hca214_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca214_adt"),
            new System.Data.OleDb.OleDbParameter("hca214_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca214_uid"),
            new System.Data.OleDb.OleDbParameter("hca214_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca214_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT             hca214.*\r\nFROM                 hca214\r\nWHERE             (1 = " +
			"1)";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hca214] SET [hca214_id] = ?, [hca214_cname] = ?, [hca214_sort] = ?, [hca2" +
			"14_stop] = ?, [hca214_aid] = ?, [hca214_adt] = ?, [hca214_uid] = ?, [hca214_udt]" +
			" = ? WHERE (([hca214_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hca214_id", System.Data.OleDb.OleDbType.WChar, 0, "hca214_id"),
            new System.Data.OleDb.OleDbParameter("hca214_cname", System.Data.OleDb.OleDbType.VarWChar, 0, "hca214_cname"),
            new System.Data.OleDb.OleDbParameter("hca214_sort", System.Data.OleDb.OleDbType.SmallInt, 0, "hca214_sort"),
            new System.Data.OleDb.OleDbParameter("hca214_stop", System.Data.OleDb.OleDbType.WChar, 0, "hca214_stop"),
            new System.Data.OleDb.OleDbParameter("hca214_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca214_aid"),
            new System.Data.OleDb.OleDbParameter("hca214_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca214_adt"),
            new System.Data.OleDb.OleDbParameter("hca214_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hca214_uid"),
            new System.Data.OleDb.OleDbParameter("hca214_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca214_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hca214_id", System.Data.OleDb.OleDbType.WChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hca214_id", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_hca214();
		this.uf_Initialize();
	}
}
