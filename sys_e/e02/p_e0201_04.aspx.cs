// *********************************************************************************
// 1. 程式描述：服務勤務管理–勤務紀錄管理–志工選擇
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

public partial class sys_e_e02_p_e0201_04 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：人員主檔資料元件</summary>
    protected ndb_hme101a_hme101b indb_hme101a_hme101b = new ndb_hme101a_hme101b();
    private string is_ReturnObjectID;
    private string is_ReturnObjectID1;
    private string is_ReturnFormID;
    private string ls_ID;
    private string ls_name;

    #endregion

    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        // 不驗證 Frame
        this.IsCheckFrame = false;
        // 不顯示 Version
        this.IsShowVersion = false;
        // 不顯示網頁 Title
        this.IsShowTitle = false;

        //初始化
        this.uf_InitializeQuery(dwQ, this.indb_hme101a_hme101b, bt_Query);
        this.uf_InitializeComponent(null, dgG, this.indb_hme101a_hme101b, null);

        this.is_ReturnFormID = this.Request["ReturnFormID"];

        if (this.Request["ReturnObjectID"] != null)
            this.is_ReturnObjectID = this.Request["ReturnObjectID"].Trim();
        else
            this.is_ReturnObjectID = "";

        if (this.Request["ReturnObjectID1"] != null)
            this.is_ReturnObjectID1 = this.Request["ReturnObjectID1"].Trim();
        else
            this.is_ReturnObjectID1 = "";

    }

    // =========================================================================
    /// <summary>
    /// 事件描述：dgG 選擇某筆資料所要做的處理
    /// </summary>
    protected override void idgG_SelectedIndexChanged(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        string ls_JavaScript = "";

        // 取得選擇的品項
        ls_ID = dgG.Items[dgG.SelectedIndex].Cells[10].Text.Trim();
        ls_name = ((Label)dgG.Items[dgG.SelectedIndex].FindControl("dwG_hme101b_sdate_c")).Text;

        // 組成 JavaScript

        ls_JavaScript += "	if (opener.document.getElementById(\"" + this.Request["ReturnObjectID"].Trim() + "\") != null)" + "\r\n";
        ls_JavaScript += "		opener.document.all." + this.Request["ReturnObjectID"].Trim() + ".value=\"" + ls_ID + "\";" + "\r\n";
        ls_JavaScript += "	if (opener.document.getElementById(\"" + this.Request["ReturnObjectID1"].Trim() + "\") != null)" + "\r\n";
        ls_JavaScript += "		opener.document.all." + this.Request["ReturnObjectID1"].Trim() + ".value=\"" + ls_name + "\";" + "\r\n";

        ls_JavaScript += " close();" + "\r\n";
        this.uf_AddJavaScript(ls_JavaScript);

    }
    protected void dgG_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        // ##### 宣告變數 #####
        Label lb_TName = new Label();
        Label lb_Note = new Label();
        Label lb_Add = new Label();
        System.Text.Encoding l_Encoding = System.Text.Encoding.GetEncoding(950);	// 得到指定的編碼方式

        DataRowView drvODetail;
        drvODetail = (DataRowView)e.Item.DataItem;

        if (drvODetail != null)
        {
            //直接蓋掉cell的欄位值
            //已排姓名
            string ls_hme101b_pdid = "", ls_TName = "", ls_TName_Tool = "";

            //活動事由
            ls_TName_Tool = e.Item.Cells[5].Text.Trim();
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 25)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_Note.Text = ls_TName;
            lb_Note.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_Note.Attributes["onmouseout"] = "UnTip()";
            lb_Note.ToolTip = "";

            e.Item.Cells[5].Controls.Add(lb_Note);

            //報到地點
            ls_TName_Tool = e.Item.Cells[6].Text.Trim();
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 20)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_Add.Text = ls_TName;
            lb_Add.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_Add.Attributes["onmouseout"] = "UnTip()";
            lb_Add.ToolTip = "";

            e.Item.Cells[6].Controls.Add(lb_Add);

            //已排姓名
            ls_hme101b_pdid = e.Item.Cells[9].Text.Trim();
            ls_TName_Tool = e01Project.uf_pname_hme101c(ls_hme101b_pdid);
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 20)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_TName.Text = ls_TName;
            lb_TName.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_TName.Attributes["onmouseout"] = "UnTip()";
            lb_TName.ToolTip = "";

            e.Item.Cells[9].Controls.Add(lb_TName);
        }
    }
}
