using AbsenceTest.App_Code;
using AbsenceTest.Models;
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
        AbsenceImplementation AbsenceImplementation;
        private static Permiso Absences;
        protected void Page_Load(object sender, EventArgs e)
        {


            ShowHideError(false, "");
            if (!IsPostBack)
            {
                Absences = new Permiso();
                AbsenceImplementation = new AbsenceImplementation();
                var tipospermisos = ConverTable.LINQToDataTable(AbsenceImplementation.GetAbsenceTypes());
                ddlapbsencetaype.DataSource = tipospermisos;
                ddlapbsencetaype.DataBind();

                ddlapbsencetaype.DataTextField = "Descripcion";
                ddlapbsencetaype.DataValueField = "Id";
                ddlapbsencetaype.DataBind();
                Absence();
            }

        }

        private void Absence()

        {
            if (Session["Id"] != null)
            {
                int Id = int.Parse(Session["Id"].ToString());
                var tblTarifas = new DataTable();
                Absences = AbsenceImplementation.GetAbsences().Where(a => a.Id == Id).FirstOrDefault();
                //ConverTable.LINQToDataTable(AbsenceImplementation.GetAbsences().Where(a=>a.Id== Id));

                if (Absences != null)
                {
                    TbxName.Text = Absences.NombreEmpleado;
                    TbxLastName.Text = Absences.ApellidosEmpleado;
                    AbsenceDate.Text = string.Format("{0:0:yyyy-MM-dd}", Absences.FechaPermiso.ToShortDateString());
                    ddlapbsencetaype.SelectedValue = Absences.TipoPermiso.ToString();



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


        protected void ibtnOk_Click(object sender, EventArgs e)
        {
            bool Failed = false;
            try
            {
                AbsenceImplementation = new AbsenceImplementation();
                if (Absences == null)

                    Absences = new Permiso();


                Absences.NombreEmpleado = TbxName.Text.ToUpper();
                Absences.FechaPermiso = DateTime.Parse(AbsenceDate.Text);
                Absences.ApellidosEmpleado = TbxLastName.Text.ToUpper();

                Absences.TipoPermiso = int.Parse(ddlapbsencetaype.SelectedValue);
                if (Session["Id"] != null)
                    AbsenceImplementation.UpdateAbsence(Absences);
                else
                    AbsenceImplementation.AddAbsence(Absences);
                Failed = true;
            }
            catch (Exception)
            {

                Failed = false;
            }






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
