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
    public partial class MainForm : Form
    {
        public string body = "";
        public string emcode = "";

        private static string path = System.IO.Directory.GetCurrentDirectory();

        public MainForm()
        {
            InitializeComponent();
            Random picturecode = new Random();
            string piccode = Convert.ToString(picturecode.Next(1, 15));
            Dictionary<string, string> codes = new Dictionary<string, string>();
            var lines = File.ReadAllLines("Codes\\Codeha.txt");
            foreach (var line in lines)
            {
                var moshakhasat = line.Split('_');
                codes.Add(moshakhasat[0], moshakhasat[1]);
            }
            pictureBox1.ImageLocation = $"{path}\\Codes\\code" + piccode + "_" + codes[piccode] + ".png";
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInformation.CheckNationalCode(textBox1.Text) == false)
            {
                MessageBox.Show("کد ملّی اشتباه است");
            }
            if (CheckInformation.CheckBirthDate(dateTimePicker1.Text, textBox1.Text) == false)
            {
                MessageBox.Show("تاریخ تولّد اشتباه است");
            }
            if (pictureBox1.ImageLocation.Split('_')[1].Split('.')[0] != textBox4.Text)
            {
                MessageBox.Show("کد امنیتی اشتباه است");
            }
            if (CheckInformation.CheckNationalCode(textBox1.Text) == true && CheckInformation.CheckBirthDate(dateTimePicker1.Text, textBox1.Text) == true && pictureBox1.ImageLocation.Split('_')[1].Split('.')[0] == textBox4.Text)
            {
                panel15.Visible = true;
                textBox2.Visible = true;
                button3.Visible = true;
                Random emailcode = new Random();
                emcode = Convert.ToString(emailcode.Next(1000, 10000));
                body = "سلام" + " " + UserInformation.UserName(textBox1.Text) + " " + "عزیز" + " " + "کد تایید شما" + " " + emcode + " " + "است";
                string to = textBox3.Text;
                try
                {
                    MyApplication appcode = new MyApplication(new SendCode());
                    appcode.SendMessageWithEmail(to, body);
                    MessageBox.Show("کد تایید به ایمیل شما ارسال شد");
                }
                catch
                {
                    MessageBox.Show("کد تایید ارسال نشد");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel2.Text = DateTime.Now.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Random picturecode = new Random();
            string piccode = Convert.ToString(picturecode.Next(1, 15));
            Dictionary<string, string> codes = new Dictionary<string, string>();
            var lines = File.ReadAllLines("Codes\\Codeha.txt");
            foreach (var line in lines)
            {
                var moshakhasat = line.Split('_');
                codes.Add(moshakhasat[0], moshakhasat[1]);
            }
            pictureBox1.ImageLocation = $"{path}\\Codes\\code" + piccode + "_" + codes[piccode] + ".png";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == emcode)
            {
                if (CheckInformation.IsPerson(textBox1.Text) == true)
                {
                    MyApplication Jadid = new MyApplication(new Person(UserInformation.UserName(textBox1.Text), "0", textBox1.Text, dateTimePicker1.Text.Split('/')[0], dateTimePicker1.Text.Split('/')[1], dateTimePicker1.Text.Split('/')[2]));
                    Jadid.UserForm(dateTimePicker1.Text, textBox1.Text, textBox3.Text);
                }
                else
                {
                    MyApplication Jadid = new MyApplication(new Admin(UserInformation.UserName(textBox1.Text), "1", textBox1.Text, dateTimePicker1.Text.Split('/')[0], dateTimePicker1.Text.Split('/')[1], dateTimePicker1.Text.Split('/')[2]));
                    Jadid.UserForm(dateTimePicker1.Text, textBox1.Text, textBox3.Text);
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                dateTimePicker1.Value = DateTime.Today;
            }
            else
            {
                MessageBox.Show("کد تایید اشتباه است");
            }
        }

        private void toolStripLabel1_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "شماره دانشجویی : 9926783";
        }

        private void MainForm_MouseEnter(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
            toolStripLabel2.Text = DateTime.Now.ToString();
        }

        private void DeleteEditVaccinationTurn_Click(object sender, EventArgs e)
        {
            EditDeleteVaccinationTurnForm EditDelete = new EditDeleteVaccinationTurnForm();
            EditDelete.Show();
        }

        private void Digital_card_Click(object sender, EventArgs e)
        {
            CardForm DigitalCard = new CardForm();
            DigitalCard.Show();
        }
    }
}
