// *********************************************************************************
// 1. 程式描述：hmf102a資料元件–無傳入值
// 2. 撰寫人員：rong
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// ndb_hmf102a 的摘要描述
/// </summary>
public class ndb_hmf102a: WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hmf102a(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hmf102a()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ndb_hmf102a));
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
            new System.Data.Common.DataTableMapping("Table", "hmf102a", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hmf102a_trainid", "hmf102a_trainid"),
                        new System.Data.Common.DataColumnMapping("hmf102a_seq", "hmf102a_seq"),
                        new System.Data.Common.DataColumnMapping("hmf102a_date", "hmf102a_date"),
                        new System.Data.Common.DataColumnMapping("hmf102a_stime", "hmf102a_stime"),
                        new System.Data.Common.DataColumnMapping("hmf102a_etime", "hmf102a_etime"),
                        new System.Data.Common.DataColumnMapping("hmf102a_aid", "hmf102a_aid"),
                        new System.Data.Common.DataColumnMapping("hmf102a_adt", "hmf102a_adt"),
                        new System.Data.Common.DataColumnMapping("hmf102a_uid", "hmf102a_uid"),
                        new System.Data.Common.DataColumnMapping("hmf102a_udt", "hmf102a_udt")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmf102a] WHERE (([hmf102a_trainid] = ?) AND ([hmf102a_seq] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hmf102a_trainid", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmf102a_trainid", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_hmf102a_seq", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmf102a_seq", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmf102a] ([hmf102a_trainid], [hmf102a_seq], [hmf102a_date], [hmf102a_stime], [hmf102a_etime], [hmf102a_aid], [hmf102a_adt], [hmf102a_uid], [hmf102a_udt]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmf102a_trainid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102a_trainid"),
            new System.Data.OleDb.OleDbParameter("hmf102a_seq", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102a_seq"),
            new System.Data.OleDb.OleDbParameter("hmf102a_date", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102a_date"),
            new System.Data.OleDb.OleDbParameter("hmf102a_stime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102a_stime"),
            new System.Data.OleDb.OleDbParameter("hmf102a_etime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102a_etime"),
            new System.Data.OleDb.OleDbParameter("hmf102a_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102a_aid"),
            new System.Data.OleDb.OleDbParameter("hmf102a_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102a_adt"),
            new System.Data.OleDb.OleDbParameter("hmf102a_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102a_uid"),
            new System.Data.OleDb.OleDbParameter("hmf102a_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102a_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = @"SELECT             hmf102a_trainid, hmf102a_seq, hmf102a_date, hmf102a_stime, hmf102a_etime, hmf102a_aid, hmf102a_adt, hmf102a_uid, 
                              hmf102a_udt
FROM                 hmf102a
WHERE             (1 = 1)";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmf102a] SET [hmf102a_trainid] = ?, [hmf102a_seq] = ?, [hmf102a_date] = ?, [hmf102a_stime] = ?, [hmf102a_etime] = ?, [hmf102a_aid] = ?, [hmf102a_adt] = ?, [hmf102a_uid] = ?, [hmf102a_udt] = ? WHERE (([hmf102a_trainid] = ?) AND ([hmf102a_seq] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmf102a_trainid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102a_trainid"),
            new System.Data.OleDb.OleDbParameter("hmf102a_seq", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102a_seq"),
            new System.Data.OleDb.OleDbParameter("hmf102a_date", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102a_date"),
            new System.Data.OleDb.OleDbParameter("hmf102a_stime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102a_stime"),
            new System.Data.OleDb.OleDbParameter("hmf102a_etime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102a_etime"),
            new System.Data.OleDb.OleDbParameter("hmf102a_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102a_aid"),
            new System.Data.OleDb.OleDbParameter("hmf102a_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102a_adt"),
            new System.Data.OleDb.OleDbParameter("hmf102a_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102a_uid"),
            new System.Data.OleDb.OleDbParameter("hmf102a_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102a_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hmf102a_trainid", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmf102a_trainid", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_hmf102a_seq", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmf102a_seq", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_hmf102a();
		this.uf_Initialize();
	}
}
