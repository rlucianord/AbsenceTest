namespace AbsenceTest.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AbsenceModel : DbContext
    {
        public AbsenceModel()
            : base("name=AbsenceModel")
        {
        }
        public DbSet<Permiso> Absences { get; set; }
        public DbSet<TipoPermiso> AbsenceTypes { get; set; }

    }
}

