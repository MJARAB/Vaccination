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
    public partial class AdminForm : Form
    {
        private static string path = System.IO.Directory.GetCurrentDirectory();

        public AdminForm()
        {
            InitializeComponent();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label13.Text = "";
            label14.Text = "";
            SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
            pictureBox2.ImageLocation = $"{path}\\Cities\\" + comboBox1.Text + "\\" + comboBox2.Text + Convert.ToString(SaverLoaderCentersFile.LoadCities()[comboBox2.Text].Count()) + ".png";
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            label13.Text = Convert.ToString(e.X);
            label14.Text = Convert.ToString(e.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool Types = false;
            List<string> vaccines = new List<string>();
            foreach (CheckBox Type in groupBox1.Controls)
            {
                if (Type.Checked == true)
                {
                    vaccines.Add(Type.Text);
                    Types = true;
                }
            }
            if (label13.Text != "" && label14.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox6.Text != "" && textBox1.Text != "" && Types == true)
            {
                SaverLoader SaverLoaderCentersFile = new SaverLoader("Centers.txt");
                Pen pen = new Pen(Color.Yellow, 20);
                Bitmap bitmap = new Bitmap("Cities\\" + comboBox1.Text + "\\" + comboBox2.Text + Convert.ToString(SaverLoaderCentersFile.LoadCities()[comboBox2.Text].Count()) + ".png");
                Graphics graphics = Graphics.FromImage(bitmap);
                Font font = new Font(new FontFamily("Segoe UI"), 20, FontStyle.Bold);
                pictureBox2.Image = bitmap;
                float picturex = Convert.ToSingle(Convert.ToInt32(label13.Text) * (float)pictureBox2.Image.Size.Width / pictureBox2.Size.Width);
                float picturey = Convert.ToSingle(Convert.ToInt32(label14.Text) * (float)pictureBox2.Image.Size.Height / pictureBox2.Size.Height);
                graphics.DrawRectangle(pen, picturex, picturey, pen.Width, pen.Width);
                graphics.DrawString(Convert.ToString(SaverLoaderCentersFile.LoadCities()[comboBox2.Text].Count() + 1), font, Brushes.Green, picturex, picturey);
                string filepath = "Cities\\" + comboBox1.Text + "\\" + comboBox2.Text + Convert.ToString(SaverLoaderCentersFile.LoadCities()[comboBox2.Text].Count() + 1) + ".png";
                FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                pictureBox2.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                Center Jadid = new Center(Convert.ToString(comboBox2.Text + " " + Convert.ToString(SaverLoaderCentersFile.LoadCities()[comboBox2.Text].Count() + 1)), comboBox1.Text, vaccines, Convert.ToInt32(comboBox3.Text.Trim()), Convert.ToInt32(comboBox4.Text.Trim()), Convert.ToInt32(comboBox6.Text.Trim()), Convert.ToInt32(textBox1.Text.Trim()), Convert.ToInt32(label13.Text), Convert.ToInt32(label14.Text));
                SaverLoader SaveCenterFileJadid = new SaverLoader("Centers.txt");
                SaveCenterFileJadid.SaveCenter(Jadid);
                MessageBox.Show("مرکز واکسیناسیون جدید ثبت شد");
                label13.Text = "";
                label14.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox6.Text = "";
                textBox1.Text = "";
                foreach (CheckBox Type in groupBox1.Controls)
                {
                    if (Type.Checked == true)
                    {
                        Type.Checked = false;
                    }
                }
            }
        }
    }
}
