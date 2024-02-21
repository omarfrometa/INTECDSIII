using INTEC.Project2.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INTEC.Project2
{
    public partial class LoginForm : Form
    {
        private const string filePath = "users.json";
        private List<UserEntity> users;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ValidateUser();
        }

        private void ValidateUser()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("El usuario es un valor requerido.");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("La clave es un valor requerido.");
                return;
            }

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<UserEntity>>(json);


                var user = users.FirstOrDefault(x => (x.UserName == txtUsername.Text || x.Email == txtUsername.Text) && x.Password == txtPassword.Text);
                if (user == null)
                {
                    MessageBox.Show("Credenciales Invalidas.", "CONTROL DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Credenciales Validas.", "CONTROL DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
    }
}
