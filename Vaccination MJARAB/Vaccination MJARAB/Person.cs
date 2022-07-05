using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    class Person : IMember
    {
        public string Name { get; set; }
        public string User { get; set; }
        public string NationalCode { get; set; }
        public string BirthDate { get; set; }
        public string BirthYear { get; set; }
        public string BirthMonth { get; set; }
        public string BirthDay { get; set; }
        public string Province { get; set; }
        public IVaccineTurn TurnVaccine { get; set; }

        public Person(string name, string user, string nationalCode, string birthYear, string birthMonth, string birthDay)
        {
            Name = name;
            User = user;
            NationalCode = nationalCode;
            BirthYear = birthYear;
            BirthMonth = birthMonth;
            BirthDay = birthDay;
        }

        public Person(string nationalcode, string province, IVaccineTurn turnVaccine)
        {
            NationalCode = nationalcode;
            Province = province;
            TurnVaccine = turnVaccine;
        }

        public void FormUser(string datetimepicker, string textbox , string email)
        {
            PersonForm UserPerson = new PersonForm();
            UserPerson.label9.Text = datetimepicker;
            UserPerson.label10.Text = UserInformation.UserName(textbox);
            UserPerson.label12.Text = textbox;
            UserPerson.label1.Text = email;
            UserPerson.Show();
        }
    }
}
