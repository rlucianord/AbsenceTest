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
/// Summary 
/// This class manage all Data for Absences
/// </summary>
/// 

namespace AbsenceTest.App_Code
{
    public class ClAbsence
    {
        ClConenection ObConecction;
        ClDataReturn ObjDataReturn;
        SqlCommand Command;
        DataTable Table;
        string Error;

        public event EventHandler ErrorDatos;
      
        public ClAbsence(ClConenection Conexion)
        {
            ObConecction = Conexion;
            Command = new SqlCommand();
            Command.CommandType = CommandType.StoredProcedure;
            //
            ObjDataReturn = new ClDataReturn(ObConecction);
            ObjDataReturn.ErrorRetornaDatos += new EventHandler(ObRetornaDatos_ErrorRetornaDatos);
            LastError = "";
        }

        void ObRetornaDatos_ErrorRetornaDatos(Object sender, EventArgs e)
        {
            LastError = ObjDataReturn.LastError;
            if (LastError != "") { if (ErrorDatos != null) ErrorDatos(this, EventArgs.Empty); }
        }

        public DataTable ListTipoPermisos()
        {
            Command.CommandText = "Ltipo_Permisos";
            Command.Parameters.Clear();
            //
            Table = ObjDataReturn.Buscar(Command);
            return Table;
        }


        public DataTable Find()
        {
            Command.CommandText = "L_Permisos";
            Command.Parameters.Clear();
            //
            Table = ObjDataReturn.Buscar(Command);
            return Table;
        }
        public DataTable Find(int IdPermiso)
        {
            Command.CommandText = "L_Permisos";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@IdPermiso", IdPermiso);
            //
            Table = ObjDataReturn.Buscar(Command);
            return Table;
        }

        public Boolean Insert(string Nombres, string Apellidos, int TipoPermiso, DateTime Fecha)
        {
            Command.CommandText = "P_M_Permisos";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@flag", 1);
            Command.Parameters.AddWithValue("@NombreEmpleado", Nombres);
            Command.Parameters.AddWithValue("@ApellidosEmpleado", Apellidos);
            Command.Parameters.AddWithValue("@TipoPermiso", TipoPermiso);
            Command.Parameters.AddWithValue("@FechaPermiso", Fecha);

            Command.Connection = ObConecction.Connection;
            //
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (SqlException esql)
            {
                LastError = esql.Message;
                if (ErrorDatos != null) ErrorDatos(this, EventArgs.Empty);
                return false;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                if (ErrorDatos != null) ErrorDatos(this, EventArgs.Empty);
                return false;
            }
            return true;
        }


        public Boolean Update(string Nombres, string Apellidos, int TipoPermiso, DateTime Fecha, int Id)
        {
            Command.CommandText = "P_M_Permisos";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@flag", 2);
            Command.Parameters.AddWithValue("@NombreEmpleado", Nombres);
            Command.Parameters.AddWithValue("@ApellidosEmpleado", Apellidos);
            Command.Parameters.AddWithValue("@TipoPermiso", TipoPermiso);
            Command.Parameters.AddWithValue("@FechaPermiso", Fecha);
            Command.Parameters.AddWithValue("@Id", Id);

            Command.Connection = ObConecction.Connection;
            //
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (SqlException esql)
            {
                LastError = esql.Message;
                if (ErrorDatos != null) ErrorDatos(this, EventArgs.Empty);
                return false;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                if (ErrorDatos != null) ErrorDatos(this, EventArgs.Empty);
                return false;
            }
            return true;
        }


        public Boolean Delete(int Id)
        {
            Command.CommandText = "P_M_Permisos";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@flag", 3);
            //Command.Parameters.AddWithValue("@NombreEmpleado", "");
            //Command.Parameters.AddWithValue("@ApellidosEmpleado", "");
            //Command.Parameters.AddWithValue("@TipoPermiso", "");
            //Command.Parameters.AddWithValue("@FechaPermiso", "");
            Command.Parameters.AddWithValue("@Id", Id);

            Command.Connection = ObConecction.Connection;


            try
            {
                Command.ExecuteNonQuery();
            }
            catch (SqlException esql)
            {
                LastError = esql.Message;
                if (ErrorDatos != null) ErrorDatos(this, EventArgs.Empty);
                return false;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                if (ErrorDatos != null) ErrorDatos(this, EventArgs.Empty);
                return false;
            }
            return true;
        }

        public string LastError
        {
            get { return Error; }
            set { Error = value; }
        }
    }
}