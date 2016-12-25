// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排班表樣板管理–排班主檔–明細
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

public partial class sys_e_e01_p_e0105_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

	/// <summary>變數描述：人員類別資料元件</summary>
	protected ndb_hme105a indb_hme105a = new ndb_hme105a();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 初始化
		this.uf_InitializeQuery(null, this.indb_hme105a, null);
		this.uf_InitializeComponent(dwF, null, this.indb_hme105a, u_Edit_F);
        this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
		this.IsQuery_SessionRemove = false;

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
			//this.uf_AddJavaScript("uf_SelectFrame(2);");
		}

		// 將主鍵值記錄為尋找資料的條件
		this.dgG_FindValue = new object[1];
        this.dgG_FindValue[0] = this.StoredKey;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（新增）
	/// </summary>
	private bool u_Edit_F_PreEndEdit(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		if (adrv_Row == null) return true;

        //if (dwF_hme105a_syear.Text.Trim() == "")
        //{
        //    uf_Msg("請輸入班表年度！");
        //    return false;
        //}

        //if (dwF_hme105a_smonth.Text.Trim() == "")
        //{
        //    uf_Msg("請輸入班表月份！");
        //    return false;
        //}


		// 如果資料為新增的
		if (adrv_Row.IsNew)
		{
            int li_count = 0;

            DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme105a WHERE hme105a_tid = '" + dwF_hme105a_tid.SelectedValue + "' AND hme105a_name = '" + dwF_hme105a_name.Text.Trim() + "'", ref li_count);
            if (li_count > 0)
            {
                uf_Msg(dwF_hme105a_tid.SelectedItem.Text.Trim() + "已存在" + dwF_hme105a_name.Text.Trim() + "！");
                return false;
            }

			// 取得流水號的系統編號–資料庫最大值+1
            adrv_Row["hme105a_ssid"] = e01Project.uf_Get_SystemNo("hme105a.hme105a_ssid", "");
            this.StoredKey = adrv_Row["hme105a_ssid"].ToString();

            adrv_Row["hme105a_aid"] = LoginUser.ID; 
            adrv_Row["hme105a_adt"] = DbMethods.uf_GetDateTime();
            adrv_Row["hme105a_uid"] = LoginUser.ID; 
            adrv_Row["hme105a_udt"] = DbMethods.uf_GetDateTime();

		}

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
}
