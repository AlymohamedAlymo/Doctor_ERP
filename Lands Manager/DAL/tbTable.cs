using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbTable
{

    public static List<tbTable> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "Guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid Guid { get; set; }
    [DataGUIAttribute(GUIName = "RegDate", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtRegDate")]
    public DateTime RegDate { get; set; }
    [DataGUIAttribute(GUIName = "Number", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtNumber")]
    public int Number { get; set; }
    [DataGUIAttribute(GUIName = "Name", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtName")]
    public string Name { get; set; }
    [DataGUIAttribute(GUIName = "Type", Formatting = "", Visibility = true, Width = 100, ControlName = "CmbType")]
    public string Type { get; set; }
    [DataGUIAttribute(GUIName = "Fav", Formatting = "", Visibility = true, Width = 100, ControlName = "ChkFav")]
    public bool Fav { get; set; }
    [DataGUIAttribute(GUIName = "Price", Formatting = "N2", Visibility = true, Width = 100, ControlName = "TxtPrice")]
    public float Price { get; set; }
    [DataGUIAttribute(GUIName = "Note", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtNote")]
    public string Note { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbTable VALUES (@Guid, @RegDate, @Number, @Name, @Type, @Fav, @Price, @Note)";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@RegDate", RegDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@Number", Number);
        DBConnect.DBCommand.Parameters.AddWithValue("@Name", Name);
        DBConnect.DBCommand.Parameters.AddWithValue("@Type", Type);
        DBConnect.DBCommand.Parameters.AddWithValue("@Fav", Fav);
        DBConnect.DBCommand.Parameters.AddWithValue("@Price", Price);
        DBConnect.DBCommand.Parameters.AddWithValue("@Note", Note);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbTable SET RegDate = @RegDate, Number = @Number, Name = @Name, Type = @Type, Fav = @Fav, Price = @Price, Note = @Note WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@RegDate", RegDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@Number", Number);
        DBConnect.DBCommand.Parameters.AddWithValue("@Name", Name);
        DBConnect.DBCommand.Parameters.AddWithValue("@Type", Type);
        DBConnect.DBCommand.Parameters.AddWithValue("@Fav", Fav);
        DBConnect.DBCommand.Parameters.AddWithValue("@Price", Price);
        DBConnect.DBCommand.Parameters.AddWithValue("@Note", Note);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbTable WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbTable  WHERE {0} = @val", dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbTable>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbTable", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTable table = new tbTable();

            table.Guid = new Guid(dr["Guid"].ToString());
            table.RegDate = (DateTime)dr["RegDate"];
            table.Number = (int)dr["Number"];
            table.Name = (string)dr["Name"];
            table.Type = (string)dr["Type"];
            table.Fav = (bool)dr["Fav"];
            table.Price = float.Parse(dr["Price"].ToString());
            table.Note = (string)dr["Note"];

            lstData.Add(table);
        }
    }

    public static void Fill(Guid guid)
    {
        lstData = new List<tbTable>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbTable WHERE Guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTable table = new tbTable();

            table.Guid = new Guid(dr["Guid"].ToString());
            table.RegDate = (DateTime)dr["RegDate"];
            table.Number = (int)dr["Number"];
            table.Name = (string)dr["Name"];
            table.Type = (string)dr["Type"];
            table.Fav = (bool)dr["Fav"];
            table.Price = float.Parse(dr["Price"].ToString());
            table.Note = (string)dr["Note"];

            lstData.Add(table);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbTable>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbTable WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTable table = new tbTable();

            table.Guid = new Guid(dr["Guid"].ToString());
            table.RegDate = (DateTime)dr["RegDate"];
            table.Number = (int)dr["Number"];
            table.Name = (string)dr["Name"];
            table.Type = (string)dr["Type"];
            table.Fav = (bool)dr["Fav"];
            table.Price = float.Parse(dr["Price"].ToString());
            table.Note = (string)dr["Note"];

            lstData.Add(table);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbTable>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbTable WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@keyword", keyword);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTable table = new tbTable();

            table.Guid = new Guid(dr["Guid"].ToString());
            table.RegDate = (DateTime)dr["RegDate"];
            table.Number = (int)dr["Number"];
            table.Name = (string)dr["Name"];
            table.Type = (string)dr["Type"];
            table.Fav = (bool)dr["Fav"];
            table.Price = float.Parse(dr["Price"].ToString());
            table.Note = (string)dr["Note"];

            lstData.Add(table);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbTable FindBy(string dbcolumn, object val)
    {
        tbTable table = new tbTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbTable WHERE {0} = @{1}", dbcolumn, dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            table.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            table.RegDate = (DateTime)DBConnect.DBReader["RegDate"];
            table.Number = (int)DBConnect.DBReader["Number"];
            table.Name = (string)DBConnect.DBReader["Name"];
            table.Type = (string)DBConnect.DBReader["Type"];
            table.Fav = (bool)DBConnect.DBReader["Fav"];
            table.Price = float.Parse(DBConnect.DBReader["Price"].ToString());
            table.Note = (string)DBConnect.DBReader["Note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return table;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbTable WHERE {0} = @{1}", dbcolumn, dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbTable", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbTable", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbTable", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbTable WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbTable", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

