using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apartment
{
    public partial class calendar : UserControl
    {
        //https://devangelma.tistory.com/229 참고
        public delegate void sendDateDele(string date);
        public static event sendDateDele sendDate;

        private int[] months = { 31, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private string[] Eng_months = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        private DateTime datestring;

        int year = DateTime.Today.Year;
        int month = DateTime.Today.Month;
        int day = DateTime.Today.Day;
        int dayofweek = (int)DateTime.Today.DayOfWeek;

        public calendar()
        {
            InitializeComponent();

            cal();
            label53.Text = "오늘 날짜: " + DateTime.Today.ToShortDateString();
        }

        public void cal()
        {

            if ((dayofweek + 7 - day % 7) % 7 != 6)
            {
                label1.Text = (months[month - 1] - (dayofweek + 7 - day % 7) % 7).ToString();
                label1.ForeColor = Color.DarkGray;
            }
            else
            {
                label1.Text = "1";
                label1.ForeColor = Color.White;
            }

            if (int.Parse(label1.Text) < 7)
            {
                label2.Text = (int.Parse(label1.Text) + 1).ToString();
                label2.ForeColor = Color.White;
            }
            else if (int.Parse(label1.Text) == months[month - 1])
            {
                label2.Text = "1";
                label2.ForeColor = Color.White;
            }
            else
            {
                label2.Text = (months[month - 1] - (dayofweek + 6 - day % 7) % 7).ToString();
                label2.ForeColor = Color.DarkGray;
            }

            if (int.Parse(label2.Text) < 7)
            {
                label3.Text = (int.Parse(label2.Text) + 1).ToString();
                label3.ForeColor = Color.White;
            }
            else if (int.Parse(label2.Text) == months[month - 1])
            {
                label3.Text = "1";
                label3.ForeColor = Color.White;
            }
            else
            {
                label3.Text = (months[month - 1] - (dayofweek + 5 - day % 7) % 7).ToString();
                label3.ForeColor = Color.DarkGray;
            }

            if (int.Parse(label3.Text) < 7)
            {
                label4.Text = (int.Parse(label3.Text) + 1).ToString();
                label4.ForeColor = Color.White;
            }
            else if (int.Parse(label3.Text) == months[month - 1])
            {
                label4.Text = "1";
                label4.ForeColor = Color.White;
            }
            else
            {
                label4.Text = (months[month - 1] - (dayofweek + 4 - day % 7) % 7).ToString();
                label4.ForeColor = Color.DarkGray;
            }

            if (int.Parse(label4.Text) < 7)
            {
                label5.Text = (int.Parse(label4.Text) + 1).ToString();
                label5.ForeColor = Color.White;
            }
            else if (int.Parse(label4.Text) == months[month - 1])
            {
                label5.Text = "1";
                label5.ForeColor = Color.White;
            }
            else
            {
                label5.Text = (months[month - 1] - (dayofweek + 3 - day % 7) % 7).ToString();
                label5.ForeColor = Color.DarkGray;
            }

            if (int.Parse(label5.Text) < 7)
            {
                label6.Text = (int.Parse(label5.Text) + 1).ToString();
                label6.ForeColor = Color.White;
            }
            else if (int.Parse(label5.Text) == months[month - 1])
            {
                label6.Text = "1";
                label6.ForeColor = Color.White;
            }
            else
            {
                label6.Text = (months[month - 1] - (dayofweek + 2 - day % 7) % 7).ToString();
                label6.ForeColor = Color.DarkGray;
            }

            if (int.Parse(label6.Text) == months[month - 1])
            {
                label7.Text = "1";
            }
            else
            {
                label7.Text = (int.Parse(label6.Text) + 1).ToString();
            }
            label8.Text = (int.Parse(label7.Text) + 1).ToString();
            label9.Text = (int.Parse(label8.Text) + 1).ToString();
            label10.Text = (int.Parse(label9.Text) + 1).ToString();
            label11.Text = (int.Parse(label10.Text) + 1).ToString();
            label12.Text = (int.Parse(label11.Text) + 1).ToString();
            label13.Text = (int.Parse(label12.Text) + 1).ToString();
            label14.Text = (int.Parse(label13.Text) + 1).ToString();
            label15.Text = (int.Parse(label14.Text) + 1).ToString();
            label16.Text = (int.Parse(label15.Text) + 1).ToString();
            label17.Text = (int.Parse(label16.Text) + 1).ToString();
            label18.Text = (int.Parse(label17.Text) + 1).ToString();
            label19.Text = (int.Parse(label18.Text) + 1).ToString();
            label20.Text = (int.Parse(label19.Text) + 1).ToString();
            label21.Text = (int.Parse(label20.Text) + 1).ToString();
            label22.Text = (int.Parse(label21.Text) + 1).ToString();
            label23.Text = (int.Parse(label22.Text) + 1).ToString();
            label24.Text = (int.Parse(label23.Text) + 1).ToString();
            label25.Text = (int.Parse(label24.Text) + 1).ToString();
            label26.Text = (int.Parse(label25.Text) + 1).ToString();
            label27.Text = (int.Parse(label26.Text) + 1).ToString();
            label28.Text = (int.Parse(label27.Text) + 1).ToString();

            if (int.Parse(label28.Text) == months[month])
            {
                label29.Text = "1";
                label29.ForeColor = Color.DarkGray;
            }
            else
            {
                label29.Text = (int.Parse(label28.Text) + 1).ToString();
                label29.ForeColor = Color.White;
            }

            if (int.Parse(label29.Text) == months[month])
            {
                label30.Text = "1";
                label30.ForeColor = Color.DarkGray;
            }
            else if (int.Parse(label29.Text) < 7)
            {
                label30.Text = (int.Parse(label29.Text) + 1).ToString();
                label30.ForeColor = Color.DarkGray;
            }
            else
            {
                label30.Text = (int.Parse(label29.Text) + 1).ToString();
                label30.ForeColor = Color.White;
            }

            if (int.Parse(label30.Text) == months[month])
            {
                label31.Text = "1";
                label31.ForeColor = Color.DarkGray;
            }
            else if (int.Parse(label30.Text) < 7)
            {
                label31.Text = (int.Parse(label30.Text) + 1).ToString();
                label31.ForeColor = Color.DarkGray;
            }
            else
            {
                label31.Text = (int.Parse(label30.Text) + 1).ToString();
                label31.ForeColor = Color.White;
            }

            if (int.Parse(label31.Text) == months[month])
            {
                label32.Text = "1";
                label32.ForeColor = Color.DarkGray;
            }
            else if (int.Parse(label31.Text) < 7)
            {
                label32.Text = (int.Parse(label31.Text) + 1).ToString();
                label32.ForeColor = Color.DarkGray;
            }
            else
            {
                label32.Text = (int.Parse(label31.Text) + 1).ToString();
                label32.ForeColor = Color.White;
            }

            if (int.Parse(label32.Text) == months[month])
            {
                label33.Text = "1";
                label33.ForeColor = Color.DarkGray;
            }
            else if (int.Parse(label32.Text) < 7)
            {
                label33.Text = (int.Parse(label32.Text) + 1).ToString();
                label33.ForeColor = Color.DarkGray;
            }
            else
            {
                label33.Text = (int.Parse(label32.Text) + 1).ToString();
                label33.ForeColor = Color.White;
            }

            if (int.Parse(label33.Text) == months[month])
            {
                label34.Text = "1";
                label34.ForeColor = Color.DarkGray;
            }
            else if (int.Parse(label33.Text) < 7)
            {
                label34.Text = (int.Parse(label33.Text) + 1).ToString();
                label34.ForeColor = Color.DarkGray;
            }
            else
            {
                label34.Text = (int.Parse(label33.Text) + 1).ToString();
                label34.ForeColor = Color.White;
            }

            if (int.Parse(label34.Text) == months[month])
            {
                label35.Text = "1";
                label35.ForeColor = Color.DarkGray;
            }
            else if (int.Parse(label34.Text) < 7)
            {
                label35.Text = (int.Parse(label34.Text) + 1).ToString();
                label35.ForeColor = Color.DarkGray;
            }
            else
            {
                label35.Text = (int.Parse(label34.Text) + 1).ToString();
                label35.ForeColor = Color.White;
            }

            if (int.Parse(label35.Text) == months[month])
            {
                label36.Text = "1";
                label36.ForeColor = Color.DarkGray;
            }
            else if (int.Parse(label35.Text) > 28)
            {
                label36.Text = (int.Parse(label35.Text) + 1).ToString();
                label36.ForeColor = Color.White;
            }
            else
            {
                label36.Text = (int.Parse(label35.Text) + 1).ToString();
                label36.ForeColor = Color.DarkGray;
            }

            if (int.Parse(label36.Text) == months[month])
            {
                label37.Text = "1";
                label37.ForeColor = Color.DarkGray;
            }
            else if (int.Parse(label36.Text) > 28)
            {
                label37.Text = (int.Parse(label36.Text) + 1).ToString();
                label37.ForeColor = Color.White;
            }
            else
            {
                label37.Text = (int.Parse(label36.Text) + 1).ToString();
                label37.ForeColor = Color.DarkGray;
            }

            if (int.Parse(label37.Text) == months[month])
            {
                label38.Text = "1";
            }
            else
            {
                label38.Text = (int.Parse(label37.Text) + 1).ToString();
            }
            label39.Text = (int.Parse(label38.Text) + 1).ToString();
            label40.Text = (int.Parse(label39.Text) + 1).ToString();
            label41.Text = (int.Parse(label40.Text) + 1).ToString();
            label42.Text = (int.Parse(label41.Text) + 1).ToString();

            label43.Text = year + ",";
            label44.Text = Eng_months[month].ToString();

            if (year % 400 == 0 && year % 100 != 0 || year % 4 == 0)
            {
                months[2] = 29;
            }
            else
            {
                months[2] = 28;
            }

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            if (day == int.Parse(label1.Text) && int.Parse(label1.Text) < 7)
            {
                pictureBox48.Visible = true;
            }
            else
            {
                pictureBox48.Visible = false;
            }

            if (day == int.Parse(label2.Text) && int.Parse(label2.Text) < 7)
            {
                pictureBox49.Visible = true;
            }
            else
            {
                pictureBox49.Visible = false;
            }

            if (day == int.Parse(label3.Text) && int.Parse(label3.Text) < 7)
            {
                pictureBox50.Visible = true;
            }
            else
            {
                pictureBox50.Visible = false;
            }

            if (day == int.Parse(label4.Text) && int.Parse(label4.Text) < 7)
            {
                pictureBox51.Visible = true;
            }
            else
            {
                pictureBox51.Visible = false;
            }

            if (day == int.Parse(label5.Text) && int.Parse(label5.Text) < 7)
            {
                pictureBox52.Visible = true;
            }
            else
            {
                pictureBox52.Visible = false;
            }

            if (day == int.Parse(label6.Text) && int.Parse(label6.Text) < 7)
            {
                pictureBox53.Visible = true;
            }
            else
            {
                pictureBox53.Visible = false;
            }

            if (day == int.Parse(label7.Text))
            {
                pictureBox54.Visible = true;
            }
            else
            {
                pictureBox54.Visible = false;
            }

            if (day == int.Parse(label8.Text))
            {
                pictureBox55.Visible = true;
            }
            else
            {
                pictureBox55.Visible = false;
            }

            if (day == int.Parse(label9.Text))
            {
                pictureBox56.Visible = true;
            }
            else
            {
                pictureBox56.Visible = false;
            }

            if (day == int.Parse(label10.Text))
            {
                pictureBox57.Visible = true;
            }
            else
            {
                pictureBox57.Visible = false;
            }

            if (day == int.Parse(label11.Text))
            {
                pictureBox58.Visible = true;
            }
            else
            {
                pictureBox58.Visible = false;
            }

            if (day == int.Parse(label12.Text))
            {
                pictureBox59.Visible = true;
            }
            else
            {
                pictureBox59.Visible = false;
            }

            if (day == int.Parse(label13.Text))
            {
                pictureBox60.Visible = true;
            }
            else
            {
                pictureBox60.Visible = false;
            }

            if (day == int.Parse(label14.Text))
            {
                pictureBox61.Visible = true;
            }
            else
            {
                pictureBox61.Visible = false;
            }

            if (day == int.Parse(label15.Text))
            {
                pictureBox62.Visible = true;
            }
            else
            {
                pictureBox62.Visible = false;
            }

            if (day == int.Parse(label16.Text))
            {
                pictureBox63.Visible = true;
            }
            else
            {
                pictureBox63.Visible = false;
            }

            if (day == int.Parse(label17.Text))
            {
                pictureBox64.Visible = true;
            }
            else
            {
                pictureBox64.Visible = false;
            }

            if (day == int.Parse(label18.Text))
            {
                pictureBox65.Visible = true;
            }
            else
            {
                pictureBox65.Visible = false;
            }

            if (day == int.Parse(label19.Text))
            {
                pictureBox66.Visible = true;
            }
            else
            {
                pictureBox66.Visible = false;
            }

            if (day == int.Parse(label20.Text))
            {
                pictureBox67.Visible = true;
            }
            else
            {
                pictureBox67.Visible = false;
            }

            if (day == int.Parse(label21.Text))
            {
                pictureBox68.Visible = true;
            }
            else
            {
                pictureBox68.Visible = false;
            }

            if (day == int.Parse(label22.Text))
            {
                pictureBox69.Visible = true;
            }
            else
            {
                pictureBox69.Visible = false;
            }

            if (day == int.Parse(label23.Text))
            {
                pictureBox70.Visible = true;
            }
            else
            {
                pictureBox70.Visible = false;
            }

            if (day == int.Parse(label24.Text))
            {
                pictureBox71.Visible = true;
            }
            else
            {
                pictureBox71.Visible = false;
            }

            if (day == int.Parse(label25.Text))
            {
                pictureBox72.Visible = true;
            }
            else
            {
                pictureBox72.Visible = false;
            }

            if (day == int.Parse(label26.Text))
            {
                pictureBox73.Visible = true;
            }
            else
            {
                pictureBox73.Visible = false;
            }

            if (day == int.Parse(label27.Text))
            {
                pictureBox74.Visible = true;
            }
            else
            {
                pictureBox74.Visible = false;
            }

            if (day == int.Parse(label28.Text))
            {
                pictureBox75.Visible = true;
            }
            else
            {
                pictureBox75.Visible = false;
            }

            if (day == int.Parse(label29.Text) && int.Parse(label29.Text) > 22)
            {
                pictureBox76.Visible = true;
            }
            else
            {
                pictureBox76.Visible = false;
            }

            if (day == int.Parse(label30.Text) && int.Parse(label30.Text) > 22)
            {
                pictureBox77.Visible = true;
            }
            else
            {
                pictureBox77.Visible = false;
            }

            if (day == int.Parse(label31.Text) && int.Parse(label31.Text) > 22)
            {
                pictureBox78.Visible = true;
            }
            else
            {
                pictureBox78.Visible = false;
            }

            if (day == int.Parse(label32.Text) && int.Parse(label32.Text) > 22)
            {
                pictureBox79.Visible = true;
            }
            else
            {
                pictureBox79.Visible = false;
            }

            if (day == int.Parse(label33.Text) && int.Parse(label33.Text) > 22)
            {
                pictureBox80.Visible = true;
            }
            else
            {
                pictureBox80.Visible = false;
            }

            if (day == int.Parse(label34.Text) && int.Parse(label34.Text) > 22)
            {
                pictureBox81.Visible = true;
            }
            else
            {
                pictureBox81.Visible = false;
            }

            if (day == int.Parse(label35.Text) && int.Parse(label35.Text) > 22)
            {
                pictureBox82.Visible = true;
            }
            else
            {
                pictureBox82.Visible = false;
            }

            if (day == int.Parse(label36.Text) && int.Parse(label36.Text) > 22)
            {
                pictureBox83.Visible = true;
            }
            else
            {
                pictureBox83.Visible = false;
            }

            if (day == int.Parse(label37.Text) && int.Parse(label37.Text) > 22)
            {
                pictureBox84.Visible = true;
            }
            else
            {
                pictureBox84.Visible = false;
            }

            if (int.Parse(label1.Text) < 7)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label1.Text) == DateTime.Today.Day)
                {
                    pictureBox85.Visible = true;
                }
                else
                {
                    pictureBox85.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month + 1 && int.Parse(label1.Text) == DateTime.Today.Day)
                {
                    pictureBox85.Visible = true;
                }
                else
                {
                    pictureBox85.Visible = false;
                }
            }

            if (int.Parse(label2.Text) < 7)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label2.Text) == DateTime.Today.Day)
                {
                    pictureBox86.Visible = true;
                }
                else
                {
                    pictureBox86.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month + 1 && int.Parse(label2.Text) == DateTime.Today.Day)
                {
                    pictureBox86.Visible = true;
                }
                else
                {
                    pictureBox86.Visible = false;
                }
            }

            if (int.Parse(label3.Text) < 7)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label3.Text) == DateTime.Today.Day)
                {
                    pictureBox87.Visible = true;
                }
                else
                {
                    pictureBox87.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month + 1 && int.Parse(label3.Text) == DateTime.Today.Day)
                {
                    pictureBox87.Visible = true;
                }
                else
                {
                    pictureBox87.Visible = false;
                }
            }

            if (int.Parse(label4.Text) < 7)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label4.Text) == DateTime.Today.Day)
                {
                    pictureBox88.Visible = true;
                }
                else
                {
                    pictureBox88.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month + 1 && int.Parse(label4.Text) == DateTime.Today.Day)
                {
                    pictureBox88.Visible = true;
                }
                else
                {
                    pictureBox88.Visible = false;
                }
            }

            if (int.Parse(label5.Text) < 7)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label5.Text) == DateTime.Today.Day)
                {
                    pictureBox89.Visible = true;
                }
                else
                {
                    pictureBox89.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month + 1 && int.Parse(label5.Text) == DateTime.Today.Day)
                {
                    pictureBox89.Visible = true;
                }
                else
                {
                    pictureBox89.Visible = false;
                }
            }

            if (int.Parse(label6.Text) < 7)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label6.Text) == DateTime.Today.Day)
                {
                    pictureBox90.Visible = true;
                }
                else
                {
                    pictureBox90.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month + 1 && int.Parse(label6.Text) == DateTime.Today.Day)
                {
                    pictureBox90.Visible = true;
                }
                else
                {
                    pictureBox90.Visible = false;
                }
            }

            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label7.Text) == DateTime.Today.Day)
            {
                pictureBox91.Visible = true;
            }
            else
            {
                pictureBox91.Visible = false;
            }

            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label8.Text) == DateTime.Today.Day)
            {
                pictureBox92.Visible = true;
            }
            else
            {
                pictureBox92.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label9.Text) == DateTime.Today.Day)
            {
                pictureBox93.Visible = true;
            }
            else
            {
                pictureBox93.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label10.Text) == DateTime.Today.Day)
            {
                pictureBox94.Visible = true;
            }
            else
            {
                pictureBox94.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label11.Text) == DateTime.Today.Day)
            {
                pictureBox95.Visible = true;
            }
            else
            {
                pictureBox95.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label12.Text) == DateTime.Today.Day)
            {
                pictureBox96.Visible = true;
            }
            else
            {
                pictureBox96.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label13.Text) == DateTime.Today.Day)
            {
                pictureBox97.Visible = true;
            }
            else
            {
                pictureBox97.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label14.Text) == DateTime.Today.Day)
            {
                pictureBox98.Visible = true;
            }
            else
            {
                pictureBox98.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label15.Text) == DateTime.Today.Day)
            {
                pictureBox99.Visible = true;
            }
            else
            {
                pictureBox99.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label16.Text) == DateTime.Today.Day)
            {
                pictureBox100.Visible = true;
            }
            else
            {
                pictureBox100.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label17.Text) == DateTime.Today.Day)
            {
                pictureBox101.Visible = true;
            }
            else
            {
                pictureBox101.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label18.Text) == DateTime.Today.Day)
            {
                pictureBox102.Visible = true;
            }
            else
            {
                pictureBox102.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label19.Text) == DateTime.Today.Day)
            {
                pictureBox103.Visible = true;
            }
            else
            {
                pictureBox103.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label20.Text) == DateTime.Today.Day)
            {
                pictureBox104.Visible = true;
            }
            else
            {
                pictureBox104.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label21.Text) == DateTime.Today.Day)
            {
                pictureBox105.Visible = true;
            }
            else
            {
                pictureBox105.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label22.Text) == DateTime.Today.Day)
            {
                pictureBox106.Visible = true;
            }
            else
            {
                pictureBox106.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label23.Text) == DateTime.Today.Day)
            {
                pictureBox107.Visible = true;
            }
            else
            {
                pictureBox107.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label24.Text) == DateTime.Today.Day)
            {
                pictureBox108.Visible = true;
            }
            else
            {
                pictureBox108.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label25.Text) == DateTime.Today.Day)
            {
                pictureBox109.Visible = true;
            }
            else
            {
                pictureBox109.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label26.Text) == DateTime.Today.Day)
            {
                pictureBox110.Visible = true;
            }
            else
            {
                pictureBox110.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label27.Text) == DateTime.Today.Day)
            {
                pictureBox111.Visible = true;
            }
            else
            {
                pictureBox111.Visible = false;
            }
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label28.Text) == DateTime.Today.Day)
            {
                pictureBox112.Visible = true;
            }
            else
            {
                pictureBox112.Visible = false;
            }
            if (int.Parse(label29.Text) > 22)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label29.Text) == DateTime.Today.Day)
                {
                    pictureBox113.Visible = true;
                }
                else
                {
                    pictureBox113.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month - 1 && int.Parse(label29.Text) == DateTime.Today.Day)
                {
                    pictureBox113.Visible = true;
                }
                else
                {
                    pictureBox113.Visible = false;
                }
            }
            if (int.Parse(label30.Text) > 22)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label30.Text) == DateTime.Today.Day)
                {
                    pictureBox114.Visible = true;
                }
                else
                {
                    pictureBox114.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month - 1 && int.Parse(label30.Text) == DateTime.Today.Day)
                {
                    pictureBox114.Visible = true;
                }
                else
                {
                    pictureBox114.Visible = false;
                }
            }
            if (int.Parse(label31.Text) > 22)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label31.Text) == DateTime.Today.Day)
                {
                    pictureBox115.Visible = true;
                }
                else
                {
                    pictureBox115.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month - 1 && int.Parse(label31.Text) == DateTime.Today.Day)
                {
                    pictureBox115.Visible = true;
                }
                else
                {
                    pictureBox115.Visible = false;
                }
            }
            if (int.Parse(label32.Text) > 22)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label32.Text) == DateTime.Today.Day)
                {
                    pictureBox116.Visible = true;
                }
                else
                {
                    pictureBox116.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month - 1 && int.Parse(label32.Text) == DateTime.Today.Day)
                {
                    pictureBox116.Visible = true;
                }
                else
                {
                    pictureBox116.Visible = false;
                }
            }
            if (int.Parse(label33.Text) > 22)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label33.Text) == DateTime.Today.Day)
                {
                    pictureBox117.Visible = true;
                }
                else
                {
                    pictureBox117.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month - 1 && int.Parse(label33.Text) == DateTime.Today.Day)
                {
                    pictureBox117.Visible = true;
                }
                else
                {
                    pictureBox117.Visible = false;
                }
            }
            if (int.Parse(label34.Text) > 22)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label34.Text) == DateTime.Today.Day)
                {
                    pictureBox118.Visible = true;
                }
                else
                {
                    pictureBox118.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month - 1 && int.Parse(label34.Text) == DateTime.Today.Day)
                {
                    pictureBox118.Visible = true;
                }
                else
                {
                    pictureBox118.Visible = false;
                }
            }
            if (int.Parse(label35.Text) > 22)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label35.Text) == DateTime.Today.Day)
                {
                    pictureBox119.Visible = true;
                }
                else
                {
                    pictureBox119.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month - 1 && int.Parse(label35.Text) == DateTime.Today.Day)
                {
                    pictureBox119.Visible = true;
                }
                else
                {
                    pictureBox119.Visible = false;
                }
            }
            if (int.Parse(label36.Text) > 22)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label36.Text) == DateTime.Today.Day)
                {
                    pictureBox120.Visible = true;
                }
                else
                {
                    pictureBox120.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month - 1 && int.Parse(label36.Text) == DateTime.Today.Day)
                {
                    pictureBox120.Visible = true;
                }
                else
                {
                    pictureBox120.Visible = false;
                }
            }
            if (int.Parse(label37.Text) > 22)
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && int.Parse(label37.Text) == DateTime.Today.Day)
                {
                    pictureBox121.Visible = true;
                }
                else
                {
                    pictureBox121.Visible = false;
                }
            }
            else
            {
                if (year == DateTime.Today.Year && month == DateTime.Today.Month - 1 && int.Parse(label37.Text) == DateTime.Today.Day)
                {
                    pictureBox121.Visible = true;
                }
                else
                {
                    pictureBox121.Visible = false;
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (int.Parse(label1.Text) > 7)
            {
                day = int.Parse(label1.Text);
                if (month == 1)
                {
                    month = 12;
                    year--;
                }
                else
                {
                    month--;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label1.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (int.Parse(label2.Text) > 7)
            {
                day = int.Parse(label2.Text);
                if (month == 1)
                {
                    month = 12;
                    year--;
                }
                else
                {
                    month--;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label2.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (int.Parse(label3.Text) > 7)
            {
                day = int.Parse(label3.Text);
                if (month == 1)
                {
                    month = 12;
                    year--;
                }
                else
                {
                    month--;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label3.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (int.Parse(label4.Text) > 7)
            {
                day = int.Parse(label4.Text);
                if (month == 1)
                {
                    month = 12;
                    year--;
                }
                else
                {
                    month--;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label4.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (int.Parse(label5.Text) > 7)
            {
                day = int.Parse(label5.Text);
                if (month == 1)
                {
                    month = 12;
                    year--;
                }
                else
                {
                    month--;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label5.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (int.Parse(label6.Text) > 7)
            {
                day = int.Parse(label6.Text);
                if (month == 1)
                {
                    month = 12;
                    year--;
                }
                else
                {
                    month--;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label6.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            day = int.Parse(label7.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            day = int.Parse(label8.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            day = int.Parse(label9.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            day = int.Parse(label10.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            day = int.Parse(label11.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            day = int.Parse(label12.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            day = int.Parse(label13.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            day = int.Parse(label14.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            day = int.Parse(label15.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            day = int.Parse(label16.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            day = int.Parse(label17.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            day = int.Parse(label18.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            day = int.Parse(label19.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            day = int.Parse(label20.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            day = int.Parse(label21.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            day = int.Parse(label22.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            day = int.Parse(label23.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            day = int.Parse(label24.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            day = int.Parse(label25.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            day = int.Parse(label26.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            day = int.Parse(label27.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            day = int.Parse(label28.Text);

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)datestring.DayOfWeek;
            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (int.Parse(label29.Text) > 22)
            {
                day = int.Parse(label29.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label29.Text);

                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                else
                {
                    month++;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            if (int.Parse(label30.Text) > 22)
            {
                day = int.Parse(label30.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label30.Text);

                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                else
                {
                    month++;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            if (int.Parse(label31.Text) > 22)
            {
                day = int.Parse(label31.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label31.Text);

                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                else
                {
                    month++;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            if (int.Parse(label32.Text) > 22)
            {
                day = int.Parse(label32.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label32.Text);

                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                else
                {
                    month++;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            if (int.Parse(label33.Text) > 22)
            {
                day = int.Parse(label33.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label33.Text);

                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                else
                {
                    month++;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            if (int.Parse(label34.Text) > 22)
            {
                day = int.Parse(label34.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label34.Text);

                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                else
                {
                    month++;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            if (int.Parse(label35.Text) > 22)
            {
                day = int.Parse(label35.Text);

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
            else
            {
                day = int.Parse(label35.Text);

                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                else
                {
                    month++;
                }

                datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                dayofweek = (int)datestring.DayOfWeek;
                cal();

                label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                sendDate(datestring.ToShortDateString());
            }
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            if (label36.Text != "")
            {
                if (int.Parse(label36.Text) > 22)
                {
                    day = int.Parse(label36.Text);

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
                else
                {
                    day = int.Parse(label36.Text);

                    if (month == 12)
                    {
                        month = 1;
                        year++;
                    }
                    else
                    {
                        month++;
                    }

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
            }
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            if (label37.Text != "")
            {
                if (int.Parse(label37.Text) > 22)
                {
                    day = int.Parse(label37.Text);

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
                else
                {
                    day = int.Parse(label37.Text);

                    if (month == 12)
                    {
                        month = 1;
                        year++;
                    }
                    else
                    {
                        month++;
                    }

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
            }
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            if (label38.Text != "")
            {
                if (int.Parse(label38.Text) > 22)
                {
                    day = int.Parse(label38.Text);

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
                else
                {
                    day = int.Parse(label38.Text);

                    if (month == 12)
                    {
                        month = 1;
                        year++;
                    }
                    else
                    {
                        month++;
                    }

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
            }
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            if (label39.Text != "")
            {
                if (int.Parse(label39.Text) > 22)
                {
                    day = int.Parse(label39.Text);

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
                else
                {
                    day = int.Parse(label39.Text);

                    if (month == 12)
                    {
                        month = 1;
                        year++;
                    }
                    else
                    {
                        month++;
                    }

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
            }
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            if (label40.Text != "")
            {
                if (int.Parse(label40.Text) > 22)
                {
                    day = int.Parse(label40.Text);

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
                else
                {
                    day = int.Parse(label40.Text);

                    if (month == 12)
                    {
                        month = 1;
                        year++;
                    }
                    else
                    {
                        month++;
                    }

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
            }
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            if (label41.Text != "")
            {
                if (int.Parse(label41.Text) > 22)
                {
                    day = int.Parse(label41.Text);

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
                else
                {
                    day = int.Parse(label41.Text);

                    if (month == 12)
                    {
                        month = 1;
                        year++;
                    }
                    else
                    {
                        month++;
                    }

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
            }
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            if (label42.Text != "")
            {
                if (int.Parse(label42.Text) > 22)
                {
                    day = int.Parse(label42.Text);

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
                else
                {
                    day = int.Parse(label42.Text);

                    if (month == 12)
                    {
                        month = 1;
                        year++;
                    }
                    else
                    {
                        month++;
                    }

                    datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
                    dayofweek = (int)datestring.DayOfWeek;
                    cal();

                    label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

                    sendDate(datestring.ToShortDateString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            year = DateTime.Today.Year;
            month = DateTime.Today.Month;
            day = DateTime.Today.Day;
            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            dayofweek = (int)DateTime.Today.DayOfWeek;

            cal();

            label45.Text = "선택된 날짜: " + datestring.ToShortDateString();

            sendDate(datestring.ToShortDateString());
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            if (month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }

            if (day > months[month])
            {
                day = months[month];
            }

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            sendDate(datestring.ToShortDateString());
            dayofweek = (int)datestring.DayOfWeek;
            cal();
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else
            {
                month++;
            }

            if (day > months[month])
            {
                day = months[month];
            }

            datestring = Convert.ToDateTime(year + "-" + month + "-" + day);
            sendDate(datestring.ToShortDateString());
            dayofweek = (int)datestring.DayOfWeek;
            cal();
        }
    }
}
