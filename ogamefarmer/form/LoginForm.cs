using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace OgameFarmer
{
    public partial class LoginForm : Form
    {
        private StarScript ss;

        public LoginForm()
        {
            //string XPATH_METALMINE = "/html/body/center/table/tr/td/center/table/tr[{0:d}]/td[2]/a";
            //string s = string.Format(XPATH_METALMINE, 2);
            InitializeComponent();
            this.ss = new StarScript();
            ss.Osender += this.OnLogin;
            
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cb_uni.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_uni.SelectedIndex = 1;
            tb_username.Text = "隔江犹唱后庭花";
            tb_pw.Text = "911911f911";
        }

        private void b_login_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            this.b_login.Text = "login...";
            this.b_login.Enabled = false;
            StarScript.loginname = this.tb_username.Text;
            StarScript.password = this.tb_pw.Text;
            StarScript.universe = cb_uni.SelectedItem.ToString();
            try
            {
                ss.run(2);
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
            //Main m = new Main(this.ss);
            //m.Show();
            //ss.Osender -= this.OnLogin;
            //this.Hide();
        }

        private LoginInfo li;

        private void OnLogin(object o)
        {
            if (o.GetType() == typeof(LoginInfo))
            {
                li = (LoginInfo)o;
                Object[] list = { this, System.EventArgs.Empty };
                this.l_loginMessage.BeginInvoke(new EventHandler(ShowMessage), list);
            }
        }

        public void ShowMessage(object sender, EventArgs e)
        {
            if (li.LoginSuccess)
            {
                Thread.Sleep(2000);
                Main m = new Main(this.ss);
                m.Show();
                ss.Osender -= this.OnLogin;
                this.Hide();
            }
            else
            {
                b_login.Text = "Login";
                b_login.Enabled = true;
                l_loginMessage.Text = "登录失败";
            }
        }

        private void tb_pw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                login();
            }
        }
    }
}
