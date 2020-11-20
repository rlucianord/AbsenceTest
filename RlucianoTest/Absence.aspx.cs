using AbsenceTest.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace AbsenceTest
{
    public partial class Absence : Page
    {
        ClConenection objConexion;
        ClAbsence ObjAbsence;
        string strCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DataTable Datatable;
        protected void Page_Load(object sender, EventArgs e)
        {
            ListAbsecense();




        }
        private void ListAbsecense()

        {
            objConexion = new ClConenection(strCon);
            objConexion.ErrorConexion += new EventHandler(objConexion_ErrorConexion);
            objConexion.Connect();
            ObjAbsence = new ClAbsence(objConexion);
            ObjAbsence.ErrorDatos += new EventHandler(objErrorPermiso_Error);
            Datatable = ObjAbsence.Buscar();
            ViewState["Permisos"] = Datatable;
            gvPermisos.DataSource = ViewState["Permisos"];
            gvPermisos.DataBind();
            objConexion.CloseConexion();
            objConexion = null;
            ObjAbsence = null;
        }
        protected void ibtnDelete_Click(object sender, EventArgs e)
        {
            objConexion = new ClConenection(strCon);
            objConexion.ErrorConexion += new EventHandler(objConexion_ErrorConexion);
            objConexion.Connect();
            //
            ObjAbsence = new ClAbsence(objConexion);
            ObjAbsence.ErrorDatos += new EventHandler(objErrorPermiso_Error);
            ObjAbsence.Delete(int.Parse(((ImageButton)(sender)).CommandArgument));
            //
            objConexion.CloseConexion();
            objConexion = null;
            ObjAbsence = null;
            //
            Page_Load(sender, EventArgs.Empty);
        }

        protected void ibtnEdit_Click(object sender, EventArgs e)
        {
            Session["Id"] = ((ImageButton)(sender)).CommandArgument;
            Response.Redirect("AddEditAbsence.aspx");
        }

        protected void lbtnPrimero_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditAbsence.aspx");
        }

        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddEditAbsence.aspx");
        }

        protected void gvTarifas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPermisos.PageIndex = e.NewPageIndex;
            gvPermisos.DataSource = ViewState["Permisos"];
            gvPermisos.DataBind();
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
            ShowHideError(true, ObjAbsence.LastError);
        }
    }
}