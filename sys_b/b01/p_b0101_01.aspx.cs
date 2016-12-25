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

public partial class sys_b_b01_p_b0101_01 : p_hrBase
{
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
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
            if ( !dwQ_hmc101_type.Items[li_row].Selected ) continue;
            if (ls_query != "") ls_query += ",";
            ls_query += dwQ_hmc101_type.Items[li_row].Value.Trim();
        }
        return ls_query;
    }

    protected void bt_Query_Click(object sender, EventArgs e)
    {
		this.uf_AddJavaScript("uf_LinkFrame('p_b0101_02.aspx', '02Frame', '" + dwQ_condition.SelectedValue + "|" + uf_getQuery() + "|" + dwQ_hmc101_type1.SelectedValue + "|" +  dwQ_hmc101_stop.SelectedValue + "' ); ");
    }
}
