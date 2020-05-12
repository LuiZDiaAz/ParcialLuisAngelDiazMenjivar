using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appparcial2.Model;

namespace appparcial2.Vista
{
    public partial class frmInfousuario : Form
    {
        public frmInfousuario()
        {
            InitializeComponent();
        }

        Usuarios User = new Usuarios();

        void CargarDatos()
        {
            using (gobEntities db = new gobEntities())
            {
                var tb_usuario = db.Usuarios;

                dgvInfousuario.DataSource = db.Usuarios.ToList();
            }
        }

        private void bttnGuardar_Click(object sender, EventArgs e)
        {
            using (gobEntities db = new gobEntities())
            {
                User.id = int.Parse(txtID.Text);
                User.Nombre = txtNombre.Text;
                User.DUI = txtDUI.Text;

                db.Usuarios.Add(User);
                db.SaveChanges();
            }
            CargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (gobEntities db = new gobEntities())
            {
                String Id = dgvInfousuario.CurrentRow.Cells[0].Value.ToString();

                User = db.Usuarios.Find(int.Parse(Id));
                db.Usuarios.Remove(User);
                db.SaveChanges();
            }
            CargarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (gobEntities db = new gobEntities())
            {
                string Id = dgvInfousuario.CurrentRow.Cells[0].Value.ToString();
                int IdC = int.Parse(Id);
                User = db.Usuarios.Where(VerificarId => VerificarId.id == IdC).First();
                User.Nombre = txtNombre.Text;
                User.DUI = txtDUI.Text;
                db.Entry(User).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CargarDatos();
        }

        private void frmInfousuario_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
