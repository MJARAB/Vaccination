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
    public partial class CardForm : Form
    {
        public CardForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaverLoader ListJadid = new SaverLoader("VaccinationList.txt");
            List<Person> Jadid = ListJadid.LoadVaccineTurnPerson();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            foreach (var user in Jadid)
            {
                if (user.NationalCode == textBox1.Text && user.TurnVaccine.Turn()=="نوبت 1")
                {
                    Bitmap bitmap = new Bitmap("VaccineCard1.jpeg");
                    Graphics graphics = Graphics.FromImage(bitmap);
                    pictureBox1.Image = bitmap;
                    Font font = new Font(new FontFamily("Segoe UI"), 15, FontStyle.Bold);
                    graphics.DrawString(UserInformation.UserName(user.NationalCode), font, Brushes.Blue, 150, 350);
                    graphics.DrawString(UserInformation.UserAge(user.NationalCode), font, Brushes.Blue, 150, 400);
                    graphics.DrawString(user.NationalCode, font, Brushes.Blue, 150, 425);
                    graphics.DrawString(user.TurnVaccine.TypeVaccine, font, Brushes.Blue, 145, 600);
                    graphics.DrawString(user.TurnVaccine.VaccinationDate, font, Brushes.Blue, 140, 650);
                }
                if (user.NationalCode == textBox1.Text && user.TurnVaccine.Turn() == "نوبت 2")
                {
                    Bitmap bitmap = new Bitmap("VaccineCard2.jpeg");
                    Graphics graphics = Graphics.FromImage(bitmap);
                    pictureBox2.Image = bitmap;
                    Font font = new Font(new FontFamily("Segoe UI"), 15, FontStyle.Bold);
                    graphics.DrawString(UserInformation.UserName(user.NationalCode), font, Brushes.Blue, 150, 350);
                    graphics.DrawString(UserInformation.UserAge(user.NationalCode), font, Brushes.Blue, 150, 400);
                    graphics.DrawString(user.NationalCode, font, Brushes.Blue, 150, 425);
                    graphics.DrawString(user.TurnVaccine.TypeVaccine, font, Brushes.Blue, 145, 600);
                    graphics.DrawString(user.TurnVaccine.VaccinationDate, font, Brushes.Blue, 140, 650);
                }
            }
        }
    }
}
