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
    public partial class Form1 : Form
    {
        //string loginConn = "Data Source=192.168.0.200;Initial Catalog=jh_20200611;Persist Security Info=True;User Id=sa;Password=8765432!";
        string loginConn = "Data Source=192.168.0.200;Initial Catalog=jh_20200611;Persist Security Info=True;User Id=sa;Password=8765432!";

        public Form1()
        {
            InitializeComponent();
        }

        private void login_click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(loginConn);

            SqlCommand sc = new SqlCommand("select ID, PW from login");
            sc.Connection = sqlcon;
            sqlcon.Open();

            SqlDataReader dr = sc.ExecuteReader();

            while (dr.Read())
            {
                if (dr["ID"].ToString() == tb_id.Text && dr["PW"].ToString() == tb_pw.Text)
                {
                    this.Hide();
                    new Form2().ShowDialog();

                    //Form1(로그인창)이 숨겨지지만 꺼지지는 않은 상태(Form2가 열리면서 this.Close()가 실행되지 않아서)
                    // 이 프로그램에서는 Form2에 종료버튼(혹은 ESC)를 누를 시 Application.Exit()으로인해 Form1을 포함해서 프로그램 전체가 종료되므로 this.Close()를 안써도 된다.

                    // 일반적으로 새로 열린 폼창에서 Application.Exit()로 전체 앱을 닫는게 아닌, 열린 폼창만 닫으면 Form1은 숨겨져있을 뿐 프로세스에 남아있으므로
                    // 새로 열린 폼창이 닫히면 현재 폼창(Form1)도 닫히게 하기 위해서 this.Close()를 써놓아야 한다.
                    this.Close();
                }
                else
                {
                    tb_id.Clear();
                    tb_pw.Clear();
                    MessageBox.Show("ID 혹은 Password가 다릅니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_id.Focus();  // ID 입력에 커서 가도록
                }
            }
            sqlcon.Close();
        }

        private void Form1_keyUp(object sender, KeyEventArgs e)
        {
            if (tb_id.Text != "" && tb_pw.Text != "")
            {

                if (e.KeyCode == Keys.Enter)   // 엔터 누르면 로그인버튼 눌림
                {
                    login_click(sender, e);
                }
            }

            if (e.KeyCode == Keys.Escape)  // esc 누르면 종료버튼 눌림
            {
                Application.Exit();
            }
        }
    }
}
