using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    class UserInformation
    {
        public static string PathPersons = "Members.txt";
        public static SaverLoader SaverLoaderPeoplesFile = new SaverLoader(PathPersons);
        public static string UserName(string codemeli)
        {
            string nameuser = "";
            foreach (var line in SaverLoaderPeoplesFile.LoadPeople())
            {
                if (line.NationalCode == codemeli)
                {
                    nameuser = line.Name;
                }
            }
            return nameuser;
        }
        public static string UserAge(string codemeli)
        {
            string ageuser = "";
            foreach (var line in SaverLoaderPeoplesFile.LoadPeople())
            {
                if (line.NationalCode == codemeli)
                {
                    ageuser = line.BirthYear + "/" + line.BirthMonth + "/" + line.BirthDay;
                }
            }
            return ageuser;
        }
    }
}
