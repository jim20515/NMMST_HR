// *********************************************************************************
// 1. �{���y�z�G�W�U�Z��d�t�� - ��d�T����ơV�ǤJ�u���u�s���v�B�u��d�����V�W�Z(1)�F�U�Z(2)�v�M�u��d��IP�v
// 2. ���g�H���Gfen
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// �W�U�Z��d�t�� - ��d�T����ơV�ǤJ�u���u�s���v�B�u��d�����V�W�Z(1)�F�U�Z(2)�v�M�u��d��IP�v
/// </summary>
public class ndb_signin_duty2 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_signin_duty2(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// �N��ưt�����]�� current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
		this.uf_InitializeSelect_CutQuote();
	}

	public ndb_signin_duty2()
	{
		InitializeComponent();

		// �N��ưt�����]�� current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
		this.uf_InitializeSelect_CutQuote();
	}

	#region Component Designer generated code
	///// <summary>
	///// �]�p�u��һݪ��ܼơC
	///// </summary>
	//private System.ComponentModel.Container components = null;

	/// <summary>
	/// �����]�p�u��䴩�ҥ��ݪ���k - �ФŨϥε{���X�s�边�ק�
	/// �o�Ӥ�k�����e�C
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
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "dbo.[usp_signin_duty2]";
		this.oleDbSelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
		this.oleDbSelectCommand.Connection = this.cn_DB;
		this.oleDbSelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("as_empno", System.Data.OleDb.OleDbType.VarChar, 9));
		this.oleDbSelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("as_type", System.Data.OleDb.OleDbType.VarChar, 1));
		this.oleDbSelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("as_ip", System.Data.OleDb.OleDbType.VarChar, 15));
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
		// ���N DataSet �ŧi�����w�����c�A��l�ơV�m�m���i�b������l�ơn�n
		//this.ds_Data = new d_signin_duty2();
		//this.uf_Initialize();
	}
}
