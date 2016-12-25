// *********************************************************************************
// 1. 程式描述：使用記錄查詢–使用紀錄刪除管理
// 2. 撰寫人員：shaun
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

public partial class sys_s_s03_p_s0303 : p_sBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：shaun

    protected ndb_LoginLog indb_LoginLog = new ndb_LoginLog();
    protected ndb_ActionLog indb_ActionLog = new ndb_ActionLog();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.uf_InitializeQuery(dwQ, null, null);
        
        if (!IsPostBack)
        {
            u_Date2.Value = System.DateTime.Today.AddYears(-1).ToShortDateString();
        }
    }
    
    protected void bt_Delete_Click(object sender, EventArgs e)
    {
        #region ☆ 檢核刪除區間

        if (u_Date1.Value == "" && u_Date2.Value == "")
        {
            uf_Msg("請選擇刪除區間起迄日期");
            return;
        }

        if (u_Date1.Value != "" && u_Date2.Value != "" && Convert.ToDateTime(u_Date1.Value) > Convert.ToDateTime(u_Date2.Value))
        {
            uf_Msg("刪除起日不得大於迄日");
            return;
        }

        if (u_Date2.Value != "" && Convert.ToDateTime(u_Date2.Value) > System.DateTime.Today.AddYears(-1))
        {
            uf_Msg("不得刪除包含最近一年內紀錄");
            return;
        }

        if (u_Date1.Value != "" && u_Date2.Value == "")
        {
            uf_Msg("不得刪除包含最近一年內紀錄");
            return;
        }

        #endregion

        int li_clogin = 0;
        int li_caction = 0;
        string ls_logaction = "";

        //刪除紀錄語法
        string ls_dlogin = "DELETE FROM LoginLog WHERE LoginTime >= '" + u_Date1.Value + "' AND LoginTime <= '" + u_Date2.Value + " 23:59:00'";
        string ls_daction = "DELETE FROM ActionLog WHERE LDate >= '" + u_Date1.Value + "' AND LDate <= '" + u_Date2.Value + " 23:59:00'";
        
        //取得刪除紀錄筆數
        indb_LoginLog.uf_Retrieve(" AND LoginTime >= '" + u_Date1.Value + "' AND LoginTime <= '" + u_Date2.Value + " 23:59:00'");
        indb_ActionLog.uf_Retrieve(" AND LDate >= '" + u_Date1.Value + "' AND LDate <= '" + u_Date2.Value + " 23:59:00'");

        if (delete_type.SelectedValue == "1")  //刪除全部紀錄
        {
            li_clogin = indb_LoginLog.uf_RowCount();
            li_caction = indb_ActionLog.uf_RowCount();

            if (li_clogin == 0 && li_caction == 0)
            {
                uf_Msg("無紀錄可供刪除");
                return;
            }

            //執行刪除動作
            DbMethods.uf_ExecSQL(ls_dlogin);
            DbMethods.uf_ExecSQL(ls_daction);

            ls_logaction = "刪除全部紀錄";
        }
        else if (delete_type.SelectedValue == "2")  //刪除登入登出紀錄
        {
            li_clogin = indb_LoginLog.uf_RowCount();
            if (li_clogin == 0)
            {
                uf_Msg("無紀錄可供刪除");
                return;
            }
            DbMethods.uf_ExecSQL(ls_dlogin);

            ls_logaction = "刪除登入登出紀錄";
        }
        else                                        //刪除操作紀錄
        {
            li_caction = indb_ActionLog.uf_RowCount();
            if (li_caction == 0)
            {
                uf_Msg("無紀錄可供刪除");
                return;
            }
            DbMethods.uf_ExecSQL(ls_daction);

            ls_logaction = "刪除操作紀錄";
        }

        //將刪除動作紀錄至ActionLog
        Page l_Page = (Page)HttpContext.Current.Handler;
        int li_aid = 0;
        DbMethods.uf_ExecSQL("SELECT ISNULL(MAX(A_Id), 0) +1 FROM ActionLog", ref li_aid);
        string ls_insertlog = @"SET IDENTITY_INSERT ActionLog ON " +
                              "INSERT INTO ActionLog(A_Id, DeptName, UID, UName, LIP, LDate, PRG_ID, PRG_DESC, Keys)" +
                              " VALUES("+ li_aid +", '" + LoginUser.DeptName + "', '" + LoginUser.ID + "', '" + LoginUser.Name +
                              "', '" + l_Page.Request.UserHostAddress + "', GETDATE(), '使用記錄查詢>使用紀錄刪除管理', "+
                              "'使用記錄查詢>使用紀錄刪除管理-"+ ls_logaction +"', '"+ u_Date1.Value +", "+ u_Date2.Value +
                              "') SET IDENTITY_INSERT ActionLog OFF";
        DbMethods.uf_ExecSQL(ls_insertlog);

        //顯示執行刪除後結果
        uf_Msg("執行結果：\r\n" +
                "刪除  " + u_Date1.Value + " ~ " + u_Date2.Value + " \n" +
                "登入登出紀錄： " + li_clogin.ToString() + "筆 \n" +
                "操作紀錄： " + li_caction.ToString() + "筆");
    }
}
