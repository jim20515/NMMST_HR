// *********************************************************************************
// 1. 程式描述：人力資源管理﹒基本資料檔管理﹒博物館之友管理﹒分類管理
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

public partial class sys_c_c01_p_c0102_01 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫會員：Emily

    /// <summary>變數描述：分類資料元件</summary>
    protected ndb_hmc102_g8 indb_hmc102_g8 = new ndb_hmc102_g8();
    /// <summary>變數描述：人員分類資料元件</summary>
    protected ndb_hmc102 indb_hmc102 = new ndb_hmc102();

    #endregion

    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        indb_hmc102_g8.uf_Retrieve(" AND (G1 IS NULL) AND (G8 IS NULL) ORDER BY G3,G4");
        indb_hmc102_g8.dv_View = indb_hmc102_g8.ds_Data.Tables[0].DefaultView;

        dgG.DataBind();
    }

    protected string uf_get_id(object ao_g)
    {
        int ls_return = 0;
        int li_index = -1;

        if (ao_g != null)
        {
            li_index = ao_g.ToString().IndexOf("_o_");
            if (li_index > -1)
            {
                ls_return = Convert.ToInt16(ao_g.ToString().Substring(0, li_index)); ;
            }
        }
        return Convert.ToString(ls_return);
    }

    protected string uf_get_name(object ao_g)
    {
        string ls_return = "";
        int li_index = -1;

        if (ao_g != null)
        {
            li_index = ao_g.ToString().IndexOf("_o_");
            if (li_index > -1)
            {
                ls_return = ao_g.ToString().Substring(li_index + 3, ao_g.ToString().Length - li_index - 3);
            }
        }
        return ls_return;
    }

    protected bool uf_visible(object ao_value, object ao_col, object ao_index)
    {
        bool lb_return = false;
        int li_index = 0;
        string ls_col = "";

        if (ao_value != null && ao_value.ToString() != "" && ao_col != null && ao_index != null)
        {
            li_index = Convert.ToInt16(ao_index);
            ls_col = Convert.ToString(ao_col);
            // 若重複則不顯示
            if (li_index > 0)
            {
                if (indb_hmc102_g8[li_index][ls_col].ToString() != indb_hmc102_g8[li_index - 1][ls_col].ToString())
                    lb_return = true;
            }
            else
                lb_return = true;
        }
        return lb_return;
    }

    protected bool uf_get_enable(object ao_value)
    {
        bool lb_return = false;
        string ls_id = uf_get_id(ao_value);

        if (ls_id != "")
        {
            indb_hmc102.uf_Retrieve(" AND hmc102_id = '" + ls_id + "' AND hmc102_blocked = 'N' ");
            if (indb_hmc102.uf_RowCount() > 0)
            {
                lb_return = true;
            }
        }
        return lb_return;
    }

    protected void dgG_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "") return;

        string ls_id = "";

        ls_id = uf_get_id(((Label)dgG.Items[e.Item.ItemIndex].FindControl(e.CommandName)).Text);

        this.uf_AddJavaScript("uf_LinkFrame('p_c0102_02.aspx', '02Frame', '" + ls_id + "')");
    }
}
