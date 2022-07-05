using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    class Admin : IMember
    {
        public string Name { get; set; }
        public string User { get; set; }
        public string NationalCode { get; set; }
        public string BirthDate { get; set; }
        public string BirthYear { get; set; }
        public string BirthMonth { get; set; }
        public string BirthDay { get; set; }

        public Admin(string name, string user, string nationalCode, string birthYear, string birthMonth, string birthDay)
        {
            Name = name;
            User = user;
            NationalCode = nationalCode;
            BirthYear = birthYear;
            BirthMonth = birthMonth;
            BirthDay = birthDay;
        }

        public void FormUser(string datetimepicker, string textbox, string email)
        {
            AdminForm UserAdmin = new AdminForm();
            UserAdmin.label9.Text = datetimepicker;
            UserAdmin.label10.Text = UserInformation.UserName(textbox);
            UserAdmin.label12.Text = textbox;
            UserAdmin.Show();
        }
    }
}
