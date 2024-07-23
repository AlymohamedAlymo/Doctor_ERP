using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbAgent
{

    public static List<tbAgent> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "رقم العميل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الاسم", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtname")]
    public string name { get; set; }
    [DataGUIAttribute(GUIName = "رقم الهوية", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcivilid")]
    public string civilid { get; set; }
    [DataGUIAttribute(GUIName = "رقم الجوال", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtmobile")]
    public string mobile { get; set; }
    [DataGUIAttribute(GUIName = "البريد الإلكتروني", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtemail")]
    public string email { get; set; }

    [DataGUIAttribute(GUIName = "الرقم الضريبي", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtvatid")]
    public string vatid { get; set; }
    [DataGUIAttribute(GUIName = "رقم المعلن", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtpublicnumber")]
    public string publicnumber { get; set; }
    [DataGUIAttribute(GUIName = "اسم الوكيل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagentname")]
    public string agentname { get; set; }
    [DataGUIAttribute(GUIName = "رقم هوية الوكيل", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtagentcivilid")]
    public string agentcivilid { get; set; }
    [DataGUIAttribute(GUIName = "رقم جوال الوكيل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagentmobile")]
    public string agentmobile { get; set; }
    [DataGUIAttribute(GUIName = "إيميل الوكيل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagentemail")]
    public string agentemail { get; set; }
    [DataGUIAttribute(GUIName = "الرقم الضريبي للوكيل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagentvatid")]
    public string agentvatid { get; set; }
    [DataGUIAttribute(GUIName = "رقم الوكالة", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagencynumber")]
    public string agencynumber { get; set; }
    [DataGUIAttribute(GUIName = "رقم المعلن للوكيل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagentpublicnumber")]
    public string agentpublicnumber { get; set; }
    [DataGUIAttribute(GUIName = "officename", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtofficename")]
    public string officename { get; set; }
    [DataGUIAttribute(GUIName = "officecr", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtofficecr")]
    public string officecr { get; set; }
    [DataGUIAttribute(GUIName = "officephone", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtofficephone")]
    public string officephone { get; set; }
    [DataGUIAttribute(GUIName = "إيميل المكتب", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtofficeemail")]
    public string officeemail { get; set; }
    [DataGUIAttribute(GUIName = "officevatid", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtofficevatid")]
    public string officevatid { get; set; }
    [DataGUIAttribute(GUIName = "officepublicnumber", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtofficepublicnumber")]
    public string officepublicnumber { get; set; }
    [DataGUIAttribute(GUIName = "ملاحظات", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }
    [DataGUIAttribute(GUIName = "agenttype", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public int agenttype { get; set; }
    [DataGUIAttribute(GUIName = "آخر عملية", Formatting = "", Visibility = false, Width = 100, ControlName = "txtlastaction")]
    public string lastaction { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbAgent VALUES (@guid, @number,  @name, @civilid, @mobile, @email , @vatid,  @publicnumber, @agentname, @agentcivilid, @agentmobile, @agentemail , @agentvatid, @agencynumber, @agentpublicnumber, @officename, @officecr, @officephone, @officeemail , @officevatid, @officepublicnumber, @note, @agenttype , @lastaction)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);
        DBConnect.DBCommand.Parameters.AddWithValue("@civilid", civilid);
        DBConnect.DBCommand.Parameters.AddWithValue("@mobile", mobile);
        DBConnect.DBCommand.Parameters.AddWithValue("@email", email);
        DBConnect.DBCommand.Parameters.AddWithValue("@vatid", vatid);
        DBConnect.DBCommand.Parameters.AddWithValue("@publicnumber", publicnumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentname", agentname);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentcivilid", agentcivilid);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentmobile", agentmobile);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentemail", agentemail);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentvatid", agentvatid);
        DBConnect.DBCommand.Parameters.AddWithValue("@agencynumber", agencynumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentpublicnumber", agentpublicnumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@officename", officename);
        DBConnect.DBCommand.Parameters.AddWithValue("@officecr", officecr);
        DBConnect.DBCommand.Parameters.AddWithValue("@officephone", officephone);
        DBConnect.DBCommand.Parameters.AddWithValue("@officeemail", officeemail);
        DBConnect.DBCommand.Parameters.AddWithValue("@officevatid", officevatid);
        DBConnect.DBCommand.Parameters.AddWithValue("@officepublicnumber", officepublicnumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@agenttype", agenttype);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", @lastaction);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbAgent SET number = @number,  name = @name, civilid = @civilid, mobile = @mobile, email = @email, vatid = @vatid,  publicnumber = @publicnumber, agentname = @agentname, agentcivilid = @agentcivilid, agentmobile = @agentmobile, agentemail = @agentemail, agentvatid = @agentvatid, agencynumber = @agencynumber, agentpublicnumber = @agentpublicnumber, officename = @officename, officecr = @officecr, officephone = @officephone, officeemail = @officeemail, officevatid = @officevatid, officepublicnumber = @officepublicnumber, note = @note, agenttype = @agenttype , lastaction = @lastaction WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);
        DBConnect.DBCommand.Parameters.AddWithValue("@civilid", civilid);
        DBConnect.DBCommand.Parameters.AddWithValue("@mobile", mobile);
        DBConnect.DBCommand.Parameters.AddWithValue("@email", email);
        DBConnect.DBCommand.Parameters.AddWithValue("@vatid", vatid);
        DBConnect.DBCommand.Parameters.AddWithValue("@publicnumber", publicnumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentname", agentname);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentcivilid", agentcivilid);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentmobile", agentmobile);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentemail", agentemail);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentvatid", agentvatid);
        DBConnect.DBCommand.Parameters.AddWithValue("@agencynumber", agencynumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@agentpublicnumber", agentpublicnumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@officename", officename);
        DBConnect.DBCommand.Parameters.AddWithValue("@officecr", officecr);
        DBConnect.DBCommand.Parameters.AddWithValue("@officephone", officephone);
        DBConnect.DBCommand.Parameters.AddWithValue("@officeemail", officeemail);
        DBConnect.DBCommand.Parameters.AddWithValue("@officevatid", officevatid);
        DBConnect.DBCommand.Parameters.AddWithValue("@officepublicnumber", officepublicnumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@agenttype", agenttype);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", @lastaction);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbAgent WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbAgent  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbAgent";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbAgent>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbAgent", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAgent Agent = new tbAgent();

            Agent.guid = new Guid(dr["guid"].ToString());
            Agent.number = (int)dr["number"];
            Agent.name = (string)dr["name"];
            Agent.civilid = (string)dr["civilid"];
            Agent.mobile = (string)dr["mobile"];
            Agent.email = (string)dr["email"];
            Agent.vatid = (string)dr["vatid"];
            Agent.publicnumber = (string)dr["publicnumber"];
            Agent.agentname = (string)dr["agentname"];
            Agent.agentemail = (string)dr["agentemail"];
            Agent.agentcivilid = (string)dr["agentcivilid"];
            Agent.agentmobile = (string)dr["agentmobile"];
            Agent.agentvatid = (string)dr["agentvatid"];
            Agent.agencynumber = (string)dr["agencynumber"];
            Agent.agentpublicnumber = (string)dr["agentpublicnumber"];
            Agent.officename = (string)dr["officename"];
            Agent.officecr = (string)dr["officecr"];
            Agent.officephone = (string)dr["officephone"];
            Agent.officeemail = (string)dr["officeemail"];
            Agent.officevatid = (string)dr["officevatid"];
            Agent.officepublicnumber = (string)dr["officepublicnumber"];
            Agent.note = (string)dr["note"];
            Agent.agenttype = (int)dr["agenttype"];
            Agent.lastaction = (string)dr["lastaction"];

            lstData.Add(Agent);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbAgent>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbAgent WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAgent Agent = new tbAgent();

            Agent.guid = new Guid(dr["guid"].ToString());
            Agent.number = (int)dr["number"];
            Agent.name = (string)dr["name"];
            Agent.civilid = (string)dr["civilid"];
            Agent.mobile = (string)dr["mobile"];
            Agent.email = (string)dr["email"];
            Agent.vatid = (string)dr["vatid"];
            Agent.publicnumber = (string)dr["publicnumber"];
            Agent.agentname = (string)dr["agentname"];
            Agent.agentemail = (string)dr["agentemail"];
            Agent.agentcivilid = (string)dr["agentcivilid"];
            Agent.agentmobile = (string)dr["agentmobile"];
            Agent.agentvatid = (string)dr["agentvatid"];
            Agent.agencynumber = (string)dr["agencynumber"];
            Agent.agentpublicnumber = (string)dr["agentpublicnumber"];
            Agent.officename = (string)dr["officename"];
            Agent.officecr = (string)dr["officecr"];
            Agent.officephone = (string)dr["officephone"];
            Agent.officeemail = (string)dr["officeemail"];
            Agent.officevatid = (string)dr["officevatid"];
            Agent.officepublicnumber = (string)dr["officepublicnumber"];
            Agent.note = (string)dr["note"];
            Agent.agenttype = (int)dr["agenttype"];
            Agent.lastaction = (string)dr["lastaction"];

            lstData.Add(Agent);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbAgent>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAgent WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAgent Agent = new tbAgent();

            Agent.guid = new Guid(dr["guid"].ToString());
            Agent.number = (int)dr["number"];
            Agent.name = (string)dr["name"];
            Agent.civilid = (string)dr["civilid"];
            Agent.mobile = (string)dr["mobile"];
            Agent.email = (string)dr["email"];
            Agent.vatid = (string)dr["vatid"];
            Agent.publicnumber = (string)dr["publicnumber"];
            Agent.agentname = (string)dr["agentname"];
            Agent.agentemail = (string)dr["agentemail"];
            Agent.agentcivilid = (string)dr["agentcivilid"];
            Agent.agentmobile = (string)dr["agentmobile"];
            Agent.agentvatid = (string)dr["agentvatid"];
            Agent.agencynumber = (string)dr["agencynumber"];
            Agent.agentpublicnumber = (string)dr["agentpublicnumber"];
            Agent.officename = (string)dr["officename"];
            Agent.officecr = (string)dr["officecr"];
            Agent.officephone = (string)dr["officephone"];
            Agent.officeemail = (string)dr["officeemail"];
            Agent.officevatid = (string)dr["officevatid"];
            Agent.officepublicnumber = (string)dr["officepublicnumber"];
            Agent.note = (string)dr["note"];
            Agent.agenttype = (int)dr["agenttype"];
            Agent.lastaction = (string)dr["lastaction"];

            lstData.Add(Agent);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbAgent>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAgent WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAgent Agent = new tbAgent();

            Agent.guid = new Guid(dr["guid"].ToString());
            Agent.number = (int)dr["number"];
            Agent.name = (string)dr["name"];
            Agent.civilid = (string)dr["civilid"];
            Agent.mobile = (string)dr["mobile"];
            Agent.email = (string)dr["email"];
            Agent.vatid = (string)dr["vatid"];
            Agent.publicnumber = (string)dr["publicnumber"];
            Agent.agentname = (string)dr["agentname"];
            Agent.agentemail = (string)dr["agentemail"];
            Agent.agentcivilid = (string)dr["agentcivilid"];
            Agent.agentmobile = (string)dr["agentmobile"];
            Agent.agentvatid = (string)dr["agentvatid"];
            Agent.agencynumber = (string)dr["agencynumber"];
            Agent.agentpublicnumber = (string)dr["agentpublicnumber"];
            Agent.officename = (string)dr["officename"];
            Agent.officecr = (string)dr["officecr"];
            Agent.officephone = (string)dr["officephone"];
            Agent.officeemail = (string)dr["officeemail"];
            Agent.officevatid = (string)dr["officevatid"];
            Agent.officepublicnumber = (string)dr["officepublicnumber"];
            Agent.note = (string)dr["note"];
            Agent.agenttype = (int)dr["agenttype"];
            Agent.lastaction = (string)dr["lastaction"];

            lstData.Add(Agent);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(string dbcolumn, string keyword, int agenttype)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbAgent>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAgent WHERE {0} LIKE '%{1}%' AND agenttype = @agenttype", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@agenttype", agenttype);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);

        foreach (DataRow dr in dtData.Rows)
        {
            tbAgent Agent = new tbAgent();

            Agent.guid = new Guid(dr["guid"].ToString());
            Agent.number = (int)dr["number"];
            Agent.name = (string)dr["name"];
            Agent.civilid = (string)dr["civilid"];
            Agent.mobile = (string)dr["mobile"];
            Agent.email = (string)dr["email"];
            Agent.vatid = (string)dr["vatid"];
            Agent.publicnumber = (string)dr["publicnumber"];
            Agent.agentname = (string)dr["agentname"];
            Agent.agentemail = (string)dr["agentemail"];
            Agent.agentcivilid = (string)dr["agentcivilid"];
            Agent.agentmobile = (string)dr["agentmobile"];
            Agent.agentvatid = (string)dr["agentvatid"];
            Agent.agencynumber = (string)dr["agencynumber"];
            Agent.agentpublicnumber = (string)dr["agentpublicnumber"];
            Agent.officename = (string)dr["officename"];
            Agent.officecr = (string)dr["officecr"];
            Agent.officephone = (string)dr["officephone"];
            Agent.officeemail = (string)dr["officeemail"];
            Agent.officevatid = (string)dr["officevatid"];
            Agent.officepublicnumber = (string)dr["officepublicnumber"];
            Agent.note = (string)dr["note"];
            Agent.agenttype = (int)dr["agenttype"];
            Agent.lastaction = (string)dr["lastaction"];

            lstData.Add(Agent);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static tbAgent FindBy(string dbcolumn, object val)
    {
        tbAgent Agent = new tbAgent();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAgent WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Agent.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Agent.number = (int)DBConnect.DBReader["number"];
            Agent.name = (string)DBConnect.DBReader["name"];
            Agent.civilid = (string)DBConnect.DBReader["civilid"];
            Agent.mobile = (string)DBConnect.DBReader["mobile"];
            Agent.email = (string)DBConnect.DBReader["email"];
            Agent.vatid = (string)DBConnect.DBReader["vatid"];
            Agent.publicnumber = (string)DBConnect.DBReader["publicnumber"];
            Agent.agentname = (string)DBConnect.DBReader["agentname"];
            Agent.agentemail = (string)DBConnect.DBReader["agentemail"];
            Agent.agentcivilid = (string)DBConnect.DBReader["agentcivilid"];
            Agent.agentmobile = (string)DBConnect.DBReader["agentmobile"];
            Agent.agentvatid = (string)DBConnect.DBReader["agentvatid"];
            Agent.agencynumber = (string)DBConnect.DBReader["agencynumber"];
            Agent.agentpublicnumber = (string)DBConnect.DBReader["agentpublicnumber"];
            Agent.officename = (string)DBConnect.DBReader["officename"];
            Agent.officecr = (string)DBConnect.DBReader["officecr"];
            Agent.officephone = (string)DBConnect.DBReader["officephone"];
            Agent.officeemail = (string)DBConnect.DBReader["officeemail"];
            Agent.officevatid = (string)DBConnect.DBReader["officevatid"];
            Agent.officepublicnumber = (string)DBConnect.DBReader["officepublicnumber"];
            Agent.note = (string)DBConnect.DBReader["note"];
            Agent.agenttype = (int)DBConnect.DBReader["agenttype"];
            Agent.lastaction = (string)DBConnect.DBReader["lastaction"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Agent;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbAgent WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static bool IsExistTrans(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand.CommandText = string.Format("SELECT count(*) FROM tbAgent WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbAgent", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            lstUnique.Add((string)DBConnect.DBReader[dbcolumn.ToString()]);
        }
        DBConnect.DBReader.Close();
        return lstUnique;
    }

    public static int GetMaxNumber(string dbcolumn)
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbAgent", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbAgent", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static int GetMaxNumber(string dbcolumn, int agenttype)
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbAgent WHERE agenttype = @agenttype", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.AddWithValue("@agenttype", agenttype);
        DBConnect.DBCommand.Parameters.Clear();
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbAgent WHERE agenttype = @agenttype", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.AddWithValue("@agenttype", agenttype);

            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static int GetMaxNumberTrans(string dbcolumn, int agenttype)
    {
        DBConnect.DBCommand.CommandText = "SELECT COUNT(*) FROM tbAgent WHERE agenttype = @agenttype";
        DBConnect.DBCommand.Parameters.AddWithValue("@agenttype", agenttype);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
       
        DBConnect.DBCommand.Parameters.Clear();
        if (icount >= 1)
        {
            DBConnect.DBCommand.CommandText = string.Format("SELECT MAX({0}) FROM tbAgent WHERE agenttype = @agenttype", dbcolumn);
            DBConnect.DBCommand.Parameters.AddWithValue("@agenttype", agenttype);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
          

            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbAgent WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbAgent", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtcode
Txtname
Txtcivilid
Txtmobile
Txtvatid
Txtplanname
Txtplannumber
Txtpublicnumber
Txtagentname
Txtagentcivilid
Txtagentmobile
Txtagentvatid
Txtagencynumber
Txtagentpublicnumber
Txtofficename
Txtofficecr
Txtofficephone
Txtofficevatid
Txtofficepublicnumber
Txtnote
Chkagenttype


*/