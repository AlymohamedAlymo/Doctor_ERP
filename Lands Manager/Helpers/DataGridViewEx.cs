using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

class DataGridViewEx : KryptonDataGridView
{

    public enum Direction
    {
        Right,
        Left
    }

    #region Fields
    private object _lastvalue;
    public object LastValue
    {
        get
        {
            return _lastvalue;
        }
    }

    private object _prevvalue;
    public object PrevValue
    {
        get
        {
            return _prevvalue;
        }
    }

    public DataGridViewColumn FirstVisibleColumn
    {
        get
        {
            DataGridViewColumnCollection columnCollection = this.Columns;
            DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);
            return firstVisibleColumn;
        }
    }

    public DataGridViewColumn LastVisibleColumn
    {
        get
        {
            DataGridViewColumnCollection columnCollection = this.Columns;
            DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);
            return lastVisibleColumn;
        }
    }
    #endregion

    #region override
    protected override bool ProcessDialogKey(Keys keyData)
    {
        if (keyData == Keys.Enter)
        {
            EndEdit();
            return true;
        }
        return base.ProcessDialogKey(keyData);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
            e.Handled = true;
        base.OnKeyDown(e);
    }

    protected override void OnCellLeave(DataGridViewCellEventArgs e)
    {
        if (CurrentCell.IsInEditMode)
            EndEdit();

        base.OnCellLeave(e);
    }

    protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
    {
        _lastvalue = CurrentCell.Value;
        base.OnCellEndEdit(e);
    }

    protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
    {
        _prevvalue = CurrentCell.Value;
        base.OnCellBeginEdit(e);
    }

    protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
    {
        e.Cancel = true;
    }
    #endregion

    #region Moves
    public void MoveToLeftColumn()
    {
        DataGridViewColumnCollection columnCollection = this.Columns;
        DataGridViewColumn NextColumn = columnCollection.GetNextColumn(this.Columns[CurrentCell.ColumnIndex], DataGridViewElementStates.Visible, DataGridViewElementStates.None);
        if (NextColumn != null)
            CurrentCell = Rows[CurrentCell.RowIndex].Cells[NextColumn.Index];
    }

    public void MoveToRightColumn()
    {
        DataGridViewColumnCollection columnCollection = this.Columns;
        DataGridViewColumn PrevColumn = columnCollection.GetPreviousColumn(this.Columns[CurrentCell.ColumnIndex], DataGridViewElementStates.Visible, DataGridViewElementStates.None);
        if (PrevColumn != null)
            CurrentCell = Rows[CurrentCell.RowIndex].Cells[PrevColumn.Index];
    }

    public void MoveToFirstColumn()
    {
        DataGridViewColumnCollection columnCollection = this.Columns;
        DataGridViewColumn firstVisibleColumn = columnCollection.GetFirstColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

        CurrentCell = Rows[CurrentCell.RowIndex].Cells[firstVisibleColumn.Index];
    }

    public void MoveToLastColumn()
    {
        DataGridViewColumnCollection columnCollection = this.Columns;
        DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);

        CurrentCell = Rows[CurrentCell.RowIndex].Cells[lastVisibleColumn.Index];
    }

    public void MoveToNextRow()
    {
        DataGridViewRowCollection rowCollection = this.Rows;
        int NextRow = rowCollection.GetNextRow(CurrentRow.Index, DataGridViewElementStates.None);
        if (NextRow > 0)
            CurrentCell = Rows[NextRow].Cells[CurrentCell.ColumnIndex];
    }

    public void MoveToPrevRow()
    {
        DataGridViewRowCollection rowCollection = this.Rows;
        int PrevRow = rowCollection.GetPreviousRow(CurrentRow.Index, DataGridViewElementStates.None);

        if (PrevRow >= 0)
            CurrentCell = Rows[PrevRow].Cells[CurrentCell.ColumnIndex];
    }

    public void MoveToFirstRow()
    {
        DataGridViewRowCollection rowCollection = this.Rows;
        int FirstRow = rowCollection.GetFirstRow(DataGridViewElementStates.None);

        if (FirstRow >= 0)
            CurrentCell = Rows[FirstRow].Cells[CurrentCell.ColumnIndex];
    }

    public void MoveToLastRow()
    {
        DataGridViewRowCollection rowCollection = this.Rows;
        int LastRow = rowCollection.GetLastRow(DataGridViewElementStates.None);

        if (LastRow > -1)
            CurrentCell = Rows[LastRow].Cells[CurrentCell.ColumnIndex];
    }


    public void MoveToColumn(string ColumnName)
    {
        CurrentCell = Rows[CurrentCell.RowIndex].Cells[ColumnName];
    }

    public void MoveToRow(int RowIndex)
    {
        CurrentCell = Rows[RowIndex].Cells[CurrentCell.ColumnIndex];
    }

    public void MoveToNextCell(Direction direction, int End_ColumnIndex, int Start_ColumnIndex)
    {
        if (direction == Direction.Left)
        {
            DataGridViewColumnCollection columnCollection = this.Columns;
            DataGridViewColumn NextColumn = columnCollection.GetNextColumn(this.Columns[CurrentCell.ColumnIndex], DataGridViewElementStates.Visible, DataGridViewElementStates.None);
            if (NextColumn != null && NextColumn.Index <= Start_ColumnIndex)
                CurrentCell = Rows[CurrentCell.RowIndex].Cells[NextColumn.Index];
            else
            {
                MoveToNextRow();
                MoveToColumn(Columns[End_ColumnIndex].Name);
            }
        }
        else if (direction == Direction.Right)
        {
            DataGridViewColumnCollection columnCollection = this.Columns;
            DataGridViewColumn PrevColumn = columnCollection.GetPreviousColumn(this.Columns[CurrentCell.ColumnIndex], DataGridViewElementStates.Visible, DataGridViewElementStates.None);
            if (PrevColumn != null && PrevColumn.Index >= End_ColumnIndex)
                CurrentCell = Rows[CurrentCell.RowIndex].Cells[PrevColumn.Index];
            else
            {
                MoveToNextRow();
                MoveToColumn(Columns[Start_ColumnIndex].Name);
            }
        }
    }

    public void MoveTo(int RowIndex, int ColumnIndex)
    {
        CurrentCell = Rows[RowIndex].Cells[ColumnIndex];
    }
    #endregion

    #region Clear
    public void ClearCurrentCell()
    {
        var oType = CurrentCell.ValueType;
        object obj = null;
        if (oType == typeof(string))
            obj = string.Empty;
        else
        {
            obj = Activator.CreateInstance(oType);
            if (obj.Equals(0) || obj.Equals(0.0F))
                obj = DBNull.Value;
        }
        CurrentCell.Value = obj;
    }

    public void ClearCell(int RowIndex, string ColumnName)
    {
        var oType = CurrentCell.ValueType;
        object obj = null;
        if (oType == typeof(string))
            obj = string.Empty;
        else
        {
            obj = Activator.CreateInstance(oType);
            if (obj.Equals(0) || obj.Equals(0.0F))
                obj = DBNull.Value;
        }
        Rows[RowIndex].Cells[ColumnName].Value = obj;
    }

    public void ClearRow(int RowIndex)
    {
        List<dynamic> lstRowData = new List<dynamic>();
        foreach (DataGridViewColumn GridColumn in Columns)
        {
            var oType = GridColumn.ValueType;
            object obj = null;
            if (oType == typeof(string))
                obj = string.Empty;
            else
            {
                obj = Activator.CreateInstance(oType);
                if (obj.Equals(0) || obj.Equals(0.0F))
                    obj = DBNull.Value;
            }
            lstRowData.Add(obj);
        }

        foreach (DataGridViewCell c in Rows[RowIndex].Cells)
            c.Value = lstRowData[c.ColumnIndex];
    }
    #endregion

    #region Totals
    public float GetCurrentCellNumberValue()
    {
        float OneCellValue = 0;
        float.TryParse(CurrentCell.Value.ToString(), out OneCellValue);

        return OneCellValue;
    }

    public float GetCellNumberValue(int RowIndex, string ColumnName)
    {
        float OneCellValue = 0;
        float.TryParse(Rows[RowIndex].Cells[ColumnName].Value.ToString(), out OneCellValue);

        return OneCellValue;
    }


    public float GetColumnTotal(string ColumnName)
    {
        float TotalValue = 0;

        foreach (DataGridViewRow row in Rows)
        {
            float OneCellValue = 0;
            float.TryParse(row.Cells[ColumnName].Value.ToString(), out OneCellValue);
            TotalValue += OneCellValue;
        }
        return TotalValue;
    }
    #endregion
}

