using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            InitializeComponent();
            this.ss = new StarScript();
            ss.Osender += this.OnLogin;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cb_uni.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_uni.SelectedIndex = 1;
        }

        private void b_login_Click(object sender, EventArgs e)
        {
            login();
            this.b_login.Text = "login...";
            this.b_login.Enabled = false;
        }

        private void login()
        {
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
    }
}
