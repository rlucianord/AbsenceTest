using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace AbsenceTest.Models
{
    [Table("Permiso")]

    public partial class Permiso
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is Requeired")]
        public string NombreEmpleado { get; set; }
        [Required(ErrorMessage = "This field is Requeired")]

        public string ApellidosEmpleado { get; set; }
        [Required(ErrorMessage = "This field is Requeired")]

        public DateTime FechaPermiso { get; set; }
        [ForeignKey("AbsenceType"), Required(ErrorMessage = "This field is Requeired")]
        public int TipoPermiso { get; set; }
        public TipoPermiso AbsenceType { get; set; }
        //public string DescTipoPermiso
        //{
        //    get
        //    {
        //        return AbsenceType.Descripcion;
        //    }
        //}

    }
}