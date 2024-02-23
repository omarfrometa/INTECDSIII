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
    public partial class UsersForm : Form, MyInterface
    {
        private const string filePath = "users.json";
        private List<UserEntity> users;
        private bool IsNew = true;
        private string RecordId = string.Empty;
        public UsersForm()
        {
            InitializeComponent();

            defaultView();
            loadData();
        }

        private void defaultView()
        {
            gbForm.Enabled = false;
        }

        private void loadData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<UserEntity>>(json);
            }
            else
            {
                users = new List<UserEntity>();
            }


            dgvResults.DataSource = users;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        void saveRecord()
        {
            var obj = new UserEntity();
            obj.Id = Guid.NewGuid().ToString();
            obj.UserName= txtUsername.Text;
            obj.Password= txtPassword.Text;
            obj.FullName = txtDisplayName.Text;
            obj.Email = txtEmail.Text;
            obj.Authorized = rblYes.Checked;
            obj.CreatedDate = DateTime.Now;

            users.Add(obj);

            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(filePath, json);

            MessageBox.Show("Registro almacenado con exito!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void clearForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPasswordConfirm.Text = string.Empty;
            txtDisplayName.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private bool IsFormValid()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("El campo Usuario es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("El campo Clave es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtPasswordConfirm.Text))
            {
                MessageBox.Show("El campo Confirmar Clave es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Las claves deben ser iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
          
            return true;
        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RecordId = dgvResults.Rows[dgvResults.CurrentRow.Index].Cells[0].Value.ToString();
            getRecord();
        }

        private void getRecord()
        {
            IsNew = false;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<UserEntity>>(json);

                var user = users.FirstOrDefault(x=> x.Id == RecordId);
                if(user != null) {
                    txtUsername.Text = user.UserName;
                    txtPassword.Text = user.Password;
                    txtPasswordConfirm.Text = user.Password;
                    txtDisplayName.Text = user.FullName;
                    txtEmail.Text = user.Email;
                    rblYes.Checked = user.Authorized;

                    gbForm.Enabled = true;
                }
            }
        }

        public void New()
        {
            gbForm.Enabled = true;
        }

        public void Save()
        {
            if (IsFormValid())
            {
                saveRecord();
                defaultView();
                loadData();
                clearForm();
            }
        }

        public void Cancel()
        {
            MessageBox.Show("METODO NO IMPLEMENTADO");
        }

        public void Delete()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<UserEntity>>(json);

                var user = users.FirstOrDefault(x=> x.Id == RecordId);
                if (user != null)
                { 
                    users.Remove(user);

                    json = JsonConvert.SerializeObject(users);
                    File.WriteAllText(filePath, json);

                    MessageBox.Show("Usuario Eliminado con exito!");

                    loadData();
                    gbForm.Enabled = false;
                    clearForm();
                }
            }
        }
    }
}
