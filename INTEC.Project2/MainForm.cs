using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INTEC.Project2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
            lblMessage.Text = $"Autenticado como {wi.Name.ToString()}";

            //var form = new LoginForm() { MdiParent = this};
            //form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas salir del sistema", "GESTION DE CIUDADANOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            { 
                Close();
                Application.Exit();
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new UsersForm() {  MdiParent = this };
            form.Show();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PeopleForm() { MdiParent = this };
            form.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void iconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void closeAllWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        private void closeCurrentWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = (Form)this.ActiveMdiChild;
            if (form != null)
            {
                form.Close();
            }
        }
    }
}
