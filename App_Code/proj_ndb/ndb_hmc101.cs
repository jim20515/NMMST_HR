// *********************************************************************************
// 1. 程式描述：hmc101資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hmc101資料元件–無傳入值
/// </summary>
public class ndb_hmc101 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hmc101(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hmc101()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ndb_hmc101));
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
            new System.Data.Common.DataTableMapping("Table", "hmc101", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hmc101_id", "hmc101_id"),
                        new System.Data.Common.DataColumnMapping("hmc101_cname", "hmc101_cname"),
                        new System.Data.Common.DataColumnMapping("hmc101_gent", "hmc101_gent"),
                        new System.Data.Common.DataColumnMapping("hmc101_bday", "hmc101_bday"),
                        new System.Data.Common.DataColumnMapping("hmc101_SSN", "hmc101_SSN"),
                        new System.Data.Common.DataColumnMapping("hmc101_deptid", "hmc101_deptid"),
                        new System.Data.Common.DataColumnMapping("hmc101_eduid", "hmc101_eduid"),
                        new System.Data.Common.DataColumnMapping("hmc101_jobid", "hmc101_jobid"),
                        new System.Data.Common.DataColumnMapping("hmc101_joborg", "hmc101_joborg"),
                        new System.Data.Common.DataColumnMapping("hmc101_jobdepartment", "hmc101_jobdepartment"),
                        new System.Data.Common.DataColumnMapping("hmc101_jobtitle", "hmc101_jobtitle"),
                        new System.Data.Common.DataColumnMapping("hmc101_addid", "hmc101_addid"),
                        new System.Data.Common.DataColumnMapping("hmc101_addot", "hmc101_addot"),
                        new System.Data.Common.DataColumnMapping("hmc101_email", "hmc101_email"),
                        new System.Data.Common.DataColumnMapping("hmc101_phnow", "hmc101_phnow"),
                        new System.Data.Common.DataColumnMapping("hmc101_phnowex", "hmc101_phnowex"),
                        new System.Data.Common.DataColumnMapping("hmc101_phnoa", "hmc101_phnoa"),
                        new System.Data.Common.DataColumnMapping("hmc101_phnom", "hmc101_phnom"),
                        new System.Data.Common.DataColumnMapping("hmc101_fax", "hmc101_fax"),
                        new System.Data.Common.DataColumnMapping("hmc101_memberid", "hmc101_memberid"),
                        new System.Data.Common.DataColumnMapping("hmc101_memberpwd", "hmc101_memberpwd"),
                        new System.Data.Common.DataColumnMapping("hmc101_passed", "hmc101_passed"),
                        new System.Data.Common.DataColumnMapping("hmc101_rejectepaper", "hmc101_rejectepaper"),
                        new System.Data.Common.DataColumnMapping("hmc101_ps", "hmc101_ps"),
                        new System.Data.Common.DataColumnMapping("hmc101_notel", "hmc101_notel"),
                        new System.Data.Common.DataColumnMapping("hmc101_expert", "hmc101_expert"),
                        new System.Data.Common.DataColumnMapping("hmc101_stop", "hmc101_stop"),
                        new System.Data.Common.DataColumnMapping("hmc101_aid", "hmc101_aid"),
                        new System.Data.Common.DataColumnMapping("hmc101_adt", "hmc101_adt"),
                        new System.Data.Common.DataColumnMapping("hmc101_uid", "hmc101_uid"),
                        new System.Data.Common.DataColumnMapping("hmc101_udt", "hmc101_udt")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmc101] WHERE (([hmc101_id] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hmc101_id", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmc101_id", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmc101] ([hmc101_id], [hmc101_cname], [hmc101_gent], [hmc101_bday], [hmc101_SSN], [hmc101_deptid], [hmc101_eduid], [hmc101_jobid], [hmc101_joborg], [hmc101_jobdepartment], [hmc101_jobtitle], [hmc101_addid], [hmc101_addot], [hmc101_email], [hmc101_phnow], [hmc101_phnowex], [hmc101_phnoa], [hmc101_phnom], [hmc101_fax], [hmc101_memberid], [hmc101_memberpwd], [hmc101_passed], [hmc101_rejectepaper], [hmc101_ps], [hmc101_notel], [hmc101_expert], [hmc101_stop], [hmc101_aid], [hmc101_adt], [hmc101_uid], [hmc101_udt]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmc101_id", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_id"),
            new System.Data.OleDb.OleDbParameter("hmc101_cname", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_cname"),
            new System.Data.OleDb.OleDbParameter("hmc101_gent", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_gent"),
            new System.Data.OleDb.OleDbParameter("hmc101_bday", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmc101_bday"),
            new System.Data.OleDb.OleDbParameter("hmc101_SSN", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_SSN"),
            new System.Data.OleDb.OleDbParameter("hmc101_deptid", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_deptid"),
            new System.Data.OleDb.OleDbParameter("hmc101_eduid", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_eduid"),
            new System.Data.OleDb.OleDbParameter("hmc101_jobid", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_jobid"),
            new System.Data.OleDb.OleDbParameter("hmc101_joborg", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_joborg"),
            new System.Data.OleDb.OleDbParameter("hmc101_jobdepartment", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_jobdepartment"),
            new System.Data.OleDb.OleDbParameter("hmc101_jobtitle", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_jobtitle"),
            new System.Data.OleDb.OleDbParameter("hmc101_addid", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_addid"),
            new System.Data.OleDb.OleDbParameter("hmc101_addot", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_addot"),
            new System.Data.OleDb.OleDbParameter("hmc101_email", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_email"),
            new System.Data.OleDb.OleDbParameter("hmc101_phnow", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_phnow"),
            new System.Data.OleDb.OleDbParameter("hmc101_phnowex", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_phnowex"),
            new System.Data.OleDb.OleDbParameter("hmc101_phnoa", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_phnoa"),
            new System.Data.OleDb.OleDbParameter("hmc101_phnom", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_phnom"),
            new System.Data.OleDb.OleDbParameter("hmc101_fax", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_fax"),
            new System.Data.OleDb.OleDbParameter("hmc101_memberid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_memberid"),
            new System.Data.OleDb.OleDbParameter("hmc101_memberpwd", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_memberpwd"),
            new System.Data.OleDb.OleDbParameter("hmc101_passed", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_passed"),
            new System.Data.OleDb.OleDbParameter("hmc101_rejectepaper", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_rejectepaper"),
            new System.Data.OleDb.OleDbParameter("hmc101_ps", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hmc101_ps"),
            new System.Data.OleDb.OleDbParameter("hmc101_notel", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hmc101_notel"),
            new System.Data.OleDb.OleDbParameter("hmc101_expert", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hmc101_expert"),
            new System.Data.OleDb.OleDbParameter("hmc101_stop", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_stop"),
            new System.Data.OleDb.OleDbParameter("hmc101_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_aid"),
            new System.Data.OleDb.OleDbParameter("hmc101_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmc101_adt"),
            new System.Data.OleDb.OleDbParameter("hmc101_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_uid"),
            new System.Data.OleDb.OleDbParameter("hmc101_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmc101_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT * FROM [hmc101] WHERE (1=1) ";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmc101] SET [hmc101_id] = ?, [hmc101_cname] = ?, [hmc101_gent] = ?, [hmc101_bday] = ?, [hmc101_SSN] = ?, [hmc101_deptid] = ?, [hmc101_eduid] = ?, [hmc101_jobid] = ?, [hmc101_joborg] = ?, [hmc101_jobdepartment] = ?, [hmc101_jobtitle] = ?, [hmc101_addid] = ?, [hmc101_addot] = ?, [hmc101_email] = ?, [hmc101_phnow] = ?, [hmc101_phnowex] = ?, [hmc101_phnoa] = ?, [hmc101_phnom] = ?, [hmc101_fax] = ?, [hmc101_memberid] = ?, [hmc101_memberpwd] = ?, [hmc101_passed] = ?, [hmc101_rejectepaper] = ?, [hmc101_ps] = ?, [hmc101_notel] = ?, [hmc101_expert] = ?, [hmc101_stop] = ?, [hmc101_aid] = ?, [hmc101_adt] = ?, [hmc101_uid] = ?, [hmc101_udt] = ? WHERE (([hmc101_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmc101_id", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_id"),
            new System.Data.OleDb.OleDbParameter("hmc101_cname", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_cname"),
            new System.Data.OleDb.OleDbParameter("hmc101_gent", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_gent"),
            new System.Data.OleDb.OleDbParameter("hmc101_bday", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmc101_bday"),
            new System.Data.OleDb.OleDbParameter("hmc101_SSN", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_SSN"),
            new System.Data.OleDb.OleDbParameter("hmc101_deptid", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_deptid"),
            new System.Data.OleDb.OleDbParameter("hmc101_eduid", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_eduid"),
            new System.Data.OleDb.OleDbParameter("hmc101_jobid", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_jobid"),
            new System.Data.OleDb.OleDbParameter("hmc101_joborg", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_joborg"),
            new System.Data.OleDb.OleDbParameter("hmc101_jobdepartment", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_jobdepartment"),
            new System.Data.OleDb.OleDbParameter("hmc101_jobtitle", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_jobtitle"),
            new System.Data.OleDb.OleDbParameter("hmc101_addid", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_addid"),
            new System.Data.OleDb.OleDbParameter("hmc101_addot", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_addot"),
            new System.Data.OleDb.OleDbParameter("hmc101_email", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_email"),
            new System.Data.OleDb.OleDbParameter("hmc101_phnow", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_phnow"),
            new System.Data.OleDb.OleDbParameter("hmc101_phnowex", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_phnowex"),
            new System.Data.OleDb.OleDbParameter("hmc101_phnoa", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_phnoa"),
            new System.Data.OleDb.OleDbParameter("hmc101_phnom", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_phnom"),
            new System.Data.OleDb.OleDbParameter("hmc101_fax", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_fax"),
            new System.Data.OleDb.OleDbParameter("hmc101_memberid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_memberid"),
            new System.Data.OleDb.OleDbParameter("hmc101_memberpwd", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_memberpwd"),
            new System.Data.OleDb.OleDbParameter("hmc101_passed", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_passed"),
            new System.Data.OleDb.OleDbParameter("hmc101_rejectepaper", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_rejectepaper"),
            new System.Data.OleDb.OleDbParameter("hmc101_ps", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hmc101_ps"),
            new System.Data.OleDb.OleDbParameter("hmc101_notel", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hmc101_notel"),
            new System.Data.OleDb.OleDbParameter("hmc101_expert", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hmc101_expert"),
            new System.Data.OleDb.OleDbParameter("hmc101_stop", System.Data.OleDb.OleDbType.WChar, 0, "hmc101_stop"),
            new System.Data.OleDb.OleDbParameter("hmc101_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_aid"),
            new System.Data.OleDb.OleDbParameter("hmc101_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmc101_adt"),
            new System.Data.OleDb.OleDbParameter("hmc101_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmc101_uid"),
            new System.Data.OleDb.OleDbParameter("hmc101_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmc101_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hmc101_id", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmc101_id", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_hmc101();
		this.uf_Initialize();
	}
}
