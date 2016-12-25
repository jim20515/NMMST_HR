﻿// *********************************************************************************
// 1. 程式描述：hmd202資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;


/// <summary>
/// ndb_hmd202 的摘要描述
/// </summary>
public class ndb_hmd202: WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hmd202(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hmd202()
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
            new System.Data.Common.DataTableMapping("Table", "hmd202", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hmd202_id", "hmd202_id"),
                        new System.Data.Common.DataColumnMapping("hmd202_open", "hmd202_open"),
                        new System.Data.Common.DataColumnMapping("hmd202_aid", "hmd202_aid"),
                        new System.Data.Common.DataColumnMapping("hmd202_adt", "hmd202_adt"),
                        new System.Data.Common.DataColumnMapping("hmd202_uid", "hmd202_uid"),
                        new System.Data.Common.DataColumnMapping("hmd202_udt", "hmd202_udt")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmd202] WHERE (([hmd202_id] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hmd202_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmd202_id", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmd202] ([hmd202_id], [hmd202_open], [hmd202_aid], [hmd202_adt], [hm" +
			"d202_uid], [hmd202_udt]) VALUES (?, ?, ?, ?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmd202_id", System.Data.OleDb.OleDbType.Integer, 0, "hmd202_id"),
            new System.Data.OleDb.OleDbParameter("hmd202_open", System.Data.OleDb.OleDbType.WChar, 0, "hmd202_open"),
            new System.Data.OleDb.OleDbParameter("hmd202_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd202_aid"),
            new System.Data.OleDb.OleDbParameter("hmd202_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd202_adt"),
            new System.Data.OleDb.OleDbParameter("hmd202_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd202_uid"),
            new System.Data.OleDb.OleDbParameter("hmd202_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd202_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT * FROM [hmd202] WHERE (1=1) ";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmd202] SET [hmd202_id] = ?, [hmd202_open] = ?, [hmd202_aid] = ?, [hmd202" +
			"_adt] = ?, [hmd202_uid] = ?, [hmd202_udt] = ? WHERE (([hmd202_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmd202_id", System.Data.OleDb.OleDbType.Integer, 0, "hmd202_id"),
            new System.Data.OleDb.OleDbParameter("hmd202_open", System.Data.OleDb.OleDbType.WChar, 0, "hmd202_open"),
            new System.Data.OleDb.OleDbParameter("hmd202_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd202_aid"),
            new System.Data.OleDb.OleDbParameter("hmd202_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd202_adt"),
            new System.Data.OleDb.OleDbParameter("hmd202_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd202_uid"),
            new System.Data.OleDb.OleDbParameter("hmd202_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd202_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hmd202_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmd202_id", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_hmd202();
		this.uf_Initialize();
	}
}
