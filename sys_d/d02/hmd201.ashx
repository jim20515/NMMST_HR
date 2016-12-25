<%@ WebHandler Language="C#" Class="hmd201Pic" %>
// *********************************************************************************
// 1. 程式描述：志工照片顯示
// 2. 撰寫人員：QFLin
// *********************************************************************************
using System;
using System.Web;
using System.Web.SessionState;
using System.Data.OleDb;
using WIT.Template.Project;

public class hmd201Pic : IHttpHandler, IReadOnlySessionState
{
	public void ProcessRequest(HttpContext context)
	{
		// 宣告並接收傳入值
		String ls_no = "";
		String ls_type = "";
		object lo_pic = null;

		// 取得 session 變數 志工ID序號 md201vid
		if (context.Session["md201vid"] != null)
			ls_no = context.Session["md201vid"].ToString().Trim();

		if ( ls_no != "")
		{

			OleDbConnection lcn_Conn = DbMethods.uf_GetConn();
			String ls_SqlCmd = "SELECT hmd201_photo, hmd201_filetype FROM hmd201 WHERE hmd201_vid = '" + ls_no + "'";
			OleDbCommand lcm_sql = new OleDbCommand(ls_SqlCmd, lcn_Conn);
			lcn_Conn.Open();
            
			try
			{
				OleDbDataReader ldr_Result = lcm_sql.ExecuteReader();
				if (ldr_Result.Read())
				{
					lo_pic = ldr_Result.GetValue(0);
					ls_type = ldr_Result.GetValue(1).ToString().ToLower();
				}

				ldr_Result.Close();
				ldr_Result.Dispose();
			}
			catch { }
			lcn_Conn.Close();
			lcn_Conn.Dispose();
		}

		bool lb_IsOpen = true;

		// 設定網頁類型
		if (".bmp.".Contains("." + ls_type + "."))
			context.Response.ContentType = "image/bmp";
		else if (".gif.".Contains("." + ls_type + "."))
			context.Response.ContentType = "image/gif";
		else if (".jpg.jpeg.jpe.jif.jfif.".Contains("." + ls_type + "."))
			context.Response.ContentType = "image/jpeg";
		else if (".png.".Contains("." + ls_type + "."))
			context.Response.ContentType = "image/png";
		else if (".tiff.tif.".Contains("." + ls_type + "."))
			context.Response.ContentType = "image/tiff";
		else
		{
			context.Response.ContentType = "application/octet-stream";
			lb_IsOpen = false;
		}

		// 讀取檔案
        if (lo_pic != null && lo_pic.ToString() != "")
		{
            context.Response.BinaryWrite((byte[])lo_pic);
		}

        context.Response.Expires = 0;
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

		context.Response.End();
	}

	public bool IsReusable
	{
		get { return false; }
	}
}