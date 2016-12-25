// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排轉正式班表–指定班表
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

public partial class sys_d_d02_p_d0201_06 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：Linda

    /// <summary>變數描述：排班表需求班次資料元件</summary>
    protected ndb_hlg203 indb_hlg203 = new ndb_hlg203();
    protected ndb_hmd100b indb_hmd100b = new ndb_hmd100b();

    #endregion


    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
		this.IsQuery_SessionRemove = false;
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)
            {
                this.StoredKey = this.Request["args"].Trim();
            }
        }
        uf_BindDgG();
    }

    private void uf_BindDgG()
    {
        string ax = "";
        DbMethods.uf_ExecSQL(" SELECT hmd201_cname FROM hmd201  WHERE hmd201_vid = '" + this.StoredKey + "' ", ref ax);
        dwG_ShowMsg.Text = ax + "(" + this.StoredKey + ")";

        string ax1 = "";
        DbMethods.uf_ExecSQL(" SELECT hmd201_id FROM hmd201  WHERE hmd201_vid = '" + this.StoredKey + "' ", ref ax1);

        dwG_msg1.Text = "◎得獎紀錄";
        dwG_msg2.Text = "◎幹部紀錄";

        indb_hlg203.uf_Retrieve(" AND hlg203_vid = '" + this.StoredKey + "' ");
        //indb_hmd100b.uf_Retrieve(" AND hmd100b_vid = '" + this.StoredKey + "' ");

        DataSet ds_type;
        DataView dv_type;

        DbMethods.uf_Retrieve_FromSQL(out ds_type, @" select ( Case When Rtrim(Isnull(hmc101_deptid,'')) = '' THEN ( SELECT TOP 1 hmd101_tname From hmd101 Where hmd101_tid in (Select hmd201_tid From hmd201 where hmd201_id = hmc101_id)  ) ELSE ( Select hca202_name from hca202 where hca202_id = hmc101_deptid ) END  ) as depname , *  from hmd100b 
                                                        Inner Join hmd100a 
                                                        ON hmd100b_posid = hmd100a_posid
                                                        Inner Join hmc101 ON hmd100b_vid = hmc101_id
                                                         WHERE hmd100b_vid = '" + ax1 + "' ");
        dv_type = ds_type.Tables[0].DefaultView;
        dv_type.Sort = "hmd100b_sdt desc , hmd100b_tdt desc";

        indb_hlg203.uf_Sort("hlg203_mdate desc");
        indb_hmd100b.uf_Sort("hmd100b_sdt desc , hmd100b_tdt desc");

        dgG1.DataBind();
        dgG2.DataSource = dv_type;
        dgG2.DataBind();
    }
   
}
