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

public partial class sys_e_e02_p_e0201_01_xls:Page
{

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	
	protected void Page_Load(object sender, EventArgs e)
    {
        string args="";
        string[] lsa_Arguments = null;
        string sql = "";
        string qsql = "";
        sql = "SELECT hle201_vid,hle201_cancel,hle201_cway,hle201_sdatetime,CONVERT(varchar(10), hle201_sdatetime, 111) AS sdate FROM hle201 where";
        // 接收傳入值
        if (this.Request["args"] != null)
            args = this.Request["args"].Trim();
        if (args != "")
        {
            lsa_Arguments = args.Split('|');
        }
        if (!string.IsNullOrEmpty(lsa_Arguments[0]))
        {
            //sql = sql + "姓名:" + lsa_Arguments[0];
            qsql = qsql + " hle201_vid in ( SELECT Hmd201_vid From Hmd201 Where Hmd201_id in ( Select hmc101_id From hmc101 where hmc101_cname like '%" + lsa_Arguments[0] + "%') )    AND";
        }
        if (!string.IsNullOrEmpty(lsa_Arguments[1]))
        {
            //sql = sql + "代號:" + lsa_Arguments[1];
            qsql = qsql + " hle201_vid like'%" + lsa_Arguments[1] + "%'  and";
        }
        if (!string.IsNullOrEmpty(lsa_Arguments[2]))
        {
            //sql = sql + "單位:" + lsa_Arguments[2];
            qsql = qsql + " hle201_vid in ( SELECT Hmd201_vid From Hmd201 Where hmd201_tid = '" + lsa_Arguments[2] + "' )   AND";
        }
        if (!string.IsNullOrEmpty(lsa_Arguments[3]))
        {
           // sql = sql + "日起:" + lsa_Arguments[3];
            qsql = qsql + " hle201_sdatetime >= '" + lsa_Arguments[3] + "'   AND";
        }
        if (!string.IsNullOrEmpty(lsa_Arguments[4]))
        {
            //sql = sql+"日迄:" + lsa_Arguments[4];
            qsql = qsql + " hle201_sdatetime < DateAdd(dd , 1 , CAST ('" + lsa_Arguments[4] + "' as datetime))   AND";
        }
        sql = sql + qsql;


        //取得人、日期
        string sql1 = "";
        sql1 = "SELECT DISTINCT hle201_vid,CONVERT(varchar(10), hle201_sdatetime, 111) AS sdate FROM hle201 where";
        //sql1 = "SELECT DISTINCT hle201_vid FROM hle201 where";
        sql1= sql1 + qsql;
        sql1 = sql1.Substring(0, sql1.Length - 5);
        sql1 = sql1 + " ORDER BY hle201_vid";

       // string tmpstr = "";
        DataSet lds_data1;
        DbMethods.uf_Retrieve_FromSQL(out lds_data1, sql1);
        //刷卡上下用的
        string sqldate ="SELECT hle201_sdatetime FROM hle201 WHERE";
        sqldate = sqldate + qsql;

        //取得筆數
        //ohtest.Text = sql;
        string tmpstr = "<Table>";
        //組第一排列名
        tmpstr += "<tr><td>志工手冊編號</td><td>志工姓名</td><td>上班刷卡時間</td><td>上班是否取消</td><td>上班建檔方式</td><td>下班刷卡時間</td><td>下班是否取消	</td><td>下班建檔方式</td><td>預排時間</td><td>實際時間</td></tr>";
        
        string tmpsql = "";

        for (int i = 0; i < lds_data1.Tables[0].Rows.Count; i++)
        {
            tmpstr += "<tr>";
            //tmpsql = sql + " hle201_vid='" + lds_data1.Tables[0].Rows[i][0].ToString() + "' and hle201_type='1'  and";
            tmpsql = sql + " hle201_vid='" + lds_data1.Tables[0].Rows[i][0].ToString() + "' and  CONVERT(varchar(10), hle201_sdatetime, 111)='" + lds_data1.Tables[0].Rows[i][1].ToString() + "' and hle201_type='1'  and";  
            tmpsql = tmpsql.Substring(0, tmpsql.Length - 5);
            tmpsql = tmpsql + "  ORDER BY sdate DESC";
           
            DataSet lds_data2;
            DbMethods.uf_Retrieve_FromSQL(out lds_data2, tmpsql);
            tmpsql = "";
            //tmpsql = sql + " hle201_vid='" + lds_data1.Tables[0].Rows[i][0].ToString() + "' and hle201_type='2'  and";
            tmpsql = sql + " hle201_vid='" + lds_data1.Tables[0].Rows[i][0].ToString() + "' and  CONVERT(varchar(10), hle201_sdatetime, 111)='" + lds_data1.Tables[0].Rows[i][1].ToString() + "' and hle201_type='2'  and";  
            tmpsql = tmpsql.Substring(0, tmpsql.Length - 5);
            tmpsql = tmpsql + "  ORDER BY sdate DESC";

            DataSet lds_data3;
            DbMethods.uf_Retrieve_FromSQL(out lds_data3, tmpsql);


            string hmd201_bookid = "";
            DbMethods.uf_ExecSQL("select hmd201_bookid from hmd201 where hmd201_vid='" + lds_data1.Tables[0].Rows[i][0].ToString() + "'", ref hmd201_bookid);
            string hmd201_cname = "";
            DbMethods.uf_ExecSQL("select hmd201_cname from hmd201 where hmd201_vid='" + lds_data1.Tables[0].Rows[i][0].ToString() + "'", ref hmd201_cname);

            //預排時間
            DataSet lds_data4;
            DbMethods.uf_Retrieve_FromSQL(out lds_data4, "select CAST(hme101b_hour as nvarchar(10)) as hme101b_hour from hme101b where  CONVERT(varchar(10), hme101b_sdate, 111) ='" + lds_data1.Tables[0].Rows[i][1].ToString() + "' order by hme101b_endtime");


            //取得刷卡數(上下班比較)
            int bigcount = 0;
            bigcount = lds_data2.Tables[0].Rows.Count;
            if (lds_data2.Tables[0].Rows.Count < lds_data3.Tables[0].Rows.Count)
            {
                bigcount = lds_data3.Tables[0].Rows.Count;
            }
            for (int j = 0; j < bigcount; j++)
            {
                tmpstr += "<td>" + hmd201_bookid + "</td>";

                tmpstr += "<td>" + hmd201_cname + "</td>";
          

                //上班起欄位
                if (lds_data2.Tables[0].Rows.Count > 0 && lds_data2.Tables[0].Rows.Count >= bigcount)
                {
                    if (!string.IsNullOrEmpty(lds_data2.Tables[0].Rows[j][3].ToString()))
                    {
                        tmpstr += "<td>" + Convert.ToDateTime(lds_data2.Tables[0].Rows[j][3].ToString()).ToString("yyyy/MM/dd HH:mm") + "</td>";
                    }
                    else
                    {
                        tmpstr += "<td></td>";
                    }
                    if (!string.IsNullOrEmpty(lds_data2.Tables[0].Rows[j][1].ToString()))
                    {
                        if (lds_data2.Tables[0].Rows[j][1].ToString() == "N")
                        {
                            tmpstr += "<td>否</td>";
                        }
                        else
                        {
                            tmpstr += "<td>是</td>";
                        }
                    }
                    else
                    {
                        tmpstr += "<td></td>";
                        //tmpstr += "<td>" + lds_data2.Tables[0].Rows[j][1].ToString() + "</td>";
                    }
                    if (!string.IsNullOrEmpty(lds_data2.Tables[0].Rows[j][2].ToString()))
                    {
                        if (lds_data2.Tables[0].Rows[j][2].ToString() == "1")
                        {
                            tmpstr += "<td>刷卡機</td>";
                        }
                        else
                        {
                            tmpstr += "<td>手動補登</td>";
                        }
                    }
                    else
                    {
                        tmpstr += "<td></td>";
                        //tmpstr += "<td>" + lds_data2.Tables[0].Rows[j][2].ToString() + "</td>";
                    }
                }
                else
                {
                    tmpstr += "<td></td>";
                    tmpstr += "<td></td>";
                    tmpstr += "<td></td>";
                }
                if (lds_data3.Tables[0].Rows.Count > 0 && lds_data3.Tables[0].Rows.Count >= bigcount)
                {
                    //上班迄欄位
                    if (!string.IsNullOrEmpty(lds_data3.Tables[0].Rows[j][3].ToString()))
                    {
                        tmpstr += "<td>" + Convert.ToDateTime(lds_data3.Tables[0].Rows[j][3].ToString()).ToString("yyyy/MM/dd HH:mm") + "</td>";
                    }
                    else
                    {
                        tmpstr += "<td></td>";
                    }
                    if (!string.IsNullOrEmpty(lds_data3.Tables[0].Rows[j][1].ToString()))
                    {
                        if (lds_data3.Tables[0].Rows[j][1].ToString() == "N")
                        {
                            tmpstr += "<td>否</td>";
                        }
                        else
                        {
                            tmpstr += "<td>是</td>";
                        }
                    }
                    else
                    {
                        tmpstr += "<td></td>";
                        //tmpstr += "<td>" + lds_data2.Tables[0].Rows[j][1].ToString() + "</td>";
                    }
                    if (!string.IsNullOrEmpty(lds_data3.Tables[0].Rows[j][2].ToString()))
                    {
                        if (lds_data3.Tables[0].Rows[j][2].ToString() == "1")
                        {
                            tmpstr += "<td>刷卡機</td>";
                        }
                        else
                        {
                            tmpstr += "<td>手動補登</td>";
                        }
                    }
                    else
                    {
                        tmpstr += "<td></td>";
                        //tmpstr += "<td>" + lds_data2.Tables[0].Rows[j][2].ToString() + "</td>";
                    }
                }
                else
                {
                    tmpstr += "<td></td>";
                    tmpstr += "<td></td>";
                    tmpstr += "<td></td>";
                }

                //預排時間
                //string hme101b_hour = "";
                //DbMethods.uf_ExecSQL("select CAST(hme101b_hour as nvarchar(10)) as hme101b_hour from hme101b where  CONVERT(varchar(10), hme101b_sdate, 111) ='" + lds_data1.Tables[0].Rows[i][1].ToString() + "' order by hme101b_endtime desc", ref hme101b_hour);
                if (lds_data4.Tables[0].Rows.Count > j)
                {
                //if (!string.IsNullOrEmpty(lds_data4.Tables[0].Rows[j][0].ToString()))
                //{
                    tmpstr += "<td>" + lds_data4.Tables[0].Rows[j][0].ToString() + "</td>";
                }
                else
                {
                    tmpstr += "<td></td>";
                }
                //實際時間
                if (lds_data2.Tables[0].Rows.Count > 0 && lds_data3.Tables[0].Rows.Count > 0)
                {
                    if (lds_data2.Tables[0].Rows.Count > j && lds_data3.Tables[0].Rows.Count > j)
                    {
                        TimeSpan span = DateTime.Parse(lds_data3.Tables[0].Rows[j][3].ToString()).Subtract(DateTime.Parse(lds_data2.Tables[0].Rows[j][3].ToString()));
                        tmpstr += "<td>" + span.Hours + ":" + span.Minutes + "</td>";
                    }
                    else
                    {
                        if (lds_data2.Tables[0].Rows.Count <= j)
                        {
                            tmpstr += "<td>上班未刷卡</td>";
                        }
                        if (lds_data3.Tables[0].Rows.Count <= j)
                        {
                            tmpstr += "<td>下班未刷卡</td>";
                        }
                    }
                }
                else
                {
                    if (lds_data2.Tables[0].Rows.Count == 0)
                    {
                        tmpstr += "<td>上班未刷卡</td>";
                    }
                    else if (lds_data3.Tables[0].Rows.Count == 0)
                    {
                        tmpstr += "<td>下班未刷卡</td>";
                    }
                }
                tmpstr += "</tr>";
            }
            

        }
        tmpstr += "<table>";
       // tmpstr += Convert.ToDateTime(lds_data1.Tables[0].Rows[0][0].ToString()).ToString("yyyy/MM/dd"); ;

        ohtest.Text = tmpstr;
        //ohtest.Text = lds_data1.Tables.Count;
		    Response.AddHeader("content-disposition", "attachment; filename=creditcardtime.xls");
        Response.ContentType = "application/ms-excel";
       
	}

	
}
