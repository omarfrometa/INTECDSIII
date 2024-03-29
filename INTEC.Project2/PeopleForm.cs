﻿using INTEC.Project2.Entities;
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
    public partial class PeopleForm : Form, MyInterface
    {
        private const string filePath = "db.json";
        private const string nationalityPath = "nationalities.json";
        private List<PersonEntity> persons;
        private List<NationalityEntity> nationalities;

        public PeopleForm()
        {
            InitializeComponent();

            defaultView();
            loadData();
            getNationalities();
        }

        private void getNationalities()
        {
            if (File.Exists(nationalityPath))
            {
                string json = File.ReadAllText(nationalityPath);
                nationalities = JsonConvert.DeserializeObject<List<NationalityEntity>>(json);
            }
            else
            {
                nationalities = new List<NationalityEntity>();
            }

            cbNationality.SelectedValue = "Id";
            cbNationality.DisplayMember = "Name";
            cbNationality.DataSource = nationalities;
        }

        private void loadData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                persons = JsonConvert.DeserializeObject<List<PersonEntity>>(json);
            }
            else
            {
                persons = new List<PersonEntity>();
            }


            dgvResults.DataSource = persons;
        }

        void addNew()
        { 
            var person = new PersonEntity();
            person.Id = Guid.NewGuid().ToString();
            person.Cedula = txtCedula.Text;
            person.FirstName = txtFirstName.Text;
            person.LastName = txtLastName.Text;
            person.DOB = dtpDOB.Value;
            person.BirthPlace = txtBirthPlace.Text;
            person.Gender = rblMale.Checked ? "M" : "F";
            person.NationalityId = cbNationality.SelectedValue.ToString();
            person.AddressLine1 = txtAddress.Text;
            person.BloodTypeId = txtBloodType.Text;
            person.CivilStatusId = txtCivilStatus.Text;
            person.IsDead = rblDeadYes.Checked;
            person.CreatedDate = DateTime.Now;

            persons.Add(person);

            string json = JsonConvert.SerializeObject(persons);
            File.WriteAllText(filePath, json);

            MessageBox.Show("Registro almacenado con exito!");
        }

        private void defaultView()
        {
            lblStatus.Text = $"Autenticado como: {System.Security.Principal.WindowsIdentity.GetCurrent().Name}";

            btnNew.Enabled = true;
            gbForm.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            dtpDOB.Value = DateTime.Now.AddYears(-18);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            gbForm.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                addNew();
                defaultView();
                loadData();
                clearForm();
            }
        }

        private bool IsFormValid()
        {
            if (string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("El campo Cedula es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (CedulaExist())
            {
                MessageBox.Show($"El No. de Cedula ({txtCedula.Text}) ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("El campo Nombres es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("El campo Apellidos es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dtpDOB.Value == null)
            {
                MessageBox.Show("El campo Fecha de Nacimiento es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CedulaExist()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                persons = JsonConvert.DeserializeObject<List<PersonEntity>>(json);

                var personExist = persons.Count(x=> x.Cedula == txtCedula.Text) > 0;

                return personExist;
            }

            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();
            //defaultView();
        }

        private void clearForm()
        {
            txtCedula.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtBirthPlace.Text = string.Empty;
            dtpDOB.Value = DateTime.Now.AddYears(-18);
            rblMale.Checked = true;

            cbNationality.SelectedIndex = 0;
            txtAddress.Text = string.Empty;
            txtBloodType.Text = string.Empty;
            txtOccupation.Text = string.Empty;
            txtCivilStatus.Text = string.Empty;
            rblDeadYes.Checked = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                persons = JsonConvert.DeserializeObject<List<PersonEntity>>(json);


                var p = persons.Where(x => x.Cedula.ToLower().Contains(txtSearch.Text.ToLower()) || x.FirstName.ToLower().Contains(txtSearch.Text.ToLower()) || x.LastName.ToLower().Contains(txtSearch.Text.ToLower()));

                dgvResults.DataSource = p.ToList();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            defaultView();
            loadData();
        }

        public void New()
        {
            MessageBox.Show("METODO NO IMPLEMENTADO");
        }

        public void Save()
        {
            MessageBox.Show("METODO NO IMPLEMENTADO");
        }

        public void Cancel()
        {
            MessageBox.Show("METODO NO IMPLEMENTADO");
        }

        public void Delete()
        {
            MessageBox.Show("METODO NO IMPLEMENTADO");
        }
    }
}
