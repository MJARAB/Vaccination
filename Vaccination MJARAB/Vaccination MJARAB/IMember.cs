using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    interface IMember
    {
        string Name { get; set; }
        string User { get; set; }
        string NationalCode { get; set; }
        string BirthDate { get; set; }
        string BirthYear { get; set; }
        string BirthMonth { get; set; }
        string BirthDay { get; set; }
        void FormUser(string datetimepicker, string textbox, string email);
    }
}
