using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public static class TableVisualisation
    {
        internal static void ShowTable<T>(List<T> tableData, string tableName = "") where T : class
        {
            Console.Clear();
            ConsoleTableBuilder.From(tableData).WithColumn(tableName).ExportAndWriteLine();
        }
    }
}
