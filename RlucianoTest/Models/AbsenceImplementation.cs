using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AbsenceTest.Interfaces;

namespace AbsenceTest.Models
{
    public partial class AbsenceImplementation : IAbsences
    {
        AbsenceModel DataModel;
        public AbsenceImplementation()
        {
            DataModel = new AbsenceModel();
        }

        public void AddAbsence(Permiso Absences)
        {
            try
            {
                Absences.AbsenceType = GetAbsenceTypes().Where(a => a.Id == Absences.TipoPermiso).FirstOrDefault();

                DataModel.Absences.Attach(Absences);
                DataModel.Entry(Absences).State = EntityState.Added;

                // modeloDatos.TaxsRates.Add(taxs);
                DataModel.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void DeleteAbsence(int Id)
        {
            var absence = GetAbsences().Where(a => a.Id == Id).FirstOrDefault();
            try
            {
                if (absence != null)
                {
                    DataModel.Absences.Remove(absence);

                }
                DataModel.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Permiso> GetAbsences()
        {
            List<Permiso> absences = new List<Permiso>();
            try
            {
                absences = DataModel.Absences.Include(T => T.AbsenceType).ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return absences;
        }

        public List<TipoPermiso> GetAbsenceTypes()
        {
            return DataModel.AbsenceTypes.ToList();
        }

        public void UpdateAbsence(Permiso Absences)
        {
            try
            {
                Absences.AbsenceType = GetAbsenceTypes().Where(a => a.Id == Absences.TipoPermiso).FirstOrDefault();
                DataModel.Entry(Absences).State = EntityState.Modified;

                // modeloDatos.TaxsRates.Add(taxs);
                DataModel.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}