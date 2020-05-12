using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appparcial2.Vista
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals("master") & txtContrasena.Text.Equals("123"))
            {
                MessageBox.Show("Datos correctos..." + "\nBienvenido:" + txtUsuario.Text + "\nPulse aceptar para continuar");
                frmInfousuario f = new frmInfousuario();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lo Sentimos, Su informacion es invalida");
            }
        }
    }
}
