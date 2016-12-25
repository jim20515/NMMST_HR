
// *********************************************************************************
// 1. 程式描述：系統公告管理–系統公告
// 2. 撰寫人員：
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

public partial class sys_d_d02_p_d0201_05 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：Linda


	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        this.IsQuery_SessionRemove = false;

        this.Bt_Leave.Attributes["OnClick"] = "if (! confirm('是否確定要離隊? ')) return false;";
        this.Bt_Back.Attributes["OnClick"] = "if (! confirm('是否確定要歸隊? ')) return false;";
        dwQ_year.Attributes["onBlur"] = "uf_GetNumeric(" + dwQ_year.ClientID + ");";

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)
            {
                this.StoredKey = this.Request["args"].Trim();
            }

            string ax = "";
            DbMethods.uf_ExecSQL(" SELECT hmd201_cname FROM hmd201  WHERE hmd201_vid = '" + this.StoredKey + "' ", ref ax);
            dwF_hmd201_vid.Text = ax + "(" + this.StoredKey + ")";

            string cx1 = "";
            DbMethods.uf_ExecSQL(" SELECT hca206_name FROM  hca206 WHERE  hca206_id IN ( SELECT hmd201_lvid FROM hmd201 WHERE hmd201_vid = '" + this.StoredKey + "')", ref cx1);
            dwF_Lv.Text = cx1;
			// add by rong 2009/09/08
			string ls_work_year = "0";
			DbMethods.uf_ExecSQL("SELECT cast(dbo.uf_getvyearplus(hmd201_vid) as char) FROM hmd201 WHERE hmd201_vid ='" + this.StoredKey.ToString().Trim() + "'", ref ls_work_year);
			dwF_TotalYear.Text = "共" + ls_work_year + "年";
            uf_ShowStatus();
			Dbcfg.uf_Bind(DDL_Reason, "hca208_c", "", "", true);
            dwQ_year.Text = Convert.ToString(DateTime.Now.Year - 1911).PadLeft(3, '0');

            this.bt_Query_Click(this, EventArgs.Empty);

            // 將頁面切換到此頁
            //this.uf_AddJavaScript("uf_SelectFrame(2);");
        }		
	}

    protected void uf_ShowStatus()
    {
        string cx2 = "";
        DbMethods.uf_ExecSQL(" SELECT hca207_name FROM  hca207 WHERE  hca207_id IN ( SELECT hmd201_status FROM hmd201 WHERE hmd201_vid = '" + this.StoredKey + "')", ref cx2);
        dwF_Stutas.Text = cx2;
        if (dwF_Stutas.Text.Trim() == "離隊")
        {
            Bt_Leave.Enabled = false;
            Bt_Back.Enabled = true;
        }
        else if (dwF_Stutas.Text.Trim() == "正常")
        {
            Bt_Back.Enabled = false;
            Bt_Leave.Enabled = true;
        }

    }


    protected void Bt_Leave_Click(object sender, EventArgs e)
    {
        DbMethods.uf_ExecSQL(" UPDATE hmd201 SET hmd201_status = '2'  WHERE hmd201_vid ='" + this.StoredKey + "'");
        DbMethods.uf_ExecSQL(" INSERT INTO hld201(hld201_vid, hld201_logtype, hld201_logdate,hld201_ps,hld201_aid,hld201_adt,hld201_uid,hld201_udt) VALUES('" + this.StoredKey + "','L',getdate(),'" + DDL_Reason.Text + "','user',getdate(),'user',getdate())");
        uf_ShowStatus();
    }

    protected void Bt_Back_Click(object sender, EventArgs e)
    {
        DbMethods.uf_ExecSQL(" UPDATE hmd201 SET hmd201_status = '1'  WHERE hmd201_vid ='" + this.StoredKey + "'");
        DbMethods.uf_ExecSQL(" INSERT INTO hld201(hld201_vid, hld201_logtype, hld201_logdate,hld201_ps,hld201_aid,hld201_adt,hld201_uid,hld201_udt) VALUES('" + this.StoredKey + "','B',getdate(),'" + DDL_Reason.Text + "','user',getdate(),'user',getdate())");
        uf_ShowStatus();
    }

    protected void bt_Query_Click(object sender, EventArgs e)
    {
        if (dwQ_year.Text.Trim() == "")
        {
            uf_Msg("請輸入年度！");
            return;
        }

        string cx3 = "";
        DbMethods.uf_ExecSQL(" SELECT Isnull(CAST(Round(SUM(hme101c_onduty),1) as varchar(10)),'0') FROM hme101c WHERE hme101c_vid ='" + this.StoredKey + "' ", ref cx3);
        dwF_TotalHours.Text = "總累積時數 " + cx3 + " 小時";

        string cx4 = "";
        DbMethods.uf_ExecSQL(" SELECT Isnull(CAST(Round(SUM(hme101c_onduty),1) as varchar(10)),'0') FROM hme101c WHERE hme101c_vid ='" + this.StoredKey + "' AND hme101c_pdid IN (SELECT hme101b_pdid FROM hme101b WHERE hme101b_sdate >= (SELECT hmd201_lappdt FROM hmd201 WHERE hmd201_vid ='" + this.StoredKey + "'))", ref cx4);
        dwF_TotalFromThatDay.Text = "最近榮譽卡申請後累積 " + cx4 + " 小時";

        string ct5 = "";
        DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(THours),1) as varchar(10)) as Total FROM hme101bc WHERE vid ='" + this.StoredKey + "'AND NOT(Onduty is null) AND year(SDT) = (CAST('" + dwQ_year.Text + "'  as int)+1911) ", ref ct5);
        if (ct5 == "")
        {
            ct5 = "0_0_0";
        }
        string[] ctX = ct5.Split('_');
        dwF_ThisYear1.Text = "應服務 " + ctX[2] + " 小時,  實際服務 " + ctX[0] + " 小時";
        string percentage = "";
        if (ctX[2] == "0")
        {
            percentage = "0";
        }
        else
        {
            percentage = Convert.ToString(Math.Round((Double.Parse(ctX[1], System.Globalization.NumberStyles.Float) * 100) / Double.Parse(ctX[2], System.Globalization.NumberStyles.Float), 1));
        }

        dwF_ThisYear2.Text = "缺席 " + ctX[1] + "小時, 缺席率為 " + percentage + "%";

        string cx6 = "";
        DbMethods.uf_ExecSQL(" SELECT CAST(count(*) as varchar(10)) FROM hme101c WHERE hme101c_vid ='" + this.StoredKey + "' AND hme101c_pdid IN (SELECT hme101b_pdid FROM hme101b WHERE year(hme101b_sdate) =(CAST('" + dwQ_year.Text + "'  as int)+1911) )", ref cx6);
        dwF_ThisYear3.Text = "共服務 " + cx6 + " 次";
    }
}
