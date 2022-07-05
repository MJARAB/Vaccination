using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vaccination_MJARAB
{
    public partial class EditDeleteVaccinationTurnForm : Form
    {
        public EditDeleteVaccinationTurnForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaverLoader ListJadid = new SaverLoader("VaccinationList.txt");
            if (comboBox2.Text == "حذف")
            {
                List<Person> Jadid = ListJadid.LoadVaccineTurnPerson();
                File.WriteAllText("VaccinationList.txt", "");
                foreach (var user in Jadid)
                {
                    if ((user.NationalCode != textBox1.Text) || (user.NationalCode == textBox1.Text && user.TurnVaccine.Turn() != comboBox4.Text))
                    {
                        ListJadid.SaveVaccineTurnPerson(user, user.TurnVaccine.Turn());
                    }
                }
                MessageBox.Show("نوبت شما حذف شد");
                this.Close();
            }
            else if (comboBox2.Text == "ویرایش")
            {
                SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
                List<Person> Jadid = ListJadid.LoadVaccineTurnPerson();
                panel1.Visible = false;
                panel2.Visible = true;
                foreach (var user in Jadid)
                {
                    if (user.NationalCode == textBox1.Text)
                    {
                        var listcenters = from center in SaverLoaderCentersFile.LoadCenters() where center.Province == user.Province select center;
                        foreach (var markaz in listcenters)
                        {
                            comboBox1.Items.Add(markaz.Name);
                        }
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaverLoader ListJadid = new SaverLoader("VaccinationList.txt");
            SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
            List<Person> Jadid = ListJadid.LoadVaccineTurnPerson();
            File.WriteAllText("VaccinationList.txt", "");
            foreach (var user in Jadid)
            {
                if (user.NationalCode == textBox1.Text && user.TurnVaccine.Turn() == comboBox4.Text)
                {
                    user.TurnVaccine.VaccinationCenter = comboBox1.Text;
                    user.TurnVaccine.VaccinationDate = dateTimePicker1.Text;
                    user.TurnVaccine.VaccinationTime = comboBox3.Text.Split(' ')[0];
                    user.TurnVaccine.TypeVaccine = comboBox5.Text;
                    ListJadid.SaveVaccineTurnPerson(user,comboBox4.Text);
                }
                else if(user.NationalCode != textBox1.Text || (user.NationalCode == textBox1.Text && user.TurnVaccine.Turn() != comboBox4.Text))
                {
                    ListJadid.SaveVaccineTurnPerson(user, user.TurnVaccine.Turn());
                }
            }
            MessageBox.Show("نوبت شما ویرایش شد");
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
            foreach (var line in SaverLoaderCentersFile.LoadCenters())
            {
                if (line.Name == comboBox1.Text)
                {
                    foreach (var typevaccine in line.Vaccines)
                    {
                        comboBox5.Items.Add(typevaccine);
                    }
                    break;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
            SaverLoader SaverLoaderVaccinationTurnListFile = new SaverLoader("VaccinationList.txt");
            List<Person> Jadid = SaverLoaderVaccinationTurnListFile.LoadVaccineTurnPerson();
            int Capacity = 0;
            foreach (var line in SaverLoaderCentersFile.LoadCenters())
            {
                if (line.Name == comboBox1.Text)
                {
                    foreach (var time in MyApplication.TimeCenter(line))
                    {
                        Capacity = line.Capacity;
                        foreach (var user in Jadid)
                        {
                            if (user.TurnVaccine.VaccinationDate == dateTimePicker1.Text && user.TurnVaccine.VaccinationTime == time)
                            {
                                Capacity = Capacity - 1;
                            }
                        }
                        comboBox3.Items.Add(time + "    " + Convert.ToString(Capacity));
                    }
                    break;
                }
            }
        }
    }
}
