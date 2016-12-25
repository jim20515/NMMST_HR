// *********************************************************************************
// 1. 程式描述：服務勤務管理–勤務紀錄管理–查詢及清單
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
using System.IO;

public partial class sys_e_e02_p_e0201_01 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：WITSETER (QFLin)

	/// <summary>變數描述：資料元件</summary>
	protected ndb_hle201 indb_hle201 = new ndb_hle201();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	
	protected void Page_Load(object sender, EventArgs e)
    {
		// 初始化
		this.uf_InitializeQuery(dwQ, this.indb_hle201, bt_Query);
		this.uf_InitializeComponent(null, dgG, this.indb_hle201, null);
		this.dgG_Sort = "hle201_vid , hle201_sdatetime desc";

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            u_Date1.Value = DbMethods.uf_GetDate().ToString();
            u_Date2.Value = DbMethods.uf_GetDate().ToString();
        }
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：dgG 選擇某筆資料所要做的處理
	/// </summary>
	protected override void idgG_SelectedIndexChanged(object sender, EventArgs e)
    {
		this.uf_AddJavaScript("uf_LinkFrame('p_e0201_02.aspx', '02Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "')");
	}

    // =========================================================================
    /// <summary>
    /// 函式描述：資料控制項容器控制項組合出查詢語法之後針對特殊或不能處理的子控制項再修改組合出的查詢語法（一個控制項處理一次）（覆蓋上層）
    /// </summary>
    /// <param name="acto_Child">資料控制項容器上的子控制項</param>
    /// <param name="as_ColType">子控制項對應欄位的型態種類–清空時(空字串)；字串等於(S)；字串相似(SL)；日期時間(DT)；日期(D)；時間(T)；數值(N)</param>
    /// <param name="as_Value">子控制項對應欄位的值(已去空白)–傳入的值已處理不安全內容，如有變更需自行確認其安全性</param>
    /// <param name="a_Action">處理種類–清空(New)；查詢(Set)</param>
    /// <param name="as_AddSQL">清空(New)為空字串；查詢(Set)則傳入之前組合出的查詢語法(尚未加入此控制項語法)</param>
    /// <param name="ab_IsAdd">是否加入此控制項語法或參數–是(true)；否(false)</param>
    /// <param name="a_Kind">資料查詢種類–語法(AddSQL)；參數(AddArg)</param>
    /// <returns>成功(true)；失敗(false)</returns>
    protected override bool uf_DwQ_SQLAfter(Control acto_Child, ref string as_ColType, ref string as_Value, DwActions a_Action, ref string as_AddSQL, ref bool ab_IsAdd, DwQKinds a_Kind)
    {
        if (a_Action == DwActions.Set)
        {
            // 人員姓名
            if (acto_Child == dwQ_hle201_vname)
            {
                if (dwQ_hle201_vname.Text.Trim() != "")
                {
                    as_AddSQL += " AND hle201_vid in ( SELECT Hmd201_vid From Hmd201 Where Hmd201_id in ( Select hmc101_id From hmc101 where hmc101_cname like '%" + dwQ_hle201_vname.Text.Trim() + "%') ) ";
                }
                return true;
            }

            // 志工隊
            if (acto_Child == dwQ_hle201_tid)
            {
                if (dwQ_hle201_tid.SelectedValue != "")
                {
                    as_AddSQL += " AND hle201_vid in ( SELECT Hmd201_vid From Hmd201 Where hmd201_tid = '" + dwQ_hle201_tid.SelectedValue + "' ) ";
                }
                return true;
            }

            // 刷卡時間-起
            if (acto_Child == dwQ_hle201_sdatetime_s)
            {
                if (u_Date1.Value != "")
                {
                    as_AddSQL += " AND hle201_sdatetime >= '" + u_Date1.Value + "' ";
                }
                return true;
            }

            // 刷卡時間-迄
            if (acto_Child == dwQ_hle201_sdatetime_e)
            {
                if (u_Date2.Value != "")
                {
                    as_AddSQL += " AND hle201_sdatetime < DateAdd(dd , 1 , CAST ('" + u_Date2.Value + "' as datetime)) ";
                }
                return true;
            }

        }
        return true;
    }

	protected void bt_Print_Click(object sender, EventArgs e)
	{
		if (dgG.Items.Count == 0)
		{
			uf_Msg("請先查詢出資料再進行列印！");
			return;
		}
        this.uf_AddJavaScript("uf_LinkFrame('p_e0201_01_xls.aspx', '01Frame','" + dwQ_hle201_vname.Text.Trim() + "|" + dwQ_hle201_vid.Text.Trim() + "|" + dwQ_hle201_tid.SelectedValue + "|" + u_Date1.Value + "|" + u_Date2.Value + "')");
      ////這不行  this.uf_AddJavaScript("window.open(\"" + this.Request.ApplicationPath + "/sys_e/e02/p_e0201_01_xls.aspx);");
        //WExcel myexcel = new WExcel();
        //// ##### 宣告變數 #####
        //string ls_key = "E0201_" + DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        //string ls_root = this.Request.PhysicalApplicationPath;
        //string ls_dir = "App_Data\\File";
        //string ls_fileName = ls_key + ".xls";
        //string ls_file = ls_root + ls_dir + "\\" + ls_fileName;
        //string ls_msg = "";
        //string ls_report = "E0201.xls";

        //ls_msg = myexcel.uf_Open(Server.MapPath(Request.ApplicationPath) + @"\App_Data\Report\" + ls_report + "", WExcel.FileMode.OpenOrCreate, ls_file, "刷卡資料匯出", 6, 0, 0, null, 1, 1, 1);

        //string[] lsa_value = new string[6];

        //for (int i = 0; i < dgG.Items.Count; i++)
        //{

        //    lsa_value[0] = ((Label)dgG.Items[i].FindControl("dwG_hmd201_bookid_c")).Text;
        //    lsa_value[1] = ((Label)dgG.Items[i].FindControl("dwG_hle201_vid_c")).Text;
        //    lsa_value[2] = ((Label)dgG.Items[i].FindControl("dwG_hle201_sdatetime_c")).Text;
        //    lsa_value[3] = ((Label)dgG.Items[i].FindControl("dwG_hle201_type_c")).Text;
        //    lsa_value[4] = ((Label)dgG.Items[i].FindControl("dwG_hle201_cancel_c")).Text;
        //    lsa_value[5] = ((Label)dgG.Items[i].FindControl("dwG_hle201_cway_c")).Text;
        //    myexcel.uf_InsertRow(lsa_value);
        //}


        ////------------------------------------------
        //ls_msg = myexcel.uf_Save();

        //// 將檔案內容讀入 Application 中
        //this.Application[ls_key] = File.ReadAllBytes(ls_file);
        //this.Application["name:" + ls_key] = ls_fileName;

        ////刪除檔案
        //try { File.Delete(ls_file); }
        //catch (IOException ee)
        //{
        //    uf_Msg(ee.Message);
        //    return;
        //}
        //// 下載檔案
        //this.uf_AddJavaScript("window.open(\"" + this.Request.ApplicationPath + "/proj_uctrl/h_download_file.ashx?key=" + ls_key + "\");");
	}
}
