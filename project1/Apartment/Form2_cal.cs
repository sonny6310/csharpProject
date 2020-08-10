using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apartment
{
    public partial class Form2_cal : Form
    {
        public Form2_cal()
        {
            InitializeComponent();

            calendar.sendDate += new calendar.sendDateDele(cal_sendDate);
        }

        private string path = @"LogFolder\Log.txt";
        private bool dateClick = false;
        private string dt1;

        private void cal_sendDate(string msg)
        {
            dt1 = msg;

            listBox1.Items.Clear();

            try
            {
                IEnumerable<string> log = System.IO.File.ReadLines(path);
                foreach (string logLine in log)
                {
                    if (logLine.Contains(dt1))
                    {
                        listBox1.Items.Insert(0, logLine);
                        listBox1.Items.Insert(0, Environment.NewLine);
                    }
                }
            }
            catch (Exception except)
            {
                MessageBox.Show("\t\t-- 오류메시지 --\n" + except.Message + Environment.NewLine + Environment.NewLine + "\t\t-- 오류내용 --\n" + except.StackTrace, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dateClick = true;
        }

        private void btn_check_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();

            try
            {
                IEnumerable<string> log = System.IO.File.ReadLines(path);
                foreach (string logLine in log)
                {
                    if (dateClick)
                    {
                        if (logLine.Contains(textBox1.Text) && logLine.Contains(dt1))
                        {
                            listBox1.Items.Insert(0, logLine);
                            listBox1.Items.Insert(0, Environment.NewLine);
                        }
                    }
                    else
                    {
                        if (logLine.Contains(textBox1.Text))
                        {
                            listBox1.Items.Insert(0, logLine);
                            listBox1.Items.Insert(0, Environment.NewLine);
                        }
                    }
                }
            }
            catch (Exception except)
            {
                MessageBox.Show("\t\t-- 오류메시지 --\n" + except.Message + Environment.NewLine + Environment.NewLine + "\t\t-- 오류내용 --\n" + except.StackTrace, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dateClick = false;
        }
    }
}
