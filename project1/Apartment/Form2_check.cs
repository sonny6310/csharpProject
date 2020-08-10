using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apartment
{
    public partial class Form2_check : Form
    {
        public Form2_check()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            selectQuery();

            listView2.View = View.Details;
            listView2.FullRowSelect = true;
        }

        private string loginConn = "Data Source=192.168.0.200;Initial Catalog=jh_20200611;Persist Security Info=True;User Id=sa;Password=8765432!";

        private void selectQuery()
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(loginConn);
                sqlcon.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter adpt = new SqlDataAdapter("select * from resident;", sqlcon);
                adpt.Fill(ds);

                listView1.Items.Clear();

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    string pet = ((r["pets"]).Equals(true)) ? "Y" : "N";
                    string baby = ((r["baby"]).Equals(true)) ? "Y" : "N";
                    string[] data = { r["building"] + "", r["unit"] + "", r["head"] + "", r["member"] + "", r["contact"] + "", r["car1"] + "", r["car2"] + "", pet, baby, r["register"] + "", r["remark"] + "", r["reg_date"] + "" };
                    listView1.Items.Add(new ListViewItem(data));
                }

                sqlcon.Close();
            }
            catch (Exception except)
            {
                MessageBox.Show("\t\t-- 오류메시지 --\n" + except.Message + Environment.NewLine + Environment.NewLine + "\t\t-- 오류내용 --\n" + except.StackTrace, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            if (tb_building.Text != "" && tb_unit.Text != "")
            {
                try
                {
                    SqlConnection sqlcon = new SqlConnection(loginConn);
                    sqlcon.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter adpt = new SqlDataAdapter("select * from resident where building=@building and unit=@unit;", sqlcon);
                    SqlParameter prmt1 = new SqlParameter();
                    SqlParameter prmt2 = new SqlParameter();
                    prmt1.ParameterName = "@building";
                    prmt1.Value = Convert.ToInt32(tb_building.Text);
                    prmt2.ParameterName = "@unit";
                    prmt2.Value = Convert.ToInt32(tb_unit.Text);
                    adpt.SelectCommand.Parameters.Add(prmt1);
                    adpt.SelectCommand.Parameters.Add(prmt2);
                    adpt.Fill(ds);

                    listView2.Items.Clear();

                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        string pet = ((r["pets"]).Equals(true)) ? "Y" : "N";
                        string baby = ((r["baby"]).Equals(true)) ? "Y" : "N";
                        string[] data = { r["building"] + "", r["unit"] + "", r["head"] + "", r["member"] + "", r["contact"] + "", r["car1"] + "", r["car2"] + "", pet, baby, r["register"] + "", r["remark"] + "", r["reg_date"] + "" };
                        listView2.Items.Add(new ListViewItem(data));
                    }

                    sqlcon.Close();

                    if (listView2.Items.Count == 0)
                    {
                        MessageBox.Show($"'{tb_building.Text}'동 '{tb_unit.Text}'호는 없는 동호수입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception except)
                {
                    MessageBox.Show("\t\t-- 오류메시지 --\n" + except.Message + Environment.NewLine + Environment.NewLine + "\t\t-- 오류내용 --\n" + except.StackTrace, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tb_building.Text != "" || tb_unit.Text != "")
            {
                MessageBox.Show("동호수를 모두 입력하시오.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((tb_building.Text == "" && tb_unit.Text == "") && tb_car.Text != "")
            {
                try
                {
                    SqlConnection sqlcon = new SqlConnection(loginConn);
                    sqlcon.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter adpt = new SqlDataAdapter("select * from resident where car1=@car1 or car2=@car2;", sqlcon);
                    SqlParameter prmt1 = new SqlParameter();
                    SqlParameter prmt2 = new SqlParameter();
                    prmt1.ParameterName = "@car1";
                    prmt1.Value = tb_car.Text;
                    prmt2.ParameterName = "@car2";
                    prmt2.Value = tb_car.Text;
                    adpt.SelectCommand.Parameters.Add(prmt1);
                    adpt.SelectCommand.Parameters.Add(prmt2);
                    adpt.Fill(ds);

                    listView2.Items.Clear();

                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        string pet = ((r["pets"]).Equals(true)) ? "Y" : "N";
                        string baby = ((r["baby"]).Equals(true)) ? "Y" : "N";
                        string[] data = { r["building"] + "", r["unit"] + "", r["head"] + "", r["member"] + "", r["contact"] + "", r["car1"] + "", r["car2"] + "", pet, baby, r["register"] + "", r["remark"] + "", r["reg_date"] + "" };
                        listView2.Items.Add(new ListViewItem(data));
                    }

                    sqlcon.Close();

                    if (listView2.Items.Count == 0)
                    {
                        MessageBox.Show($"차 번호 '{tb_car.Text}'는 등록되지 않은 번호입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception except)
                {
                    MessageBox.Show("\t\t-- 오류메시지 --\n" + except.Message + Environment.NewLine + Environment.NewLine + "\t\t-- 오류내용 --\n" + except.StackTrace, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if ((tb_building.Text == "" && tb_unit.Text == "" && tb_car.Text == "") && tb_head.Text != "")
            {
                try
                {
                    SqlConnection sqlcon = new SqlConnection(loginConn);
                    sqlcon.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter adpt = new SqlDataAdapter("select * from resident where head=@head;", sqlcon);
                    SqlParameter prmt1 = new SqlParameter();
                    prmt1.ParameterName = "@head";
                    prmt1.Value = tb_head.Text;
                    adpt.SelectCommand.Parameters.Add(prmt1);
                    adpt.Fill(ds);

                    listView2.Items.Clear();

                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        string pet = ((r["pets"]).Equals(true)) ? "Y" : "N";
                        string baby = ((r["baby"]).Equals(true)) ? "Y" : "N";
                        string[] data = { r["building"] + "", r["unit"] + "", r["head"] + "", r["member"] + "", r["contact"] + "", r["car1"] + "", r["car2"] + "", pet, baby, r["register"] + "", r["remark"] + "", r["reg_date"] + "" };
                        listView2.Items.Add(new ListViewItem(data));
                    }

                    sqlcon.Close();

                    if (listView2.Items.Count == 0)
                    {
                        MessageBox.Show($"'{tb_head.Text}'은(는) 세대주로 등록되어있지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception except)
                {
                    MessageBox.Show("\t\t-- 오류메시지 --\n" + except.Message + Environment.NewLine + Environment.NewLine + "\t\t-- 오류내용 --\n" + except.StackTrace, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("데이터가 입력되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // listview column 클릭시 정렬
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // 내용 클릭된 채로 정렬하면 오류나서 클릭상태 해제처리
            listView1.FocusedItem.Selected = false;

            if (listView1.Sorting == System.Windows.Forms.SortOrder.Ascending)
            {
                listView1.Sorting = System.Windows.Forms.SortOrder.Descending;
            }
            else
            {
                listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }

            listView1.ListViewItemSorter = new Sorter();      // * 1
            Sorter s = (Sorter)listView1.ListViewItemSorter;
            s.Order = listView1.Sorting;
            s.Column = e.Column;
            listView1.Sort();
        }

        // textbox에 숫자, 백스페이스만 입력되게
        private void tb_onlyNum(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
