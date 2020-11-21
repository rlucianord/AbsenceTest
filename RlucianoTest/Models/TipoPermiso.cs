using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AbsenceTest.Models
{
    [Table("TipoPermiso")]
    public partial class TipoPermiso
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }
        public List<Permiso> Absences { get; set; }


    }
}