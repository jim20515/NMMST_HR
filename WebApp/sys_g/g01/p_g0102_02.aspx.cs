﻿// *********************************************************************************
// 1. 程式描述：
// 2. 撰寫人員：Generated by WITSETER (by QFLin)
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

public partial class sys_g_g01_p_g0102_02 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：WITSETER (by QFLin)

    /// <summary>變數描述：人員類別資料元件</summary>
    protected ndb_hmf102 indb_hmf102 = new ndb_hmf102();

    #endregion

    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        // 初始化
        //this.uf_InitializeQuery(null, this.indb_hmf102, null);
        //this.uf_InitializeComponent(dwF, null, this.indb_hmf102, u_Edit_F);
        //this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
        //this.IsQuery_SessionRemove = false;

        // 註冊執行事件
        this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
        this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        this.ue_DataDelete_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)
                this.StoredKey = this.Request["args"].Trim();

            // 將頁面切換到此頁
            this.uf_AddJavaScript("uf_SelectFrame(2);");

            int li_count = 0;
            DbMethods.uf_ExecSQL(" SELECT count(*) FROM hmg101a as A join hmg101b as B on A.hmg101a_kid = B.hmg101b_kid WHERE A.hmg101a_kid = '" + this.StoredKey + "' ", ref li_count);
            dwF_vcount.Text = "" + li_count.ToString() + " 人";

            string StrName = "";
            DbMethods.uf_ExecSQL("SELECT hmg101a_name FROm hmg101a WHERE hmg101a_kid = '" + this.StoredKey + "' ", ref StrName);
            dwF_name.Text = "【" + StrName + "】";

            //SELECT hmg101a_syear, (hmg101a_ktype + hmg101a_sseason) as KT FROm hmg101a;

            int StrYY = 0;
            DbMethods.uf_ExecSQL("SELECT CAST(hmg101a_syear as int) + 1911 as KT FROm hmg101a WHERE hmg101a_kid = '" + this.StoredKey + "' ", ref StrYY);
            dwF_ktype.Text = "【" + Convert.ToString((StrYY -1911)) + "】";

            string StrKind = "";
            DbMethods.uf_ExecSQL("SELECT (hmg101a_ktype + hmg101a_sseason) FROm hmg101a WHERE hmg101a_kid = '" + this.StoredKey + "' ", ref StrKind);

            DateTime dtS, dtE;

            dtS = Convert.ToDateTime("" + Convert.ToString(StrYY) + "/01/01 00:00:00");
            dtE = Convert.ToDateTime("" + Convert.ToString(StrYY) + "/12/31 23:59:59");



            switch (StrKind)
            {
                case "10":
                    dwF_ktype.Text = "【實習志工考核】";
                    break;

                case "21":
                    dwF_ktype.Text = "【志工第一季季考核】";
                    dtS = Convert.ToDateTime("" + Convert.ToString(StrYY)+ "/01/01 00:00:00");
                    dtE = Convert.ToDateTime("" + Convert.ToString(StrYY)+ "/03/31 23:59:59");
                    break;

                case "22":
                    dwF_ktype.Text = "【志工第二季季考核】";
                    dtS = Convert.ToDateTime("" + Convert.ToString(StrYY)+ "/04/01 00:00:00");
                    dtE = Convert.ToDateTime("" + Convert.ToString(StrYY)+ "/06/30 23:59:59");
                    break;

                case "23":
                    dwF_ktype.Text = "【志工第三季季考核】";
                    dtS = Convert.ToDateTime("" + Convert.ToString(StrYY)+ "/07/01 00:00:00");
                    dtE = Convert.ToDateTime("" + Convert.ToString(StrYY)+ "/09/30 23:59:59");
                    break;

                case "30":
                    dwF_ktype.Text = "【志工年考核】";
                    break;

                default:
                    dwF_ktype.Text = "【Error】";
                    break;
            }

            ViewState["dtS"] = dtS.ToString("yyyy/MM/dd HH:mm:ss");
            ViewState["dtE"] = dtE.ToString("yyyy/MM/dd HH:mm:ss");

            dwF_KTime.Text = "【" + dtS.ToString("yyyy/MM/dd HH:mm:ss") + "~" + dtE.ToString("yyyy/MM/dd HH:mm:ss") + "】";

            //Button1.Attributes["OnClick"] = "window.open('../../app_doc/Report_g0102.xls')";
            //Button3.Attributes["OnClick"] = "window.open('../../app_doc/form_g0102.doc')";

            // 將主鍵值記錄為尋找資料的條件
            //this.dgG_FindValue = new object[1];
            //this.dgG_FindValue[0] = this.StoredKey;
        }
    }
    // =========================================================================
    /// <summary>
    /// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（新增）
    /// </summary>
    private bool u_Edit_F_PreEndEdit(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
    {
        return true;
    }

    // =========================================================================
    /// <summary>
    /// 事件描述：按下 u_Edit_F 按鈕資料儲存之後所做的處理（新增、修改、刪除）
    /// </summary>
    private bool u_Edit_F_AfterSave(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
    {
        // 重新取出查詢及清單資料
        this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); uf_SelectFrame(1);");
        return true;
    }

    #region ☆ Override Methods --------------------------------------- 撰寫人員：fen

    // =========================================================================
    /// <summary>
    /// 函式描述：資料控制項容器做相關處理之後針對特殊或不能處理的子控制項做相關處理（覆蓋上層）
    /// </summary>
    /// <param name="acto_Child">資料控制項容器上的子控制項</param>
    /// <param name="as_Value">子控制項對應欄位的值(如為取出則沒去空白)</param>
    /// <param name="a_Action">處理種類–新增(New)；取出(Get)；放入(Set)；繫結(Bind)</param>
    /// <param name="adrv_Row">當筆資料列</param>
    /// <returns>成功(true)；失敗(false)</returns>
    protected override bool uf_DwF_DataAfter(Control acto_Child, ref string as_Value, DwActions a_Action, DataRowView adrv_Row)
    {
        if (a_Action == DwActions.New || a_Action == DwActions.Get)
        {
            // 是否停用
            if (acto_Child == dwF_vcount)
            {
                int li_count = 0;
                DbMethods.uf_ExecSQL(" SELECT count(*) FROM hmg101a as A join hmg101b as B on A.hmg101a_kid = B.hmg101b_kid WHERE A.hmg101a_kid = '" + this.StoredKey + "' ", ref li_count);
                dwF_vcount.Text = "" + li_count.ToString() + " 人";
                return true;
            }
        }

        return true;
    }

    #endregion

    protected void bt_report1_Click(object sender, EventArgs e)
    {
        this.uf_AddJavaScript("uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_uctrl/p_render.aspx?path=" + "/NMMST_HR_Report/rs_g0102_1&format=PDF&query=kid=" + this.StoredKey + ";adt_s=" + ViewState["dtS"].ToString() + ";adt_e=" + ViewState["dtE"].ToString() + "','',1024,768,'no','no');");
    }
    protected void bt_report2_Click(object sender, EventArgs e)
    {
        this.uf_AddJavaScript("uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_uctrl/p_render.aspx?path=" + "/NMMST_HR_Report/rs_g0102_2&format=PDF&query=kid=" + this.StoredKey + ";adt_s=" + ViewState["dtS"].ToString() + ";adt_e=" + ViewState["dtE"].ToString() + "','',1024,768,'no','no');");
    }
}
