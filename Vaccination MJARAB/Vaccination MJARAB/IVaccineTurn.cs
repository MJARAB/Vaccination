using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    interface IVaccineTurn
    {
        string VaccinationCenter { get; set; }
        string VaccinationDate { get; set; }
        string VaccinationTime { get; set; }
        string TypeVaccine { get; set; }
        string Turn();
    }
}
