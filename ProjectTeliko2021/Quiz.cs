using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjectTeliko2021
{
    public partial class Quiz : Form
    {
        int wins = 0;
        int ticks = 0;
        int score = 0;
        String ReadFilesRTB;
        static string prosorini;
        public Quiz()
        {
            InitializeComponent();
            timer1.Start();
            textBox1.Clear();
            methodX();

            //read
            StreamReader sr = new StreamReader(Application.StartupPath + "test_score.txt");
            prosorini = sr.ReadToEnd();

            sr.Close();



           
        }
        int cal = 0;

        public void methodX()
        {
            Random rand = new Random();

            Random symbolrand = new Random();

            int first_value = rand.Next(10, 20);
            int secont_value = rand.Next(10, 20);
            int SYNOLO = rand.Next(1, 4);
            int calculate = 0;

            cal = calculate;



            switch (SYNOLO)
            {
                case 1:
                    cal = first_value + secont_value;
                    label1.Text = first_value + " + " + secont_value + " =?";
                    break;
                case 2:
                    label1.Text = first_value + " - " + secont_value + " =?";
                    if (first_value < secont_value)
                    {

                        label1.Text = secont_value + " - " + first_value + " =?";
                        cal = secont_value - first_value;
                    }
                    else
                    {
                        label1.Text = first_value + " - " + secont_value + " =?";
                        cal = first_value - secont_value;
                    }
                    break;
                case 3:
                    cal = first_value * secont_value;
                    label1.Text = first_value + " * " + secont_value + " =?";
                    break;
                case 4:
                    cal = first_value / secont_value;
                    label1.Text = first_value + " / " + secont_value + " =?";
                    break;
            }
            
        }

        private void start_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x = textBox1.Text;
            try
            {
                if (Int32.Parse(x).Equals(cal) && ticks < 40)
                {
                    //read
                    StreamReader sr = new StreamReader(Application.StartupPath + "test_score.txt");
                    ReadFilesRTB = sr.ReadToEnd();
                    sr.Close();

                    if (Int32.Parse(ReadFilesRTB) >= 1000)
                    {
                        score = Int32.Parse(ReadFilesRTB);
                        label2.Text = "GOLDEN USER";
                        score += 100;
                    }
                    else
                    {
                        score = Int32.Parse(ReadFilesRTB);
                        score += 50;
                    }
                    wins++;
                    
                    MessageBox.Show("Your anser is correct :" + wins + "  Total Score: " + score + " initial score: " + prosorini);
                    textBox1.Clear();


                    //write
                    StreamWriter sw = new StreamWriter(Application.StartupPath + "test_score.txt");
                    sw.WriteLine(score);
                    sw.Close();


                    methodX();
                    if (wins == 4)
                    {
                        MessageBox.Show("Winner");
                        System.Windows.Forms.Application.Exit();
                    }



                }
                else if (ticks == 40)
                {
                    MessageBox.Show("YOU LOST");
                    wins = 0;
                    score = 0;

                    StreamWriter sw = new StreamWriter(Application.StartupPath + "test_score.txt");
                    sw.WriteLine(prosorini);
                    sw.Close();
                    System.Windows.Forms.Application.Exit();


                }
                else
                {
                    MessageBox.Show("wrong");
                    MessageBox.Show("Try again");
                    methodX();
                }

                //ticks == 10
                //timer1.Start();
                //textBox1.Clear();
            }
            catch (Exception b)
            {
                MessageBox.Show("Something went wrong.");
                textBox1.Clear();

            }
        }
        


        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            label7.Text = ticks.ToString();

            //if (ticks == 40)
            //{
            //    timer1.Stop();
            //}
            if (ticks == 40)
            {
                timer1.Stop();
                MessageBox.Show("YOU LOST");
                wins = 0;
                score = 0;

                StreamWriter sw = new StreamWriter(Application.StartupPath + "test_score.txt");
                sw.WriteLine(prosorini);
                sw.Close();
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
