// *********************************************************************************
// 1. 程式描述：hmi101資料元件–無傳入值
// 2. 撰寫人員：
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hmi101資料元件–無傳入值
/// </summary>
public class ndb_hmi101 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_hmi101(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hmi101()
	{
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ndb_hmi101));
        this.da_SQL_current = new System.Data.OleDb.OleDbDataAdapter();
        this.oleDbSelectCommand = new System.Data.OleDb.OleDbCommand();
        ((System.ComponentModel.ISupportInitialize)(this.ds_Data)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dv_View)).BeginInit();
        // 
        // da_SQL_current
        // 
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
                        new System.Data.Common.DataColumnMapping("hmc101_jobtitle", "hmc101_jobtitle"),
                        new System.Data.Common.DataColumnMapping("hmc101_addid", "hmc101_addid"),
                        new System.Data.Common.DataColumnMapping("hmc101_addot", "hmc101_addot"),
                        new System.Data.Common.DataColumnMapping("hmc101_email", "hmc101_email"),
                        new System.Data.Common.DataColumnMapping("hmc101_phnow", "hmc101_phnow"),
                        new System.Data.Common.DataColumnMapping("hmc101_phnowex", "hmc101_phnowex"),
                        new System.Data.Common.DataColumnMapping("hmc101_phnoa", "hmc101_phnoa"),
                        new System.Data.Common.DataColumnMapping("hmc101_phnom", "hmc101_phnom"),
                        new System.Data.Common.DataColumnMapping("hmc101_memberid", "hmc101_memberid"),
                        new System.Data.Common.DataColumnMapping("hmc101_memberpwd", "hmc101_memberpwd"),
                        new System.Data.Common.DataColumnMapping("hmc101_passed", "hmc101_passed"),
                        new System.Data.Common.DataColumnMapping("hmc101_rejectepaper", "hmc101_rejectepaper"),
                        new System.Data.Common.DataColumnMapping("hmc101_ps", "hmc101_ps"),
                        new System.Data.Common.DataColumnMapping("hmc101_notel", "hmc101_notel"),
                        new System.Data.Common.DataColumnMapping("hmc101_expert", "hmc101_expert"),
                        new System.Data.Common.DataColumnMapping("hmc101_cdt", "hmc101_cdt"),
                        new System.Data.Common.DataColumnMapping("hmc101_uid", "hmc101_uid"),
                        new System.Data.Common.DataColumnMapping("hmc101_udt", "hmc101_udt")})});
        // 
        // oleDbSelectCommand
        // 
        this.oleDbSelectCommand.CommandText = @"SELECT         A.hmc101_id, A.hmc101_cname, A.hmc101_gent, A.hmc101_bday, 
                          A.hmc101_SSN, A.hmc101_deptid, A.hmc101_eduid, A.hmc101_jobid, 
                          A.hmc101_joborg, A.hmc101_jobtitle, A.hmc101_addid, A.hmc101_addot, 
                          A.hmc101_email, A.hmc101_phnow, A.hmc101_phnowex, A.hmc101_phnoa, 
                          A.hmc101_phnom, A.hmc101_memberid, A.hmc101_memberpwd, 
                          A.hmc101_passed, A.hmc101_rejectepaper, A.hmc101_ps, A.hmc101_notel, 
                          A.hmc101_expert, A.hmc101_cdt, A.hmc101_uid, A.hmc101_udt
FROM             hmc101 AS A INNER JOIN
                          hmc101_102 AS B ON A.hmc101_id = B.hmc101_id
WHERE         (B.hmc102_id = '1')";
        this.oleDbSelectCommand.Connection = this.cn_DB;
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
		this.ds_Data = new d_hmi101();
		this.uf_Initialize();
	}
}
