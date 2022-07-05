using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    class VaccineTurn1 : IVaccineTurn
    {
        public string VaccinationCenter { get; set; }
        public string VaccinationDate { get; set; }
        public string VaccinationTime { get; set; }
        public string TypeVaccine { get; set; }
        public string Turn()
        {
            return "نوبت 1";
        }
        public VaccineTurn1(string vaccinationCenter, string vaccinationDate, string vaccinationTime, string typeVaccine)
        {
            VaccinationCenter = vaccinationCenter;
            VaccinationDate = vaccinationDate;
            VaccinationTime = vaccinationTime;
            TypeVaccine = typeVaccine;
        }
    }
}
