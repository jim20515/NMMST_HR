﻿
// *********************************************************************************
// 1. 程式描述：系統公告管理–系統公告
// 2. 撰寫人員：
// *********************************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WIT.Template.Project;

public partial class sys_e_e01_p_e0105 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：Linda

	/// <summary>變數描述：公告管理資料元件</summary>
    //protected ndb_aec02 indb_aec02 = new ndb_aec02();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.IsAJAXScript = true;
		
		//U_DateSelect_ROC3.Value = "2008 / 11 / 01";
  

		// 建立一個暫存表格1
        //DataTable ldt_EmpList = new DataTable("EmpList");
        //DataView ldv_EmpList = ldt_EmpList.DefaultView;
        //DataRowView ldrv_New;

        //// 增加欄位
        //ldt_EmpList.Columns.Add("志工隊", typeof(String));
        //ldt_EmpList.Columns.Add("年", typeof(String));
        //ldt_EmpList.Columns.Add("月", typeof(String));
        //ldt_EmpList.Columns.Add("班次", typeof(String));
        //ldt_EmpList.Columns.Add("人次", typeof(String)); 
        //ldt_EmpList.Columns.Add("開放", typeof(String));
        
        ////ldt_EmpList.Columns.Add("支票號碼", typeof(String));
        ////ldt_EmpList.Columns.Add("支票開立日期", typeof(String));
        ////ldt_EmpList.Columns.Add("受(繳)款人", typeof(String));
        ////ldt_EmpList.Columns.Add("支票金額", typeof(String));
        ////ldt_EmpList.Columns.Add("支票兌現到期日", typeof(String));
        ////ldt_EmpList.Columns.Add("劃線", typeof(String));
        ////ldt_EmpList.Columns.Add("禁背", typeof(String));
        ////ldt_EmpList.Columns.Add("郵寄日期", typeof(String));


        //ldrv_New = ldv_EmpList.AddNew();
        //ldrv_New["志工隊"] = "技術志工";
        //ldrv_New["年"] = "097";
        //ldrv_New["月"] = "07";
        //ldrv_New["班次"] = "2";
        //ldrv_New["人次"] = "10";
        //ldrv_New["開放"] = "是";

        

        //ldrv_New = ldv_EmpList.AddNew();
        //ldrv_New["志工隊"] = "行政志工";
        //ldrv_New["年"] = "097";
        //ldrv_New["月"] = "07";
        //ldrv_New["班次"] = "3";
        //ldrv_New["人次"] = "2";
        //ldrv_New["開放"] = "是";
   



        
        //dgG.DataSource = ldv_EmpList;
        //dgG.DataBind();


      
	}






    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void u_Date4_Load(object sender, EventArgs e)
    {

    }
}
