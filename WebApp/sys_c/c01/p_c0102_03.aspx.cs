
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

public partial class sys_c_c01_p_c0102_03 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫會員：Emily

    /// <summary>變數描述：分類資料元件</summary>
    protected ndb_hmc102_g8 indb_hmc102_g8 = new ndb_hmc102_g8();
    /// <summary>變數描述：人員分類資料元件</summary>
    protected ndb_hmc101_102 indb_hmc101_102 = new ndb_hmc101_102();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)
                this.StoredKey = this.Request["args"].Trim();

            if (this.StoredKey != "")
            {
                this.dgG_Retrieve = " AND hmc101_id = '" + this.StoredKey + "' ";
                indb_hmc101_102.uf_Retrieve(dgG_Retrieve);

                indb_hmc102_g8.uf_Retrieve(" AND G1 is NULL AND G8 is Null ");
                indb_hmc102_g8.uf_Sort("G2,G3");
                dgG.DataBind();
            }

            // 將頁面切換到此頁
            this.uf_AddJavaScript("uf_SelectFrame(3);uf_SelectFrame(2);");
        }
        uf_dgG_CheckRetrieve();
	}

    // =========================================================================
	/// <summary>
	/// 函式描述：勾選後，一併勾選上層
	/// </summary>
    private void uf_dgG_CheckRetrieve()
    {
        DataRowView ldrv_Row;

        // 先將資料全部刪除
        indb_hmc101_102.uf_Retrieve(dgG_Retrieve);
        indb_hmc101_102.uf_DeleteRowAll();

        string ls_id = "";

        for (int li_g = 6; li_g >= 2; li_g--)
        {
            for (int li_count = 0; li_count < dgG.Items.Count; li_count++)
            {
                if (!(((CheckBox)dgG.Items[li_count].FindControl("cb_g" + li_g.ToString())).Checked && ((CheckBox)dgG.Items[li_count].FindControl("cb_g" + li_g.ToString())).Visible) ) continue;

                ls_id = uf_get_id(((Label)dgG.Items[li_count].FindControl("lb_g" + li_g.ToString())).Text);

                indb_hmc101_102.uf_Filter(" hmc101_id = '" + this.StoredKey + "' AND hmc102_id = '" + ls_id + "' ");
                if( indb_hmc101_102.uf_RowCount() <= 0 )
                {
                    this.indb_hmc101_102.uf_InsertRow(out ldrv_Row);

                    ldrv_Row["hmc102_id"] = Convert.ToInt16(ls_id);
                    ldrv_Row["hmc101_id"] = this.StoredKey;
                    ldrv_Row.EndEdit();
                }

                while (true)
                {
                    int li_parent = -1;

                    //新增上層
                    DbMethods.uf_ExecSQL(" SELECT hmc102_parentid From hmc102 WHERE hmc102_id = '" + ls_id + "'", ref li_parent);

                    if (li_parent >= 0)
                    {
                        indb_hmc101_102.uf_Filter(" hmc101_id = '" + this.StoredKey + "' AND hmc102_id = '" + li_parent.ToString() + "' ");
                        if (indb_hmc101_102.uf_RowCount() <= 0)
                        {
                            this.indb_hmc101_102.uf_InsertRow(out ldrv_Row);

                            ldrv_Row["hmc102_id"] = li_parent;
                            ldrv_Row["hmc101_id"] = this.StoredKey;
                            ldrv_Row.EndEdit();
                        }
                        ls_id = li_parent.ToString();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        indb_hmc101_102.uf_Filter("");
        indb_hmc102_g8.uf_Retrieve(" AND G1 is NULL AND G8 is Null ");
        indb_hmc102_g8.uf_Sort("G2,G3");
        dgG.DataBind();
    }
   
    protected string uf_get_name( object ao_g )
    {
        string ls_return = "";
        int li_index = -1;

        if (ao_g != null)
        {
            li_index = ao_g.ToString().IndexOf("_o_");
            if (li_index > -1)
            {
                ls_return = ao_g.ToString().Substring(0, li_index);
            }
        }
        return ls_return;
    }

    protected string uf_get_id(object ao_g)
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

    protected bool uf_visible(object ao_value , object ao_col , object ao_index)
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

    protected bool uf_get_check(object ao_value)
    {
        bool lb_return = false;
        string ls_id = uf_get_id(ao_value);

        if (ls_id != "")
        {
            indb_hmc101_102.uf_Filter(" hmc102_id = '" + ls_id + "' ");
            if (indb_hmc101_102.uf_RowCount() > 0)
            {
                lb_return = true;
            }
            this.indb_hmc101_102.uf_Filter("");
        }
        return lb_return;
    }

    protected void bt_confirm_Click(object sender, EventArgs e)
    {
        // 儲存資料
        if (this.indb_hmc101_102.uf_Update() != 1)
        {
            this.indb_hmc101_102.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hmc101_102.ErrorMsg);
            return;
        }
        else
        {
            this.uf_Msg("修改人員分類完成！");
        }
    }
}
