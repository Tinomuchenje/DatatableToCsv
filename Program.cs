using System;
using System.Data;
using System.IO;
using System.Text;

public static class Extensions
{
    public static string ToCSV(this DataTable table)
    {
        var result = new StringBuilder();
        for (int i = 0; i < table.Columns.Count; i++)
        {
            result.Append(table.Columns[i].ColumnName);
            result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
        }

        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(row[i].ToString());
                result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
            }
        }

        return result.ToString();
    }
}

public class Program
{
    public static void Main()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Name");
        table.Columns.Add("Age");
        table.Rows.Add("John Doe", "45");
        table.Rows.Add("Jane Doe", "35");
        table.Rows.Add("Jack Doe", "27");

        string csv = table.ToCSV();
        File.WriteAllText("output.csv", csv);
    }
}
