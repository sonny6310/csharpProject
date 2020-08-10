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
    public partial class Form2_insert : Form
    {
        public Form2_insert()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            selectQuery();
        }

        // 로그
        private void WriteLog(string contents)
        {
            string logContents = $"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] {contents}";
            LogWriter.PrintLog(logContents);
            listBox1.Items.Insert(0, logContents);
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

        private void btn_insert_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_building.Text == "" || tb_unit.Text == "")
                {
                    MessageBox.Show("동호수를 모두 입력하시오.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection sqlcon = new SqlConnection(loginConn);
                    sqlcon.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter adpt = new SqlDataAdapter("select head,member,contact,pets,baby,register from resident where building=@building and unit=@unit;", sqlcon);
                    SqlParameter prmt1 = new SqlParameter();
                    SqlParameter prmt2 = new SqlParameter();
                    prmt1.ParameterName = "@building";
                    prmt1.Value = Convert.ToInt32(tb_building.Text);
                    prmt2.ParameterName = "@unit";
                    prmt2.Value = Convert.ToInt32(tb_unit.Text);
                    adpt.SelectCommand.Parameters.Add(prmt1);
                    adpt.SelectCommand.Parameters.Add(prmt2);
                    adpt.Fill(ds);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show($"'{tb_building.Text}'동 '{tb_unit.Text}'호는 없는 동호수입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            // Null과 DBNull차이 확실히해야. MSSQL에서 보면 NULL이라 적혀서, c#에서 item["head"].Equals(null) 혹은 == null 등으로 비교하면 false라고 나옴.
                            if (!(item["head"].ToString() == string.Empty && item["member"].ToString() == string.Empty && item["contact"].ToString() == string.Empty && item["register"].ToString() == string.Empty))
                            {
                                MessageBox.Show("이미 등록되어있습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (tb_head.Text == "" || tb_member.Text == "" || tb_contact.Text == "" || (!(rb_babyN.Checked) && !(rb_babyY.Checked)) || (!(rb_petN.Checked) && !(rb_petY.Checked)))
                                {
                                    MessageBox.Show("기본 데이터가 입력되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    SqlCommand cmd = new SqlCommand("update resident set head = @head, member = @member, contact = @contact, car1 = @car1, car2 = @car2, pets = @pets, baby = @baby, remark = @remark, reg_date = getdate(), register = getdate() where building = @building and unit = @unit;", sqlcon);
                                    cmd.Parameters.AddWithValue("@building", Convert.ToInt32(tb_building.Text));
                                    cmd.Parameters.AddWithValue("@unit", Convert.ToInt32(tb_unit.Text));
                                    cmd.Parameters.AddWithValue("@head", tb_head.Text);
                                    cmd.Parameters.AddWithValue("@member", Convert.ToInt32(tb_member.Text));
                                    cmd.Parameters.AddWithValue("@contact", tb_contact.Text);
                                    cmd.Parameters.AddWithValue("@car1", tb_car1.Text);
                                    cmd.Parameters.AddWithValue("@car2", tb_car2.Text);

                                    if (rb_petN.Checked)
                                    {
                                        petBit = false;
                                    }
                                    else if (rb_petY.Checked)
                                    {
                                        petBit = true;
                                    }

                                    if (rb_babyN.Checked)
                                    {
                                        babyBit = false;
                                    }
                                    else if (rb_babyY.Checked)
                                    {
                                        babyBit = true;
                                    }

                                    cmd.Parameters.AddWithValue("@pets", petBit);
                                    cmd.Parameters.AddWithValue("@baby", babyBit);
                                    cmd.Parameters.AddWithValue("@remark", "전입");
                                    cmd.ExecuteNonQuery();

                                    string pet = (petBit.Equals(true)) ? "Y" : "N";
                                    string baby = (babyBit.Equals(true)) ? "Y" : "N";
                                    WriteLog($"[등록(전입)] {tb_building.Text}동 {tb_unit.Text}호    세대주 명:{tb_head.Text}    구성원 수:{tb_member.Text}    연락처:{tb_contact.Text}    차 번호1:{tb_car1.Text}    차 번호2:{tb_car2.Text}    애완동물:{pet}    영유아:{baby}");

                                    rb_babyN.Checked = false;
                                    rb_babyY.Checked = false;
                                    rb_petN.Checked = false;
                                    rb_petY.Checked = false;
                                    tb_building.Clear();
                                    tb_unit.Clear();
                                    tb_member.Clear();
                                    tb_head.Clear();
                                    tb_contact.Clear();
                                    tb_car1.Clear();
                                    tb_car2.Clear();
                                    tb_remark.Clear();

                                }
                            }
                        }
                    }

                    sqlcon.Close();

                    selectQuery();
                }
            }
            catch (Exception except)
            {
                MessageBox.Show("\t\t-- 오류메시지 --\n" + except.Message + Environment.NewLine + Environment.NewLine + "\t\t-- 오류내용 --\n" + except.StackTrace, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool petBit;
        private bool babyBit;
        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(loginConn);
                sqlcon.Open();

                if (tb_head.Text == "" || tb_member.Text == "" || tb_contact.Text == "" || (!(rb_babyN.Checked) && !(rb_babyY.Checked)) || (!(rb_petN.Checked) && !(rb_petY.Checked)))
                {
                    MessageBox.Show("기본 데이터가 입력되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(tb_remark.Text == "")
                    {
                        MessageBox.Show("수정하는 이유를 비고란에 기입해야합니다.","확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("update resident set head = @head, member = @member, contact = @contact, car1 = @car1, car2 = @car2, pets = @pets, baby = @baby, remark = @remark, reg_date = getdate() where building = @building and unit = @unit;", sqlcon);
                        cmd.Parameters.AddWithValue("@building", Convert.ToInt32(tb_building.Text));
                        cmd.Parameters.AddWithValue("@unit", Convert.ToInt32(tb_unit.Text));
                        cmd.Parameters.AddWithValue("@head", tb_head.Text);
                        cmd.Parameters.AddWithValue("@member", Convert.ToInt32(tb_member.Text));
                        cmd.Parameters.AddWithValue("@contact", tb_contact.Text);
                        cmd.Parameters.AddWithValue("@car1", tb_car1.Text);
                        cmd.Parameters.AddWithValue("@car2", tb_car2.Text);

                        if (rb_petN.Checked)
                        {
                            petBit = false;
                        }
                        else if (rb_petY.Checked)
                        {
                            petBit = true;
                        }

                        if (rb_babyN.Checked)
                        {
                            babyBit = false;
                        }
                        else if (rb_babyY.Checked)
                        {
                            babyBit = true;
                        }

                        cmd.Parameters.AddWithValue("@pets", petBit);
                        cmd.Parameters.AddWithValue("@baby", babyBit);
                        cmd.Parameters.AddWithValue("@remark", tb_remark.Text);
                        int update = cmd.ExecuteNonQuery();

                        if (update == 1)
                        {
                            string pet = (petBit.Equals(true)) ? "Y" : "N";
                            string baby = (babyBit.Equals(true)) ? "Y" : "N";
                            WriteLog($"[수정({tb_remark.Text})] {tb_building.Text}동 {tb_unit.Text}호    세대주 명:{tb_head.Text}    구성원 수:{tb_member.Text}    연락처:{tb_contact.Text}    차 번호1:{tb_car1.Text}    차 번호2:{tb_car2.Text}    애완동물:{pet}    영유아:{baby}");

                            rb_babyN.Checked = false;
                            rb_babyY.Checked = false;
                            rb_petN.Checked = false;
                            rb_petY.Checked = false;
                            tb_building.Clear();
                            tb_unit.Clear();
                            tb_member.Clear();
                            tb_head.Clear();
                            tb_contact.Clear();
                            tb_car1.Clear();
                            tb_car2.Clear();
                            tb_remark.Clear();
                        }
                        else
                        {
                            MessageBox.Show("수정에 실패하였습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                sqlcon.Close();

                selectQuery();
            }
            catch (Exception except)
            {
                MessageBox.Show("\t\t-- 오류메시지 --\n" + except.Message + Environment.NewLine + Environment.NewLine + "\t\t-- 오류내용 --\n" + except.StackTrace, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_building.Text == "" || tb_unit.Text == "")
                {
                    MessageBox.Show("동호수를 입력하지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection sqlcon = new SqlConnection(loginConn);
                    sqlcon.Open();

                    DialogResult result = MessageBox.Show($"정말로 {tb_building.Text}동 {tb_unit.Text}호의 데이터를 지우시겠습니까?", "", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand("delete from resident where building = @building and unit = @unit", sqlcon);
                        cmd.Parameters.AddWithValue("@building", Convert.ToInt32(tb_building.Text));
                        cmd.Parameters.AddWithValue("@unit", Convert.ToInt32(tb_unit.Text));
                        int deleteNum = cmd.ExecuteNonQuery();

                        // ExecuteNonQuery : 성공하면 1 반환, 실패하면 0 반환
                        if (deleteNum == 1)
                        {
                            cmd = new SqlCommand("insert into resident (building,unit,remark,reg_date) values (@building,@unit,@remark,getdate());", sqlcon);
                            cmd.Parameters.AddWithValue("@building", Convert.ToInt32(tb_building.Text));
                            cmd.Parameters.AddWithValue("@unit", Convert.ToInt32(tb_unit.Text));
                            cmd.Parameters.AddWithValue("@remark", "전출");
                            cmd.ExecuteNonQuery();

                            WriteLog($"[삭제(전출)] {tb_building.Text}동 {tb_unit.Text}호");

                            rb_babyN.Checked = false;
                            rb_babyY.Checked = false;
                            rb_petN.Checked = false;
                            rb_petY.Checked = false;
                            tb_building.Clear();
                            tb_unit.Clear();
                            tb_member.Clear();
                            tb_head.Clear();
                            tb_contact.Clear();
                            tb_car1.Clear();
                            tb_car2.Clear();
                            tb_remark.Clear();
                        }
                        else
                        {
                            MessageBox.Show($"'{tb_building.Text}'동 '{tb_unit.Text}'호는 없는 동호수입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    sqlcon.Close();

                    selectQuery();
                }
            }
            catch (Exception except)
            {
                MessageBox.Show("\t\t-- 오류메시지 --\n" + except.Message + Environment.NewLine + Environment.NewLine + "\t\t-- 오류내용 --\n" + except.StackTrace, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                rb_babyN.Checked = false;
                rb_babyY.Checked = false;
                rb_petN.Checked = false;
                rb_petY.Checked = false;

                tb_building.Text = listView1.FocusedItem.SubItems[0].Text;
                tb_unit.Text = listView1.FocusedItem.SubItems[1].Text;
                tb_head.Text = listView1.FocusedItem.SubItems[2].Text;
                tb_member.Text = listView1.FocusedItem.SubItems[3].Text;
                tb_contact.Text = listView1.FocusedItem.SubItems[4].Text;
                tb_car1.Text = listView1.FocusedItem.SubItems[5].Text;
                tb_car2.Text = listView1.FocusedItem.SubItems[6].Text;
                if (listView1.FocusedItem.SubItems[7].Text.Equals("N"))
                {
                    rb_petN.Checked = true;
                }
                else if (listView1.FocusedItem.SubItems[7].Text.Equals("Y"))
                {
                    rb_petY.Checked = true;
                }
                if (listView1.FocusedItem.SubItems[8].Text.Equals("N"))
                {
                    rb_babyN.Checked = true;
                }
                else if (listView1.FocusedItem.SubItems[8].Text.Equals("Y"))
                {
                    rb_babyY.Checked = true;
                }
            }
            catch (Exception except)
            {
                MessageBox.Show("\t\t-- 오류메시지 --\n" + except.Message + Environment.NewLine + Environment.NewLine + "\t\t-- 오류내용 --\n" + except.StackTrace, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // textbox에 숫자, 백스페이스만 입력되게
        private void tb_onlyNum(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        // 연락처textBox에 숫자, 백스페이스, -만 입력되게
        private void tb_numHyp(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))
            {
                e.Handled = true;
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

            //https://bigenergy.tistory.com/318 참고
            listView1.ListViewItemSorter = new Sorter();      // * 1
            Sorter s = (Sorter)listView1.ListViewItemSorter;
            s.Order = listView1.Sorting;
            s.Column = e.Column;
            listView1.Sort();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            //엑셀 저장하기
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;

            saveFileDialog1.DefaultExt = "*.xls";
            saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
            saveFileDialog1.InitialDirectory = "C:\\";

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    object missingType = Type.Missing;
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Add(missingType);
                    Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.Add(missingType, missingType, missingType, missingType);
                    excelApp.Visible = false;

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        for (int j = 0; j < listView1.Columns.Count; j++)
                        {
                            if (i == 0)
                            {
                                excelWorksheet.Cells[1, j + 1] = this.listView1.Columns[j].Text;
                            }
                            excelWorksheet.Cells[i + 2, j + 1] = this.listView1.Items[i].SubItems[j].Text;
                        }
                    }
                    excelBook.SaveAs(@saveFileDialog1.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, missingType, missingType, missingType, missingType, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, missingType, missingType, missingType, missingType, missingType);
                    excelApp.Visible = true;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
                catch
                {
                    MessageBox.Show("Excel 파일 저장중 에러가 발생했습니다." + "\n재시도 바랍니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
