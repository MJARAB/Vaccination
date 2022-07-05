using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    class SaverLoader
    {
        public string PathFile { get; set; }
        public SaverLoader(string pathfile)
        {
            PathFile = pathfile;
        }
        public List<IMember> LoadPeople()
        {
            List<IMember> people = new List<IMember>();
            var khatha = File.ReadAllLines(PathFile, Encoding.Default);
            foreach (var khat in khatha)
            {
                var moshakhasat = khat.Split('|');
                if (moshakhasat[4] == "0")
                {
                    people.Add(new Person(moshakhasat[5], moshakhasat[4], moshakhasat[0], moshakhasat[1], moshakhasat[2], moshakhasat[3]));
                }
                else if (moshakhasat[4] == "1")
                {
                    people.Add(new Admin(moshakhasat[5], moshakhasat[4], moshakhasat[0], moshakhasat[1], moshakhasat[2], moshakhasat[3]));
                }
            }
            return people;
        }
        public List<Center> LoadCenters()
        {
            List<Center> Centers = new List<Center>();
            var khatha = File.ReadAllLines(PathFile, Encoding.Default);
            foreach (var khat in khatha)
            {
                List<string> vaccineTypes = new List<string>();
                var moshakhasat = khat.Split('|');
                foreach (var typevaccine in khat.Split('|')[2].Split(','))
                {
                    vaccineTypes.Add(typevaccine);
                }
                Centers.Add(new Center(moshakhasat[1], moshakhasat[0], vaccineTypes, Convert.ToInt32(moshakhasat[3]), Convert.ToInt32(moshakhasat[4]), Convert.ToInt32(moshakhasat[5]), Convert.ToInt32(moshakhasat[6]), Convert.ToInt32(moshakhasat[7]), Convert.ToInt32(moshakhasat[8])));
            }
            return Centers;
        }
        public Dictionary<string, List<Center>> LoadCities()
        {
            Dictionary<string, List<Center>> Cities = new Dictionary<string, List<Center>>();
            List<string> cities = new List<string>();
            foreach (var line in LoadCenters())
            {
                if (cities.Contains(line.Name.Remove(line.Name.Length - 2, 2)) == false)
                {
                    cities.Add(line.Name.Remove(line.Name.Length - 2, 2));
                }
            }
            foreach (var city in cities)
            {
                List<Center> centers = new List<Center>();
                foreach (var center in LoadCenters())
                {
                    if (center.Name.Remove(center.Name.Length - 2, 2) == city)
                    {
                        centers.Add(new Center(center.Name));
                    }
                }
                Cities[city] = centers;
            }
            return Cities;
        }
        public List<Person> LoadVaccineTurnPerson()
        {
            List<Person> people = new List<Person>();
            var khatha = File.ReadAllLines(PathFile, Encoding.Default);
            foreach (var khat in khatha)
            {
                var moshakhasat = khat.Split('|');
                if (moshakhasat[3] == "نوبت 1")
                {
                    people.Add(new Person(moshakhasat[0], moshakhasat[6], new VaccineTurn1(moshakhasat[1], moshakhasat[4], moshakhasat[5], moshakhasat[2])));
                }
                else if (moshakhasat[3] == "نوبت 2")
                {
                    people.Add(new Person(moshakhasat[0], moshakhasat[6], new VaccineTurn2(moshakhasat[1], moshakhasat[4], moshakhasat[5], moshakhasat[2])));
                }
            }
            return people;
        }
        public void SaveVaccineTurnPerson(Person user,string Turn)
        {
            string[] FileContent = new string[1];
            FileContent[0] = user.NationalCode + "|" + user.TurnVaccine.VaccinationCenter + "|" + user.TurnVaccine.TypeVaccine + "|" + Turn + "|" + user.TurnVaccine.VaccinationDate + "|" + user.TurnVaccine.VaccinationTime + "|" + user.Province;
            File.AppendAllLines(PathFile, FileContent, Encoding.Default);
        }
        public void SaveCenter(Center Jadid)
        {
            StringBuilder types = new StringBuilder("");
            string[] FileContent = new string[1];
            foreach (var type in Jadid.Vaccines)
            {
                types.Append(type + ",");
            }
            FileContent[0] = Jadid.Province + "|" + Jadid.Name + "|" + Convert.ToString(types).Remove(Convert.ToString(types).Length - 1, 1) + "|" + Convert.ToString(Jadid.Start) + "|" + Convert.ToString(Jadid.End) + "|" + Convert.ToString(Jadid.PeriodTime) + "|" + Convert.ToString(Jadid.Capacity) + "|" + Convert.ToString(Jadid.Xcordinate) + "|" + Convert.ToString(Jadid.Ycordinate);
            File.AppendAllLines(PathFile, FileContent, Encoding.Default);
        }
    }
}
