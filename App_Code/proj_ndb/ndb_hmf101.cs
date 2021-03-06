// *********************************************************************************
// 1. 程式描述：hmf101資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hmf101資料元件–無傳入值
/// </summary>
public class ndb_hmf101 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hmf101(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hmf101()
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
		// 容器
		// 
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
                                           new System.Data.Common.DataColumnMapping("hmf101_udt", "hmf101_udt")
                                           })
            });
                                           
		// 
		// 刪除命令
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmf101] WHERE (([hmf101_courseid] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hmf101_courseid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hmf101_courseid", System.Data.DataRowVersion.Original, null)
		});


		// 
		// 新增區
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmf101] ([hmf101_courseid],[hmf101_name],[hmf101_coursetype],[hmf101_hourse],[hmf101_openfor],[hmf101_force],[hmf101_ps],[hmf101_aid],[hmf101_adt],[hmf101_uid],[hmf101_udt]) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hmf101_courseid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_courseid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_name", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_name"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_coursetype", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_coursetype"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_hourse", System.Data.OleDb.OleDbType.SmallInt, 0, "hmf101_hourse"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_openfor", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_openfor"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_force", System.Data.OleDb.OleDbType.Char, 0, "hmf101_force"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_ps", System.Data.OleDb.OleDbType.LongVarChar, 0, "hmf101_ps"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf101_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf101_udt")
		});


		// 
		// 查詢區
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hmf101] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// 更新區
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmf101] SET  [hmf101_courseid] = ?, [hmf101_name] = ?, [hmf101_coursetype] = ?, [hmf101_hourse] = ?, [hmf101_openfor] = ?, [hmf101_force] = ?, [hmf101_ps] = ?, [hmf101_aid] = ?, [hmf101_adt] = ?, [hmf101_uid] = ?, [hmf101_udt] = ?  WHERE (([hmf101_courseid] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hmf101_courseid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_courseid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_name", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_name"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_coursetype", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_coursetype"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_hourse", System.Data.OleDb.OleDbType.SmallInt, 0, "hmf101_hourse"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_openfor", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_openfor"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_force", System.Data.OleDb.OleDbType.Char, 0, "hmf101_force"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_ps", System.Data.OleDb.OleDbType.LongVarChar, 0, "hmf101_ps"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf101_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf101_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf101_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf101_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmf101_courseid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hmf101_courseid", System.Data.DataRowVersion.Original, null)                                                });

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
		this.ds_Data = new d_hmf101();
		this.uf_Initialize();
	}
}
