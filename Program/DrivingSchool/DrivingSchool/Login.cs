using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingSchool
{
    public partial class Login : Form
    {
        /// <summary>
        /// Omogučava vraćanje korisničkog imena nakon zatvaranja forme
        /// </summary>
        public string UserName
        {
            get;
            private set;
        }

        /// <summary>
        /// Omogučava vraćanje lozinke nakon zatvaranja forme
        /// </summary>
        public string Password
        {
            get;
            private set;
        }

        public Login()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            UserName = textBoxUserName.Text;
            Password = textBoxPassword.Text;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            checkTextBoxes();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            checkTextBoxes();
        }

        void checkTextBoxes()
        {
            if (!(textBoxUserName.Text.Equals(String.Empty) || textBoxPassword.Text.Equals(String.Empty)))
            {
                buttonOk.Enabled = true;
            }
            else
            {
                buttonOk.Enabled = false;
            }
        }

        void ResetTextBoxPassword()
        {
            textBoxPassword.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ResetTextBoxPassword();
        }

    }
}
