using System.Collections.Generic;
using AbsenceTest.Models;
/// <summary>
/// This interface implement absence methods;
/// </summary>
namespace AbsenceTest.Interfaces
{
    public interface IAbsences
    {

        List<TipoPermiso> GetAbsenceTypes();
        List<Permiso> GetAbsences();

        void AddAbsence(Permiso Absences);
        void UpdateAbsence(Permiso Absences);
        void DeleteAbsence(int Id);


    }
}

