using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    class MyApplication
    {
        public ISendMessageEmail Sender { get; set; }
        public IVaccineTurn VaccineTurn { get; set; }
        public IMember User { get; set; }

        public MyApplication(ISendMessageEmail sender)
        {
            Sender = sender;
        }

        public MyApplication(IVaccineTurn vaccineTurn)
        {
            VaccineTurn = vaccineTurn;
        }

        public MyApplication(IMember user)
        {
            User = user;
        }

        public void SendMessageWithEmail(string to, string body)
        {
            Sender.SendMessage(to, body);
        }

        public string TurnVaccine()
        {
            return VaccineTurn.Turn();
        }

        public void UserForm(string datetimepicker, string textbox , string email)
        {
            User.FormUser(datetimepicker, textbox , email);
        }

        public static List<Center> CentersListAscendingFasele(int x, int y)
        {
            SaverLoader loadcenter = new SaverLoader("Centers.txt");
            var listcenters = from center in loadcenter.LoadCenters() let fasele = Math.Sqrt((center.Xcordinate - x) * (center.Xcordinate - x) + (center.Ycordinate - y) * (center.Ycordinate - y)) orderby fasele ascending select center;
            List<Center> ListJadid = listcenters.ToList();
            return ListJadid;
        }

        public static List<Center> CentersDescendingVaccineType()
        {
            SaverLoader loadcenter = new SaverLoader("Centers.txt");
            var listcenters = from center in loadcenter.LoadCenters() orderby center.Vaccines.Count() descending select center;
            List<Center> ListJadid = listcenters.ToList();
            return ListJadid;
        }

        public static List<string> TimeCenter(Center center)
        {
            List<string> centertime = new List<string>();
            for (int i = center.Start * 100; i < center.End * 100; i += center.PeriodTime)
            {
                string a1 = "";
                string a2 = "";
                string a3 = "";
                string a4 = "";
                if (i % 100 >= 60)
                {
                    i += 100;
                    i -= i % 100;
                }
                int j = i + center.PeriodTime;
                if (j % 100 >= 60)
                {
                    j += 100;
                    j -= j % 100;
                }
                if (i / 100 >= 10)
                {
                    a1 = Convert.ToString(i / 100);
                }
                else
                {
                    a1 = "0" + Convert.ToString(i / 100);
                }
                if (i % 100 == 0)
                {
                    a2 = "00";
                }
                else
                {
                    a2 = Convert.ToString(i % 100);
                }
                if (j / 100 >= 10)
                {
                    a3 = Convert.ToString(j / 100);
                }
                else
                {
                    a3 = "0" + Convert.ToString(j / 100);
                }
                if (j % 100 == 0)
                {
                    a4 = "00";
                }
                else
                {
                    a4 = Convert.ToString(j % 100);
                }
                centertime.Add(a1 + ":" + a2 + "_" + a3 + ":" + a4);
            }
            return centertime;
        }
    }
}
