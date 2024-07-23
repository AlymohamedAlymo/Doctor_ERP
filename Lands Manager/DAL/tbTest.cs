using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbTest
{

    public static List<tbTest> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "Guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid Guid { get; set; }
    [DataGUIAttribute(GUIName = "Name", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtName")]
    public string Name { get; set; }
    [DataGUIAttribute(GUIName = "Amount", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtAmount")]
    public decimal Amount { get; set; }
    [DataGUIAttribute(GUIName = "Amount2", Formatting = "N2", Visibility = true, Width = 100, ControlName = "TxtAmount2")]
    public float Amount2 { get; set; }
    [DataGUIAttribute(GUIName = "Qty", Formatting = "N0", Visibility = true, Width = 100, ControlName = "TxtQty")]
    public int Qty { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbTest VALUES (@Guid, @Name, @Amount, @Amount2, @Qty)";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@Name", Name);
        DBConnect.DBCommand.Parameters.AddWithValue("@Amount", Amount);
        DBConnect.DBCommand.Parameters.AddWithValue("@Amount2", Amount2);
        DBConnect.DBCommand.Parameters.AddWithValue("@Qty", Qty);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbTest SET Name = @Name, Amount = @Amount, Amount2 = @Amount2, Qty = @Qty WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@Name", Name);
        DBConnect.DBCommand.Parameters.AddWithValue("@Amount", Amount);
        DBConnect.DBCommand.Parameters.AddWithValue("@Amount2", Amount2);
        DBConnect.DBCommand.Parameters.AddWithValue("@Qty", Qty);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbTest WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbTest  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbTest";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbTest>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbTest", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTest test = new tbTest();

            test.Guid = new Guid(dr["Guid"].ToString());
            test.Name = (string)dr["Name"];
            test.Amount = decimal.Parse(dr["Amount"].ToString());
            test.Amount2 = float.Parse(dr["Amount2"].ToString());
            test.Qty = (int)dr["Qty"];

            lstData.Add(test);
        }
    }

    public static void Fill(Guid guid)
    {
        lstData = new List<tbTest>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbTest WHERE Guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTest test = new tbTest();

            test.Guid = new Guid(dr["Guid"].ToString());
            test.Name = (string)dr["Name"];
            test.Amount = decimal.Parse(dr["Amount"].ToString());
            test.Amount2 = float.Parse(dr["Amount2"].ToString());
            test.Qty = (int)dr["Qty"];

            lstData.Add(test);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbTest>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbTest WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTest test = new tbTest();

            test.Guid = new Guid(dr["Guid"].ToString());
            test.Name = (string)dr["Name"];
            test.Amount = decimal.Parse(dr["Amount"].ToString());
            test.Amount2 = float.Parse(dr["Amount2"].ToString());
            test.Qty = (int)dr["Qty"];

            lstData.Add(test);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbTest>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbTest WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTest test = new tbTest();

            test.Guid = new Guid(dr["Guid"].ToString());
            test.Name = (string)dr["Name"];
            test.Amount = decimal.Parse(dr["Amount"].ToString());
            test.Amount2 = float.Parse(dr["Amount2"].ToString());
            test.Qty = (int)dr["Qty"];

            lstData.Add(test);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbTest FindBy(string dbcolumn, object val)
    {
        tbTest test = new tbTest();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbTest WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            test.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            test.Name = (string)DBConnect.DBReader["Name"];
            test.Amount = (decimal)DBConnect.DBReader["Amount"];
            test.Amount2 = float.Parse(DBConnect.DBReader["Amount2"].ToString());
            test.Qty = (int)DBConnect.DBReader["Qty"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return test;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbTest WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbTest", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbTest", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbTest", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbTest WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbTest", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

TxtName
TxtAmount
TxtAmount2
TxtQty


*/
