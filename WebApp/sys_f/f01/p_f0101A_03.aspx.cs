// *********************************************************************************
// 1. 程式描述：
// 2. 撰寫人員：QFLin
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

public partial class sys_f_f01_p_f0101A_03 : p_hrBase
{


    #region ☆ Declare Variables -------------------------------------- 撰寫人員：QFLin

    /// <summary>變數描述：認識內含的課程代碼元件</summary>
    protected ndb_hmf101b indb_hmf101b = new ndb_hmf101b();

    /// <summary>變數描述：課程資料元件</summary>
    protected ndb_hmf101 indb_hmf101 = new ndb_hmf101();

    #endregion

    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        // 初始化

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)   //0:hmf101a_certid  1:hmf101a_name
            {
                string[] lsa_Arguments = null;
                lsa_Arguments = this.Request["args"].Split('|');

                this.StoredKey = lsa_Arguments[0];        //認證編號
                string CertiName = lsa_Arguments[1];   //認證名稱

                indb_hmf101b.uf_Retrieve(" AND hmf101b_certid = '" + this.StoredKey + "' ");

                dwF_name.Text = "【" + CertiName + "(" + this.StoredKey + ")】";
                Bind_lb_all();

                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(2);");

            }
        }


    }

    protected void uf_ShowBt(bool ab_show)
    {
        bt_confirm.Enabled = ab_show;
        bt_toreset.Enabled = ab_show;
        bt_toright.Enabled = ab_show;
        bt_toleft.Enabled = ab_show;
    }

    protected void Bind_lb_all()
    {
        // ##### 宣告變數 #####
        string ls_show = "";
        int li_pc = 0, li_ts = 0, li_hour = 0;
        TimeSpan lts_period;

        lb_all.Items.Clear();
        lb_go.Items.Clear();

            indb_hmf101.uf_Retrieve(" AND hmf101_courseid not in ( Select hmf101b_courseid From hmf101b Where hmf101b_certid = '" + this.StoredKey + "' ) ");
            if (indb_hmf101.uf_RowCount() > 0)
            {
                for (int li_row = 0; li_row < indb_hmf101.uf_RowCount(); li_row++)
                {
                    lb_all.Items.Add(new ListItem(uf_Dg_Bind("hmf101", indb_hmf101[li_row]["hmf101_courseid"].ToString().Trim()) + " (" + indb_hmf101[li_row]["hmf101_courseid"] + ")", indb_hmf101[li_row]["hmf101_courseid"].ToString().Trim()));
                }
            }

            indb_hmf101.uf_Retrieve(" AND hmf101_courseid in ( Select hmf101b_courseid From hmf101b Where hmf101b_certid = '" + this.StoredKey + "' ) ");
            if (indb_hmf101.uf_RowCount() > 0)
            {
                for (int li_row = 0; li_row < indb_hmf101.uf_RowCount(); li_row++)
                {
                    lb_go.Items.Add(new ListItem(uf_Dg_Bind("hmf101", indb_hmf101[li_row]["hmf101_courseid"].ToString().Trim()) + " (" + indb_hmf101[li_row]["hmf101_courseid"] + ")", indb_hmf101[li_row]["hmf101_courseid"].ToString().Trim()));
                }
            }

    }

    protected void bt_toright_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        ListItem lli_Item;
        string ls_find = "", ls_show = "";
        int li_pc = 0, li_ts = 0;

        if (lb_all.SelectedIndex > -1)
        {
            ls_find = lb_all.SelectedValue;
            lli_Item = lb_all.Items.FindByValue(ls_find);
            if (lli_Item != null)
            {
                // 幾時幾班需重算
                ls_show = uf_Dg_Bind("hmf101", lli_Item.Value) + " (" + lli_Item.Value + ")";
                lb_go.Items.Add(new ListItem(ls_show, lli_Item.Value));
                lb_all.Items.Remove(lli_Item);
            }
        }
        else
        {
            uf_Msg("請先選定課程！");
            return;
        }
    }

    protected void bt_toleft_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        ListItem lli_Item;
        string ls_find = "", ls_show = "";
        int li_pc = 0, li_ts = 0;

        if (lb_go.SelectedIndex > -1)
        {
            ls_find = lb_go.SelectedValue;
            lli_Item = lb_go.Items.FindByValue(ls_find);
            if (lli_Item != null)
            {
                // 幾時幾班需重算
                ls_show = uf_Dg_Bind("hmf101", lli_Item.Value) + " (" + lli_Item.Value + ")";
                lb_all.Items.Add(new ListItem(ls_show, lli_Item.Value));
                lb_go.Items.Remove(lli_Item);
            }
        }
        else
        {
            uf_Msg("請先選定課程！");
            return;
        }

    }
    protected void bt_toreset_Click(object sender, EventArgs e)
    {
        Bind_lb_all();
    }

    protected void bt_confirm_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        DataRowView ldrv_Row;

        indb_hmf101b.uf_Retrieve(" AND hmf101b_certid = '" + this.StoredKey + "' ");
        indb_hmf101b.uf_Sort("hmf101b_courseid");

        // 1. 刪除被管理者刪除的資料
        foreach (ListItem lli_Item in lb_all.Items)
        {
            int li_find = -1;
            li_find = indb_hmf101b.uf_FindSortIndex(lli_Item.Value);
            //若找到欲刪除的資料
            if (li_find > -1)
            {
                indb_hmf101b.uf_DeleteRow(li_find);
            }
        }

        // 2. 新增原本不存在的資料
        foreach (ListItem lli_Item in lb_go.Items)
        {
            int li_find = -1;
            li_find = indb_hmf101b.uf_FindSortIndex(lli_Item.Value);
            //若資料不存在
            if (li_find < 0)
            {
                this.indb_hmf101b.uf_InsertRow(out ldrv_Row);

                ldrv_Row["hmf101b_certid"] = this.StoredKey;
                ldrv_Row["hmf101b_courseid"] = lli_Item.Value;
                ldrv_Row["hmf101b_aid"] = LoginUser.ID;
                ldrv_Row["hmf101b_adt"] = DbMethods.uf_GetDateTime();
                ldrv_Row["hmf101b_uid"] = LoginUser.ID;
                ldrv_Row["hmf101b_udt"] = DbMethods.uf_GetDateTime();

                ldrv_Row.EndEdit();
            }
        }

        // 儲存資料
        if (this.indb_hmf101b.uf_Update() != 1)
        {
            this.indb_hmf101b.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hmf101b.ErrorMsg);
            return;
        }
        else
        {
            Bind_lb_all();
            // 重新取出查詢及清單資料
            this.uf_AddJavaScript("parent.frames[2].__doPostBack('','');  uf_LinkFrame('p_f0101A_02.aspx', '02Frame', '" + this.StoredKey + "'); ");
            this.uf_Msg("課程編輯完成！");
        }

    }
}
