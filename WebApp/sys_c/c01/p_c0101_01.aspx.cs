
// *********************************************************************************
// 1. 程式描述：人力資源管理﹒基本資料檔管理﹒博物館之友管理﹒查詢及清單
// 2. 撰寫會員：Emily
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

public partial class sys_c_c01_p_c0101_01 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫會員：Emily

	/// <summary>變數描述：公告管理資料元件</summary>
    protected ndb_hmc101 indb_hmc101 = new ndb_hmc101();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        this.uf_InitializeQuery(dwQ, this.indb_hmc101, bt_Query);
        this.uf_InitializeComponent(null, dgG, this.indb_hmc101, null);
        this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

        if (!IsPostBack)
        {
            DataSet ds_type;
            DataView dv_type;

            DbMethods.uf_Retrieve_FromSQL(out ds_type, " SELECT hmc102_name, hmc102_id FROM hmc102 WHERE ( hmc102_id != '0' ) ");
            dv_type = ds_type.Tables[0].DefaultView;
            dv_type.Sort = "hmc102_id";
            dwQ_hmc101_type.DataSource = dv_type;
            dwQ_hmc101_type.DataTextField = "hmc102_name";
            dwQ_hmc101_type.DataValueField = "hmc102_id";
            dwQ_hmc101_type.DataBind();
        }
		this.ue_DataQuery_AfterRetrieve += new EventHandler(this.bt_Query_AfterRetrieve);
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

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Query 《查詢》按鈕資料取出之後所做的處理
	/// </summary>
	private void bt_Query_AfterRetrieve(object sender, EventArgs e)
	{
		dwS_RowCount.Text = "共" + indb_hmc101.dv_View.Count.ToString() + "資料";
		// 
		if (!(indb_hmc101.dv_View.Count > 0)) uf_Msg("查無符合資料！");

	}

    protected override bool uf_DwQ_SQLAfter(Control acto_Child, ref string as_ColType, ref string as_Value, DwActions a_Action, ref string as_AddSQL, ref bool ab_IsAdd, DwQKinds a_Kind)
    {
		if (a_Action == DwActions.New)
		{
			if (acto_Child == dwQ_hmc101_type1)
			{
				dwQ_hmc101_type1_SelectedIndexChanged(null, EventArgs.Empty);
			}
		}
		else if (a_Action == DwActions.Set)
        {
            // 人員分類checkbox
            if (acto_Child == dwQ_hmc101_type)
            {
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
                    as_AddSQL += " AND hmc101_id in ( SELECT hmc101_102.hmc101_id From hmc101_102 Where hmc102_id in ( " + ls_value + " ) ) ";
                }
                return true;
            }

			if (acto_Child == dwQ_hmc101_type1)
			{
				if (dwQ_hmc101_type1.SelectedValue.Trim() != "Y")
				{
					as_AddSQL += " AND hmc101_id not in ( SELECT hmc101_102.hmc101_id From hmc101_102) ";
				}
			}

			if (acto_Child == dwQ_hmc101_stop_c)
			{
				if (dwQ_hmc101_stop_c.SelectedValue.Trim() != "ALL")
				{
					if (dwQ_hmc101_stop_c.SelectedValue.Trim() == "Y")
						as_AddSQL += " AND IsNull(hmc101_stop,'') = 'Y' ";
					else
						as_AddSQL += " AND IsNull(hmc101_stop,'') <> 'Y' ";
				}
				return true;
			}
        }
        return true;
    }

    // =========================================================================
    /// <summary>
    /// 事件描述：dgG 選擇某筆資料所要做的處理
    /// </summary>
    protected override void idgG_SelectedIndexChanged(object sender, EventArgs e)
    {
		this.uf_AddJavaScript("uf_LinkFrame('p_c0101_03.aspx', '03Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "') ; uf_LinkFrame('p_c0101_02.aspx', '02Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "') ; uf_SelectFrame(2);");
    }




    
}
