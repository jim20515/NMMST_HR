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

public partial class sys_d_d01_p_d0100_03 : p_hrBase
{

    #region ☆ Declare Variables -------------------------------------- 撰寫人員：QFLin

    /// <summary>變數描述：認識內含的課程代碼元件</summary>
    protected ndb_hmd100b indb_hmd100b = new ndb_hmd100b();

    /// <summary>變數描述：課程資料元件</summary>
    protected ndb_hmc101_102 indb_hmc101_102 = new ndb_hmc101_102();

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
            if (this.Request["args"] != null)     //0:tranid  1:tran_name
            {
                string[] lsa_Arguments = null;
                lsa_Arguments = this.Request["args"].Split('|');

                this.StoredKey = lsa_Arguments[0];             //職位代碼
                string CertiName = lsa_Arguments[1];        //職位名稱
                string BeloneS = lsa_Arguments[2];        //編制來源
                string PosNo = lsa_Arguments[3];        //職位數目
                ViewState["PosNo"] = PosNo;

                //DbMethods.uf_ExecSQL(" SELECT hmd100a_belon FROM hmd100a  WHERE hmd100a_posid = '" + this.StoredKey + "' ", ref BeloneS);

                indb_hmd100b.uf_Retrieve(" AND hmd100b_posid = '" + this.StoredKey + "' AND hmd100b_active = '1' ");

                dwF_name.Text = "【" + CertiName + "(" + this.StoredKey + ")】";
                dwF_belone.Text = (BeloneS == "E") ? "員工" : "志工";
                dwF_posno.Text = PosNo;

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

        lb_all.Items.Clear();
        lb_go.Items.Clear();

        indb_hmc101_102.uf_Retrieve(" AND hmc101_id not in (Select hmd100b_vid FROM hmd100b WHERE hmd100b_posid = '" + this.StoredKey + "' AND hmd100b_active = '1' ) AND hmc101_id in  ( Select hmc101_id FROM hmc101 Where hmc102_id ='" + ((dwF_belone.Text == "員工") ? "1" : "2") + "' ) ");
        if (indb_hmc101_102.uf_RowCount() > 0)
        {
            for (int li_row = 0; li_row < indb_hmc101_102.uf_RowCount(); li_row++)
            {
                lb_all.Items.Add(new ListItem(uf_Dg_Bind("hmc101", indb_hmc101_102[li_row]["hmc101_id"].ToString().Trim()) + " (" + indb_hmc101_102[li_row]["hmc101_id"] + ")", indb_hmc101_102[li_row]["hmc101_id"].ToString().Trim()));
            }
        }

        indb_hmc101_102.uf_Retrieve(" AND hmc101_id in (Select hmd100b_vid FROM hmd100b WHERE hmd100b_posid = '" + this.StoredKey + "'  AND hmd100b_active = '1'  ) AND hmc101_id in  ( Select hmc101_id FROM hmc101 Where hmc102_id ='" + ((dwF_belone.Text == "員工") ? "1" : "2") + "' ) ");
        if (indb_hmc101_102.uf_RowCount() > 0)
        {
            for (int li_row = 0; li_row < indb_hmc101_102.uf_RowCount(); li_row++)
            {
                lb_go.Items.Add(new ListItem(uf_Dg_Bind("hmc101", indb_hmc101_102[li_row]["hmc101_id"].ToString().Trim()) + " (" + indb_hmc101_102[li_row]["hmc101_id"] + ")", indb_hmc101_102[li_row]["hmc101_id"].ToString().Trim()));
            }
        }

    }

    protected void bt_toright_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        ListItem lli_Item;
        string ls_find = "", ls_show = "";

