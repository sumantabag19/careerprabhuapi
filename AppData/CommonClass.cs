﻿using System;
using System.Data;
using System.Configuration;
using System.Web;

using MySql.Data.MySqlClient;
using System.Net.Mail;


/// <summary>
/// Summary description for commonclass
/// </summary>
public class commonclass
{
    public MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    protected MySqlCommand cmd = new MySqlCommand();
    protected MySqlDataAdapter adp = new MySqlDataAdapter();
    protected MySqlDataReader dr;

    protected DataSet ds = new DataSet();

    public void conopen()
    {

        if (con.State == ConnectionState.Closed)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

        }
    }
    public void conclose()
    {

        if (con.State == ConnectionState.Open)
        {
            con.Close();

        }
    }
    //public void BindradioListBox(RadioButtonList ctr, string st, string dttext, string dvtext)
    //{
    //    MySqlDataAdapter adp = new MySqlDataAdapter(st, ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    //    DataSet ds = new DataSet();

    //    adp.Fill(ds);
    //    ((RadioButtonList)ctr).Items.Clear();

    //    ((RadioButtonList)ctr).DataTextField = dttext;

    //    ((RadioButtonList)ctr).DataValueField = dvtext;
    //    ((RadioButtonList)ctr).DataSource = ds;

    //    ((RadioButtonList)ctr).DataBind();

    //}
    public bool Check(string st)
    {

        bool code = false;
        if (con.State == ConnectionState.Closed)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();

        }

        MySqlCommand cmd = new MySqlCommand(st, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            code = true;
        }
        else
        {
            code = false;
        }
        dr.Close();
        con.Close();
        return (code);
    }

    public string Return_string(string st)
    {

        string code = "";

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        MySqlCommand cmd = new MySqlCommand(st, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            dr.Read();
            code = dr[0].ToString();

        }
        dr.Close();
        con.Close();
        return (code);
    }


    public System.DateTime Return_Date(string st)
    {
        DateTime DateTimeNow = Indiadt();
        DateTime code = DateTimeNow;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        MySqlCommand cmd = new MySqlCommand(st, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            dr.Read();
            if (dr[0] is DBNull)
            {

            }
            else
            {
                code = Convert.ToDateTime(dr[0]);
            }

        }
        dr.Close();
        con.Close();
        return code;
    }
    public DateTime Indiadt()
    {
        DateTime dt = DateTime.Now;
        //dt = dt.AddMinutes(0);
        return dt;
    }
    public int Return_Int(string st)
    {

        int code = 0;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        MySqlCommand cmd = new MySqlCommand(st, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            dr.Read();
            if (dr[0] is DBNull)
            {
            }
            else
            {
                code = Convert.ToInt32(dr[0]);
            }


        }
        dr.Close();
        con.Close();
        return (code);
    }
    //public void InsetDDLitems(Microsoft.Web.Mvc.Controls.DropDownList drp, string st)
    //{
    //    con.Open();

    //    MySqlCommand cmd = new MySqlCommand(st, con);
    //    MySqlDataReader dr = cmd.ExecuteReader();

    //    if (dr.HasRows == true)
    //    {
    //        while (dr.Read())
    //        {
    //            drp.Items.Add(dr[0].ToString());
    //        }

    //    }
    //    dr.Close();
    //    con.Close();
    //}
    public string[] return_arr(string st, int size)
    {
        con.Open();

        MySqlCommand cmd = new MySqlCommand(st, con);
        MySqlDataReader dr = cmd.ExecuteReader();
        string[] strSplitArr = new string[size];
        int i = 0;
        if (dr.HasRows == true)
        {

            while (dr.Read())
            {

                strSplitArr[i] = dr[0].ToString();

                i = i + 1;
            }

        }

        dr.Close();
        con.Close();
        return strSplitArr;
    }

   
    public void Execqry(string qry)
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        if ((con.State == ConnectionState.Closed) || (con.State == ConnectionState.Broken))
            con.Open();
        MySqlCommand cmd = new MySqlCommand(qry);
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
    }
  
    public void Return_DS(DataSet ds, string str)
    {

        MySqlDataAdapter adp = new MySqlDataAdapter(str, con);
        adp.Fill(ds);

        //((DataGrid)ctr).DataSource=ds;
        //((DataGrid)ctr).DataBind();	
    }
    public Int32 autocode(string str)
    {
        if ((con.State == ConnectionState.Closed) || (con.State == ConnectionState.Broken))
            con.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = str;
        cmd.Connection = con;
        MySqlDataReader dr;
        dr = cmd.ExecuteReader();
        Int32 i;
        dr.Read();
        if (dr[0] is DBNull)
        {
            i = 0;
        }
        else
        {
            i = Convert.ToInt32(dr[0]);
        }
        cmd.Dispose();
        con.Close();
        return i + 1;

    }
    public string Converter(string ddate)
    {
        DateTime dt;


        char[] separator = new char[] { '/' };
        string[] strSplitArr = ddate.Split(separator);
        string dd, mm, yy;

        dd = strSplitArr[0].ToString();
        mm = strSplitArr[1].ToString();
        yy = strSplitArr[2].ToString();
        string db;
        db = mm + "/" + dd + "/" + yy;
        dt = Convert.ToDateTime(db);

        return dt.ToString("yyyy/MM/dd");

    }
    public string ConvertFormTimeToDatabase(string dtime)
    {



        char[] separator1 = new char[] { ' ' };
        string[] strSplitArr1 = dtime.Split(separator1);

        string stime;

        stime = strSplitArr1[0].ToString() + ":00";
        //+ " " + strSplitArr1[2].ToString();
        if (strSplitArr1[1].ToString() == "PM")
        {
            char[] separator2 = new char[] { ':' };
            string ampm = strSplitArr1[0].ToString();
            string[] strSplitArr3 = ampm.Split(separator2);
            string f, s, t;
            int g;
            g = Convert.ToInt32(strSplitArr3[0]) + 12;
            if (g == 24)
            {

                f = "12";
            }
            else
            {
                f = g.ToString();
            }
            s = strSplitArr3[1].ToString();
            t = "00";
            strSplitArr1[0] = f + ":" + s + ":" + t;
            stime = strSplitArr1[0].ToString();
        }
        else
        {
            char[] separator2 = new char[] { ':' };
            string ampm = strSplitArr1[0].ToString();
            string[] strSplitArr3 = ampm.Split(separator2);
            string f, s, t;
            int g;
            g = Convert.ToInt32(strSplitArr3[0]) + 12;
            if (g == 24)
            {
                g = 0;
                f = "00";
                s = strSplitArr3[1].ToString();
                t = "00";
                strSplitArr1[0] = f + ":" + s + ":" + t;
                stime = strSplitArr1[0].ToString();
            }


        }
        return stime;

    }
    public string ConvertTime(string dtime)
    {



        char[] separator1 = new char[] { ' ' };
        string[] strSplitArr1 = dtime.Split(separator1);

        string stime;

        stime = strSplitArr1[0].ToString();
        //+ " " + strSplitArr1[2].ToString();
        if (strSplitArr1[1].ToString() == "PM")
        {
            char[] separator2 = new char[] { ':' };
            string ampm = strSplitArr1[0].ToString();
            string[] strSplitArr3 = ampm.Split(separator2);
            string f, s, t;
            int g;
            g = Convert.ToInt32(strSplitArr3[0]) + 12;
            if (g == 24)
            {

                f = "12";
            }
            else
            {
                f = g.ToString();
            }
            s = strSplitArr3[1].ToString();
            t = "00";
            strSplitArr1[0] = f + ":" + s + ":" + t;
            stime = strSplitArr1[0].ToString();
        }
        else
        {
            char[] separator2 = new char[] { ':' };
            string ampm = strSplitArr1[0].ToString();
            string[] strSplitArr3 = ampm.Split(separator2);
            string f, s, t;
            int g;
            g = Convert.ToInt32(strSplitArr3[0]) + 12;
            if (g == 24)
            {
                g = 0;
                f = "00";
                s = strSplitArr3[1].ToString();
                t = "00";
                strSplitArr1[0] = f + ":" + s + ":" + t;
                stime = strSplitArr1[0].ToString();
            }


        }
        return stime;

    }
    public string ConvertSingle(string val)
    {
        string f, l;
        string v = val;
        if (val.Contains(".") == true)
        {
            char[] separator1 = new char[] { '.' };
            string[] strSplitArr1 = val.Split(separator1);

            f = strSplitArr1[0].ToString();
            if (strSplitArr1.GetLength(0) > 1)
            {

                l = strSplitArr1[1].ToString();
                if (l.Length == 0)
                {
                    l = "00";

                }
                if (l.Length == 1)
                {
                    l = l + "0";
                }
                if (l.Length == 2)
                {
                    l = l;
                }
            }
            else
            {
                l = "00";
            }
            if (f.Length == 1)
            {
                f = "0" + f;
            }

            v = f + "." + l;
        }
        else
        {
            if (val.Length == 0)
            {
                v = "00.00";
            }
            if (val.Length == 1)
            {
                v = "0" + val + ".00";

            }
            if (val.Length == 2)
            {
                v = val + ".00";

            }
        }

        return v;
    }
    public string ConvertTimeRev(string dtime)
    {



        string stime;


        char[] separator2 = new char[] { ':' };
        //string ampm = strSplitArr1[0].ToString();
        string[] strSplitArr3 = dtime.Split(separator2);
        string f, s, t;
        int g;
        string l = "AM";
        g = Convert.ToInt32(strSplitArr3[0]);
        if (g == 00)
        {

            f = "12";
            l = "AM";
        }
        else if (g == 12)
        {

            f = "12";
            l = "PM";
        }
        else if (g > 12)
        {
            int T;
            T = g - 12;

            f = T.ToString();
            if (f.Length == 1)
            {
                f = "0" + f;
            }
            l = "PM";
        }
        else if (g < 12)
        {
            int T;
            T = g;
            f = T.ToString();
            if (f.Length == 1)
            {
                f = "0" + f;
            }
            l = "AM";
        }
        else
        {
            f = g.ToString();
            l = "AM";
        }
        s = strSplitArr3[1].ToString();
        t = "00";


        strSplitArr3[0] = f + ":" + s + ":" + t + " " + l;
        stime = strSplitArr3[0].ToString();

        return stime;

    }
    public string ConvertTimeHSAMPM(string dtime)
    {



        string stime;


        char[] separator2 = new char[] { ':' };
        //string ampm = strSplitArr1[0].ToString();
        string[] strSplitArr3 = dtime.Split(separator2);
        string f, s, t;
        int g;
        string l = "AM";
        g = Convert.ToInt32(strSplitArr3[0]);
        if (g == 00)
        {

            f = "12";
            l = "AM";
        }
        else if (g == 12)
        {

            f = "12";
            l = "PM";
        }
        else if (g > 12)
        {
            int T;
            T = g - 12;

            f = T.ToString();
            if (f.Length == 1)
            {
                f = "0" + f;
            }
            l = "PM";
        }
        else if (g < 12)
        {
            int T;
            T = g;
            f = T.ToString();
            if (f.Length == 1)
            {
                f = "0" + f;
            }
            l = "AM";
        }
        else
        {
            f = g.ToString();
            l = "AM";
        }
        s = strSplitArr3[1].ToString();
        t = "00";


        strSplitArr3[0] = f + ":" + s + " " + l;
        stime = strSplitArr3[0].ToString();

        return stime;

    }
    public string ConverterDT(string ddate)
    {
        try
        {
            DateTime dt;


            char[] separator1 = new char[] { ' ' };
            string[] strSplitArr1 = ddate.Split(separator1);

            string sdate, stime;
            sdate = strSplitArr1[0].ToString();
            stime = strSplitArr1[1].ToString();
            //+ " " + strSplitArr1[2].ToString();
            if (strSplitArr1[2].ToString() == "PM")
            {
                char[] separator2 = new char[] { ':' };
                string ampm = strSplitArr1[1].ToString();
                string[] strSplitArr3 = ampm.Split(separator2);
                string f, s, t;
                int g;
                g = Convert.ToInt32(strSplitArr3[0]) + 12;
                if (g == 24)
                {

                    f = "12";
                }
                else
                {
                    f = g.ToString();
                }
                s = strSplitArr3[1].ToString();
                t = strSplitArr3[2].ToString();
                strSplitArr1[1] = f + ":" + s + ":" + t;
                stime = strSplitArr1[1].ToString();
            }

            else
            {
                char[] separator2 = new char[] { ':' };
                string ampm = strSplitArr1[1].ToString();
                string[] strSplitArr3 = ampm.Split(separator2);
                string f, s, t;
                int g;
                g = Convert.ToInt32(strSplitArr3[0]) + 12;
                if (g == 24)
                {
                    g = 0;
                    f = "00";
                    s = strSplitArr3[1].ToString();
                    t = "00";
                    strSplitArr1[0] = f + ":" + s + ":" + t;
                    stime = strSplitArr1[0].ToString();
                }


            }


            char[] separator = new char[] { '/' };
            string[] strSplitArr = sdate.Split(separator);
            string dd, mm, yy;

            dd = strSplitArr[0].ToString();
            mm = strSplitArr[1].ToString();
            yy = strSplitArr[2].ToString();
            string db;
            db = mm + "/" + dd + "/" + yy;
            dt = Convert.ToDateTime(db);

            return dt.ToString("yyyy/MM/dd") + " " + stime;
        }
        catch
        {
            throw;
        }
    }

    public string ConverterSystemDT(string ddate)
    {
        try
        {
            DateTime dt;


            char[] separator1 = new char[] { ' ' };
            string[] strSplitArr1 = ddate.Split(separator1);

            string sdate, stime;
            sdate = strSplitArr1[0].ToString();
            stime = strSplitArr1[1].ToString();
            //+ " " + strSplitArr1[2].ToString();
            if (strSplitArr1[2].ToString() == "PM")
            {
                char[] separator2 = new char[] { ':' };
                string ampm = strSplitArr1[1].ToString();
                string[] strSplitArr3 = ampm.Split(separator2);
                string f, s, t;
                int g;
                g = Convert.ToInt32(strSplitArr3[0]) + 12;
                if (g == 24)
                {

                    f = "12";
                }
                else
                {
                    f = g.ToString();
                }
                s = strSplitArr3[1].ToString();
                t = strSplitArr3[2].ToString();
                strSplitArr1[1] = f + ":" + s + ":" + t;
                stime = strSplitArr1[1].ToString();
            }

            else
            {
                char[] separator2 = new char[] { ':' };
                string ampm = strSplitArr1[1].ToString();
                string[] strSplitArr3 = ampm.Split(separator2);
                string f, s, t;
                int g;
                g = Convert.ToInt32(strSplitArr3[0]) + 12;
                if (g == 24)
                {
                    g = 0;
                    f = "00";
                    s = strSplitArr3[1].ToString();
                    t = "00";
                    strSplitArr1[0] = f + ":" + s + ":" + t;
                    stime = strSplitArr1[0].ToString();
                }


            }


            char[] separator = new char[] { '/' };
            string[] strSplitArr = sdate.Split(separator);
            string dd, mm, yy;

            dd = strSplitArr[1].ToString();
            mm = strSplitArr[0].ToString();
            yy = strSplitArr[2].ToString();
            string db;
            db = mm + "/" + dd + "/" + yy;
            dt = Convert.ToDateTime(db);

            return dt.ToString("yyyy/MM/dd") + " " + stime;
        }
        catch
        {
            throw;
        }
    }
    public DateTime GetDate(string ddate)
    {
        DateTime dt;


        char[] separator = new char[] { '/' };
        string[] strSplitArr = ddate.Split(separator);
        string dd, mm, yy;

        dd = strSplitArr[0].ToString();
        mm = strSplitArr[1].ToString();
        yy = strSplitArr[2].ToString();
        string db;
        db = mm + "/" + dd + "/" + yy;
        dt = Convert.ToDateTime(db);

        return dt;

    }
    public Boolean check(string str)
    {


        if ((con.State == ConnectionState.Closed) || (con.State == ConnectionState.Broken))
            con.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = str;
        cmd.Connection = con;
        MySqlDataReader dr;
        dr = cmd.ExecuteReader();
        Int32 i;
        dr.Read();
        if (dr.HasRows == true)
        {
            if (dr[0] is DBNull)
            {
                i = 0;
            }
            else
            {
                i = Convert.ToInt32(dr[0]);
            }
            cmd.Dispose();
            con.Close();
            if (i == 0)
            {
                cmd.Dispose();
                con.Close();
                return false;
            }
            else
            {
                cmd.Dispose();
                con.Close();
                return true;
            }
        }
        else
        {
            cmd.Dispose();
            con.Close();
            return false;
        }


    }
    public Boolean CheckSecurity(string tblname, string col, int check_id, string roleid, int uid, int bid)
    {
        Boolean chk = true;
        if (roleid == "1")
        {

        }
        else if (roleid == "2")
        {
            if (check("select a." + col + " from " + tblname + " a,userdetail b where a.userid=b.userid and a." + col + "=" + check_id + " and b.cityid=" + bid + "") == true)
            {

            }
            else
            {
                chk = false;
            }

        }
        else
        {
            if (check("select a." + col + " from " + tblname + " a where " + col + "=" + check_id + " and userid=" + uid + "") == true)
            {

            }
            else
            {
                chk = false;
            }
        }
        return chk;
        //
    }
    public DataSet Get_DS(string str)
    {
        if ((con.State == ConnectionState.Closed) || (con.State == ConnectionState.Broken))
            con.Open();
        ds.Tables.Clear();
        MySqlDataAdapter adp = new MySqlDataAdapter(str, con);
        adp.SelectCommand.CommandTimeout = 12000;
        adp.Fill(ds);
        return ds;
    }
    public String SendEmail(string _Subject, string _FromEmail, string _FromUserName, string _To, string _Message, string _Attachment, string _Port, string _Host, string _EmailPwd)
    {
        string Message = null;
        string from = _FromEmail.Trim();
        MailMessage mail = new MailMessage();
        foreach (string ToEmail in _To.Split(','))
            mail.To.Add(ToEmail);
        // mail.CC.Add("swapnendu@cybrain.co.in")
        mail.From = new MailAddress(from, Convert.ToString(_FromUserName), System.Text.Encoding.UTF8);
        mail.Subject = _Subject;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = _Message;
        string AttachFile = _Attachment;
        if (AttachFile != "")
            mail.Attachments.Add(new Attachment(AttachFile));
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential(from, Convert.ToString(_EmailPwd));
        client.Port = Convert.ToInt32(_Port);
        client.Host = _Host;
        client.EnableSsl = true;
        try
        {
            client.Send(mail);
            mail.Attachments.Dispose();
            Message = "";
        }
        catch (Exception ex)
        {
            Message = ex.Message;
        }
        return Message;
    }
   
}
