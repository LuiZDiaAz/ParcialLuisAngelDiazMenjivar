using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appparcial2.Vista;
using appparcial2.Model;

namespace appparcial2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (gobEntities db = new gobEntities())
            {
                var lista = from Usuario in db.Usuarios
                            where Usuario.DUI ==
                            txtConsultarDUI.Text
                            select Usuario;
                if (lista.Count() > 0)
                {
                    var nombre = from Usuario in db.Usuarios
                                 where Usuario.DUI ==
                                 txtConsultarDUI.Text
                                 select new
                                 {
                                     nomnbre = Usuario.Nombre.ToString()
                                 };
                    foreach (var iterarnombre in nombre)
                    {
                        lblNombre.Text = iterarnombre.nomnbre.ToString();

                        lblNombre.Visible = true;
                        lblBeneficiario.Visible = true;
                    }
                }
                else
                {
                    lblNombre.Text = "LO SENTIMOS USTED NO ES BENEFICIARIO";
                    lblNombre.Visible = true;
                    lblBeneficiario.Visible = false;
                }
            }
        }
    }
}