        if (lb_all.SelectedIndex > -1)
        {
            ls_find = lb_all.SelectedValue;
            lli_Item = lb_all.Items.FindByValue(ls_find);
            if (lli_Item != null)
            {
                // 幾時幾班需重算
                ls_show = uf_Dg_Bind("hmc101", lli_Item.Value) + " (" + lli_Item.Value + ")";
                lb_go.Items.Add(new ListItem(ls_show, lli_Item.Value));
                lb_all.Items.Remove(lli_Item);
            }
        }
        else
        {
            uf_Msg("請先選定成員！");
            return;
        }
    }

    protected void bt_toleft_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        ListItem lli_Item;
        string ls_find = "", ls_show = "";

        if (lb_go.SelectedIndex > -1)
        {
            ls_find = lb_go.SelectedValue;
            lli_Item = lb_go.Items.FindByValue(ls_find);
            if (lli_Item != null)
            {
                // 幾時幾班需重算
                ls_show = uf_Dg_Bind("hmc101", lli_Item.Value) + " (" + lli_Item.Value + ")";
                lb_all.Items.Add(new ListItem(ls_show, lli_Item.Value));
                lb_go.Items.Remove(lli_Item);
            }
        }
        else
        {
            uf_Msg("請先選定成員！");
            return;
        }

    }
    protected void bt_toreset_Click(object sender, EventArgs e)
    {
        Bind_lb_all();
    }

    protected void bt_confirm_Click(object sender, EventArgs e)
    {
        //判斷新增人數須小於編制人數
        if (ViewState["PosNo"] != null)
        {
            if (lb_go.Items.Count > Convert.ToInt16(ViewState["PosNo"]))
            {
                uf_Msg("編制人員為" + ViewState["PosNo"].ToString() + "人，任命人數不得超出！");
                return;
            }
        }

        // ##### 宣告變數 #####
        DataRowView ldrv_Row;

        indb_hmd100b.uf_Retrieve(" AND hmd100b_posid = '" + this.StoredKey + "' AND hmd100b_active = '1' ");
        indb_hmd100b.uf_Sort("hmd100b_vid");

        // 1. 刪除被管理者刪除的資料
        foreach (ListItem lli_Item in lb_all.Items)
        {
            int li_find = -1;
            li_find = indb_hmd100b.uf_FindSortIndex(lli_Item.Value);
            //若找到欲刪除的資料
            if (li_find > -1)
            {
                //更新記錄
                //DbMethods.uf_ExecSQL(" UPDATE hmd100b SET hmd100b_active = '0', hmd100b_tdt = getdate(), hmd100b_uid = '" + LoginUser.ID + "', hmd100b_udt =  getdate()  WHERE hmd100b_posid = '" + this.StoredKey + "'  AND hmd100b_vid ='" + lli_Item.Value + "' AND hmd100b_active = '1'");
                //DbMethods.uf_ExecSQL(" UPDATE hmd100b SET hmd100b_active = '0' ");
                indb_hmd100b[li_find]["hmd100b_active"] = "0";
                indb_hmd100b[li_find]["hmd100b_tdt"] = DbMethods.uf_GetDateTime();
                indb_hmd100b[li_find]["hmd100b_uid"] = LoginUser.ID;
                indb_hmd100b[li_find]["hmd100b_udt"] = DbMethods.uf_GetDateTime();
            }
        }

        // 2. 新增原本不存在的資料
        foreach (ListItem lli_Item in lb_go.Items)
        {
            int li_find = -1;
            li_find = indb_hmd100b.uf_FindSortIndex(lli_Item.Value);
            //若資料不存在
            if (li_find < 0)
            {
                this.indb_hmd100b.uf_InsertRow(out ldrv_Row);

                ldrv_Row["hmd100b_posid"] = this.StoredKey;
                ldrv_Row["hmd100b_belone"] = (dwF_belone.Text == "員工") ? "E" : "V";
                ldrv_Row["hmd100b_vid"] = lli_Item.Value;
                ldrv_Row["hmd100b_cname"] = uf_Dg_Bind("hmc101", lli_Item.Value);
                ldrv_Row["hmd100b_active"] = "1";
                ldrv_Row["hmd100b_sdt"] = DbMethods.uf_GetDateTime();
                ldrv_Row["hmd100b_aid"] = LoginUser.ID;
                ldrv_Row["hmd100b_adt"] = DbMethods.uf_GetDateTime();
                ldrv_Row["hmd100b_uid"] = LoginUser.ID;
                ldrv_Row["hmd100b_udt"] = DbMethods.uf_GetDateTime();

                ldrv_Row.EndEdit();
            }
        }

        // 儲存資料
        if (this.indb_hmd100b.uf_Update() != 1)
        {
            this.indb_hmd100b.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hmd100b.ErrorMsg);
            return;
        }
        else
        {
            Bind_lb_all();
            // 重新取出查詢及清單資料
            this.uf_AddJavaScript("parent.frames[2].__doPostBack('','');  uf_LinkFrame('p_d0100_02.aspx', '02Frame', '" + this.StoredKey + "'); ");
            this.uf_Msg("成員任命完成！");
        }

    }
}
