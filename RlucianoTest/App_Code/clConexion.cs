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

/// 
namespace AbsenceTest.App_Code
{/// <summary>
/// This class is for instance of the conecction
/// </summary>
    public partial class ClConenection
    {
        private SqlConnection SqlConexion;
        string CnStr;
        string Error;

        public event EventHandler ErrorConexion;

        public ClConenection(string strCon)
        {
            CnStr = strCon;
            LastError = "";
        }

        public void Connect()
        {
            Start(CnStr);
        }

        public void Start(string StrCon)
        {
            SqlConexion = new SqlConnection(StrCon);
            try { SqlConexion.Open(); }
            catch (SqlException esql) { LastError = esql.Message; }
            catch (Exception ex) { LastError = ex.Message; }
            if (LastError != "") { ErrorConexion?.Invoke(this, EventArgs.Empty); }
        }

        public void CloseConexion()
        {
            SqlConexion.Close();
        }

        public SqlConnection Connection
        {
            get { return SqlConexion; }
        }

        public string LastError
        {
            get { return Error; }
            set { Error = value; }
        }
    }
}