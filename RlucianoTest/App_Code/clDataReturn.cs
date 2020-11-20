using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
///  This is a general purpose Class for return table in anywhere in the program
/// </summary>
namespace AbsenceTest.App_Code
{
    public class ClDataReturn
    {
         ClConenection objConnection;
        SqlDataAdapter DataAdapter;
        DataTable Table;
        string Error;

        public event EventHandler ErrorRetornaDatos;

        public ClDataReturn(ClConenection Connection)
        {
            objConnection = Connection;
            LastError = "";
        }

        public DataTable Buscar(SqlCommand Command)
        {
            Command.Connection = objConnection.Connection;
            Command.CommandTimeout = 0;
            //
            DataAdapter = new SqlDataAdapter(Command);
            Table = new DataTable();
            //
            try { DataAdapter.Fill(Table); }
            catch (SqlException esql) { LastError = esql.Message; }
            catch (Exception ex) { LastError = ex.Message; }
            if (LastError != "") { ErrorRetornaDatos?.Invoke(this, EventArgs.Empty); }
            //
            return Table;
        }

        public string LastError
        {
            get { return Error; }
            set { Error = value; }
        }
    }
}