using AbsenceTest.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AbsenceTest.Models;
namespace AbsenceTest
{
    public partial class Absence : Page
    {

        AbsenceImplementation AbsenceImplementation;
        protected void Page_Load(object sender, EventArgs e)
        {
            ListAbsecense();




        }
        private void ListAbsecense()

        {
            AbsenceImplementation = new AbsenceImplementation();
            var query = (from ab in AbsenceImplementation.GetAbsences()
                         select new
                         {
                             ab.Id,
                             ab.NombreEmpleado,
                             ab.ApellidosEmpleado,
                             DescTipoPermiso=ab.AbsenceType.Descripcion,
                             ab.FechaPermiso

                         }).AsEnumerable();


            ViewState["Permisos"] = ConverTable.LINQToDataTable(query);
            gvPermisos.DataSource = ViewState["Permisos"];
            gvPermisos.DataBind();

        }
        protected void ibtnDelete_Click(object sender, EventArgs e)
        {
            //objConexion = new ClConenection(strCon);
            //objConexion.ErrorConexion += new EventHandler(objConexion_ErrorConexion);
            //objConexion.Connect();
            ////
            //ObjAbsence = new ClAbsence(objConexion);
            //ObjAbsence.ErrorDatos += new EventHandler(objErrorPermiso_Error);
            //ObjAbsence.Delete(int.Parse(((ImageButton)(sender)).CommandArgument));
            ////
            //objConexion.CloseConexion();
            //objConexion = null;
            //ObjAbsence = null;
            ////
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
            Session["Id"] = null;
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

    }
}