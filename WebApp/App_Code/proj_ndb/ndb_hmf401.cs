// *********************************************************************************
// 1. �{���y�z�Ghmf401��Ƥ���V�L�ǤJ��
// 2. ���g�H���Ggenerated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hmf401��Ƥ���V�L�ǤJ��
/// </summary>
public class ndb_hmf401 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hmf401(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// �N��ưt�����]�� current
		da_SQL = da_SQL_current;
	}

	public ndb_hmf401()
	{
		InitializeComponent();
		// �N��ưt�����]�� current
		da_SQL = da_SQL_current;
	}

	#region Component Designer generated code
	
	/// <summary>
	/// �����]�p�u��䴩�ҥ��ݪ���k - �ФŨϥε{���X�s�边�ק�
	/// �o�Ӥ�k�����e�C
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
		// �e��
		// 
		this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
			
                                           new System.Data.Common.DataTableMapping("Table", "hmf401", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hmf401_vid", "hmf401_vid"),
                                           new System.Data.Common.DataColumnMapping("hmf401_certid", "hmf401_certid"),
                                           new System.Data.Common.DataColumnMapping("hmf401_appid", "hmf401_appid"),
                                           new System.Data.Common.DataColumnMapping("hmf401_ps", "hmf401_ps"),
                                           new System.Data.Common.DataColumnMapping("hmf401_aid", "hmf401_aid"),
                                           new System.Data.Common.DataColumnMapping("hmf401_adt", "hmf401_adt"),
                                           new System.Data.Common.DataColumnMapping("hmf401_uid", "hmf401_uid"),
                                           new System.Data.Common.DataColumnMapping("hmf401_udt", "hmf401_udt")
                                           })
            });
                                           
		// 
		// �R���R�O
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmf401] WHERE (([hmf401_vid] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hmf401_vid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hmf401_vid", System.Data.DataRowVersion.Original, null)
		});


		// 
		// �s�W��
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmf401] ([hmf401_vid],[hmf401_certid],[hmf401_appid],[hmf401_ps],[hmf401_aid],[hmf401_adt],[hmf401_uid],[hmf401_udt]) VALUES (?,?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hmf401_vid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf401_vid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_certid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf401_certid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_appid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf401_appid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_ps", System.Data.OleDb.OleDbType.LongVarChar, 0, "hmf401_ps"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf401_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf401_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf401_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf401_udt")
		});


		// 
		// �d�߰�
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hmf401] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// ��s��
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmf401] SET  [hmf401_vid] = ?, [hmf401_certid] = ?, [hmf401_appid] = ?, [hmf401_ps] = ?, [hmf401_aid] = ?, [hmf401_adt] = ?, [hmf401_uid] = ?, [hmf401_udt] = ?  WHERE (([hmf401_vid] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hmf401_vid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf401_vid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_certid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf401_certid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_appid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf401_appid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_ps", System.Data.OleDb.OleDbType.LongVarChar, 0, "hmf401_ps"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf401_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf401_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmf401_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hmf401_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf401_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmf401_vid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hmf401_vid", System.Data.DataRowVersion.Original, null)                                                });

		((System.ComponentModel.ISupportInitialize)(this.ds_Data)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.dv_View)).EndInit();


	}
	#endregion

	// =========================================================================
	/// <summary>
	/// �禡�y�z�G�ۭq��l�ƨ禡�]�л\�W�h�^
	/// </summary>
	protected override void uf_InitializeComponent()
	{
		// ���N DataSet �ŧi�����w�����c�A��l��
		this.ds_Data = new d_hmf401();
		this.uf_Initialize();
	}
}