using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Management;
using System.Net.Mail;
using OgameFarmer.messager;

namespace OgameFarmer
{
    public partial class LoginForm : Form
    {
        #region old way
        //private StarScript ss;
        #endregion

        #region new way
        private LoginCommander loginCommander;
        #endregion

        public LoginForm()
        {
            InitializeComponent();
            #region old way
            //this.ss = new StarScript();
            //ss.LoginEvent += this.OnLogin;
            #endregion

            #region new way
            #endregion
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cb_uni.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_uni.SelectedIndex = 1;
            tb_username.Text = "隔江犹唱后庭花";
            tb_pw.Text = "911911f911";
            //tb_username.Text = "boccaro";
            //tb_pw.Text = "911911f911";
        }

        private void b_login_Click(object sender, EventArgs e)
        {
            //login();
            loginX();
        }

        #region old way
        private void login()
        {
            this.b_login.Text = "login...";
            this.b_login.Enabled = false;
            StarScript.loginname = this.tb_username.Text;
            StarScript.password = this.tb_pw.Text;
            StarScript.universe = cb_uni.SelectedItem.ToString();
            try
            {
                //ss.run(2);
            }
            catch (Exception ee)
            {
                ee.ToString();
            }
            //Main m = new Main(this.ss);
            //m.Show();
            //this.Hide();
        }
        #endregion

        #region new way
        private void loginX()
        {
            this.b_login.Text = "login...";
            this.b_login.Enabled = false;
            loginCommander = new LoginCommander(this.tb_username.Text, this.tb_pw.Text, cb_uni.SelectedItem.ToString());
            loginCommander.LoginEvent += this.OnLogin;
            CommandCenter.RUN(loginCommander);
        }
        #endregion

        

        private LoginInfo li;
        private bool isLoginSuccess = false;
        private void OnLogin(LoginMessager lm)
        {
            #region old way
            li = lm.loginInfo;
            #endregion

            #region new way
            isLoginSuccess = lm.IsLoginSuccess;
            #endregion

            Object[] list = { this, System.EventArgs.Empty };
            this.l_loginMessage.BeginInvoke(new EventHandler(ShowMessage), list);

        }

        public void ShowMessage(object sender, EventArgs e)
        {
            //if (li.LoginSuccess)
            if (this.isLoginSuccess)
            {
                Thread.Sleep(2000);
                //Main m = new Main(this.ss);
                Main m = new Main(null);
                m.Show();
                //ss.LoginEvent -= this.OnLogin;
                loginCommander.LoginEvent -= this.OnLogin;
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
