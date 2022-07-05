using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vaccination_MJARAB
{
    public partial class PersonForm : Form
    {
        public string Vaccine_Center = "";
        public string Vaccine_Date = "";
        public string Vaccine_Time = "";
        public string Vaccine_Type = "";


        private static string path = System.IO.Directory.GetCurrentDirectory();

        public PersonForm()
        {
            InitializeComponent();
        }

        public void CityCenters(string personcity)
        {
            SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
            List<RadioButton> rb = new List<RadioButton>();
            foreach (var line in MyApplication.CentersListAscendingFasele(Convert.ToInt32(label13.Text), Convert.ToInt32(label14.Text)))
            {
                if (line.Name.Remove(line.Name.Length - 2, 2) == personcity)
                {
                    rb.Add(new RadioButton());
                    rb[rb.Count - 1].Text = line.Name;
                    groupBox1.Controls.Add(rb[rb.Count - 1]);
                    if (rb.Count == 1)
                    {
                        rb[rb.Count - 1].Location = new Point(500, 50);
                    }
                    else if (rb.Count >= 2)
                    {
                        rb[rb.Count - 1].Location = new Point(500, rb[rb.Count - 2].Location.Y + 50);
                    }
                }
            }
        }

        public void CityCenters2(string personcity)
        {
            SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
            List<RadioButton> rb = new List<RadioButton>();
            foreach (var line in MyApplication.CentersDescendingVaccineType())
            {
                if (line.Name.Remove(line.Name.Length - 2, 2) == personcity)
                {
                    rb.Add(new RadioButton());
                    rb[rb.Count - 1].Text = line.Name;
                    groupBox1.Controls.Add(rb[rb.Count - 1]);
                    if (rb.Count == 1)
                    {
                        rb[rb.Count - 1].Location = new Point(500, 50);
                    }
                    else if (rb.Count >= 2)
                    {
                        rb[rb.Count - 1].Location = new Point(500, rb[rb.Count - 2].Location.Y + 50);
                    }
                }
            }
        }

        public void CenterTimes(string personcenter, string date)
        {
            SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
            SaverLoader SaverLoaderVaccinationTurnListFile = new SaverLoader("VaccinationList.txt");
            List<Person> Jadid = SaverLoaderVaccinationTurnListFile.LoadVaccineTurnPerson();
            int Capacity = 0;
            foreach (var line in SaverLoaderCentersFile.LoadCenters())
            {
                if (line.Name == personcenter)
                {
                    foreach (var time in MyApplication.TimeCenter(line))
                    {
                        Capacity = line.Capacity;
                        foreach (var user in Jadid)
                        {
                            if (user.TurnVaccine.VaccinationDate == date && user.TurnVaccine.VaccinationTime == time)
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

        public void CenterTypes(string personcenter)
        {
            SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
            List<RadioButton> rb = new List<RadioButton>();
            foreach (RadioButton type in groupBox3.Controls)
            {
                groupBox3.Controls.Remove(type);
            }
            foreach (var line in SaverLoaderCentersFile.LoadCenters())
            {
                if (line.Name == personcenter)
                {
                    foreach (var typevaccine in line.Vaccines)
                    {
                        rb.Add(new RadioButton());
                        rb[rb.Count - 1].Text = typevaccine;
                        groupBox3.Controls.Add(rb[rb.Count - 1]);
                        if (rb.Count == 1)
                        {
                            rb[rb.Count - 1].Location = new Point(500, 50);
                        }
                        else if (rb.Count >= 2)
                        {
                            rb[rb.Count - 1].Location = new Point(500, rb[rb.Count - 2].Location.Y + 50);
                        }
                    }
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label11.Text = comboBox1.Text;
            CityCenters(comboBox2.Text);
            if (label13.Text != "" && label14.Text != "")
            {
                panel7.Visible = true;
                panel16.Visible = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label13.Text = "";
            label14.Text = "";
            SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
            pictureBox2.ImageLocation = $"{path}\\Cities\\" + comboBox1.Text + "\\" + comboBox2.Text + Convert.ToString(SaverLoaderCentersFile.LoadCities()[comboBox2.Text].Count()) + ".png";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label13.Text = "";
            label14.Text = "";
            comboBox2.Items.Clear();
            SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
            foreach (var center in SaverLoaderCentersFile.LoadCenters())
            {
                if (comboBox1.Text == center.Province && comboBox2.Items.Contains(center.Name.Remove(center.Name.Length - 2, 2)) == false)
                {
                    comboBox2.Items.Add(center.Name.Remove(center.Name.Length - 2, 2));
                }
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            label13.Text = Convert.ToString(e.X);
            label14.Text = Convert.ToString(e.Y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (RadioButton center in groupBox1.Controls)
            {
                center.Enabled = false;
                if (center.Checked == true)
                {
                    Vaccine_Center = center.Text;
                    CenterTypes(center.Text);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vaccine_Time = comboBox3.Text.Split(' ')[0];
            Vaccine_Date = dateTimePicker2.Text;
            comboBox3.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (RadioButton vaccine in groupBox3.Controls)
            {
                vaccine.Enabled = false;
                if (vaccine.Checked == true)
                {
                    Vaccine_Type = vaccine.Text;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox4.Enabled = false;
            SaverLoader SaveTurn = new SaverLoader("VaccinationList.txt");
            MyApplication Jadid;
            if (comboBox4.Text == "نوبت 1")
            {
                Person user = new Person(label12.Text, label11.Text, new VaccineTurn1(Vaccine_Center, Vaccine_Date, Vaccine_Time, Vaccine_Type));
                Jadid = new MyApplication(new VaccineTurn1(Vaccine_Center, Vaccine_Date, Vaccine_Time, Vaccine_Type));
                SaveTurn.SaveVaccineTurnPerson(user, Jadid.TurnVaccine());
            }
            else if (comboBox4.Text == "نوبت 2")
            {
                Person user = new Person(label12.Text, label11.Text, new VaccineTurn2(Vaccine_Center, Vaccine_Date, Vaccine_Time, Vaccine_Type));
                Jadid = new MyApplication(new VaccineTurn2(Vaccine_Center, Vaccine_Date, Vaccine_Time, Vaccine_Type));
                SaveTurn.SaveVaccineTurnPerson(user,Jadid.TurnVaccine());
            }
            MyApplication appturn = new MyApplication(new SendVaccinePersonTurn());
            MessageBox.Show("نوبت واکسیناسیون شما با موفقیت ثبت شد");
            string to = label1.Text;
            string body = "نوبت واکسیناسیون شما :" + "\n" + "مرکز واکسیناسیون : " + Vaccine_Center + "\n" + "ساعت و تاریخ نوبت : " + Vaccine_Time + " | " + Vaccine_Date;
            try
            {
                appturn.SendMessageWithEmail(to, body);
            }
            catch
            {

            }
            this.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CenterTimes(Vaccine_Center, dateTimePicker2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "مرکز واکسیناسیون مورد نظر خود را انتخاب کنید";
            foreach (RadioButton center in groupBox1.Controls)
            {
                groupBox1.Controls.Remove(center);
            }
            CityCenters2(comboBox2.Text);
            button1.Enabled = false;
        }
    }
}
