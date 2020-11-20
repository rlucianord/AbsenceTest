using AbsenceTest.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AbsenceTest
{
    public partial class AddEditAbsence : Page
    {
        ClConenection objConexion;
        ClAbsence ObjPermisos;
        string strCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DataTable DataTable;
        protected void Page_Load(object sender, EventArgs e)
        {


            ShowHideError(false, "");
            if (!IsPostBack)
            {
                objConexion = new ClConenection(strCon);
                objConexion.Connect();
                ObjPermisos = new ClAbsence(objConexion);
                ObjPermisos.ErrorDatos += new EventHandler(objErrorPermiso_Error);
                var tipospermisos = ObjPermisos.ListTipoPermisos();
                ddlapbsencetaype.DataSource = tipospermisos;
                ddlapbsencetaype.DataBind();

                ddlapbsencetaype.DataTextField = "Descripcion";
                ddlapbsencetaype.DataValueField = "Id";
                ddlapbsencetaype.DataBind();
                Absence();
                objConexion.CloseConexion();
                objConexion = null;
                ObjPermisos = null;
            }

        }

        private void Absence()

        {
            if (Session["Id"] != null)
            {
                var tblTarifas = new DataTable();
                DataTable = ObjPermisos.Buscar(int.Parse(Session["Id"].ToString()));
                //
                if (DataTable.Rows.Count > 0)
                {
                    TbxName.Text = DataTable.Rows[0]["NombreEmpleado"].ToString();
                    TbxLastName.Text = DataTable.Rows[0]["ApellidosEmpleado"].ToString();
                    AbsenceDate.Text = string.Format("{0:0:yyyy-MM-dd}", DateTime.Parse(DataTable.Rows[0]["FechaPermiso"].ToString()).ToShortDateString());
                    ddlapbsencetaype.SelectedValue = DataTable.Rows[0]["TipoPermiso"].ToString();


                }
            }
            else
                Session["Id"] = null;


        }
        protected void ShowHideError(Boolean ShowHide, String Mensaje)
        {
            //pnlError.Visible = ShowHide;
            //lblError.Text = Mensaje;
        }
        void objConexion_ErrorConexion(object sender, EventArgs e)
        {
            ShowHideError(true, objConexion.LastError);
        }

        void objErrorPermiso_Error(object sender, EventArgs e)
        {
            ShowHideError(true, ObjPermisos.LastError);
        }

        protected void ibtnOk_Click(object sender, EventArgs e)
        {
            objConexion = new ClConenection(strCon);
            objConexion.Connect();
            ObjPermisos = new ClAbsence(objConexion);
            ObjPermisos.ErrorDatos += new EventHandler(objErrorPermiso_Error);
            bool Failed = false;


            if (Session["Id"] != null)
                Failed = ObjPermisos.Update(TbxName.Text, TbxLastName.Text, int.Parse(ddlapbsencetaype.SelectedValue), DateTime.Parse(AbsenceDate.Text), int.Parse(Session["Id"].ToString()));
            else
                Failed = ObjPermisos.Insert(TbxName.Text, TbxLastName.Text, int.Parse(ddlapbsencetaype.SelectedValue), DateTime.Parse(AbsenceDate.Text));
            //
            objConexion.CloseConexion();
            objConexion = null;
            ObjPermisos = null;
            //
            if (Failed)
                Response.Redirect("Absence.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Absence.aspx");
        }
    }
}
