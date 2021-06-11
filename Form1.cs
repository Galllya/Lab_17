using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab17
{
    public partial class Form1 : Form
    {
        int n;
        Statistic one;
        Statistic two;
        Statistic together;
        bool should_start = true;
        double label_1, label_2, t;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (one.GetModel() == 2)
            {
                chart1.Series[0].Points.AddXY(one.time_get, one.lambda_get);
                chart1.Series[2].Points.AddXY(one.time_get, one.lambda_get);
            }
            else if (one.GetModel() == 1) chart2.Series[0].Points.AddXY(one.GetCount(), one.Statistics());

            if (two.GetModel() == 2)
            {
                chart1.Series[1].Points.AddXY(two.time_get, two.lambda_get);
                chart1.Series[3].Points.AddXY(two.time_get, two.lambda_get);
            }
            else if (two.GetModel() == 2) chart2.Series[0].Points.AddXY(two.GetCount(), two.Statistics());

            if (together.GetModel() == 2)
            {
                chart1.Series[4].Points.AddXY(together.time_get, together.lambda_get);
                chart1.Series[5].Points.AddXY(together.time_get, together.lambda_get);
            }
            else if (together.GetModel() == 1) chart2.Series[1].Points.AddXY(together.GetCount(), together.Statistics());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (should_start)
            {
                label_1 = (double) numericUpDown1.Value;
                label_2 = (double) numericUpDown2.Value;
                t = (double) numericUpDown4.Value;
                n = (int) numericUpDown3.Value;
             
                one = new Statistic(label_1, t, n);
                two = new Statistic(label_2, t, n);

                together = new Statistic((double)(label_1 + label_2), t, n);

                chart1.Series[0].Points.AddXY(one.time_get, one.lambda_get);
                chart1.Series[1].Points.AddXY(two.time_get, two.lambda_get);
                chart1.Series[4].Points.AddXY(together.time_get, together.lambda_get);

                should_start = false;
            }
            for (int i = 0; i < 4; i++) chart1.Series[i].Points.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            for (int i = 0; i < 5; i++) chart1.Series[i].Points.Clear();

            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();

        }

       

      

       

    }
}
