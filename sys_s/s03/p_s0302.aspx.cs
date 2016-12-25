// *********************************************************************************
// 1. 程式描述：使用記錄查詢–操作記錄查詢
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

public partial class sys_s_s03_p_s0302 : p_sBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：shaun

    protected ndb_ActionLog indb_ActionLog = new ndb_ActionLog();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.IsAJAXScript = true;

        if (!IsPostBack)
        {
            bt_Query_Click(this, EventArgs.Empty);

        }  
    }

    //DataGrid標頭排序
    protected void dgG_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        DataView ld_view = uf_dataview();

        // get sort expression　and sort direction
        ld_view.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);

        dgG.DataSource = ld_view;
        dgG.DataBind();
    }

    private string GetSortDirection(string column)
    {

        // By default, set the sort direction to ascending.
        string sortDirection = "ASC";

        // Retrieve the last column that was sorted.
        string sortExpression = ViewState["SortExpression"] as string;

        if (sortExpression != null)
        {
            // Check if the same column is being sorted.
            // Otherwise, the default value can be returned.
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC"))
                {
                    sortDirection = "DESC";
                }
            }
        }

        // Save new values in ViewState.
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;

        return sortDirection;
    }

    protected void bt_Query_Click(object sender, EventArgs e)
    {
        if (u_Date1.Value != "" && u_Date2.Value != "")
        {
            if (Convert.ToDateTime(u_Date2.Value.ToString()) < Convert.ToDateTime(u_Date1.Value.ToString()))
                uf_Msg("迄日不得小於起日");
        }

        DataView ld_view = uf_dataview();
        ld_view.Sort = "UID ASC";
        dgG.DataSource = ld_view;
        dgG.DataBind();

    }

    protected DataView uf_dataview()
    {
        DataSet ld_data;
        DataView ldf_view;

        string ls_sql = @"SELECT UID, Uname, LIP, LDate, PRG_DESC, Keys 
                        FROM ActionLog WHERE 1=1";
        if (!IsPostBack)
            ls_sql += " and 1<>1";
        if (dwQ_UName.Text != "")
            ls_sql += " AND Uname = RTRIM('" + dwQ_UName.Text + "')";
        if (u_Date1.Value != "")
            ls_sql += " AND LDate >= '" + u_Date1.Value + "'";
        if (u_Date2.Value != "")
            ls_sql += " AND LDate <= '" + u_Date2.Value + "'";

        DbMethods.uf_Retrieve_FromSQL(out ld_data, ls_sql);
        ldf_view = ld_data.Tables[0].DefaultView;
        return ldf_view;
    }
}
