// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - TreeView 功能選單之 Web 使用者控制項
// 2. 撰寫人員：fen
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
using System.Xml;
using System.IO;
using WIT.Template.Project;

public partial class proj_right_u_TreeViewMenu : System.Web.UI.UserControl
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：Selected Module ID</summary>
	private string is_ModID = "";
	/// <summary>變數描述：Selected Menu ID</summary>
	private string is_SelectedMenuID = "";
	/// <summary>變數描述：Selected Menu Index</summary>
	private string is_SelectedMenuIndex = "";
	/// <summary>變數描述：Selected Menu Text</summary>
	private string is_SelectedMenuTexts = "";
	/// <summary>變數描述：Expand All</summary>
	private bool ib_ExpandAll = WIT.Template.Project.Invoke.Setup.ib_IsMenuTreeExpandAll;
	/// <summary>變數描述：Expand Group</summary>
	private string is_ExpandGroup = WIT.Template.Project.Invoke.Setup.is_MenuTreeExpandGroup.Trim();

	#endregion

	#region ☆ Declare Properties ------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>屬性描述：Selected Sys ID</summary>
	public string SelectedSysID
	{
		get
		{
			// 將 Menu ID 拆成子系統代碼和權限代碼
			string[] lsa_ID = this.is_SelectedMenuID.Split('.');
			return lsa_ID[0];
		}
	}

	// =========================================================================
	/// <summary>屬性描述：Selected Menu ID</summary>
	public string SelectedMenuID
	{
		get
		{
			// 將 Menu ID 拆成子系統代碼和權限代碼
			string[] lsa_ID = this.is_SelectedMenuID.Split('.');
			if (lsa_ID.Length > 1)
				return lsa_ID[1];
			else
				return lsa_ID[0];
		}
	}
	
	// =========================================================================
	/// <summary>屬性描述：Selected Menu Index</summary>
	public string SelectedMenuIndex
	{
		get { return this.is_SelectedMenuIndex; }
	}
	
	// =========================================================================
	/// <summary>屬性描述：Selected Menu Text</summary>
	public string[] SelectedMenuTexts
	{
		get { return this.is_SelectedMenuTexts.Split(';'); }
	}

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁初始化（在 WebForm 的 Page_Init 之前處理，如為動態加入則在呼叫 Controls.Add 之後處理）
	/// </summary>
	protected void Page_Init(object sender, System.EventArgs e)
	{
		// 取得記錄在 Session 中的 Module ID
		if (this.Session["ss_mod_id"] != null)
		{
			this.is_ModID = this.Session["ss_mod_id"].ToString().Trim();
		}

		// 取得記錄在 Session 中的 Menu ID–此時應該為舊 ID
		if (this.Request["menu_id"] == null && this.Session["ss_menu_id"] != null)
		{
			this.is_SelectedMenuID = this.Session["ss_menu_id"].ToString().Trim();
		}
	}
	
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟（在 WebForm 的 Page_Load 之後處理）
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {

    }

	// =========================================================================
	/// <summary>
	/// 函式描述：利用使用者權限資料建立 TreeView 選單
	/// </summary>
	/// <param name="as_UserID">使用者帳號</param>
	public void uf_Build(string as_UserID)
	{
		// ##### 宣告變數 #####
		string ls_MenuID = "", ls_SysID = "";
		int li_Pos;

		// 找 Request 傳入值的「Sys ID」
		if (this.Request["menu_id"] != null)
			ls_SysID = this.Request["menu_id"].ToString().Trim();
		// 如果傳入的「Sys ID」不正確，則再找 Session
		if (ls_SysID == "")
		{
			// 找 Session 「Menu ID」的「子系統代碼」.「子系統代碼」+「操作代碼」
			if (this.Session["ss_menu_id"] != null)
				ls_MenuID = this.Session["ss_menu_id"].ToString().Trim();

			if (ls_MenuID != "")
			{
				// 先得到操作代碼「.」之前的子系統代碼
				li_Pos = ls_MenuID.IndexOf(".");
				if (li_Pos >= 0)
					ls_SysID = ls_MenuID.Substring(0, li_Pos);
				else
					ls_SysID = ls_MenuID;
			}
		}
		// 如果 Session 的「Module ID」不正確，則指定找第一個模組
		if (ls_SysID == "") ls_SysID = "menutree";

		this.uf_Build(as_UserID, ls_SysID);
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：利用使用者權限資料建立 TreeView 選單
	/// </summary>
	/// <param name="as_UserID">使用者帳號</param>
	/// <param name="as_SysID">選擇的 Sys ID</param>
	public void uf_Build(string as_UserID, string as_SysID)
	{
		// ##### 宣告變數 #####
		string ls_XmlString;

		// 取得使用者權限 XML 格式資料
		ls_XmlString = this.uf_Xml_GetUserRight(as_UserID, as_SysID);

		// 從使用者權限產生 XML 格式資料，建立 TreeView 功能選單
		this.uf_BuildByString(ls_XmlString, as_SysID);
	}

	#region ☆ (保留)建立 TreeView 選單 Methods ----------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：利用使用者權限資料建立 TreeView 選單
	/// </summary>
	/// <param name="as_UserID">使用者帳號</param>
	/// <param name="as_SysID">系統權限–子系統代碼</param>
	private void uf_BuildByTable(string as_UserID, string as_SysID)
	{
		// 從使用者權限產生 XML 格式資料，建立 TreeView 功能選單
		this.uf_BuildByString(this.uf_Xml_GetUserRight(as_UserID, as_SysID), as_SysID);
	}
	
	// =========================================================================
	/// <summary>
	/// 函式描述：利用 XML 檔案建立 TreeView 選單
	/// </summary>
	/// <param name="as_XmlFile">XML 檔案名稱(含路徑)</param>
	/// <param name="as_SysID">系統權限–子系統代碼</param>
	private void uf_BuildByFile(string as_XmlFile, string as_SysID)
	{
		// 從檔案讀取 XML 格式資料，建立 TreeView 功能選單
		this.uf_BuildByString(this.uf_File_GetString(as_XmlFile), as_SysID);
	}

	#endregion

	#region ☆ 利用 XML 格式字串建立 TreeView 選單 Methods ------------ 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：利用 XML 格式字串建立 TreeView 選單
	/// </summary>
	/// <param name="as_XmlString">XML 格式字串</param>
	/// <param name="as_SysID">系統權限–子系統代碼</param>
	private void uf_BuildByString(string as_XmlString, string as_SysID)
	{
		// ##### 宣告變數 #####
		XmlDocument l_XmlPaser = new XmlDocument();	// XML 格式字串解析器
		XmlNode l_XmlNode;
		TreeNode l_TreeNodeChilds = new TreeNode();
		string ls_SelectedNodeIndex = null;

		try
		{
			// 利用 XML 格式字串讓解析器產生樹狀節點
			l_XmlPaser.LoadXml(as_XmlString);
		}
		catch
		{
			return;
		}

		// 判斷是否有傳入子系統代碼
		if (as_SysID.Trim() == "")
		{
			// 取得使用權限基底 XmlNode
			l_XmlNode = l_XmlPaser.DocumentElement;
		}
		else
		{
			// 再取得使用權限子系統基底 XmlNode
			l_XmlNode = l_XmlPaser.GetElementById(as_SysID);

			// 如果不存在則取得第一個使用權限子系統 XmlNode
			if (l_XmlNode == null)
			{
				l_XmlNode = l_XmlPaser.SelectSingleNode("//Sys");

				// 如果有找到則記錄下來
				if (l_XmlNode != null && l_XmlNode.Attributes["ID"] != null)
				{
					if (this.SelectedMenuID.Trim() != "")
						this.is_SelectedMenuID = l_XmlNode.Attributes["ID"].Value + "." + this.SelectedMenuID;
					else
						this.is_SelectedMenuID = l_XmlNode.Attributes["ID"].Value;
					this.Session["ss_menu_id"] = this.is_SelectedMenuID;
					as_SysID = this.SelectedSysID;
				}
			}
		}
		if (l_XmlNode == null)
			return;

		// 清除所有節點
		tv_Menu.Nodes.Clear();
		this.is_SelectedMenuIndex = "";
		this.is_SelectedMenuTexts = "";

		// 將基底 XmlNode 下所有子節點都轉換成 TreeView 節點新增到 TreeView 功能選單中
		for (int li_i = 0; li_i <= (l_XmlNode.ChildNodes.Count - 1); li_i++)
		{
			// 得到子節點集合，如果有子節點才加入 TreeView 中
			l_TreeNodeChilds = this.uf_Tree_ChildNodes(l_XmlNode.ChildNodes[li_i], ref ls_SelectedNodeIndex, this.is_SelectedMenuIndex);
			if (l_TreeNodeChilds != null)
			{
				// 將第一層 Node 加入 TreeView
				tv_Menu.Nodes.Add(l_TreeNodeChilds);
				if (l_TreeNodeChilds.Value == this.SelectedMenuID)
					ls_SelectedNodeIndex = "";
				// 判斷是否已經找到選擇節點所在位置，是則將其記錄下來
				if (ls_SelectedNodeIndex != null && this.is_SelectedMenuIndex == "")
				{
					if (ls_SelectedNodeIndex == "")
					{
						ls_SelectedNodeIndex = Convert.ToString(tv_Menu.Nodes.Count - 1);
						this.is_SelectedMenuTexts = l_TreeNodeChilds.Text;
					}
					else
					{
						ls_SelectedNodeIndex = Convert.ToString(tv_Menu.Nodes.Count - 1) + "." + ls_SelectedNodeIndex;
						this.is_SelectedMenuTexts = l_TreeNodeChilds.Text + ";" + this.is_SelectedMenuTexts;
					}
					this.is_SelectedMenuIndex = ls_SelectedNodeIndex;
					tv_Menu.Nodes[tv_Menu.Nodes.Count - 1].Expanded = true;
				}

				if (Convert.ToString("," + this.is_ExpandGroup + ",").IndexOf("," + l_TreeNodeChilds.Value + ",") >= 0)
					tv_Menu.Nodes[tv_Menu.Nodes.Count - 1].Expanded = true;
			}
		}

		// 設定 TreeView 選擇的項目
		//if (this.is_SelectedMenuIndex != null)
		//    tv_Menu.SelectedNodeIndex = this.is_SelectedMenuIndex;

		// 是否全部展開
		if (this.ib_ExpandAll) tv_Menu.ExpandAll();
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：將 Xml Node 轉成 TreeView Node
	/// </summary>
	/// <param name="a_XmlNode">Xml Node</param>
	/// <param name="as_MenuIndex">SelectedNodeIndex</param>
	/// <param name="as_ParentNodeData">Parent Node Data</param>
	/// <returns>TreeView Node</returns>
	private TreeNode uf_Tree_ChildNodes(XmlNode a_XmlNode, ref string as_SelectedNodeIndex, string as_ParentNodeData)
	{
		// ##### 宣告變數 #####
		TreeNode l_TreeNode = new TreeNode();
		TreeNode l_TreeNodeChilds = new TreeNode();

		// 設定 TreeView Node 相關資料–ID
		if (a_XmlNode.Attributes["ID"] != null)
		{
			l_TreeNode.Value = a_XmlNode.Attributes["ID"].Value;
		}
		else
		{
			return null;
		}

		// 設定 TreeView Node 相關資料–Text
		if (a_XmlNode.Attributes["Text"] != null)
		{
			l_TreeNode.Text = a_XmlNode.Attributes["Text"].Value;
			l_TreeNode.ToolTip = l_TreeNode.Text;
		}
		else
		{
			l_TreeNode.Text = "無操作中文名稱(Text)";
		}

		// 設定 TreeView Node 相關資料–URL，沒有則表示為葉節點
		if (a_XmlNode.Attributes["URL"] != null)
		{
			if (a_XmlNode.Attributes["URL"].Value.Trim() != "")
				l_TreeNode.NavigateUrl = this.Request.ApplicationPath + "/" + a_XmlNode.Attributes["URL"].Value.Trim();
		}
		else
		{
			// 判斷只有一個子節點時(可能是網址)
			if (a_XmlNode.ChildNodes.Count == 1 && a_XmlNode.ChildNodes[0].NodeType == XmlNodeType.Text)
			{
				// 果然是網址，取得節點文字當作 URL
				if (a_XmlNode.InnerText.Trim() != "")
					l_TreeNode.NavigateUrl = this.Request.ApplicationPath + "/" + a_XmlNode.InnerText.Trim();
			}
			// 此節點為葉節點，直接傳回
			return l_TreeNode;
		}

		if (a_XmlNode.HasChildNodes)
		{
			// 20070307, fen add(.NET2)
			if (l_TreeNode.NavigateUrl == "")
				l_TreeNode.SelectAction = TreeNodeSelectAction.Expand;

			for (int li_j = 0; li_j <= (a_XmlNode.ChildNodes.Count - 1); li_j++)
			{
				// 得到子節點集合，如果有子節點才加入 TreeView 中
				l_TreeNodeChilds = this.uf_Tree_ChildNodes(a_XmlNode.ChildNodes[li_j], ref as_SelectedNodeIndex, as_ParentNodeData);
				if (l_TreeNodeChilds != null)
				{
					l_TreeNode.ChildNodes.Add(l_TreeNodeChilds);
					if (l_TreeNodeChilds.Value == this.SelectedMenuID)
						as_SelectedNodeIndex = "";
					// 判斷是否已經找到選擇節點所在位置，是則將其記錄下來
					if (as_SelectedNodeIndex != null && as_ParentNodeData == "")
					{
						if (as_SelectedNodeIndex == "")
						{
							as_SelectedNodeIndex = Convert.ToString(l_TreeNode.ChildNodes.Count - 1);
							this.is_SelectedMenuTexts = l_TreeNodeChilds.Text;
						}
						else
						{
							as_SelectedNodeIndex = Convert.ToString(l_TreeNode.ChildNodes.Count - 1) + "." + as_SelectedNodeIndex;
							this.is_SelectedMenuTexts = l_TreeNodeChilds.Text + ";" + this.is_SelectedMenuTexts;
						}
						as_ParentNodeData = as_SelectedNodeIndex;
						l_TreeNode.ChildNodes[l_TreeNode.ChildNodes.Count - 1].Expanded = true;
					}

					if (Convert.ToString("," + this.is_ExpandGroup + ",").IndexOf("," + l_TreeNodeChilds.Value + ",") >= 0)
						l_TreeNode.ChildNodes[l_TreeNode.ChildNodes.Count - 1].Expanded = true;
				}
			}
		}

		// 傳回 TreeView Node(含其下節點)
		if (l_TreeNode.ChildNodes.Count > 0)
		{
			return l_TreeNode;
		}
		else
		{
			return null;
		}
	}

	#endregion

	#region ☆ 撰寫 XML 格式字串 Methods ------------------------------ 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：利用使用者權限產生 XML 格式字串
	/// </summary>
	/// <param name="as_UserID">使用者帳號</param>
	/// <param name="as_SysID">系統權限–子系統代碼</param>
	/// <returns>使用者權限 XML 格式字串</returns>
	private string uf_Xml_GetUserRight(string as_UserID, string as_SysID)
	{
		if (as_SysID == null || as_SysID.Trim() == "")
			as_SysID = "";

		// 錯誤的傳入值
		if (as_UserID == null || as_UserID.Trim() == "")
			return "<UserRight SYS=" + as_SysID + "></UserRight>";

		// 指定權限語法，連接到資料庫並取出資料 ----------------------------- ☆

		// ##### 宣告變數 #####
		int li_rowcount = 0;
		ndb_userright lndb_UserRight;

		lndb_UserRight = new ndb_userright();

		// 指定權限語法，連接到資料庫並取出指定模組資料 --------------------- ☆
		lndb_UserRight.uf_Retrieve("", as_UserID, as_SysID, this.is_ModID);
		lndb_UserRight.dv_View = lndb_UserRight.ds_Data.Tables[0].DefaultView;

		// 設定資料處理條件
		lndb_UserRight.uf_Sort("mod_id, sys_id, seq");

		// 計算資料筆數
		li_rowcount = lndb_UserRight.uf_RowCount();


		// 開始轉換成 XML 格式字串 ------------------------------------------ ☆

		// ##### 宣告變數 #####
		XmlDocument l_XmlPaser = new XmlDocument();	// XML 格式字串解析器
		XmlNode l_XmlParent;
		XmlNode l_XmlNode;
		string ls_mod_id, ls_sys_id, ls_parent_id;

		// 增加 Document Type 節點
		l_XmlPaser.AppendChild(l_XmlPaser.CreateDocumentType("UserRight", null, null, "<!ELEMENT UserRight (Module)*><!ELEMENT Module (Sys)*><!ELEMENT Sys (Func)*><!ELEMENT Func ANY><!ATTLIST Module ID ID #REQUIRED><!ATTLIST Sys ID ID #REQUIRED><!ATTLIST Func ID ID #REQUIRED>"));

		// 增加 Document Root 節點
		l_XmlNode = l_XmlPaser.CreateElement("UserRight");
		l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "SYS", as_SysID);
		l_XmlPaser.AppendChild(l_XmlNode);

		// 判斷使用者權限資料轉換成 XmlNode
		for (int li_i = 0; li_i <= (li_rowcount - 1); li_i++)
		{
			// 取得模組代碼
			ls_mod_id = lndb_UserRight[li_i]["mod_id"].ToString().Trim();

			// 判斷是否為模組資料，是則新增模組 XmlNode
			if (lndb_UserRight[li_i]["func_flag"].ToString() == "M")
			{
				l_XmlNode = l_XmlPaser.CreateElement("Module");
				l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "ID", lndb_UserRight[li_i]["mod_id"].ToString().Trim());
				l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "Text", lndb_UserRight[li_i]["mod_text"].ToString().Trim());
				l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "MinSYS", lndb_UserRight[li_i]["sys_id"].ToString().Trim());
				l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "Image", lndb_UserRight[li_i]["mod_img"].ToString().Trim());
				// 將模組 XmlNode 加入基底 XmlNode
				l_XmlNode = l_XmlPaser.DocumentElement.AppendChild(l_XmlNode);

				continue;
			}

			// 取得父層操作代碼並找出父層 XmlNode
			ls_parent_id = lndb_UserRight[li_i]["func_parent"].ToString().Trim();
			l_XmlParent = l_XmlPaser.GetElementById(ls_parent_id);

			// 取得子系統代碼
			ls_sys_id = lndb_UserRight[li_i]["sys_id"].ToString().Trim();

			// 判斷是否為子系統資料，是則新增子系統 XmlNode
			if (lndb_UserRight[li_i]["func_flag"].ToString() == "S")
			{
				l_XmlNode = l_XmlPaser.CreateElement("Sys");
				l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "ID", ls_sys_id.Trim());
				l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "Text", lndb_UserRight[li_i]["sys_text"].ToString().Trim());
				l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "ModID", lndb_UserRight[li_i]["mod_id"].ToString().Trim());
				l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "URL", lndb_UserRight[li_i]["sys_url"].ToString().Trim());
				// 判斷父層 XmlNode 是否已經存在，不存在則新增在基底
				if (l_XmlParent != null)
				{
					// 將子系統 XmlNode 加入父層 XmlNode
					l_XmlNode = l_XmlParent.AppendChild(l_XmlNode);
				}
				else
				{
					// 將子系統 XmlNode 加入基底 XmlNode
					l_XmlNode = l_XmlPaser.DocumentElement.AppendChild(l_XmlNode);
				}

				continue;
			}

			// 判斷父層 XmlNode 是否已經存在，不存在則不新增繼續
			if (l_XmlParent == null)
				continue;

			l_XmlNode = l_XmlPaser.CreateElement("Func");
			l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "ID", lndb_UserRight[li_i]["rid"].ToString().Trim());
			l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "Text", lndb_UserRight[li_i]["func_text"].ToString().Trim());
			if (lndb_UserRight[li_i]["func_flag"].ToString() != "Y")
			{
				if (lndb_UserRight[li_i]["func_url"].ToString().Trim() != "")
					l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "URL", "proj_right/p_MenuLead.aspx?menu_id=" + lndb_UserRight[li_i]["sys_id"].ToString().Trim() + "." + lndb_UserRight[li_i]["rid"].ToString().Trim());
				else
					l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "URL", lndb_UserRight[li_i]["func_url"].ToString().Trim());
				// old version
				//l_XmlNode = this.uf_Xml_AppendAttribute(l_XmlPaser, l_XmlNode, "URL", lndb_UserRight[li_i]["func_url"].ToString().Trim());
			}
			else
			{
				l_XmlNode.InnerText = "proj_right/p_MenuLead.aspx?menu_id=" + lndb_UserRight[li_i]["sys_id"].ToString().Trim() + "." + lndb_UserRight[li_i]["rid"].ToString().Trim();
				// old version
				//l_XmlNode.InnerText = lndb_UserRight[li_i]["func_url"].ToString().Trim();
			}
			// 將操作 XmlNode 加入父層 XmlNode
			l_XmlNode = l_XmlParent.AppendChild(l_XmlNode);
		}

		// 傳回 XML 格式字串
		return l_XmlPaser.InnerXml;
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：增加 Xml Attribute Node 在 Xml Node 最後
	/// </summary>
	/// <param name="a_XmlPaser">XML 格式字串解析器</param>
	/// <param name="a_XmlNode">Xml Node</param>
	/// <param name="as_Name">Attribute Name</param>
	/// <param name="as_Value">Attribute Value</param>
	/// <returns>改變後的 Xml Node</returns>
	private XmlNode uf_Xml_AppendAttribute(XmlDocument a_XmlPaser, XmlNode a_XmlNode, string as_Name, string as_Value)
	{
		// ##### 宣告變數 #####
		XmlAttribute l_XmlAttribute;						// 屬性 XmlNode

		// 產生 Xml Attribute XmlNode
		l_XmlAttribute = a_XmlPaser.CreateAttribute(as_Name);
		l_XmlAttribute.Value = as_Value;
		a_XmlNode.Attributes.Append(l_XmlAttribute);

		// 傳回最新的 XmlNode
		return a_XmlNode;
	}

	#endregion

	#region ☆ 取得 XML 檔案內容 Methods ------------------------------ 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：取得檔案內容
	/// </summary>
	/// <param name="as_FileName">檔案名稱(含路徑)</param>
	/// <returns>檔案內容字串</returns>
	private string uf_File_GetString(string as_FileName)
	{
		// ##### 宣告變數 #####
		string ls_FileString = "";
		
		// 判斷檔案是否存在，存在則取得檔案內容
		if (File.Exists(as_FileName))
		{
			// 宣告檔案讀取物件
			FileStream l_FileStream = File.OpenRead(as_FileName);
			StreamReader l_StreamReader = new StreamReader(l_FileStream, System.Text.Encoding.Default);

			// 從檔案讀取內容
			ls_FileString = l_StreamReader.ReadToEnd();

			// 關閉檔案讀取物件
			l_StreamReader.Close();
			l_FileStream.Close();
		}	// End if

		// 傳回檔案內容字串
		return ls_FileString;
	}

	#endregion

}
