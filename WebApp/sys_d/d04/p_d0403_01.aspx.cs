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

public partial class sys_d_d04_p_d0403_01 : p_hrBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string ls_user = "", ls_pass = "";
		WITCrypto lo_Crypto = new WITCrypto("4e4d4d53545f5657", "4e4d4d53545f5657");
		ls_user = lo_Crypto.uf_Encrypt("admin");
		ls_pass = lo_Crypto.uf_Encrypt("admin");
		string ls_server = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "Forum", "Server", "");
		string ls_port = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "Forum", "Port", "");
		this.uf_AddJavaScript("window.open(\"http://" + ls_server + ":" + ls_port + "/default.aspx?g=login&ReturnUrl=%2fdefault.aspx&pu=" + ls_user + "&pp=" + ls_pass + "\");");
    }
}
