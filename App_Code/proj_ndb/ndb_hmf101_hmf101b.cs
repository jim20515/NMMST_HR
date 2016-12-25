// *********************************************************************************
// 1. 程式描述：認證主檔–無傳入值
// 2. 撰寫人員：QFLin
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// 人員類別資料元件–無傳入值
/// </summary>
public class ndb_hmf101_hmf101b : WIT.Template.Project.n_dbbase
{

	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_hmf101_hmf101b(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
	}

	public ndb_hmf101_hmf101b()
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
        this.oleDbSelectCommand = new System.Data.OleDb.OleDbCommand();

        ((System.ComponentModel.ISupportInitialize)(this.ds_Data)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dv_View)).BeginInit();

        // 
        // da_SQL_current
        // 
        this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;
        this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "hmf101", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hmf101_courseid", "hmf101_courseid"),
                        new System.Data.Common.DataColumnMapping("hmf101_name", "hmf101_name"),
                        new System.Data.Common.DataColumnMapping("hmf101_coursetype", "hmf101_coursetype"),
                        new System.Data.Common.DataColumnMapping("hmf101_hourse", "hmf101_hourse"),
                        new System.Data.Common.DataColumnMapping("hmf101_openfor", "hmf101_openfor"),
                        new System.Data.Common.DataColumnMapping("hmf101_force", "hmf101_force"),
                        new System.Data.Common.DataColumnMapping("hmf101_ps", "hmf101_ps"),
                        new System.Data.Common.DataColumnMapping("hmf101_aid", "hmf101_aid"),
                        new System.Data.Common.DataColumnMapping("hmf101_adt", "hmf101_adt"),
                        new System.Data.Common.DataColumnMapping("hmf101_uid", "hmf101_uid"),
                        new System.Data.Common.DataColumnMapping("hmf101_udt", "hmf101_udt"),
                        new System.Data.Common.DataColumnMapping("hmf101b_certid", "hmf101b_certid"),
                        new System.Data.Common.DataColumnMapping("hmf101b_courseid", "hmf101b_courseid"),
                        new System.Data.Common.DataColumnMapping("hmf101b_aid", "hmf101b_aid"),
                        new System.Data.Common.DataColumnMapping("hmf101b_adt", "hmf101b_adt"),
                        new System.Data.Common.DataColumnMapping("hmf101b_uid", "hmf101b_uid"),
                        new System.Data.Common.DataColumnMapping("hmf101b_udt", "hmf101b_udt")})});

        // 
        // oleDbSelectCommand
        // 
        this.oleDbSelectCommand.CommandText = "Select hmf101.* , hmf101b.*\r\nFrom hmf101 , hmf101b\r\nWhere hmf101.hmf101_courseid " +
            "= hmf101b.hmf101b_courseid";
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
		this.ds_Data = new d_hmf101_hmf101b();
		this.uf_Initialize();
	}


}
