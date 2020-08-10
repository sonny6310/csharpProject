using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apartment
{
    public partial class Form2 : Form
    {
        //Field
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public Form2()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;

            //Home 시간
            lb_homeTime.Text = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        }

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(249, 88, 155);
            public static Color color2 = Color.FromArgb(24, 161, 251);
            public static Color color3 = Color.FromArgb(164, 123, 221);
        }

        //Methods
        private void ActivateBtn(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableBtn();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(41, 44, 51);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon Current Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                lb_titleChildForm.Text = currentBtn.Text;
            }
        }

        private void DisableBtn()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(41, 44, 51);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btn_insert(object sender, EventArgs e)
        {
            ActivateBtn(sender, RGBColors.color1);
            OpenChildForm(new Form2_insert());
        }

        private void btn_check(object sender, EventArgs e)
        {
            ActivateBtn(sender, RGBColors.color2);
            OpenChildForm(new Form2_check());
        }

        private void btn_cal(object sender, EventArgs e)
        {
            ActivateBtn(sender, RGBColors.color3);
            OpenChildForm(new Form2_cal());
        }

        private void btn_close(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)  // esc 누르면 종료버튼 눌림
            {
                btn_close(sender, e);
            }
        }

        private void logo_click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableBtn();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lb_titleChildForm.Text = "Home";
        }

        //Drag Form (상단 패널바 누른채로 마우스 움직일 시 form2창 움직임)
        //https://jw0652.tistory.com/116 참고
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //자식폼 메소드
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Home 실시간 시간 갱신
        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_homeTime.Text = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        }

    }
}
