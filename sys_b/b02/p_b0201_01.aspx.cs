// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排班表設定–排班主檔查詢–查詢及清單
// 2. 撰寫人員：demon
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

public partial class sys_b_b02_p_b0201_01 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：排班主檔資料元件</summary>
    protected ndb_hmc101 indb_hmc101 = new ndb_hmc101();

    #endregion
    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        // 初始化
        this.uf_InitializeQuery(dwQ1, this.indb_hmc101, bt_Query);
        this.uf_InitializeQuery(dwQ2, this.indb_hmc101, bt_Query);
        this.uf_InitializeQuery(dwQ3, this.indb_hmc101, bt_Query);

        dwQ_sage.Attributes["onBlur"] = "uf_GetNumeric(" + dwQ_sage.ClientID + ");";
        dwQ_eage.Attributes["onBlur"] = "uf_GetNumeric(" + dwQ_eage.ClientID + ");";

        if (!IsPostBack)
        {
            DataSet ds_type;
            DataView dv_type;

            DbMethods.uf_Retrieve_FromSQL(out ds_type, " SELECT hmc102_name, hmc102_id FROM hmc102 WHERE hmc102_id <> '0' ");
            dv_type = ds_type.Tables[0].DefaultView;
            dv_type.Sort = "hmc102_id";
            dwQ_hmc101_type.DataSource = dv_type;
            dwQ_hmc101_type.DataTextField = "hmc102_name";
            dwQ_hmc101_type.DataValueField = "hmc102_id";
            dwQ_hmc101_type.DataBind();
        }
    }

	protected void dwQ_hmc101_type1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (dwQ_hmc101_type1.SelectedValue.Trim() == "Y")
		{
			dwQ_hmc101_type.Enabled = true;
		}
		else
		{
			foreach (ListItem li_item in dwQ_hmc101_type.Items)
			{
				li_item.Selected = false;
			}
			dwQ_hmc101_type.Enabled = false;
		}
	}

    protected string uf_getQuery()
    {
        string ls_query = "";
        // 將 DataGrid 選擇的資料組成查詢字串
        for (int li_row = 0; li_row < dwQ_hmc101_type.Items.Count; li_row++)
        {
            if (!dwQ_hmc101_type.Items[li_row].Selected) continue;
            if (ls_query != "") ls_query += ",";
            ls_query += dwQ_hmc101_type.Items[li_row].Value.Trim();
        }
        return ls_query;
    }

    protected void bt_Query_Click(object sender, EventArgs e)
    {
        string ls_AddSQL = "" ,  ls_query = "";
        //this.uf_AddJavaScript("uf_LinkFrame('p_b0101_02.aspx', '02Frame', '" + dwQ_condition.SelectedValue + "|" + uf_getQuery() + "' ); ");

        if (dwQ_hmc101_deptid.SelectedIndex > 0)
        {
            ls_AddSQL += " AND hmc101_deptid = '" + dwQ_hmc101_deptid.SelectedValue + "' ";
        }

        if (dwQ_tid.SelectedIndex > 0)
        {
            ls_AddSQL += " AND hmc101_id in ( Select hmc101_id From hmc101 Where hmc101_tid = '" + dwQ_tid.SelectedValue + "' ) ";
        }

        if (dwQ_hmc101_type.SelectedIndex != -1)
        {
            string ls_value = "";
            foreach (ListItem li_item in dwQ_hmc101_type.Items)
            {
                if (li_item.Selected)
                {
                    if (ls_value != "") ls_value += ",";
                    ls_value += li_item.Value;
                }
            }
            ls_AddSQL += " AND hmc101_id in ( SELECT hmc101_102.hmc101_id From hmc101_102 Where hmc102_id in ( " + ls_value + " ) ) ";
        }

        if (dwQ_sage.Text.Trim() != "")
        {
            ls_AddSQL += " AND DateAdd(yy," + dwQ_sage .Text.Trim()+ ",hmc101_bday) < GetDate() ";
        }

        if (dwQ_eage.Text.Trim() != "")
        {
            ls_AddSQL += " AND DateAdd(yy," + dwQ_eage.Text.Trim() + ",hmc101_bday) > GetDate() ";
        }

        if (dwQ_month.SelectedIndex > 0)
        {
            ls_AddSQL += " AND Month(hmc101_bday) = " + dwQ_month.SelectedValue + " ";
        }

        if (u_Date1.Value != "")
        {
            ls_AddSQL += " AND hmc101_bday = '" + u_Date1.Value + "' ";
        }

        if (dwQ_gen.SelectedIndex > -1)
        {
            ls_AddSQL += " AND hmc101_gent = '" + dwQ_gen.SelectedValue + "' ";
        }

        if (dwQ_eduid.SelectedIndex > 0)
        {
            ls_AddSQL += " AND hmc101_eduid = '" + dwQ_eduid.SelectedValue + "' ";
        }

        if (dwQ_jobid.SelectedIndex > 0)
        {
            ls_AddSQL += " AND hmc101_jobid = '" + dwQ_jobid.SelectedValue + "' ";
        }

		if (dwQ_hmc101_type1.SelectedValue.Trim() == "N")
		{
			ls_AddSQL += " AND hmc101_id not in ( SELECT hmc101_102.hmc101_id From hmc101_102 ) ";
		}

		if (dwQ_hmc101_stop.SelectedValue.Trim() != "")
		{
			if (dwQ_hmc101_stop.SelectedValue.Trim() == "Y")
				ls_AddSQL += " AND IsNull(hmc101_stop,'') = 'Y' ";
			else
				ls_AddSQL += " AND IsNull(hmc101_stop,'') <> 'Y' ";
		}

        indb_hmc101.uf_Retrieve(ls_AddSQL);

        if (indb_hmc101.uf_RowCount() > 0)
        {
            for (int li_row = 0; li_row < indb_hmc101.uf_RowCount(); li_row++)
            {
                ls_query += indb_hmc101[li_row]["hmc101_id"].ToString().Trim() + "|";
            }

            this.uf_AddJavaScript("uf_LinkFrame('p_b0201_02.aspx', '02Frame', '" + ls_query + "' ); ");

        }
        else
        {
            uf_Msg("查無資料，請重新查詢！");
            return;
        }

    }
}
