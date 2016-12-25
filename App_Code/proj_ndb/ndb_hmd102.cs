// *********************************************************************************
// 1. 程式描述：hca214資料元件–無傳入值
// 2. 撰寫人員：rong
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// ndb_hmd102 的摘要描述
/// </summary>
public class ndb_hmd102: WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hmd102(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hmd102()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ndb_hmd102));
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
            new System.Data.Common.DataTableMapping("Table", "hmd102", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hmd102_year", "hmd102_year"),
                        new System.Data.Common.DataColumnMapping("hmd102_season", "hmd102_season"),
                        new System.Data.Common.DataColumnMapping("hmd102_tid", "hmd102_tid"),
                        new System.Data.Common.DataColumnMapping("hmd102_ktype", "hmd102_ktype"),
                        new System.Data.Common.DataColumnMapping("hmd102_epass", "hmd102_epass"),
                        new System.Data.Common.DataColumnMapping("hmd102_fpass", "hmd102_fpass"),
                        new System.Data.Common.DataColumnMapping("hmd102_aid", "hmd102_aid"),
                        new System.Data.Common.DataColumnMapping("hmd102_adt", "hmd102_adt"),
                        new System.Data.Common.DataColumnMapping("hmd102_uid", "hmd102_uid"),
                        new System.Data.Common.DataColumnMapping("hmd102_udt", "hmd102_udt")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmd102] WHERE (([hmd102_year] = ?) AND ([hmd102_season] = ?) AND ([h" +
			"md102_tid] = ?) AND ([hmd102_ktype] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hmd102_year", System.Data.OleDb.OleDbType.WChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmd102_year", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_hmd102_season", System.Data.OleDb.OleDbType.WChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmd102_season", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_hmd102_tid", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmd102_tid", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_hmd102_ktype", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmd102_ktype", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmd102] ([hmd102_year], [hmd102_season], [hmd102_tid], [hmd102_ktype], [hmd102_epass], [hmd102_fpass], [hmd102_aid], [hmd102_adt], [hmd102_uid], [hmd102_udt]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmd102_year", System.Data.OleDb.OleDbType.WChar, 0, "hmd102_year"),
            new System.Data.OleDb.OleDbParameter("hmd102_season", System.Data.OleDb.OleDbType.WChar, 0, "hmd102_season"),
            new System.Data.OleDb.OleDbParameter("hmd102_tid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd102_tid"),
            new System.Data.OleDb.OleDbParameter("hmd102_ktype", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd102_ktype"),
            new System.Data.OleDb.OleDbParameter("hmd102_epass", System.Data.OleDb.OleDbType.Integer, 0, "hmd102_epass"),
            new System.Data.OleDb.OleDbParameter("hmd102_fpass", System.Data.OleDb.OleDbType.Integer, 0, "hmd102_fpass"),
            new System.Data.OleDb.OleDbParameter("hmd102_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd102_aid"),
            new System.Data.OleDb.OleDbParameter("hmd102_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd102_adt"),
            new System.Data.OleDb.OleDbParameter("hmd102_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd102_uid"),
            new System.Data.OleDb.OleDbParameter("hmd102_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd102_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT             hmd102.*\r\nFROM                 hmd102\r\nWHERE             (1 = " +
			"1)";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmd102] SET [hmd102_year] = ?, [hmd102_season] = ?, [hmd102_tid] = ?, [hmd102_ktype] = ?, [hmd102_epass] = ?, [hmd102_fpass] = ?, [hmd102_aid] = ?, [hmd102_adt] = ?, [hmd102_uid] = ?, [hmd102_udt] = ? WHERE (([hmd102_year] = ?) AND ([hmd102_season] = ?) AND ([hmd102_tid] = ?) AND ([hmd102_ktype] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmd102_year", System.Data.OleDb.OleDbType.WChar, 0, "hmd102_year"),
            new System.Data.OleDb.OleDbParameter("hmd102_season", System.Data.OleDb.OleDbType.WChar, 0, "hmd102_season"),
            new System.Data.OleDb.OleDbParameter("hmd102_tid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd102_tid"),
            new System.Data.OleDb.OleDbParameter("hmd102_ktype", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd102_ktype"),
            new System.Data.OleDb.OleDbParameter("hmd102_epass", System.Data.OleDb.OleDbType.Integer, 0, "hmd102_epass"),
            new System.Data.OleDb.OleDbParameter("hmd102_fpass", System.Data.OleDb.OleDbType.Integer, 0, "hmd102_fpass"),
            new System.Data.OleDb.OleDbParameter("hmd102_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd102_aid"),
            new System.Data.OleDb.OleDbParameter("hmd102_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd102_adt"),
            new System.Data.OleDb.OleDbParameter("hmd102_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmd102_uid"),
            new System.Data.OleDb.OleDbParameter("hmd102_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmd102_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hmd102_year", System.Data.OleDb.OleDbType.WChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmd102_year", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_hmd102_season", System.Data.OleDb.OleDbType.WChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmd102_season", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_hmd102_tid", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmd102_tid", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_hmd102_ktype", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmd102_ktype", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_hmd102();
		this.uf_Initialize();
	}
}