/* Usage
#region DataGrid Keys
private void DataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
{
    switch (e.ColumnIndex)
    {
        case 3:
            {
                float value = 0;
                float.TryParse(DataGridMain.LastValue.ToString(), out value);
                DataGridMain[colr.Name, e.RowIndex].Value = 10 + value;
            }
            break;
        case 4:
            {
                // DataGridMain.MoveToNextCell(DataGridViewEx.Direction.Left);
            }
            break;
        default:
            break;
    }
    DataGridMain.MoveToNextCell(DataGridViewEx.Direction.Left, DataGridMain.FirstVisibleColumn.Index + 1, DataGridMain.LastVisibleColumn.Index);
}

private void DataGrid_KeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyData == Keys.Enter)
    {
        DataGridMain.MoveToNextCell(DataGridViewEx.Direction.Left, DataGridMain.FirstVisibleColumn.Index + 1, DataGridMain.LastVisibleColumn.Index);
    }
    if (e.KeyData == Keys.Delete)
    {
        if (DataGridMain.CurrentCell.ColumnIndex != 2)
            DataGridMain.ClearCurrentCell();
    }
}

private void DataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
{
    if (e.ColumnIndex == 2 || e.ColumnIndex == 9)
        e.Cancel = true;
}
#endregion
*/

