using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    class CheckInformation
    {
        public static string PathPeople = "Members.txt";
        public static string PathCenters = "Centers.txt";
        public static SaverLoader SaverLoaderPeopleFile = new SaverLoader(PathPeople);
        public static SaverLoader SaverLoaderCentersFile = new SaverLoader(PathCenters);
        public static bool CheckNationalCode(string ncode)
        {
            foreach (var user in SaverLoaderPeopleFile.LoadPeople())
            {
                if (user.NationalCode == ncode)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckCenter(string center)
        {
            foreach (var markaz in SaverLoaderCentersFile.LoadCenters())
            {
                if (markaz.Name == center)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckTypeVaccine(string typevaccine)
        {
            foreach (var markaz in SaverLoaderCentersFile.LoadCenters())
            {
                for (int i = 0; i < markaz.Vaccines.Count(); i++)
                {
                    if (markaz.Vaccines[i] == typevaccine)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool CheckBirthDate(string birthdate, string codemeli)
        {
            foreach (var user in SaverLoaderPeopleFile.LoadPeople())
            {
                if (Convert.ToString(user.BirthYear + "/" + user.BirthMonth + "/" + user.BirthDay) == birthdate && user.NationalCode == codemeli)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsPerson(string CodeMeli)
        {
            foreach (var user in SaverLoaderPeopleFile.LoadPeople())
            {
                if (user.NationalCode == CodeMeli && user.User == "0")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
